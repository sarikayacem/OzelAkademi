using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OzelAkademi.Entity.Concrete;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class UserUpdateViewModel
    {
        public string Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad zorunludur")]
        public string LastName { get; set; }
        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "Hakkında zorunludur")]
        public string Description { get; set; }
        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet zorunludur")]

        public string Gender { get; set; }
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = " zorunludur")]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("İl")]
        [Required(ErrorMessage = "İl zorunludur")]
        public string City { get; set; }
        [DisplayName("İlçe")]
        [Required(ErrorMessage = "İlçe zorunludur")]
        public string District { get; set; }
        [DisplayName("Mekan")]
        [Required(ErrorMessage = "Mekan zorunludur")]
        public string Place { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Email Onayı")]
        public bool EmailConfirmed { get; set; }
        [DisplayName("Resim")]
        public Image Image { get; set; }
        public IFormFile Images { get; set; }

        [Required(ErrorMessage = "En az bir rol seçilmelidir")]
        public IList<string> SelectedRoles { get; set; }
        public List<RoleViewModel> Roles { get; set; }

    }
}
