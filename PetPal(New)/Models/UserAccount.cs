using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PetPal_New_.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<OwnerDog> Dogs { get; set; }

    }
}