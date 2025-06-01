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
                .Include(i => i.InstrumentFeatures)
                    .ThenInclude(ifeat => ifeat.FeatureDefinition) // ThenInclude - jeszcze dołączamy definicje cech
                .FirstOrDefaultAsync(m => m.InstrumentId == id);

            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // GET: Instruments/Create
        [HttpGet]
        public IActionResult Create()
        {
            PrepareViewBags();
            return View(new Instrument());
        }

        // POST: Instruments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("InstrumentId,Name,Price,Description,EAN,SKU,SerialNumber,Quantity,SupplierId,CategoryId")] Instrument instrument, //ważne BIND - aby nie przekazywać za dużo danych
            string action,                  // "ShowFeatures" lub "SaveInstrument"
            [FromForm] IList<InstrumentFeature> InstrumentFeatures)
        {
            // Zawsze przygotowujemy ViewBag dropdownów, bo widok ich potrzebuje
            PrepareViewBags();

            // Jeżeli użytkownik wcisnął „Pokaż cechy”
            if (action == "ShowFeatures")
            {
                // Upewnijmy się przynajmniej, że wybrano kategorię
                if (instrument.CategoryId == 0)
                {
                    ModelState.AddModelError(nameof(instrument.CategoryId), "Kategoria jest wymagana, aby wyświetlić cechy.");
                }
                else
                {
                    // Jeżeli jest wartość CategoryId, ładujemy od razu cechy – bez sprawdzania pozostałych błędów
                    var cat = _context.Category.Find(instrument.CategoryId);
                    if (cat != null)
                    {
                        var typeEnum = Enum.Parse<FType>(cat.Name, ignoreCase: true);
                        ViewBag.FeatureDefinitions = _context.FeatureDefinition
                            .Where(f => f.Type == typeEnum)
                            .ToList();
                    }
                }

                // Zwracamy widok z aktualnym modelem, nawet jeśli np. Name lub Price są puste.
                // Gdy wracamy tym View(instrument), wszystkie wpisane dotąd pola w formularzu będą w polach <input asp-for="…"/>,
                // a ViewBag.FeatureDefinitions wyświetli tabelę cech (o ile CategoryId != 0).
                return View(instrument);
            }

            // Jeżeli użytkownik wcisnął „Zapisz instrument”
            else if (action == "SaveInstrument")
            {
                // Przypisz z POST-a listę cech (może być pusta, jeżeli nie było tabeli)
                instrument.InstrumentFeatures = InstrumentFeatures;

                // Teraz wykonujemy normalną walidację całego modelu
                if (!ModelState.IsValid)
                {
                    // Aby tabela cech nie zniknęła, musimy znów załadować FeatureDefinitions
                    if (instrument.CategoryId != 0)
                    {
                        var cat = _context.Category.Find(instrument.CategoryId);
                        var typeEnum = Enum.Parse<FType>(cat.Name, ignoreCase: true);
                        ViewBag.FeatureDefinitions = _context.FeatureDefinition
                            .Where(f => f.Type == typeEnum)
                            .ToList();
                    }
                    return View(instrument);
                }

                // Jeśli ModelState jest OK – zapisujemy do bazy:
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Jeśli action nie został przekazany (lub ma nietypową wartość), po prostu wyświetlamy formularz
            return View(instrument);
        }


        private void PrepareViewBags()
        {
            ViewBag.SupplierList = new SelectList(
                _context.Supplier, "SupplierId", "Name");

            ViewBag.CategoryList = new SelectList(
                _context.Category, "CategoryId", "Name");
        }



        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrument
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Include(i => i.InstrumentFeatures)
                    .ThenInclude(ifeat => ifeat.FeatureDefinition) // ThenInclude - jeszcze dołączamy definicje cech
                .FirstOrDefaultAsync(m => m.InstrumentId == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("InstrumentId,Name,Price,Description,EAN,SKU,SerialNumber,Quantity,SupplierId,CategoryId,InstrumentFeatures")] Instrument instrument)
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
                .Include(i => i.InstrumentFeatures)
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
            var instrument = await _context.Instrument.FindAsync(id); //instrument features też się usunie poprzez delete Cascade w DB (konfiguracja w pliku db context)
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
