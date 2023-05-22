using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Abstract
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<string> GetLessonNameByUrlAsync(string url);
        Task<List<Lesson>> GetLessonsAsync(bool approvesStatus);
    }
}
