using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetPal_New_.Models;


namespace PetPal_New_.Data
{
    public interface IDogBreedRepository
    {
        IQueryable<DogBreed> DogBreeds { get; }

    }
}
