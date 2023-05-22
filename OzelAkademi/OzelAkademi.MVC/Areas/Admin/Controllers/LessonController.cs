using AspNetCoreHero.ToastNotification.Abstractions;
using OzelAkademi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OzelAkademi.Business.Abstract;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.MVC.Areas.Admin.Models.ViewModels;

namespace OzelAkademi.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly INotyfService _notyfService;

        public LessonController(ILessonService lessonService, INotyfService notyfService)
        {
            _lessonService = lessonService;
            _notyfService = notyfService;
        }
        #region Listeleme
        public async Task<IActionResult> Index(LessonListViewModel lessonListViewModel)
        {
            List<Lesson> lessonList = await _lessonService.GetLessonsAsync(lessonListViewModel.ApprovedStatus);
            List<LessonViewModel> lessons = new List<LessonViewModel>();
            foreach (var lesson in lessonList)
            {
                lessons.Add(new LessonViewModel
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    Url = lesson.Url
                });
            }
            lessonListViewModel.Lessons = lessons;
            return View(lessonListViewModel);
        }
        #endregion
        #region Yeni Kayıt
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Lesson lesson = new Lesson
                {
                    Name = lessonAddViewModel.Name,
                    Url = Jobs.GetUrl(lessonAddViewModel.Name),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                await _lessonService.CreateAsync(lesson);
                _notyfService.Success($"{lesson.Name} dersi eklenmiştir.");
                return RedirectToAction("Index");
            }
            return View(lessonAddViewModel);
        }
        #endregion
        #region Kayıt Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Lesson lesson = await _lessonService.GetByIdAsync(id);
            LessonUpdateViewModel lessonUpdateViewModel = new LessonUpdateViewModel()
            {
                Name = lesson.Name,
                Url = lesson.Url,
                ModifiedDate = lesson.ModifiedDate
            };
            return View(lessonUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (LessonUpdateViewModel lessonUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Lesson lesson = await _lessonService.GetByIdAsync(lessonUpdateViewModel.Id);
                lesson.Name = lessonUpdateViewModel.Name;
                lesson.Url = Jobs.GetUrl(lessonUpdateViewModel.Name);
                lesson.ModifiedDate = DateTime.Now;
                _lessonService.Update(lesson);
                _notyfService.Success("Düzenleme kaydedildi");

                return RedirectToAction("Index");
            }
            return View(lessonUpdateViewModel);
        }
        #endregion
        #region Kayıt Silme
        public async Task<IActionResult> Delete (int id)
        {
            Lesson deletedLesson = await _lessonService.GetByIdAsync(id);
            if (deletedLesson != null)
            {
                _notyfService.Error($"{deletedLesson.Name} dersi silinmiştir.");

                _lessonService.Delete(deletedLesson);
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
