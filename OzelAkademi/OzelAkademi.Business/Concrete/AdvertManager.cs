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
    public class AdvertManager : IAdvertService
    {
        private IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        //public async Task CreateAdvert(Advert advert, int lessonId)
        //{
        //    await _advertRepository.CreateAdvert(advert, lesson);
        //}

        public async Task CreateAsync(Advert advert)
        {
            await _advertRepository.CreateAsync(advert);
        }

        public void Delete(Advert advert)
        {
            _advertRepository.Delete(advert);
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
          return await _advertRepository.GetAdvertFullDataAsync(id);
        }

        public async Task<List<Advert>> GetAllAdvert(int id)
        {
            return await _advertRepository.GetAllAdvert(id);
        }

        public async Task<List<Advert>> GetAllAdvertFullDataAsync(string lessonurl = null)
        {
            return await _advertRepository.GetAllAdvertFullDataAsync(lessonurl);
        }

        public async Task<List<Advert>> GetAllAsync()
        {
            return await _advertRepository.GetAllAsync();
        }

        public async Task<Advert> GetByIdAsync(int id)
        {
            return await _advertRepository.GetByIdAsync(id);
        }

        public async Task<Advert> GetByNameAsync(string name)
        {
            return await _advertRepository.GetByNameAsync(name);
        }

        public void Update(Advert advert)
        {
            _advertRepository.Update(advert);
        }

        //public async Task UpdateAdvert(Advert advert, int LessonId)
        //{
        //    await _advertRepository.UpdateAdvert(advert, LessonId);
        //}
    }
}
