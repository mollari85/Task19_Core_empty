using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task19_Core_empty.Models;

namespace Task19_Core_empty.Controllers
{
    public class PersonInfoController : Controller
    {
        private readonly PersonInfoContext _context;

        public PersonInfoController(PersonInfoContext context)
        {
            _context = context;
        }

        // GET: PersonInfo
        public async Task<IActionResult> Index()
        {
              return _context.PersonInfo != null ? 
                          View(await _context.PersonInfo.ToListAsync()) :
                          Problem("Entity set 'PersonInfoContext.PersonInfo'  is null.");
        }

        // GET: PersonInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonInfo == null)
            {
                return NotFound();
            }

            var personInfo = await _context.PersonInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personInfo == null)
            {
                return NotFound();
            }

            return View(personInfo);
        }

        // GET: PersonInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,ThirdName,PhoneNumber,Address,Description")] PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personInfo);
        }

        // GET: PersonInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonInfo == null)
            {
                return NotFound();
            }

            var personInfo = await _context.PersonInfo.FindAsync(id);
            if (personInfo == null)
            {
                return NotFound();
            }
            return View(personInfo);
        }

        // POST: PersonInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,ThirdName,PhoneNumber,Address,Description")] PersonInfo personInfo)
        {
            if (id != personInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonInfoExists(personInfo.Id))
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
            return View(personInfo);
        }

        // GET: PersonInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonInfo == null)
            {
                return NotFound();
            }

            var personInfo = await _context.PersonInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personInfo == null)
            {
                return NotFound();
            }

            return View(personInfo);
        }

        // POST: PersonInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonInfo == null)
            {
                return Problem("Entity set 'PersonInfoContext.PersonInfo'  is null.");
            }
            var personInfo = await _context.PersonInfo.FindAsync(id);
            if (personInfo != null)
            {
                _context.PersonInfo.Remove(personInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonInfoExists(int id)
        {
          return (_context.PersonInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
