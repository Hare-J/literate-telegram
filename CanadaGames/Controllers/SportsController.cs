using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanadaGames.Data;
using CanadaGames.Models;
using CanadaGames.Utilities;
using Microsoft.EntityFrameworkCore.Storage;
using CanadaGames.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CanadaGames.Controllers
{
    [Authorize(Roles = "Staff,Supervisor,Admin")]
    public class SportsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public SportsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Sports
        public async Task<IActionResult> Index(int? page, int? pageSizeID)
        {
            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            var sports = from d in _context.Sports
                .Include(s => s.Athletes)
                .Include(d => d.AthleteSports).ThenInclude(d => d.Athlete)
                    orderby d.Name
                    select d;

            //Handle Paging
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, ControllerName());
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);
            var pagedData = await PaginatedList<Sport>.CreateAsync(sports.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Sports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports
                .Include(s => s.Athletes)
                .Include(d => d.AthleteSports).ThenInclude(d => d.Athlete)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        // GET: Sports/Create
        [Authorize(Roles = "Supervisor,Admin")]
        public IActionResult Create()
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            Sport sport = new Sport();
            PopulateAssignedAthleteData(sport);
            return View();
        }

        // POST: Sports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name")] Sport sport, string[] selectedOptions)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            try
            {
                //Nothing to do for the BONUS becuase no Athletes can have this as their main sport
                //since it has not been created yet.
                UpdateSportAthletes(selectedOptions, sport);

                if (ModelState.IsValid)
                {
                    _context.Add(sport);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { sport.ID });
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateAssignedAthleteData(sport);
            return View(sport);
        }

        // GET: Sports/Edit/5
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports
                .Include(d => d.AthleteSports).ThenInclude(d => d.Athlete)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (sport == null)
            {
                return NotFound();
            }

            PopulateAssignedAthleteData(sport);
            return View(sport);
        }

        // POST: Sports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var sportToUpdate = await _context.Sports
                .Include(d => d.AthleteSports).ThenInclude(d => d.Athlete)
                .FirstOrDefaultAsync(m => m.ID == id);

            //Check that you got it or exit with a not found error
            if (sportToUpdate == null)
            {
                return NotFound();
            }

            UpdateSportAthletes(selectedOptions, sportToUpdate);

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<Sport>(sportToUpdate, "",
                d => d.Code, d => d.Name))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { sportToUpdate.ID });
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportExists(sportToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            PopulateAssignedAthleteData(sportToUpdate);
            return View(sportToUpdate);
        }

        // GET: Sports/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        // POST: Sports/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var sport = await _context.Sports
                .FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                _context.Sports.Remove(sport);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Sport. Remember, you cannot delete a Sport with Athletes.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.GetBaseException().Message);
            }
            return View(sport);
        }

        private void PopulateAssignedAthleteData(Sport sport)
        {
            //For this to work, you must have Included the child collection in the parent object
            //For the BONUS we leave out Athletes with this sport as their main one.
            var allOptions = _context.Athletes.Where(a=>a.SportID!=sport.ID);
            var currentOptionsHS = new HashSet<int>(sport.AthleteSports.Select(b => b.AthleteID));
            //Instead of one list with a boolean, we will make two lists
            var selected = new List<ListOptionVM>();
            var available = new List<ListOptionVM>();
            foreach (var s in allOptions)
            {
                if (currentOptionsHS.Contains(s.ID))
                {
                    selected.Add(new ListOptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.FormalName
                    });
                }
                else
                {
                    available.Add(new ListOptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.FormalName
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
        private void UpdateSportAthletes(string[] selectedOptions, Sport sportToUpdate)
        {
            //This is an alternate approach to what I demonstrated in class.
            //Instetad of trying to follow the logic in the tutorial, we are
            //just clearing them out and adding the selected ones back in.
            //Note: the earlier code is shown below in comments
            sportToUpdate.AthleteSports = new List<AthleteSport>();
            if (selectedOptions == null)
            {
                return;
            }
            else
            {
                foreach(string a in selectedOptions)
                {
                    sportToUpdate.AthleteSports.Add(new AthleteSport
                    {
                        AthleteID = Convert.ToInt32(a),
                        SportID = sportToUpdate.ID
                    });
                }
            }
        }
        //private void UpdateSportAthletes(string[] selectedOptions, Sport sportToUpdate)
        //{
        //    if (selectedOptions == null)
        //    {
        //        sportToUpdate.AthleteSports = new List<AthleteSport>();
        //        return;
        //    }

        //    var selectedOptionsHS = new HashSet<string>(selectedOptions);
        //    var currentOptionsHS = new HashSet<int>(sportToUpdate.AthleteSports.Select(b => b.AthleteID));
        //    //For the BONUS only consider Athletes who do not have this sport as their main.
        //    var availableAthletes = _context.Athletes.Where(a => a.SportID != sportToUpdate.ID);
        //    foreach (var a in availableAthletes)
        //    {
        //        if (selectedOptionsHS.Contains(a.ID.ToString()))//it is selected
        //        {
        //            if (!currentOptionsHS.Contains(a.ID))//but not currently in the Sport's collection - Add it!
        //            {
        //                sportToUpdate.AthleteSports.Add(new AthleteSport
        //                {
        //                    AthleteID = a.ID,
        //                    SportID = sportToUpdate.ID
        //                });
        //            }
        //        }
        //        else //not selected
        //        {
        //            if (currentOptionsHS.Contains(a.ID))//but is currently in the Sport's collection - Remove it!
        //            {
        //                AthleteSport athleteToRemove = sportToUpdate.AthleteSports.FirstOrDefault(d => d.AthleteID == a.ID);
        //                _context.Remove(athleteToRemove);
        //            }
        //        }
        //    }
        //}

        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }
        private bool SportExists(int id)
        {
            return _context.Sports.Any(e => e.ID == id);
        }
    }
}
