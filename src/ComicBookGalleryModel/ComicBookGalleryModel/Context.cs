using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComicBookGalleryModel.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComicBookGalleryModel
{
    class Context : DbContext
    {
        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);
        }
    }
}
