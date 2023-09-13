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
    public class DocumentoBLController : Controller
    {
        private readonly ContextApplication _context;

        public DocumentoBLController(ContextApplication context)
        {
            _context = context;
        }

        // GET: DocumentoBL
        public async Task<IActionResult> Index()
        {
              return _context.DocumentosBL != null ? 
                          View(await _context.DocumentosBL.ToListAsync()) :
                          Problem("Entity set 'ContextApplication.DocumentosBL'  is null.");
        }

        // GET: DocumentoBL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentosBL == null)
            {
                return NotFound();
            }

            var documentoBL = await _context.DocumentosBL
                .FirstOrDefaultAsync(m => m.ID == id);
            if (documentoBL == null)
            {
                return NotFound();
            }

            return View(documentoBL);
        }

        // GET: DocumentoBL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentoBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NumeroDocumento,Consignee,Navio")] DocumentoBL documentoBL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentoBL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add($"{state.Key}: {error.ErrorMessage}");
                    }
                }

                // Agora, a lista "errors" contém todas as mensagens de erro.
                // Você pode retorná-las para a View, logá-las, etc.
            }

            return View(documentoBL);
        }

        // GET: DocumentoBL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentosBL == null)
            {
                return NotFound();
            }

            var documentoBL = await _context.DocumentosBL.FindAsync(id);
            if (documentoBL == null)
            {
                return NotFound();
            }
            return View(documentoBL);
        }

        // POST: DocumentoBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NumeroDocumento,Consignee,Navio")] DocumentoBL documentoBL)
        {
            if (id != documentoBL.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentoBL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoBLExists(documentoBL.ID))
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
            return View(documentoBL);
        }

        // GET: DocumentoBL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentosBL == null)
            {
                return NotFound();
            }

            var documentoBL = await _context.DocumentosBL
                .FirstOrDefaultAsync(m => m.ID == id);
            if (documentoBL == null)
            {
                return NotFound();
            }

            return View(documentoBL);
        }

        // POST: DocumentoBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentosBL == null)
            {
                return Problem("Entity set 'ContextApplication.DocumentosBL'  is null.");
            }
            var documentoBL = await _context.DocumentosBL.FindAsync(id);
            if (documentoBL != null)
            {
                _context.DocumentosBL.Remove(documentoBL);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoBLExists(int id)
        {
          return (_context.DocumentosBL?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
