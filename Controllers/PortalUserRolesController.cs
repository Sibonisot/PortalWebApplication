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
    public class PortalUserRolesController : Controller
    {
        private readonly PortalDBContext _context;

        public PortalUserRolesController(PortalDBContext context)
        {
            _context = context;
        }

        // GET: PortalUserRoles
        public async Task<IActionResult> Index()
        {
            var portalDBContext = _context.PortalUserRoles.Include(p => p.PortalRole).Include(p => p.User);
            return View(await portalDBContext.ToListAsync());
        }

        // GET: PortalUserRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalUserRole = await _context.PortalUserRoles
                .Include(p => p.PortalRole)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PortalUserId == id);
            if (portalUserRole == null)
            {
                return NotFound();
            }

            return View(portalUserRole);
        }

        // GET: PortalUserRoles/Create
        public IActionResult Create()
        {
            ViewData["PortalRoleId"] = new SelectList(_context.PortalRoles, "PortalRoleId", "PortalRoleId");
            ViewData["UserId"] = new SelectList(_context.PortalUsers, "UserId", "UserId");
            return View();
        }

        // POST: PortalUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortalUserId,UserId,PortalRoleId,RoleDescription,IsActive,DateCreated")] PortalUserRole portalUserRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portalUserRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PortalRoleId"] = new SelectList(_context.PortalRoles, "PortalRoleId", "PortalRoleId", portalUserRole.PortalRoleId);
            ViewData["UserId"] = new SelectList(_context.PortalUsers, "UserId", "UserId", portalUserRole.UserId);
            return View(portalUserRole);
        }

        // GET: PortalUserRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalUserRole = await _context.PortalUserRoles.FindAsync(id);
            if (portalUserRole == null)
            {
                return NotFound();
            }
            ViewData["PortalRoleId"] = new SelectList(_context.PortalRoles, "PortalRoleId", "PortalRoleId", portalUserRole.PortalRoleId);
            ViewData["UserId"] = new SelectList(_context.PortalUsers, "UserId", "UserId", portalUserRole.UserId);
            return View(portalUserRole);
        }

        // POST: PortalUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortalUserId,UserId,PortalRoleId,RoleDescription,IsActive,DateCreated")] PortalUserRole portalUserRole)
        {
            if (id != portalUserRole.PortalUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portalUserRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortalUserRoleExists(portalUserRole.PortalUserId))
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
            ViewData["PortalRoleId"] = new SelectList(_context.PortalRoles, "PortalRoleId", "PortalRoleId", portalUserRole.PortalRoleId);
            ViewData["UserId"] = new SelectList(_context.PortalUsers, "UserId", "UserId", portalUserRole.UserId);
            return View(portalUserRole);
        }

        // GET: PortalUserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalUserRole = await _context.PortalUserRoles
                .Include(p => p.PortalRole)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PortalUserId == id);
            if (portalUserRole == null)
            {
                return NotFound();
            }

            return View(portalUserRole);
        }

        // POST: PortalUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portalUserRole = await _context.PortalUserRoles.FindAsync(id);
            _context.PortalUserRoles.Remove(portalUserRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortalUserRoleExists(int id)
        {
            return _context.PortalUserRoles.Any(e => e.PortalUserId == id);
        }
    }
}
