using OzelAkademi.Business.Abstract;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonRepository _lessonRepository;

        public LessonManager(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task CreateAsync(Lesson lesson)
        {
            await _lessonRepository.CreateAsync(lesson);
        }

        public void Delete(Lesson lesson)
        {
            _lessonRepository.Delete(lesson);
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public async Task<string> GetLessonNameByUrlAsync(string url)
        {
            return await _lessonRepository.GetLessonNameByUrlAsync(url);
        }

        public async Task<List<Lesson>> GetLessonsAsync(bool ApprovedStatus)
        {
            return await _lessonRepository.GetLessonsAsync(ApprovedStatus);
        }

        public void Update(Lesson lesson)
        {
            _lessonRepository.Update(lesson);
        }
    }
}
