using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NWS_Weather.Data;
using NWS_Weather.Interfaces;
using NWS_Weather.Models;

namespace NWS_Weather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly NWS_WeatherContext _context;

        private readonly ILocationService _locationService;
        private readonly IForecastService _forecastService;

        public WeatherController(NWS_WeatherContext context, ILocationService locationService, IForecastService forecastService)
        {
            _context = context;
            _locationService = locationService;
            _forecastService = forecastService;

        }

        // GET: Weather
        public async Task<IActionResult> Index()
        {
            return View(await _context.roots.ToListAsync());
        }

        // GET: Weather/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var root = await _context.roots
                .FirstOrDefaultAsync(m => m.rootId == id);
            if (root == null)
            {
                return NotFound();
            }

            return View(root);
        }

        // GET: Weather/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weather/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rootId,type")] Root root)
        {
            if (ModelState.IsValid)
            {
                _context.Add(root);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(root);
        }

        // GET: Weather/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var root = await _context.roots.FindAsync(id);
            if (root == null)
            {
                return NotFound();
            }
            return View(root);
        }

        // POST: Weather/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rootId,type")] Root root)
        {
            if (id != root.rootId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(root);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RootExists(root.rootId))
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
            return View(root);
        }

        // GET: Weather/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var root = await _context.roots
                .FirstOrDefaultAsync(m => m.rootId == id);
            if (root == null)
            {
                return NotFound();
            }

            return View(root);
        }

        // POST: Weather/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var root = await _context.roots.FindAsync(id);
            _context.roots.Remove(root);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RootExists(int id)
        {
            return _context.roots.Any(e => e.rootId == id);
        }
    }
}
