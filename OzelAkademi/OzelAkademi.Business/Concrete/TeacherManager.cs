using OzelAkademi.Business.Abstract;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherManager()
        {
        }

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherRepository.CreateAsync(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersWithAdvertsAsync(bool ApprovedStatus)
        {
            return await _teacherRepository.GetAllTeachersWithAdvertsAsync(ApprovedStatus);
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<List<Teacher>> GetTeacherByAdvert(int id)
        {
            return await _teacherRepository.GetTeacherByAdvert(id);
        }

        public async Task<Teacher> GetTeacherByUserId(string id)
        {
            return await _teacherRepository.GetTeacherByUserId(id);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
    }
}
