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
using Microsoft.AspNetCore.Authorization;

namespace CanadaGames.Controllers
{
    [Authorize(Roles="Staff,Supervisor,Admin")]
    public class AthletePlacementsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public AthletePlacementsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: AthletePlacements
        public async Task<IActionResult> Index(int? AthleteID, int? page, int? pageSizeID, int? SportID, string actionButton,
            string SearchString, string sortDirection = "desc", string sortField = "Place")
        {
            //Get the URL with the last filter, sort and page parameters from THE PATIENTS Index View
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Athletes");
            if (!AthleteID.HasValue)
            {
                //Get the proper return URL for the Athletes controller
                return Redirect(ViewData["returnURL"].ToString());
            }

            //For the filter
            ViewData["SportID"] = new SelectList(_context.Sports.OrderBy(s => s.Name), "ID", "Name");

            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            //Toggle the Open/Closed state of the collapse depending on if we are filtering
            ViewData["Filtering"] = "btn-outline-dark"; //Asume not filtering
            //Then in each "test" for filtering, add ViewData["Filtering"] = "btn-danger" if true;

            //NOTE: make sure this array has matching values to the column headings
            string[] sortOptions = new[] { "Place", "Sport", "Event" };

            var placements = from p in _context.Placements
                    .Include(p => p.Athlete)
                    .Include(p => p.Event).ThenInclude(p=>p.Gender)
                    .Include(p => p.Event).ThenInclude(p=>p.Sport)
                where p.AthleteID==AthleteID.GetValueOrDefault()
                select p;

            if (SportID.HasValue)
            {
                placements = placements.Where(p => p.Event.SportID == SportID);
                ViewData["Filtering"] = "btn-danger";
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                placements = placements.Where(p => p.Comments.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = "btn-danger";
            }
            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                page = 1;//Reset back to first page when sorting or filtering

                if (sortOptions.Contains(actionButton))//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by.
            if (sortField == "Sport")
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Event.Sport.Name)
                        .ThenBy(p => p.Event.Name);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Event.Sport.Name)
                        .ThenBy(p => p.Event.Name);
                }
            }
            else if (sortField == "Event")
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Event.Name);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Event.Name);
                }
            }
            else //Placement
            {
                if (sortDirection == "asc")
                {
                    placements = placements
                        .OrderBy(p => p.Place);
                }
                else
                {
                    placements = placements
                        .OrderByDescending(p => p.Place);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            //Now get the MASTER record, the athlete, so it can be displayed at the top of the screen
            Athlete athlete = await _context.Athletes
                .Include(a => a.Coach)
                .Include(p => p.AthleteThumbnail)
                .Include(p => p.AthleteDocuments)
                .Include(a => a.Contingent)
                .Include(a => a.Gender)
                .Include(a => a.Sport)
                .Include(a => a.Hometown).ThenInclude(a => a.Contingent)
                .Include(a => a.AthleteSports).ThenInclude(s => s.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ID == AthleteID.GetValueOrDefault());
            ViewBag.Athlete = athlete;

            //Handle Paging
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, ControllerName());
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<Placement>.CreateAsync(placements.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Placement/Add
        [Authorize(Roles = "Supervisor,Admin")]
        public IActionResult Add(int? AthleteID)
        {
            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            if (!AthleteID.HasValue)
            {
                return Redirect(ViewData["returnURL"].ToString());
            }
            //Get the Athlete so we can filter events that match
            Athlete athlete =_context.Athletes.Include(a => a.AthleteSports)
                .Where(a => a.ID == AthleteID).FirstOrDefault();

            ViewData["AthleteName"] = athlete.FullName;

            Placement p = new Placement()
            {
                AthleteID = AthleteID.GetValueOrDefault()
            };
            PopulateDropDownLists(athlete);
            return View(p);
        }

        // POST: Placement/Add
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,Place,Comments,EventID,AthleteID")] Placement placement)
        {
            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(placement);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to save changes. A placement in this event has already been recorded.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            //Get the Athlete so we can filter events that match
            Athlete athlete = _context.Athletes.Include(a => a.AthleteSports)
                .Where(a => a.ID == placement.AthleteID).FirstOrDefault();

            ViewData["AthleteName"] = athlete.FullName;
            PopulateDropDownLists(athlete, placement.EventID);

            return View(placement);
        }

        // GET: Placement/Update/5
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            var placement = await _context.Placements
                    .Include(p => p.Athlete).ThenInclude(a=>a.AthleteSports)
               .FirstOrDefaultAsync(p => p.ID == id);
            if (placement == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(placement.Athlete,placement.EventID);
            return View(placement);
        }

        // POST: Placement/Update/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            var placementToUpdate = await _context.Placements
                .Include(a => a.Athlete).ThenInclude(a => a.AthleteSports)
                .FirstOrDefaultAsync(p => p.ID == id);

            //Check that you got it or exit with a not found error
            if (placementToUpdate == null)
            {
                return NotFound();
            }

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<Placement>(placementToUpdate, "",
                p => p.Place, p => p.Comments, p => p.EventID))
            {
                try
                {
                    _context.Update(placementToUpdate);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(placementToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                    {
                        ModelState.AddModelError("", "Unable to save changes. A placement in this event has already been recorded.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }
            }
            PopulateDropDownLists(placementToUpdate.Athlete,placementToUpdate.EventID);
            return View(placementToUpdate);
        }

        // GET: Placement/Remove/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            var placement = await _context.Placements
                .Include(a => a.Athlete)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placement == null)
            {
                return NotFound();
            }
            return View(placement);
        }

        // POST: Placement/Remove/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var placement = await _context.Placements
                .Include(a => a.Athlete)
                .FirstOrDefaultAsync(m => m.ID == id);

            //Get the URL with the last filter, sort and page parameters
            ViewDataReturnURL();

            try
            {
                _context.Placements.Remove(placement);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to remove placement. Try again, and if the problem persists see your system administrator.");
            }

            return View(placement);
        }

        private void PopulateDropDownLists(Athlete athlete = null, int? EventID = null)
        {
            //BONUS - to filter for gender as well as main or alternate sports.  
            //Until we learn how to pull data from VIews in the database we need to get the data first
            //and apply filters for sports locally
            List<Event> events = new List<Event>();
            if (athlete != null)
            {
                events = _context.Events
                         .Include(e => e.Gender)
                         .Where(e => e.GenderID == athlete.GenderID).ToList();
                events = events.Where(e => e.SportID == athlete.SportID || athlete.AthleteSports.Any(s => s.SportID == e.SportID)).ToList();
            }
            else
            {
                events = _context.Events
                         .Include(e => e.Gender).ToList();
            }
            
            ViewData["EventID"] = new SelectList(events, "ID", "Summary", EventID);
        }

        public async Task<FileContentResult> Download(int id)
        {
            var theFile = await _context.UploadedFiles
                .Include(d => d.FileContent)
                .Where(f => f.ID == id)
                .FirstOrDefaultAsync();
            return File(theFile.FileContent.Content, theFile.FileContent.MimeType, theFile.FileName);
        }

        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }

        private bool PlacementExists(int id)
        {
            return _context.Placements.Any(e => e.ID == id);
        }
    }
}
