using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02___SWII6.Data;
using TP02___SWII6.Models;

namespace TP02___SWII6.Controllers
{
    public class ConteinerController : Controller
    {
        private readonly ContextApplication _context;

        public ConteinerController(ContextApplication context)
        {
            _context = context;
        }

        // GET: Conteiner
        public async Task<IActionResult> Index()
        {
            var contextApplication = _context.Conteiners.Include(c => c.DocumentoBL);
            return View(await contextApplication.ToListAsync());
        }

        // GET: Conteiner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .Include(c => c.DocumentoBL)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // GET: Conteiner/Create
        public IActionResult Create()
        {
            ViewData["ID_DocumentoBL"] = new SelectList(_context.DocumentosBL, "ID", "Consignee");
            return View();
        }

        // POST: Conteiner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NumeroConteiner,Tipo,Tamanho,ID_DocumentoBL")] Conteiner conteiner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteiner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_DocumentoBL"] = new SelectList(_context.DocumentosBL, "ID", "Consignee", conteiner.ID_DocumentoBL);
            return View(conteiner);
        }

        // GET: Conteiner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner == null)
            {
                return NotFound();
            }
            ViewData["ID_DocumentoBL"] = new SelectList(_context.DocumentosBL, "ID", "Consignee", conteiner.ID_DocumentoBL);
            return View(conteiner);
        }

        // POST: Conteiner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NumeroConteiner,Tipo,Tamanho,ID_DocumentoBL")] Conteiner conteiner)
        {
            if (id != conteiner.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteiner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerExists(conteiner.ID))
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
            ViewData["ID_DocumentoBL"] = new SelectList(_context.DocumentosBL, "ID", "Consignee", conteiner.ID_DocumentoBL);
            return View(conteiner);
        }

        // GET: Conteiner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .Include(c => c.DocumentoBL)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // POST: Conteiner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conteiners == null)
            {
                return Problem("Entity set 'ContextApplication.Conteiners'  is null.");
            }
            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner != null)
            {
                _context.Conteiners.Remove(conteiner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteinerExists(int id)
        {
          return (_context.Conteiners?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
