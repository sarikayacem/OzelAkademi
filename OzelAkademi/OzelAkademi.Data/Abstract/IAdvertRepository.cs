using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Abstract
{
    public interface IAdvertRepository :IGenericRepository<Advert>
    {
        Task<List<Advert>> GetAllAdvert(int id);
        Task<List<Advert>> GetAllAdvertFullDataAsync(string lessonurl);
        Task<Advert> GetByNameAsync(string name);
        //Task CreateAdvert(Advert advert, int LessonId);
        //Task UpdateAdvert(Advert advert, int LessonId);
        Task<Advert> GetAdvertFullDataAsync(int id);
    }
}
