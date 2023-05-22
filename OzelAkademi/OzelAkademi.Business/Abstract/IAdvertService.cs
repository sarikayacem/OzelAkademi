using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Abstract
{
    public interface IAdvertService
    {
        Task CreateAsync(Advert advert);
        Task<Advert> GetByIdAsync(int id);
        Task<List<Advert>> GetAllAsync();
        void Update(Advert advert);
        void Delete(Advert advert);
        Task<Advert> GetByNameAsync(string name);

        Task<List<Advert>> GetAllAdvert(int id);
        Task<List<Advert>> GetAllAdvertFullDataAsync(string lessonurl = null);
        //Task CreateAdvert(Advert advert, int lessonId);
        //Task UpdateAdvert(Advert advert, int Lesson);
        Task<Advert> GetAdvertFullDataAsync(int id);
    }
}
