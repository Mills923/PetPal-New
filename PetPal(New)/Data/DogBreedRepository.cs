using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetPal_New_.Models;

namespace PetPal_New_.Data
{
    public class DogBreedRepository : IDogBreedRepository
    {
        private PetPalContext _context;

        public DogBreedRepository(PetPalContext context)
        {
            _context = context;

        }

        public IQueryable<DogBreed> DogBreeds => _context.DogBreeds;
    }
}
