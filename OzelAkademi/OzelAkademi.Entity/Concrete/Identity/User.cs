using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete.Identity
{
    public class User :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string NormalizedName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public Image? Image { get; set; }
        public string Place { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }


    }
}
