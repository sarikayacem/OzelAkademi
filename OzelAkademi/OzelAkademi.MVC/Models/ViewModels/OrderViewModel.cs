using OzelAkademi.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        public string LastName { get; set; }
       
        public DateTime OrderDate { get; set; }

        public CartViewModel Cart { get; set; }
        public Advert Advert { get; set; }
        public int AdvertId { get; set; }
        public List<CartItemViewModel> OrderItems { get; set; }

        //Kredi kartı properties
        [DisplayName("Kartın üzerindeki Ad Soyad")]
        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        public string CardName { get; set; }
        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "Kart Numarası alanı boş bırakılamaz.")]
        public string CardNumber { get; set; }
        [DisplayName("Ay")]
        [Required(ErrorMessage = "Ay alanı boş bırakılamaz.")]
        public string ExpirationMonth { get; set; }
        [DisplayName("Yıl")]
        [Required(ErrorMessage = "Yıl alanı boş bırakılamaz.")]
        public string ExpirationYear { get; set; }
        [DisplayName("Cvc")]
        [Required(ErrorMessage = "Cvc alanı boş bırakılamaz.")]
        public string Cvc { get; set; }


    }
}
