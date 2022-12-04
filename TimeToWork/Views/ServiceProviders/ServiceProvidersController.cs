using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Views.ServiceProviders
{
    public class ServiceProvidersController : Controller
    {
        private readonly TimeToWorkContext _context;

        public ServiceProvidersController(TimeToWorkContext context)
        {
            _context = context;
        }

        // GET: ServiceProviders
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //return _context.ServiceProviders != null ? 
            //            View(await _context.ServiceProviders.ToListAsync()) :
            //            Problem("Entity set 'TimeToWorkContext.ServiceProviders'  is null.");

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var serviceProviders = from s in _context.ServiceProviders
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                serviceProviders = serviceProviders.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString) || s.HireDate.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    serviceProviders = serviceProviders.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    serviceProviders = serviceProviders.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    serviceProviders = serviceProviders.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    serviceProviders = serviceProviders.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 7;
            return View(await PaginatedList<ServiceProvider>.CreateAsync(serviceProviders.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ServiceProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceProviders == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProviders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // GET: ServiceProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,HireDate")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceProvider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceProviders == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProviders.FindAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,HireDate")] ServiceProvider serviceProvider)
        {
            if (id != serviceProvider.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceProviderExists(serviceProvider.ID))
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
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceProviders == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProviders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceProviders == null)
            {
                return Problem("Entity set 'TimeToWorkContext.ServiceProviders'  is null.");
            }
            var serviceProvider = await _context.ServiceProviders.FindAsync(id);
            if (serviceProvider != null)
            {
                _context.ServiceProviders.Remove(serviceProvider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceProviderExists(int id)
        {
          return (_context.ServiceProviders?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
