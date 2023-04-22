using CanadaGames.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Controllers
{
    [Authorize]
    public class LookupsController : Controller
    {
        private readonly CanadaGamesContext _context;

        public LookupsController(CanadaGamesContext context)
        {
            _context = context;
        }

        public IActionResult Index(string Tab)
        {
            ///Note: select the tab you want to load by passing in
            ///the ID of the tab.
            ViewData["Tab"] = Tab;
            return View();
        }

        public PartialViewResult Genders()
        {
            ViewData["GendersID"] = new
                SelectList(_context.Genders
                .OrderBy(a => a.Name), "ID", "Name");
            return PartialView("_Genders");
        }

        public PartialViewResult Contingents()
        {
            ViewData["ContingentsID"] = new
                SelectList(_context.Contingents
                .OrderBy(a => a.Name), "ID", "Name");
            return PartialView("_Contingents");
        }

        public PartialViewResult Hometowns()
        {
            ViewData["HometownsID"] = new
                SelectList(_context.Hometowns.Include(d=>d.Contingent)
                .OrderBy(a => a.Name), "ID", "HometownContingent");
            return PartialView("_Hometowns");
        }
    }
}
