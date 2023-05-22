using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetTeacherByAdvert(int id);
        Task<List<Teacher>> GetAllTeachersWithAdvertsAsync(bool ApprovedStatus);
        Task<Teacher> GetTeacherByUserId(string id);
    }
}
