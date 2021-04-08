using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetPal_New_.Models
{
    public class OwnerDog
    {
        public int DogID { get; set; }
        public int UserID { get; set; }
        public string ImageUrl { get; set; }
        public string Breed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string SpecialRemarks { get; set; }
        public string Misc { get; set; }
    }
}
