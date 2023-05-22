using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore.Extentions
{
    public static class ModelBuilderExtentions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> roles = new List<Role>()
            {
                new Role{ Name="Admin",Description="Yönetici",NormalizedName="ADMIN"},
                new Role { Name="Teacher",Description="Öğretmen",NormalizedName="TEACHER"},
                new Role { Name="Student",Description="Öğrenci",NormalizedName="STUDENT"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>()
            {
                new User{Id="8c455eb9-154d-4978-9f61-de614570416b",FirstName="Cem", LastName="ADmin", UserName="cem", NormalizedUserName="CEM", Email="cem@hotmail.com", NormalizedEmail="CEM@HOTMAIL.COM", Gender="Erkek", DateofBirth=new DateTime(1990,01,01), City="İstanbul", District="Küçükçekmece",Place="Online", EmailConfirmed=true, NormalizedName="ADMINCEM", Description="admin"},

                new User{Id="bd3e9102-9085-4c78-a1bf-6db66d30fd13", FirstName="Ali", LastName="Aktaş", UserName="ali", NormalizedUserName="ALI", Email="ali@hotmail.com", NormalizedEmail="ALI@HOTMAIL.COM", Gender="Erkek", DateofBirth=new DateTime(1990,01,01), City="İstanbul", District="Beşiktaş",Place="Online", EmailConfirmed=true, NormalizedName="OGRETMENALI", Description="Öğretmenim"},

                new User{Id="0588abca-4ab4-4905-b958-fbb070346b03", FirstName="Veli", LastName="Sarı", UserName="veli", NormalizedUserName="VELI", Email="veli@hotmail.com", NormalizedEmail="VELI@HOTMAIL.COM", Gender="Erkek", DateofBirth=new DateTime(1990,01,01), City="İstanbul", District="Fatih",Place="Online", EmailConfirmed=true, NormalizedName="OGRENCIVELI", Description="Öğrenciyim"},

                new User { Id = "7a3a52e5-7314-4bc6-bd6d-8a1f8a019af0", FirstName = "Ayşe", LastName = "Ertaş", UserName = "ayse", NormalizedUserName = "AYSE", Email = "ayse@gmail.com", NormalizedEmail = "ayse@gmail.com", Gender = "Kadın", DateofBirth = new DateTime(1995, 03, 15), City = "Ankara", District = "Çankaya", Place = "Fiziksel", EmailConfirmed = true, NormalizedName = "OGRENCIAYSE", Description = "Öğretmenim" },

                new User { Id = "6258e3a1-287d-4291-9e9d-610ae12961a2", FirstName = "Mehmet", LastName = "Yılmaz", UserName = "mehmet", NormalizedUserName = "MEHMET", Email = "mehmet@gmail.com", NormalizedEmail = "mehmet@gmail.com", Gender = "Erkek", DateofBirth = new DateTime(1988, 05, 10), City = "İstanbul", District = "Kadıköy", Place = "Fiziksel", EmailConfirmed = true, NormalizedName = "OGRETMENMEHMET", Description = "Öğretmenim" },

                new User { Id = "3b9d102e-bd3b-4123-9f83-66e638f5401a", FirstName = "Ekin", LastName = "Cömert", UserName = "ekin", NormalizedUserName = "EKIN", Email = "ekin@hotmail.com", NormalizedEmail = "ekin@hotmail.com", Gender = "Kadın", DateofBirth = new DateTime(1990, 01, 01), City = "İstanbul", District = "Beşiktaş", Place = "Online", EmailConfirmed = true, NormalizedName = "OGRETMENEKIN", Description = "Öğretmenim" },


            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id},
                new IdentityUserRole<string>{UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Teacher").Id},
                new IdentityUserRole<string>{UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Student").Id}
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion


            List<Student> students = new List<Student>()
            {
                new Student {Id=1, UserId=users[2].Id}
            };
            modelBuilder.Entity<Student>().HasData(students);

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher { Id=1, UserId=users[1].Id },
                new Teacher { Id=2, UserId=users[3].Id },
                new Teacher { Id=3, UserId=users[4].Id },
                new Teacher { Id=4, UserId=users[5].Id }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);




        }
    }
}
