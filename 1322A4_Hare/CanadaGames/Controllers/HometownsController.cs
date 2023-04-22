using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanadaGames.Data;
using CanadaGames.Models;

namespace CanadaGames.Controllers
{
    public class HometownsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public HometownsController(CanadaGamesContext context)
        {
            _context = context;
        }

        // GET: Hometowns
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Lookups", new { Tab = ControllerName() + "Tab" });
        }

        // GET: Hometowns/Create
        public IActionResult Create()
        {

            PopulateDropDownLists();
            return View();
        }

        // POST: Hometowns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ContingentID")] Hometown hometown)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(hometown);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Lookups", new { Tab = ControllerName() + "Tab" });
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            PopulateDropDownLists(hometown);
            return View(hometown);
        }

        // GET: Hometowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometown = await _context.Hometowns.FindAsync(id);
            if (hometown == null)
            {
                return NotFound();
            }

            PopulateDropDownLists(hometown);
            return View(hometown);
        }

        // POST: Hometowns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var hometownToUpdate = await _context.Hometowns.FindAsync(id);
            if (hometownToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Hometown>(hometownToUpdate, "",
                d => d.ContingentID, d => d.Name))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Lookups", new { Tab = ControllerName() + "Tab" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HometownExists(hometownToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            PopulateDropDownLists(hometownToUpdate);
            return View(hometownToUpdate);
        }

        // GET: Hometowns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometown = await _context.Hometowns
                .Include(h => h.Contingent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hometown == null)
            {
                return NotFound();
            }

            return View(hometown);
        }

        // POST: Hometowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hometown = await _context.Hometowns.FindAsync(id);
            try
            {
                _context.Hometowns.Remove(hometown);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Lookups", new { Tab = ControllerName() + "Tab" });
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Hometown. Remember, you cannot delete the Hometown of any Athlete in the system.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(hometown);
            
        }

        private SelectList ContingentList(int? selectedId)
        {
            return new SelectList(_context
                .Contingents
                .OrderBy(m => m.Name), "ID", "Name", selectedId);
        }
        private void PopulateDropDownLists(Hometown hometown = null)
        {
            ViewData["ContingentID"] = ContingentList(hometown?.ContingentID);
        }
        //Add this...
        private string ControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }

        private bool HometownExists(int id)
        {
            return _context.Hometowns.Any(e => e.ID == id);
        }
    }
}
