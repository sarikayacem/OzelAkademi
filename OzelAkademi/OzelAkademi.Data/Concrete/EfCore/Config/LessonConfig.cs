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
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Lesson { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Matematik", Url = "matematik" },
                new Lesson { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Fizik", Url = "fizik" },
                new Lesson { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Kimya", Url = "kimya" },
                new Lesson { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Biyoloji", Url = "biyoloji" },
                new Lesson { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "İngilizce", Url = "ingilizce" },
                new Lesson { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Almanca", Url = "almanca" },
                new Lesson { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Fransızca", Url = "fransızca" },
                new Lesson { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "İspanyolca", Url = "ispanyolca" },
                new Lesson { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "İtalyanca", Url = "italyanca" },
                new Lesson { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Japonca", Url = "japonca" },
                new Lesson { Id = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Çince", Url = "cince" },
                new Lesson { Id = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Türkçe", Url = "turkce" },
                new Lesson { Id = 14, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Sosyal bilimler", Url = "sosyal-bilimler" },
                new Lesson { Id = 15, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Tarih", Url = "tarih" },
                new Lesson { Id = 16, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Coğrafya", Url = "cografya" },
                new Lesson { Id = 17, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Sanat tarihi", Url = "sanat-tarihi" },
                new Lesson { Id = 18, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Müzik", Url = "muzik" },
                new Lesson { Id = 19, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Resim", Url = "resim" },
                new Lesson { Id = 20, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Dans", Url = "dans" },
                new Lesson { Id = 21, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Drama", Url = "drama" },
                new Lesson { Id = 22, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Üniversite sınavı hazırlık dersleri", Url = "üniversite-sınavı-hazırlık-dersleri" },
                new Lesson { Id = 23, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Dil sınavı hazırlık dersleri", Url = "dil-sınavı-hazırlık-dersleri" },
                new Lesson { Id = 24, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Programlama dilleri", Url = "programlama-dilleri" },
                new Lesson { Id = 25, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "İşletme ve finans dersleri", Url = "işletme-ve-finans-dersleri" },
                new Lesson { Id = 26, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Name = "Mühendislik dersleri", Url = "mühendislik-dersleri" });
                
        }
    }
}
