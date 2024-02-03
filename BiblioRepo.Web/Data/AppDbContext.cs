using BiblioRepo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiblioRepo.Web.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } 

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

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "The Power of Habit", Author = "Charles Duhigg", ISBN = "9780812981605", Quantity = 50, Price = 1199.99, DiscountRate = 0.1F, DiscountedPrice = 1079.99, Description = "A fascinating book that explores the science behind habit formation and how it can be transformed to improve individual and organizational lives.", CategoryId = 1 },
                new Product { Id = 2, Name = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518", Quantity = 30, Price = 699.99, DiscountRate = 0.05F, DiscountedPrice = 664.99, Description = "A classic romantic novel that follows the tumultuous relationship between Elizabeth Bennet and Mr. Darcy.", CategoryId = 3 },
                new Product { Id = 3, Name = "The Da Vinci Code", Author = "Dan Brown", ISBN = "9780307474278", Quantity = 40, Price = 899.99, DiscountRate = 0.15F, DiscountedPrice = 764.99, Description = "A gripping mystery thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre and uncovers a conspiracy.", CategoryId = 4 },
                new Product { Id = 4, Name = "The Hunger Games", Author = "Suzanne Collins", ISBN = "9780439023481", Quantity = 25, Price = 599.99, DiscountRate = 0.1F, DiscountedPrice = 539.99, Description = "Set in a dystopian future, this action-packed novel follows Katniss Everdeen as she fights for survival in a televised death match.", CategoryId = 5 },
                new Product { Id = 5, Name = "Dune", Author = "Frank Herbert", ISBN = "9780441013593", Quantity = 20, Price = 799.99, DiscountRate = 0.2F, DiscountedPrice = 639.99, Description = "A science fiction masterpiece set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice.", CategoryId = 6 },
                new Product { Id = 6, Name = "The Shining", Author = "Stephen King", ISBN = "9780307743657", Quantity = 35, Price = 499.99, DiscountRate = 0.1F, DiscountedPrice = 449.99, Description = "A chilling horror novel that follows Jack Torrance as he becomes the winter caretaker of the Overlook Hotel and descends into madness.", CategoryId = 8 },
                new Product { Id = 7, Name = "Milk and Honey", Author = "Rupi Kaur", ISBN = "9781449474256", Quantity = 45, Price = 1249.99, DiscountRate = 0.1F, DiscountedPrice = 1124.99, Description = "A collection of poetry and prose about survival, love, and the healing power of femininity.", CategoryId = 9 }
            );

        }
    }
}
