using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete.Identity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Advert> Adverts { get; set; }
        public bool IsApproved { get; set; }

    }
}
