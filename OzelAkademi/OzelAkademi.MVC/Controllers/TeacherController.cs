using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Core;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.Models.ViewModels;

namespace OzelAkademi.MVC.Controllers
{
    public class TeacherController : Controller
    {
        private IAdvertService _advertService;
        private ILessonService _lessonService;
        private ITeacherService _teacherService;
        private IImageService _ımageService;
        private UserManager<User> _userManager;
        private INotyfService _notyfService;

        public TeacherController(IAdvertService advertService, ILessonService lessonService, ITeacherService teacherService, IImageService ımageService, UserManager<User> userManager, INotyfService notyfService)
        {
            _advertService = advertService;
            _lessonService = lessonService;
            _teacherService = teacherService;
            _ımageService = ımageService;
            _userManager = userManager;
            _notyfService = notyfService;
        }
        #region Listeleme
        public async Task<IActionResult> Index(string id)
        {
            string name = id;
            var result = await _userManager.FindByNameAsync(name);
            var teacher = await _userManager.Users.Where(x => x.Id == result.Id).Include(x => x.Teacher).ThenInclude(x => x.Adverts).ThenInclude(x=>x.Lesson).FirstOrDefaultAsync();


            if (teacher.Teacher.Adverts != null)
            {
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in teacher.Teacher.Adverts)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        Name = advert.Name,
                        Description = advert.Description,
                        Price = advert.Price,
                        Comment = advert.Comment,
                        CreatedDate = advert.CreatedDate,
                        ModifiedDate = advert.ModifiedDate,
                        Lesson = new Lesson()
                        {
                            Name = advert.Lesson.Name,
                            Id = advert.Lesson.Id
                        },
                        Teacher = new Teacher()
                        {
                            Id = advert.Teacher.Id,
                            User = advert.Teacher.User
                        }
                    });
                }
                AdvertListViewModel advertList = new AdvertListViewModel
                {
                    Adverts = adverts
                };
                //teacher.Teacher.Adverts = adverts;
                return View(advertList);

            }
            return View("Index");
        }
        #endregion
        #region Yeni Kayıt
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var result = await _lessonService.GetAllAsync();
            AdvertAddViewModel advertAddViewModel = new AdvertAddViewModel
            {
                Lessons = result
            };
            var sonuc = result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.lessons = sonuc;
            
            return View(advertAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdvertAddViewModel advertAddViewModel)
        {
            User user = await _userManager.GetUserAsync(User);

            Teacher teacher = await _teacherService.GetTeacherByUserId(user.Id);
            List<Lesson> lesson = await _lessonService.GetAllAsync();
            if (ModelState.IsValid)
            {
                Advert advert = new Advert
                {

                    Name = advertAddViewModel.Name,
                    Description = advertAddViewModel.Description,
                    Price = advertAddViewModel.Price,
                    Comment = advertAddViewModel.Comment,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Url=Jobs.GetUrl(advertAddViewModel.Name),
                    Image=teacher.User.Image,
                    LessonId=advertAddViewModel.LessonId,
                    TeacherId=teacher.Id
                    
                };
                Image image = teacher.User.Image;
                //await _advertService.CreateAdvert(advert,advert.LessonId);
                await _advertService.CreateAsync(advert);
                teacher.Adverts.Add(advert);
                _notyfService.Success("İlan Ekleme Başarılı.");



            }
            return Redirect("/Teacher/Index/" + User.Identity.Name);
		}
        #endregion
        #region Kayıt Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Advert advert = await _advertService.GetByIdAsync(id);
            AdvertUpdateViewModel advertUpdateViewModel = new AdvertUpdateViewModel()
            {
                Id = advert.Id,
                Name = advert.Name,
                Description = advert.Description,
                Price = advert.Price,
                Comment = advert.Comment,
                ModifiedDate = advert.ModifiedDate,
                Url= advert.Url,

            };
            return View(advertUpdateViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> Edit (AdvertUpdateViewModel advertUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                Advert advert = await _advertService.GetByIdAsync (advertUpdateViewModel.Id);
                advert.Name = advertUpdateViewModel.Name;
                advert.Description = advertUpdateViewModel.Description;
                advert.Price = advertUpdateViewModel.Price;
                advert.Comment = advertUpdateViewModel.Comment;
                advert.Url= Jobs.GetUrl(advertUpdateViewModel.Name);
                advert.ModifiedDate = DateTime.Now;
                _advertService.Update(advert);
                _notyfService.Success("Düzenleme Başarılı.");

                return Redirect("/Teacher/Index/" + User.Identity.Name);
            }
            return View(advertUpdateViewModel);
        }
        #endregion
        #region Kayıt Silme
        public async Task<IActionResult> Delete(int id)
        {
            Advert deletedAdvert = await _advertService.GetByIdAsync(id);
            if (deletedAdvert != null)
            {
                _advertService.Delete(deletedAdvert);
                _notyfService.Error("İlan Silindi.");

            }
            return Redirect("/Teacher/Index/" + User.Identity.Name);


        }
        #endregion


    }
}
