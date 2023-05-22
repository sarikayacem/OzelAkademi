using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Core;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.Areas.Admin.Models.ViewModels;
using System.Data;

namespace OzelAkademi.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IImageService _imageService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;


        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IImageService imageService, ITeacherService teacherService, IStudentService studentService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                Image = u.Image

            }).ToListAsync();

            return View(users);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var users = await _userManager.Users.Include(x => x.Image).ToListAsync();
            User user = await _userManager.FindByIdAsync(id);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description=user.Description,
                UserName = user.UserName,
                DateOfBirth=user.DateofBirth,
                Email = user.Email,
                Gender=user.Gender,
                City=user.City,
                Place=user.Place,
                EmailConfirmed = user.EmailConfirmed,
                Image = user.Image,
                SelectedRoles = await _userManager.GetRolesAsync(user),
                Roles = _roleManager.Roles.Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList()
            };
            return View(userUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(userUpdateViewModel.Id);
                if (user == null) { return NotFound(); }
                user.FirstName = userUpdateViewModel.FirstName;
                user.LastName = userUpdateViewModel.LastName;
                user.UserName = userUpdateViewModel.UserName;
                user.Email = userUpdateViewModel.Email;
                user.EmailConfirmed = userUpdateViewModel.EmailConfirmed;
                if (userUpdateViewModel.Image != null)
                {
                    Image image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Url = Jobs.UploadImage(userUpdateViewModel.Images)
                    };
                    await _imageService.CreateAsync(image);
                }

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) { return NotFound(); }
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.AddToRolesAsync(user, userUpdateViewModel.SelectedRoles.Except(userRoles).ToList<string>());
                await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userUpdateViewModel.SelectedRoles).ToList<string>());
                return RedirectToAction("Index", "User");
            }
            userUpdateViewModel.Roles = _roleManager.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
            return View(userUpdateViewModel);
        }
        public async Task<IActionResult> ConfirmEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "User");
        }
        public async Task<IActionResult> Delete(string id)
        {
            //User user = await _userManager.FindByIdAsync(id);
            //if (user == null) return NotFound();
            //await _userManager.DeleteAsync(user);
            //return RedirectToAction("Index", "User");
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                
                await _userManager.DeleteAsync(user);
               
            }

            return RedirectToAction("Index", "User");

        }
        public async Task<IActionResult> Students()
        {
            var users = await _userManager.Users.Include(x => x.Image).ToListAsync() ;
            var students = await _studentService.GetAllAsync();

            return View(students);
        }
        public async Task<IActionResult> Teachers()
        {
            var users = await _userManager.Users.Include(x => x.Image).ToListAsync();
            var teachers = await _teacherService.GetAllAsync();

            return View(teachers);
        }
    }
}
