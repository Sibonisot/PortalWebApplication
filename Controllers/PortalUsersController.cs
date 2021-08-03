using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalWebApplication.Models;

namespace PortalWebApplication.Controllers
{
    public class PortalUsersController : Controller
    {
        private readonly PortalDBContext _context;
        private object portalUser;

        public PortalUsersController(PortalDBContext context)
        {
            _context = context;
        }

        // GET: PortalUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortalUsers.ToListAsync());
        }

        // GET: PortalUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalUser = await _context.PortalUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (portalUser == null)
            {
                return NotFound();
            }

            return View(portalUser);
        }

        // GET: PortalUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Surname,Division,Department,IsActive,Email")] PortalUser portalUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(portalUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(portalUser);
            }
            catch (Exception)
            {
                ViewBag.TitleError = $"This Role is in use.";
                ViewBag.Message = $"This Role can not be deleted because it used in Portal User Roles Table.";
                return View("Error_P");
                
            }
        }

        // GET: PortalUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalUser = await _context.PortalUsers.FindAsync(id);
            if (portalUser == null)
            {
                return NotFound();
            }
            return View(portalUser);
        }

        // POST: PortalUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Name,Surname,Division,Department,IsActive,Email")] PortalUser portalUser)
        {
            if (id != portalUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portalUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortalUserExists(portalUser.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(portalUser);
        }

        // GET: PortalUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var portalUser = await _context.PortalUsers
                    .FirstOrDefaultAsync(m => m.UserId == id);
                if (portalUser == null)
                {
                    return NotFound();
                }
                //viewModel.ErrorMessage = "Email not found or matched";
                return View(portalUser);
            }
            catch (Exception )

            {
                ViewBag.TitleError = $"This User is in use.";
                ViewBag.Message = $"This User can not be deleted because it used in Portal User Roles Table." ;
                return View("/Home/Error");
            }
        }

        // POST: PortalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var portalUser = await _context.PortalUsers.FindAsync(id);
                _context.PortalUsers.Remove(portalUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                    }


            catch (Exception )
            {
                ViewBag.TitleError = $"{portalUser}This User is in use.";
                ViewBag.Message = $"{portalUser}This User can not be deleted because it used in Portal User Roles Table.";
                return View("Error_FU");
             
            };
        }

        private bool PortalUserExists(string id)
        {
            return _context.PortalUsers.Any(e => e.UserId == id);
        }
    }
}
