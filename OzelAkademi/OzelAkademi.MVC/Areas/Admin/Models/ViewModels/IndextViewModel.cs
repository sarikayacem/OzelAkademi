using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;

namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class IndextViewModel
    {
        public List<Teacher> Teacher { get; set; }
        public List<Student> Student { get; set; }
        public List<Advert> Advert { get; set; }
        public List<Order> Order { get; set; }
    }
}
