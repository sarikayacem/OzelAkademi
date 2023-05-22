using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Url).IsRequired().HasMaxLength(1000);


            builder.HasData(
                new Image { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "1.jpg", UserId= "8c455eb9-154d-4978-9f61-de614570416b" },
                new Image { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "3.jpg", UserId= "bd3e9102-9085-4c78-a1bf-6db66d30fd13" },
                new Image { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "4.jpg", UserId= "0588abca-4ab4-4905-b958-fbb070346b03" },
                new Image { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "2.jpg", UserId= "7a3a52e5-7314-4bc6-bd6d-8a1f8a019af0" },
                new Image { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "5.jpg", UserId= "6258e3a1-287d-4291-9e9d-610ae12961a2" },
                new Image { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "6.jpg", UserId= "3b9d102e-bd3b-4123-9f83-66e638f5401a" }
                );



        }
    }
}
