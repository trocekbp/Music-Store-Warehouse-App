using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Store_Warehouse_App.Data;
using Music_Store_Warehouse_App.Models;

namespace Music_Store_Warehouse_App.Controllers
{
    public class FeatureDefinitionsController : Controller
    {
        private readonly Music_Store_Warehouse_AppContext _context;

        public FeatureDefinitionsController(Music_Store_Warehouse_AppContext context)
        {
            _context = context;
        }

        // GET: FeatureDefinitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeatureDefinition.ToListAsync());
        }

        // GET: FeatureDefinitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureDefinition = await _context.FeatureDefinition
                .FirstOrDefaultAsync(m => m.FeatureDefinitionId == id);
            if (featureDefinition == null)
            {
                return NotFound();
            }

            return View(featureDefinition);
        }

        // GET: FeatureDefinitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeatureDefinitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatureDefinitionId,Name")] FeatureDefinition featureDefinition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featureDefinition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featureDefinition);
        }

        // GET: FeatureDefinitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureDefinition = await _context.FeatureDefinition.FindAsync(id);
            if (featureDefinition == null)
            {
                return NotFound();
            }
            return View(featureDefinition);
        }

        // POST: FeatureDefinitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatureDefinitionId,Name")] FeatureDefinition featureDefinition)
        {
            if (id != featureDefinition.FeatureDefinitionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featureDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureDefinitionExists(featureDefinition.FeatureDefinitionId))
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
            return View(featureDefinition);
        }

        // GET: FeatureDefinitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureDefinition = await _context.FeatureDefinition
                .FirstOrDefaultAsync(m => m.FeatureDefinitionId == id);
            if (featureDefinition == null)
            {
                return NotFound();
            }

            return View(featureDefinition);
        }

        // POST: FeatureDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featureDefinition = await _context.FeatureDefinition.FindAsync(id);
            if (featureDefinition != null)
            {
                _context.FeatureDefinition.Remove(featureDefinition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureDefinitionExists(int id)
        {
            return _context.FeatureDefinition.Any(e => e.FeatureDefinitionId == id);
        }
    }
}
