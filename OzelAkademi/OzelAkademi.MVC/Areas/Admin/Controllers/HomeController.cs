using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.Areas.Admin.Models.ViewModels;

namespace OzelAkademi.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IAdvertService _advertService;

        public HomeController(IOrderService orderService, UserManager<User> userManager, RoleManager<Role> roleManager, ITeacherService teacherService, IStudentService studentService, IAdvertService advertService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherService = teacherService;
            _studentService = studentService;
            _advertService = advertService;
        }
        public async Task<IActionResult> Index()
        {
            var teacher = await _teacherService.GetAllAsync();
            var student = await _studentService.GetAllAsync();
            var advert = await _advertService.GetAllAsync();
            var order = await _orderService.GetAllAsync();

            IndextViewModel indextViewModel = new IndextViewModel
            {
                Student= student,
                Teacher= teacher,
                Advert=advert,
                Order = order
            };

            return View(indextViewModel);
        }
    }
}
