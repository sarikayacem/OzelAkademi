using OzelAkademi.Entity.Abstract;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Entity.Concrete
{

    public class Advert : IBaseEntity, IBaseCommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Image Image { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        



    }
}
