using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Data.Concrete.EfCore.Context;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore
{
    public class EfCoreAdvertRepository : EfCoreGenericRepository<Advert>, IAdvertRepository
    {
        public EfCoreAdvertRepository(OzelAkademiContext _appContext) : base(_appContext)
        {
        }

        OzelAkademiContext AppContext
        {
            get { return _dbContext as OzelAkademiContext; }
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
           return await AppContext.Adverts.Include(x => x.Teacher).ThenInclude(x=>x.User).ThenInclude(x => x.Image).Include(x => x.Lesson).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //public async Task CreateAdvert(Advert advert, int LessonId)
        //{
        //    await AppContext.Adverts.AddAsync(advert);
        //    await AppContext.SaveChangesAsync();
        //    //await AppContext.Lessons.AddAsync(LessonId);

        //    await AppContext.SaveChangesAsync();
        //}

        public Task<List<Advert>> GetAllAdvert(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Advert>> GetAllAdvertFullDataAsync(string lessonurl)
        {
            var adverts = AppContext
                .Adverts
                .Include(l => l.Lesson)
                .AsQueryable();
            if(lessonurl !=null)
            {
                adverts = adverts.Where(l => l.Lesson.Url == lessonurl);
            }
            return await adverts
                .Include(a => a.Teacher)
                .ThenInclude(a=>a.User)
                .Include(a => a.Lesson)
                .ToListAsync();
        }

        public async Task<Advert> GetByNameAsync(string name)
        {
            var advert= AppContext
                .Adverts
                .Include(a => a.Teacher)
                .ThenInclude(a => a.User)
                .ThenInclude(a=>a.Image)
                .Include (a=>a.Lesson)
                .Where(a=>a.Name == name).FirstOrDefaultAsync();
            return await advert;


        }

        //public async Task UpdateAdvert(Advert advert, int LessonId)
        //{
        //    Advert newAdvert = AppContext
        //        .Adverts
        //        .Include(al => al.Lesson)
        //        .FirstOrDefault(a => a.Id == advert.Id);
        //    newAdvert.Name = advert.Name;
        //    newAdvert.Description = advert.Description;
        //    newAdvert.Price = advert.Price;
        //    newAdvert.CreatedDate = advert.CreatedDate;
        //    newAdvert.ModifiedDate = DateTime.Now;
        //    newAdvert.Url = advert.Url;
        //    newAdvert.Lesson = advert.Lesson;
        //    AppContext.Update(advert);
        //    await AppContext.SaveChangesAsync();




        //}
    }
}
