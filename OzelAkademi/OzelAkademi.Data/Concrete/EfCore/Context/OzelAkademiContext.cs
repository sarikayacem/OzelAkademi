using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzelAkademi.Data.Concrete.EfCore.Config;
using OzelAkademi.Data.Concrete.EfCore.Extentions;
using OzelAkademi.Entity.Concrete;
using OzelAkademi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Data.Concrete.EfCore.Context
{
    public class OzelAkademiContext : IdentityDbContext<User, Role, string>
    {
        public OzelAkademiContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.SeedData();
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(LessonConfig).Assembly);
            base.OnModelCreating(modelbuilder);
        }

    }
}
