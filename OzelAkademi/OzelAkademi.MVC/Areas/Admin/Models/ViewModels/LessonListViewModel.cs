namespace OzelAkademi.MVC.Areas.Admin.Models.ViewModels
{
    public class LessonListViewModel
    {
        public List<LessonViewModel> Lessons { get; set; }
        public bool ApprovedStatus { get; set; }
    }
}
