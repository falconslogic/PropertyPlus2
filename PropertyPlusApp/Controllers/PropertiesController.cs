using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyPlusApp.Data;
using PropertyPlusApp.Models;

namespace PropertyPlusApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = from e in _context.Property.Include(e => e.Leaser).Include(e => e.Owner).Include(e => e.Payment) select e;

            if(!String.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(e => e.Address.Contains(searchString));
            }


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .Include(e => e.Leaser)
                .Include(e => e.Owner)
                .Include(e => e.Payment)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            ViewData["LeaserId"] = new SelectList(_context.PropertyLeaser, "LeaserId", "FullName");
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwner, "OwnerId", "FullName");
            ViewData["PaymentId"] = new SelectList(_context.Set<PaymentHistory>(), "PaymentId", "PaymentId");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,OwnerId,LeaserId,Picture,Address,SquareFeet,Bedrooms,Baths,Year,Features,MonthlyRate,Utilities,ContractTime,PaymentId")] Property @property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaserId"] = new SelectList(_context.PropertyLeaser, "LeaserId", "FullName", @property.LeaserId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwner, "OwnerId", "FullName", @property.OwnerId);
            ViewData["PaymentId"] = new SelectList(_context.Set<PaymentHistory>(), "PaymentId", "PaymentId", @property.PaymentId);
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["LeaserId"] = new SelectList(_context.PropertyLeaser, "LeaserId", "FullName", @property.LeaserId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwner, "OwnerId", "FullName", @property.OwnerId);
            ViewData["PaymentId"] = new SelectList(_context.Set<PaymentHistory>(), "PaymentId", "PaymentId", @property.PaymentId);
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,OwnerId,LeaserId,Picture,Address,SquareFeet,Bedrooms,Baths,Year,Features,MonthlyRate,Utilities,ContractTime,PaymentId")] Property @property)
        {
            if (id != @property.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.PropertyId))
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
            ViewData["LeaserId"] = new SelectList(_context.PropertyLeaser, "LeaserId", "FullName", @property.LeaserId);
            ViewData["OwnerId"] = new SelectList(_context.PropertyOwner, "OwnerId", "FullName", @property.OwnerId);
            ViewData["PaymentId"] = new SelectList(_context.Set<PaymentHistory>(), "PaymentId", "PaymentId", @property.PaymentId);
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .Include(e => e.Leaser)
                .Include(e => e.Owner)
                .Include(e => e.Payment)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Property.FindAsync(id);
            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.PropertyId == id);
        }
    }
}
