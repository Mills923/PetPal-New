using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetPal_New_.Data;
using PetPal_New_.Models;

namespace PetPal_New_.Controllers
{
    public class OwnerDogsController : Controller
    {
        private readonly PetPalContext _context;

        public OwnerDogsController(PetPalContext context)
        {
            _context = context;
        }

        // GET: OwnerDogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersDog.ToListAsync());
        }

        // GET: OwnerDogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerDog = await _context.UsersDog
                .FirstOrDefaultAsync(m => m.DogID == id);
            if (ownerDog == null)
            {
                return NotFound();
            }

            return View(ownerDog);
        }

        // GET: OwnerDogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerDogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DogID,UserID,ImageUrl,Breed,FirstName,LastName,Birthday,SpecialRemarks,Misc")] OwnerDog ownerDog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerDog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownerDog);
        }

        // GET: OwnerDogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerDog = await _context.UsersDog.FindAsync(id);
            if (ownerDog == null)
            {
                return NotFound();
            }
            return View(ownerDog);
        }

        // POST: OwnerDogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DogID,UserID,ImageUrl,Breed,FirstName,LastName,Birthday,SpecialRemarks,Misc")] OwnerDog ownerDog)
        {
            if (id != ownerDog.DogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerDog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerDogExists(ownerDog.DogID))
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
            return View(ownerDog);
        }

        // GET: OwnerDogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerDog = await _context.UsersDog
                .FirstOrDefaultAsync(m => m.DogID == id);
            if (ownerDog == null)
            {
                return NotFound();
            }

            return View(ownerDog);
        }

        // POST: OwnerDogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownerDog = await _context.UsersDog.FindAsync(id);
            _context.UsersDog.Remove(ownerDog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerDogExists(int id)
        {
            return _context.UsersDog.Any(e => e.DogID == id);
        }
    }
}
