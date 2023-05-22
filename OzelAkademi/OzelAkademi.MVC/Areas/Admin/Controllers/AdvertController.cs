using OzelAkademi.Core;
using Microsoft.AspNetCore.Mvc;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using OzelAkademi.MVC.Areas.Admin.Models.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace OzelAkademi.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;
        private readonly IImageService _imageService;
        private readonly INotyfService _notyfService;



        public AdvertController(IAdvertService advertService, ITeacherService teacherService, ILessonService lessonService, IImageService imageService, INotyfService notyfService)
        {
            _advertService = advertService;
            _teacherService = teacherService;
            _lessonService = lessonService;
            _imageService = imageService;
            _notyfService = notyfService;
        }
        #region Listeleme
        public async Task<IActionResult> Index(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                advertList = await _advertService.GetAllAdvertFullDataAsync();
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
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
                            User=advert.Teacher.User
                        }
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
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
                Teacher = advert.Teacher
                //Lesson 
                //İMAGE
            };

            return View(advertUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit ( AdvertUpdateViewModel advertUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Advert advert = await _advertService.GetByIdAsync(advertUpdateViewModel.Id);
                advert.Name= advertUpdateViewModel.Name;
                advert.Description = advertUpdateViewModel.Description;
                advert.Price=advertUpdateViewModel.Price;
                advert.Comment = advertUpdateViewModel.Comment;
                advert.Url = Jobs.GetUrl(advertUpdateViewModel.Name);
                advert.ModifiedDate = DateTime.Now;
                _advertService.Update(advert);
                _notyfService.Success("Düzenleme başarılı.");

                return RedirectToAction("Index");

            }
            return View(advertUpdateViewModel);
        }


        #endregion
        #region Kayıt Silme
        public async Task<IActionResult> Delete(int id)
        {
            Advert deletedAdvert = await _advertService.GetByIdAsync(id);
            if(deletedAdvert != null)
            {
                _advertService.Delete(deletedAdvert);
                _notyfService.Error("İlan silinmiştir.");

            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
