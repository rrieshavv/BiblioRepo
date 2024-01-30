using BiblioRepo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioRepo.Web.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        /// <summary>
        ///     The function below is for seeding data to the models
        /// </summary>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Psychology & Mind" },
                new Category { Id = 2, Title = "History" },
                new Category { Id = 3, Title = "Romance" },
                new Category { Id = 4, Title = "Crime, Thriller & Mystery" },
                new Category { Id = 5, Title = "Action & Adventure" }
            );
        }
    }
}
