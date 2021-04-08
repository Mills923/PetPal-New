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
    public class DogBreedsController : Controller
    {
        private readonly PetPalContext _context;

        public DogBreedsController(PetPalContext context)
        {
            _context = context;
        }

        // GET: DogBreeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogBreeds.ToListAsync());
        }

        // GET: DogBreeds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreeds
                .FirstOrDefaultAsync(m => m.Breed == id);
            if (dogBreed == null)
            {
                return NotFound();
            }

            return View(dogBreed);
        }

        // GET: DogBreeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogBreeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageUrl,Breed,HealthConcerns,HypoAllergenic,GroomingRequirements,Size,ExerciseRequirement,FamilyFriendly,DogFriendly,FoodTypes")] DogBreed dogBreed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogBreed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogBreed);
        }

        // GET: DogBreeds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreeds.FindAsync(id);
            if (dogBreed == null)
            {
                return NotFound();
            }
            return View(dogBreed);
        }

        // POST: DogBreeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ImageUrl,Breed,HealthConcerns,HypoAllergenic,GroomingRequirements,Size,ExerciseRequirement,FamilyFriendly,DogFriendly,FoodTypes")] DogBreed dogBreed)
        {
            if (id != dogBreed.Breed)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogBreed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogBreedExists(dogBreed.Breed))
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
            return View(dogBreed);
        }

        // GET: DogBreeds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogBreed = await _context.DogBreeds
                .FirstOrDefaultAsync(m => m.Breed == id);
            if (dogBreed == null)
            {
                return NotFound();
            }

            return View(dogBreed);
        }

        // POST: DogBreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dogBreed = await _context.DogBreeds.FindAsync(id);
            _context.DogBreeds.Remove(dogBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogBreedExists(string id)
        {
            return _context.DogBreeds.Any(e => e.Breed == id);
        }
    }
}
