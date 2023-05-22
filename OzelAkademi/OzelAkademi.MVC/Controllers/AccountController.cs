using OzelAkademi.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.EmailServices;
using OzelAkademi.MVC.Models.ViewModels;
using OzelAkademi.MVC.Models.ViewModels.AccountModels;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace OzelAkademi.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IOrderService _orderService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IImageService _imageService;
        private readonly IAdvertService _advertService;
        private readonly INotyfService _notyfService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IOrderService orderService, ITeacherService teacherService, IStudentService studentService, IImageService imageService, INotyfService notyfService, IAdvertService advertService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _orderService = orderService;
            _teacherService = teacherService;
            _studentService = studentService;
            _imageService = imageService;
            _advertService = advertService;
            _notyfService = notyfService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    NormalizedName = (registerViewModel.FirstName + registerViewModel.LastName).ToUpper(),
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Url = Jobs.UploadImage(registerViewModel.Image)
                    }
                };
                Teacher teacher = new Teacher
                {
                    UserId = user.Id,

                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                    await _teacherService.CreateAsync(teacher);
                    //await _cartService.InitializeCart()
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }
        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    NormalizedName = (registerViewModel.FirstName + registerViewModel.LastName).ToUpper(),
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Url = Jobs.UploadImage(registerViewModel.Image)
                    }

                };
                Student student = new Student
                {
                    UserId = user.Id
                };
                var url = Jobs.UploadImage(registerViewModel.Image);


                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    await _studentService.CreateAsync(student);

                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return Redirect("~/Admin");
                    }
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı");

            }


            return View(loginViewModel);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            string name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var users = await _userManager.Users.Include(x => x.Image).ToListAsync();
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });
            UserManageViewModel userManageViewModel = new UserManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
                Gender = user.Gender,
                DateOfBirth = user.DateofBirth,
                City = user.City,
                District = user.District,
                Place = user.Place,
                UserName = user.UserName,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                ModifiedDate = DateTime.Now,
                GenderSelectList = genderList,
                Image = user.Image
            };
            return View(userManageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel userManageViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userManageViewModel == null) { return NotFound(); }
                var users = await _userManager.Users.Include(x => x.Image).ToListAsync();
                User user = await _userManager.FindByIdAsync(userManageViewModel.Id);
                bool logOut = !(user.UserName == userManageViewModel.UserName);
                user.FirstName = userManageViewModel.FirstName;
                user.LastName = userManageViewModel.LastName;
                user.Description = userManageViewModel.Description;
                user.Gender = userManageViewModel.Gender;
                user.DateofBirth = userManageViewModel.DateOfBirth;
                user.City = userManageViewModel.City;
                user.District = userManageViewModel.District;
                user.Place = userManageViewModel.Place;
                user.UserName = userManageViewModel.UserName;
                user.Email = userManageViewModel.Email;
                user.CreatedDate = userManageViewModel.CreatedDate;
                user.ModifiedDate = DateTime.Now;
                if (userManageViewModel.ImageUrl != null)
                {
                    var image = await _imageService.GetByIdAsync(user.Image.Id);
                    user.Image.Url = Jobs.UploadImage(userManageViewModel.ImageUrl);
                    user.Image.ModifiedDate = DateTime.Now;

                }
                await _userManager.UpdateAsync(user);
                _notyfService.Success("Profil Güncelleme Başarılı");


                /////BAŞARILI VEYA BAŞARISIZ MESAJ YOLLAYCAK
                List<SelectListItem> genderList = new List<SelectListItem>();
                genderList.Add(new SelectListItem
                {
                    Text = "Kadın",
                    Value = "Kadın",
                    Selected = user.Gender == "Kadın" ? true : false,

                });
                genderList.Add(new SelectListItem
                {
                    Text = "Erkek",
                    Value = "Erkek",
                    Selected = user.Gender == "Erkek" ? true : false,

                });
                userManageViewModel.GenderSelectList = genderList;
                userManageViewModel.Image = user.Image;

            }

            return View(userManageViewModel);
        }
        

    }
}
