using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetPal_New_.Models
{
    public class DogBreed
    {
        public string ImageUrl { get; set; }
        public string Breed { get; set; }
        public string HealthConcerns { get; set; }
        public string HypoAllergenic { get; set; }
        public int GroomingRequirements { get; set; }
        public int Size { get; set; }
        public int ExerciseRequirement { get; set; }
        public int FamilyFriendly { get; set; }
        public int DogFriendly { get; set; }
        public string FoodTypes { get; set; }
    }
}
