using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.Entity.Concrete;
using System.ComponentModel;

namespace OzelAkademi.MVC.Models.ViewModels
{
    public class AdvertUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("İlan Adı")]

        public string Name { get; set; }
        [DisplayName("İlan hakkında bilgi")]

        public string Description { get; set; }
        [DisplayName("İlan Fiyatı")]

        public decimal? Price { get; set; }
        [DisplayName("Kendiniz hakkında ilana bilgi ")]

        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
        public List<Lesson> Lesson { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
