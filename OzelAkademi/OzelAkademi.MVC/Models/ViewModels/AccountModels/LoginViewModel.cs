using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelAkademi.MVC.Models.ViewModels.AccountModels
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adınız")]
        [Required(ErrorMessage ="(Kullanıcı adınızı giriniz)")]
        public string UserName { get; set; }

        [DisplayName("Şifreniz")]
        [Required(ErrorMessage = "(Şifrenizi giriniz)")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
