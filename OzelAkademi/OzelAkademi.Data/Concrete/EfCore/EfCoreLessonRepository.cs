using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(OzelAkademiContext _appContext) : base(_appContext)
        {
        }
        OzelAkademiContext AppContext
        {
            get { return _dbContext as OzelAkademiContext; }
        }

        public async Task<string> GetLessonNameByUrlAsync(string url)
        {
            Lesson lesson = await AppContext
                .Lessons
                .Where(l => l.Url == url)
                .FirstOrDefaultAsync();
            return lesson.Name;
        }

        public async Task<List<Lesson>> GetLessonsAsync(bool approvesStatus)
        {
            return await AppContext
                .Lessons
                .ToListAsync();
        }
    }
}
