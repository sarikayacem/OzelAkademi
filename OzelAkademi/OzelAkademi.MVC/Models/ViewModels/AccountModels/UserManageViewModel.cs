using Microsoft.AspNetCore.Mvc.Rendering;
using OzelAkademi.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Models.ViewModels.AccountModels
{
    public class UserManageViewModel
    {
        public string Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage ="Ad gereklidir.")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad gereklidir.")]
        public string LastName { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama gereklidir.")]
        public string Description { get; set; }
        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet gereklidir.")]
        public string Gender { get; set; }
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("İl")]
        [Required(ErrorMessage = "İl gereklidir.")]
        public string City { get; set; }
        [DisplayName("İlçe")]
        [Required(ErrorMessage = "İlçe gereklidir.")]
        public string District { get; set; }
        
        [DisplayName("Fotoğraf")]
        public Image Image { get; set; }
        public IFormFile ImageUrl { get; set; }
        [DisplayName("Mekan")]
        [Required(ErrorMessage = "Mekan gereklidir.")]
        public string Place { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email gereklidir.")]
        public string Email { get; set; }
        [DisplayName("Oluşturulma tarihi")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Düzenleme tarihi")]

        public DateTime ModifiedDate { get; set; }
        
        public List<SelectListItem> GenderSelectList { get; set; }
        public List<OrderViewModel> Orders { get; set; }

    }
}
