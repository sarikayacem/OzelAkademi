using OzelAkademi.MVC.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        public string LastName { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres alanı boş bırakılamaz.")]
        public string Address { get; set; }
        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılamaz.")]
        public string City { get; set; }
        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        public string Phone { get; set; }
        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılamaz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
