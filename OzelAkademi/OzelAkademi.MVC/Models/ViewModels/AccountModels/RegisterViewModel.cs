using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Models.ViewModels.AccountModels
{
    public class RegisterViewModel
    {
        [DisplayName("Adınız")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        public string FirstName { get; set; }
        [DisplayName("Soyadınız")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        public string LastName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Şifre doğrulama")]
        [Required(ErrorMessage = "(Bu alan boş bırakılamaz!)")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [DisplayName("Fotoğraf")]
        [Required(ErrorMessage = "(Lütfen fotoğraf ekleyiniz!)")]

        public IFormFile Image { get; set; }
        

    }
}
