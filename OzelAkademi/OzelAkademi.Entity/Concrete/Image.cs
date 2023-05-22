using OzelAkademi.Entity.Abstract;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete
{
    public class Image : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public string UserId  { get; set; }
        public User User { get; set; }

    }
}
