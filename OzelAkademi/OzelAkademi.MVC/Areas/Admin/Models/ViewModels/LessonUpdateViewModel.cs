using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class LessonUpdateViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ders Adı")]
        [Required(ErrorMessage ="Boş bırakılamaz")]
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
