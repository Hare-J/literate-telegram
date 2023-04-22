using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanadaGames.Data;
using CanadaGames.Models;
using Microsoft.AspNetCore.Authorization;
using CanadaGames.Utilities;

namespace CanadaGames.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserAccountController : Controller
    {
        private readonly CanadaGamesContext _context;
        private readonly ApplicationDbContext _identityContext;

        public UserAccountController(CanadaGamesContext context, ApplicationDbContext identityContext)
        {
            _context = context;
        }

        // GET: UserAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: UserAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Phone,FavouriteIceCream,Email,Active")] User user)
        {
            user.Email = User.Identity.Name;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return View(user);
        }

        // GET: UserAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, bool Active)
        {
            var userToUpdate = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            //Check to see if you are making them inactive
            if (userToUpdate.Active == true && Active == false)
            {
                //This deletes the user's login from the security system
                await DeleteIdentityUser(userToUpdate.Email);

            }

            if (await TryUpdateModelAsync<User>(userToUpdate, "",
                e => e.FirstName, e => e.LastName, e => e.Phone, e => e.FavouriteIceCream, e => e.Active))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(userToUpdate);
        }

        /*
        // GET: UserAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private async Task DeleteIdentityUser(string Email)
        {
            var userToDelete = await _identityContext.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (userToDelete != null)
            {
                _identityContext.Users.Remove(userToDelete);
                await _identityContext.SaveChangesAsync();
            }
        }

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
