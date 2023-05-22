using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Property(x => x.LessonId).IsRequired();
            //builder.Property(x=>x.UserId).IsRequired();

            //builder.HasData(
            //    new Teacher { Id = 1, UserId = "bd3e9102-9085-4c78-a1bf-6db66d30fd13" },
            //    new Teacher { Id = 2, UserId = "3a6e7b04-1e9a-47c9-81e1-0c3e0e18c645" },
            //    new Teacher { Id = 3, UserId = "f83d92e1-af68-4a5e-96da-9e7fe30228e5" },
            //    new Teacher { Id = 4, UserId = "5b60c18c-8a47-4e01-93b7-4ae36c44ff7f" },
            //    new Teacher { Id = 5, UserId = "77a71a0d-67e4-4f2f-8c79-19d8797fcbde" },
            //    new Teacher { Id = 6, UserId = "d724b3e2-93f6-41e2-b860-8f13a2771f34" },
            //    new Teacher { Id = 7, UserId = "9610a2e9-01be-48ef-9385-87241a4760d7" },
            //    new Teacher { Id = 8, UserId = "b4920f7a-4d68-44b3-a648-768c0b440b3b" },
            //    new Teacher { Id = 9, UserId = "2fd43d8c-7bda-4b2a-95e0-1dd231673116" },
            //    new Teacher { Id = 10, UserId = "ae4fc0e4-0512-486f-91f0-57c15e44b317" }
            //    );
        }
    }
}
