using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Business.Concrete;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;

namespace OzelAkademi.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        private readonly IAdvertService _advertService;
        private readonly ITeacherService _teacherService;


        public OrderController(IOrderService orderService, UserManager<User> userManager, IAdvertService advertService, ITeacherService teacherService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _advertService = advertService;
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            List<Order> orders = await _orderService.GetAllAsync();
            var teacher = await _teacherService.GetAllAsync();

            var advert = await _advertService.GetAllAsync();

            return View(orders);
        }
    }
}
