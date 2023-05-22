using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(OzelAkademiContext _appContext) : base(_appContext)
        {
        }
        OzelAkademiContext AppContext
        {
            get { return _dbContext as OzelAkademiContext; }
        }

        public async Task<List<Teacher>> GetAllTeachersWithAdvertsAsync(bool ApprovedStatus)
        {
            List<Teacher> result = await AppContext
                .Teachers
                .Where(a => a.IsApproved == ApprovedStatus)
                .Include(a => a.Adverts)
                .ToListAsync();
            return result;
        }

        public async Task<List<Teacher>> GetTeacherByAdvert(int id)
        {
            List<Teacher> result = await AppContext
                .Teachers
                .Include(a => a.Adverts)
                .Where(a => a.Adverts.Any(x => x.Id == id))
                .ToListAsync();
            return result;
        }

        public async Task<Teacher> GetTeacherByUserId(string id)
        {
            Teacher teacher = await AppContext
                .Teachers
                .Include(u=>u.User)
                .ThenInclude(u=>u.Image)
                .FirstOrDefaultAsync(x=>x.UserId==id);
            return teacher;
        }
    }
}
