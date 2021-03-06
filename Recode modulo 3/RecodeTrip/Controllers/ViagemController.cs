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
    public class ViagemController : Controller
    {
        private readonly ViagemContext _context;

        public ViagemController(ViagemContext context)
        {
            _context = context;
        }

        // GET: Viagem
        public async Task<IActionResult> Index()
        {
            var viagemContext = _context.Viagens.Include(v => v.Companhia);
            return View(await viagemContext.ToListAsync());
        }

        public async Task<IActionResult> Destino()
        {
            var viagemContext = _context.Viagens.Include(v => v.Destino);
            return View(await viagemContext.ToListAsync());
        }


        // GET: Viagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .Include(v => v.Companhia)
                .FirstOrDefaultAsync(m => m.Id_viagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagem/Create
        public IActionResult Create()
        {
            ViewData["CompanhiaId_companhia"] = new SelectList(_context.Companhias, "Id_companhia", "Nome");
            return View();
        }

        // POST: Viagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_viagem,Nome,Origem,Destino,Preco,Data_ida,CompanhiaId_companhia")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanhiaId_companhia"] = new SelectList(_context.Companhias, "Id_companhia", "Nome", viagem.CompanhiaId_companhia);
            return View(viagem);
        }

        // GET: Viagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            ViewData["CompanhiaId_companhia"] = new SelectList(_context.Companhias, "Id_companhia", "Nome", viagem.CompanhiaId_companhia);
            return View(viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_viagem,Nome,Origem,Destino,Preco,Data_ida,CompanhiaId_companhia")] Viagem viagem)
        {
            if (id != viagem.Id_viagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Id_viagem))
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
            ViewData["CompanhiaId_companhia"] = new SelectList(_context.Companhias, "Id_companhia", "Nome", viagem.CompanhiaId_companhia);
            return View(viagem);
        }

        // GET: Viagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .Include(v => v.Companhia)
                .FirstOrDefaultAsync(m => m.Id_viagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagens.Any(e => e.Id_viagem == id);
        }
    }
}
