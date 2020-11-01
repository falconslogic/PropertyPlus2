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
    public class PaymentHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentHistory.ToListAsync());
        }

        // GET: PaymentHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }

        // GET: PaymentHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,TotalPayments,TotalPaid,TotalLate,TotalMonths")] PaymentHistory paymentHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentHistory);
        }

        // GET: PaymentHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            if (paymentHistory == null)
            {
                return NotFound();
            }
            return View(paymentHistory);
        }

        // POST: PaymentHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,TotalPayments,TotalPaid,TotalLate,TotalMonths")] PaymentHistory paymentHistory)
        {
            if (id != paymentHistory.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentHistoryExists(paymentHistory.PaymentId))
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
            return View(paymentHistory);
        }

        // GET: PaymentHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentHistory = await _context.PaymentHistory
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            return View(paymentHistory);
        }

        // POST: PaymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentHistory = await _context.PaymentHistory.FindAsync(id);
            _context.PaymentHistory.Remove(paymentHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentHistoryExists(int id)
        {
            return _context.PaymentHistory.Any(e => e.PaymentId == id);
        }
    }
}
