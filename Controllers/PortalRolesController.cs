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
    public class PortalRolesController : Controller
    {
        private readonly DataPortalContext _context;

        public PortalRolesController(DataPortalContext context)
        {
            _context = context;
        }

        // GET: PortalRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortalRoles.ToListAsync());
        }

        // GET: PortalRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalRole = await _context.PortalRoles
                .FirstOrDefaultAsync(m => m.PortalRoleId == id);
            if (portalRole == null)
            {
                return NotFound();
            }

            return View(portalRole);
        }

        // GET: PortalRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortalRoleId,PortalRoleDescription,Company,IsActive,DateCreated")] PortalRole portalRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portalRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portalRole);
        }

        // GET: PortalRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalRole = await _context.PortalRoles.FindAsync(id);
            if (portalRole == null)
            {
                return NotFound();
            }
            return View(portalRole);
        }

        // POST: PortalRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortalRoleId,PortalRoleDescription,Company,IsActive,DateCreated")] PortalRole portalRole)
        {
            if (id != portalRole.PortalRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portalRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortalRoleExists(portalRole.PortalRoleId))
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
            return View(portalRole);
        }

        // GET: PortalRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalRole = await _context.PortalRoles
                .FirstOrDefaultAsync(m => m.PortalRoleId == id);
            if (portalRole == null)
            {
                return NotFound();
            }

            return View(portalRole);
        }

        // POST: PortalRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portalRole = await _context.PortalRoles.FindAsync(id);
            _context.PortalRoles.Remove(portalRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortalRoleExists(int id)
        {
            return _context.PortalRoles.Any(e => e.PortalRoleId == id);
        }
    }
}
