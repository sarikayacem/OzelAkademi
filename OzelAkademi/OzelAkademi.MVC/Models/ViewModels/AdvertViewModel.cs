using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.Entity.Concrete;

namespace OzelAkademi.MVC.Models.ViewModels
{
    public class AdvertViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Url { get; set; }
        public int LessonId { get; set; }
        public string ImageUrl { get; set; }
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
