using OzelAkademi.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete
{
    public class Lesson : IBaseEntity,IBaseCommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public List<Advert> Adverts { get; set; }

    }
}
