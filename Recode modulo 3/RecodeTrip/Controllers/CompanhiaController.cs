using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecodeTrip.Data;
using RecodeTrip.Models;

namespace RecodeTrip.Controllers
{
    public class CompanhiaController : Controller
    {
        private readonly ViagemContext _context;

        public CompanhiaController(ViagemContext context)
        {
            _context = context;
        }

        // GET: Companhia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companhias.ToListAsync());
        }

        // GET: Companhia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companhia = await _context.Companhias
                .FirstOrDefaultAsync(m => m.Id_companhia == id);
            if (companhia == null)
            {
                return NotFound();
            }

            return View(companhia);
        }

        // GET: Companhia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companhia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_companhia,Nome,Nota_avaliacao")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companhia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companhia);
        }

        // GET: Companhia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companhia = await _context.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }
            return View(companhia);
        }

        // POST: Companhia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_companhia,Nome,Nota_avaliacao")] Companhia companhia)
        {
            if (id != companhia.Id_companhia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companhia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanhiaExists(companhia.Id_companhia))
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
            return View(companhia);
        }

        // GET: Companhia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companhia = await _context.Companhias
                .FirstOrDefaultAsync(m => m.Id_companhia == id);
            if (companhia == null)
            {
                return NotFound();
            }

            return View(companhia);
        }

        // POST: Companhia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companhia = await _context.Companhias.FindAsync(id);
            _context.Companhias.Remove(companhia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanhiaExists(int id)
        {
            return _context.Companhias.Any(e => e.Id_companhia == id);
        }
    }
}
