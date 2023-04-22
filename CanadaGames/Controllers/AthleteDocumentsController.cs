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
    [Authorize(Roles = "Staff,Supervisor,Admin")]
    public class AthleteDocumentsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public AthleteDocumentsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: AthleteDocuments
        public async Task<IActionResult> Index(string SearchString,
            int? AthleteID, int? page, int? pageSizeID)
        {
            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            //Toggle the Open/Closed state of the collapse depending on if we are filtering
            ViewData["Filtering"] = ""; //Asume not filtering
            //Then in each "test" for filtering, add ViewData["Filtering"] = " show" if true;

            ViewData["AthleteID"] = new SelectList(_context.Athletes
                .OrderBy(d => d.LastName)
                .ThenBy(d => d.FirstName), "ID", "FormalName");

            var documents = from d in _context.AthleteDocuments.Include(a => a.Athlete)
                            select d;

            if (AthleteID.HasValue)
            {
                documents = documents.Where(p => p.AthleteID == AthleteID);
                ViewData["Filtering"] = " show";
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                documents = documents.Where(p => p.FileName.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = " show";
            }
            //Always sort by file name
            documents = documents.OrderBy(d => d.FileName);

            //Handle Paging
            int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID, ControllerName());
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<AthleteDocument>.CreateAsync(documents.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: AthleteDocuments/Edit/5
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var athleteDocument = await _context.AthleteDocuments
                .Include(a => a.Athlete)
                .FirstOrDefaultAsync(d => d.ID == id);

            if (athleteDocument == null)
            {
                return NotFound();
            }

            return View(athleteDocument);
        }

        // POST: AthleteDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Supervisor,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var athleteDocumentToUpdate = await _context.AthleteDocuments
                .Include(a => a.Athlete)
                .FirstOrDefaultAsync(d=>d.ID==id);

            //Check that you got it or exit with a not found error
            if (athleteDocumentToUpdate == null)
            {
                return NotFound();
            }

            //Try updating it with the values posted
            if (await TryUpdateModelAsync<AthleteDocument>(athleteDocumentToUpdate, "",
                p => p.FileName, p => p.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteDocumentExists(athleteDocumentToUpdate.ID))
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
                    //Note: there is really no reason a delete should fail if you can "talk" to the database.
                    ModelState.AddModelError("", "Unable to edit file. Try again, and if the problem persists see your system administrator.");
                }
            }

            return View(athleteDocumentToUpdate);
        }

        // GET: AthleteDocuments/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null)
            {
                return NotFound();
            }

            var athleteDocument = await _context.AthleteDocuments
                .Include(a => a.Athlete)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (athleteDocument == null)
            {
                return NotFound();
            }

            return View(athleteDocument);
        }

        // POST: AthleteDocuments/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var athleteDocument = await _context.AthleteDocuments.FindAsync(id);
            try
            {
                _context.AthleteDocuments.Remove(athleteDocument);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException)
            {
                //Note: there is really no reason a delete should fail if you can "talk" to the database.
                ModelState.AddModelError("", "Unable to delete file. Try again, and if the problem persists see your system administrator.");
            }
            return View(athleteDocument);

        }

        [Authorize(Roles = "Supervisor,Admin")]
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

        private bool AthleteDocumentExists(int id)
        {
            return _context.AthleteDocuments.Any(e => e.ID == id);
        }
    }
}
