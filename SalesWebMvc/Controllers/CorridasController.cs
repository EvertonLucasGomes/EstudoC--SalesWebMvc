using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class CorridasController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public CorridasController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Corridas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Corrida.ToListAsync());
        }

        // GET: Corridas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.Corrida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corrida == null)
            {
                return NotFound();
            }

            return View(corrida);
        }

        // GET: Corridas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corridas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeColaborador,Origem,Destino,Valor")] Corrida corrida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corrida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corrida);
        }

        // GET: Corridas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.Corrida.FindAsync(id);
            if (corrida == null)
            {
                return NotFound();
            }
            return View(corrida);
        }

        // POST: Corridas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeColaborador,Origem,Destino,Valor")] Corrida corrida)
        {
            if (id != corrida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corrida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorridaExists(corrida.Id))
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
            return View(corrida);
        }

        // GET: Corridas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.Corrida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corrida == null)
            {
                return NotFound();
            }

            return View(corrida);
        }

        // POST: Corridas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corrida = await _context.Corrida.FindAsync(id);
            _context.Corrida.Remove(corrida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorridaExists(int id)
        {
            return _context.Corrida.Any(e => e.Id == id);
        }
    }
}
