using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class AdvertUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("İlan Adı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        public string Name { get; set; }
        [DisplayName("İlan Açıklaması")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string Description { get; set; }
        [DisplayName("İlan Fiyatı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public decimal? Price { get; set; }
        [DisplayName("İlan Açıklaması-2")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
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
