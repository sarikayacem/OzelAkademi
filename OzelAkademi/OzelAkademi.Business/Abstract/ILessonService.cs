using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Abstract
{
    public interface ILessonService
    {
        Task CreateAsync(Lesson lesson);
        Task<Lesson> GetByIdAsync(int id);
        Task<List<Lesson>> GetAllAsync();
        void Update(Lesson lesson);
        void Delete(Lesson lesson);
        Task<List<Lesson>> GetLessonsAsync(bool ApprovedStatus);
        Task<string> GetLessonNameByUrlAsync(string url);
        
    }
}
