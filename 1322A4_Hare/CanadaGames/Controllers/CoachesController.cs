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

namespace CanadaGames.Controllers
{
    public class CoachesController : Controller
    {
        private readonly CanadaGamesContext _context;

        public CoachesController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Coaches
        public async Task<IActionResult> Index(string SearchString, 
            int? page, int? pageSizeID, string actionButton,
            string sortDirection = "asc", string sortField = "Last Name")
        {
            var coaches = from c in  _context.Coaches
                         select c;

            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            //Toggle the Open/Closed state of the collapse depending on if we are filtering
            ViewData["Filtering"] = ""; //Asume not filtering
            //Then in each "test" for filtering, add ViewData["Filtering"] = " show" if true;

            //NOTE: make sure this array has matching values to the column headings
            string[] sortOptions = new[] { "Last Name", "First Name" };

            if (!String.IsNullOrEmpty(SearchString))
            {
                coaches = coaches.Where(p => p.LastName.ToUpper().Contains(SearchString.ToUpper())
                                       || p.FirstName.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = " show";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted!
            {
                page = 1;//Reset page to start

                if (sortOptions.Contains(actionButton))//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by
            if (sortField == "First Name")
            {
                if (sortDirection == "asc")
                {
                    coaches = coaches
                        .OrderBy(p => p.FirstName)
                        .ThenBy(p => p.LastName);
                }
                else
                {
                    coaches = coaches
                        .OrderByDescending(p => p.FirstName)
                        .ThenByDescending(p => p.LastName);
                }
            }
            else //Sorting by Last Name
            {
                if (sortDirection == "asc")
                {
                    coaches = coaches
                        .OrderBy(p => p.LastName)
                        .ThenBy(p => p.FirstName);
                }
                else
                {
                    coaches = coaches
                        .OrderByDescending(p => p.LastName)
                        .ThenByDescending(p => p.FirstName);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            //Handle Paging
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, ControllerName());
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Coach>.CreateAsync(coaches.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .Include(c=>c.Athletes).ThenInclude(c=>c.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,MiddleName,LastName")] Coach coach)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(coach);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { coach.ID });
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(coach);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            //Go get the Coach to update
            var coachToUpdate = await _context.Coaches.SingleOrDefaultAsync(p => p.ID == id);

            //Check that you got it or exit with a not found error
            if (coachToUpdate == null)
            {
                return NotFound();
            }

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<Coach>(coachToUpdate, "",
                d => d.FirstName, d => d.MiddleName, d => d.LastName))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { coachToUpdate.ID });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coachToUpdate.ID))
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
            return View(coachToUpdate);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var coach = await _context.Coaches.FindAsync(id);
            try
            {
                _context.Coaches.Remove(coach);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Coach. Remember, you cannot delete a Coach working with Athletes.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(coach);

        }

        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }

        private bool CoachExists(int id)
        {
            return _context.Coaches.Any(e => e.ID == id);
        }
    }
}
