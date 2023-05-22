using OzelAkademi.Entity.Concrete;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Place { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public Image Image { get; set; }
        public IFormFile ImageUrl { get; set; }

    }
}
