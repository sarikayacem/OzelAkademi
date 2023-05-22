using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore.Config
{
    public class AdvertConfig : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasData(
                new Advert { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Matematik Özel Dersi", Description = "Matematik dersi verebilirim", Price = 200, Url = "matematik-ozel-dersi", TeacherId = 1, LessonId = 1,Comment="Matematik alanından mezunum." },

                new Advert { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Fizik Özel Dersi", Description = "Fizik dersi verebilirim", Price = 220, Url = "fizik-ozel-dersi", TeacherId = 3, LessonId = 2, Comment = "Fizik alanından mezunum." },

                new Advert { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Kimya Özel Dersi", Description = "Kimya dersi verebilirim", Price = 210, Url = "kimya-ozel-dersi", TeacherId = 2, LessonId = 3, Comment = "Kimya alanından mezunum." },

                new Advert { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Biyoloji Özel Dersi", Description = "Biyoloji dersi verebilirim", Price = 250, Url = "biyoloji-ozel-dersi", TeacherId = 4, LessonId = 4, Comment = "Biyoloji öğretmeniyim." },

                new Advert { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Tarih Özel Dersi", Description = "Tarih dersi verebilirim", Price = 280, Url = "tarih-ozel-dersi", TeacherId = 3, LessonId = 15, Comment = "Tarih alanında deneyimliyim." },

                new Advert { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Müzik Özel Dersi", Description = "Müzik dersi verebilirim", Price = 320, Url = "muzik-ozel-dersi", TeacherId = 1, LessonId = 18, Comment = "Müzik öğretmeniyim." },

                new Advert { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Edebiyat Özel Dersi", Description = "Edebiyat dersi verebilirim", Price = 280, Url = "edebiyat-ozel-dersi", TeacherId = 2, LessonId = 12, Comment = "Edebiyat alanında uzmanım." }

                );



        }
    }
}
