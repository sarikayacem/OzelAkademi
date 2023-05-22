using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Abstract
{
    public interface ITeacherService
    {
        Task CreateAsync(Teacher teacher);
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Task<List<Teacher>> GetAllTeachersWithAdvertsAsync(bool ApprovedStatus);
        Task<List<Teacher>> GetTeacherByAdvert(int id);
        Task<Teacher> GetTeacherByUserId(string id);

    }
}
