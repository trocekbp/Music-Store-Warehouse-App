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
    public class InstrumentsController : Controller
    {
        private readonly Music_Store_Warehouse_AppContext _context;

        public InstrumentsController(Music_Store_Warehouse_AppContext context)
        {
            _context = context;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
            var music_Store_Warehouse_AppContext = _context.Instrument.Include(i => i.Category).Include(i => i.Supplier);
            return View(await music_Store_Warehouse_AppContext.ToListAsync());
        }

        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrument
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.InstrumentId == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // GET: Instruments/Create
        [HttpGet]
        public IActionResult Create(int? categoryId)
        {
            // Przygotuj dropdowny dostawców i kategorii
            ViewBag.SupplierList = new SelectList(_context.Supplier, "SupplierId", "Name");
            ViewBag.CategoryList = new SelectList(_context.Category, "CategoryId", "Name");

            // Jeśli wybrano kategorię, załaduj odpowiadające FeatureDefinition
            if (categoryId.HasValue)
            {
                var cat = _context.Category.Find(categoryId.Value);
                if (cat != null)
                {
                    var typeEnum = Enum.Parse<FType>(cat.Name, ignoreCase: true); //Parsowanie kategorii na enum kiedyś zamienię to na id kategorii lub category name żeby było prościej

                    ViewBag.FeatureDefinitions = _context.FeatureDefinition
                        .Where(f => f.Type == typeEnum)
                        .ToList();
                }
            }

            // Utwórz "pusty" obiekt Instrument, ewentualnie z wstępnie ustawionym CategoryId
            var model = new Instrument();
            if (categoryId.HasValue) model.CategoryId = categoryId.Value;
            return View(model);
        }

        // POST: Instruments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instrument instrument)
        {
            // Zanim zwrócisz widok z błędami, pamiętaj o ponownym wypełnieniu ViewBag‐ów
            ViewBag.SupplierList = new SelectList(_context.Supplier, "SupplierId", "Name");
            ViewBag.CategoryList = new SelectList(_context.Category, "CategoryId", "Name");
            if (instrument.CategoryId != 0)
            {
                var cat = _context.Category.Find(instrument.CategoryId);
                var typeEnum = Enum.Parse<FType>(cat.Name, ignoreCase: true);
                ViewBag.FeatureDefinitions = _context.FeatureDefinition
                    .Where(f => f.Type == typeEnum)
                    .ToList();
            }

            if (!ModelState.IsValid)
                return View(instrument);

            // instrument.InstrumentFeatures zostanie uzupełnione z inputów
            _context.Add(instrument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrument.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", instrument.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", instrument.SupplierId);
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrumentId,Name,Price,Description,EAN,SKU,SerialNumber,SupplierId,CategoryId")] Instrument instrument)
        {
            if (id != instrument.InstrumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentExists(instrument.InstrumentId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", instrument.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", instrument.SupplierId);
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrument
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.InstrumentId == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrument = await _context.Instrument.FindAsync(id);
            if (instrument != null)
            {
                _context.Instrument.Remove(instrument);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentExists(int id)
        {
            return _context.Instrument.Any(e => e.InstrumentId == id);
        }
    }
}
