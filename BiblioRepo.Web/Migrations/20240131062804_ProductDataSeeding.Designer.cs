﻿// <auto-generated />
using BiblioRepo.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiblioRepo.Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240131062804_ProductDataSeeding")]
    partial class ProductDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BiblioRepo.Web.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Psychology & Mind"
                        },
                        new
                        {
                            Id = 2,
                            Title = "History"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Romance"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Crime, Thriller & Mystery"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Action & Adventure"
                        });
                });

            modelBuilder.Entity("BiblioRepo.Web.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("DiscountRate")
                        .HasColumnType("float");

                    b.Property<double>("DiscountedPrice")
                        .HasColumnType("double");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Charles Duhigg",
                            CategoryId = 1,
                            Description = "A fascinating book that explores the science behind habit formation and how it can be transformed to improve individual and organizational lives.",
                            DiscountRate = 0.1f,
                            DiscountedPrice = 1079.99,
                            ISBN = "9780812981605",
                            Name = "The Power of Habit",
                            Price = 1199.99,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jane Austen",
                            CategoryId = 3,
                            Description = "A classic romantic novel that follows the tumultuous relationship between Elizabeth Bennet and Mr. Darcy.",
                            DiscountRate = 0.05f,
                            DiscountedPrice = 664.99000000000001,
                            ISBN = "9780141439518",
                            Name = "Pride and Prejudice",
                            Price = 699.99000000000001,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 3,
                            Author = "Dan Brown",
                            CategoryId = 4,
                            Description = "A gripping mystery thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre and uncovers a conspiracy.",
                            DiscountRate = 0.15f,
                            DiscountedPrice = 764.99000000000001,
                            ISBN = "9780307474278",
                            Name = "The Da Vinci Code",
                            Price = 899.99000000000001,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 4,
                            Author = "Suzanne Collins",
                            CategoryId = 5,
                            Description = "Set in a dystopian future, this action-packed novel follows Katniss Everdeen as she fights for survival in a televised death match.",
                            DiscountRate = 0.1f,
                            DiscountedPrice = 539.99000000000001,
                            ISBN = "9780439023481",
                            Name = "The Hunger Games",
                            Price = 599.99000000000001,
                            Quantity = 25
                        },
                        new
                        {
                            Id = 5,
                            Author = "Frank Herbert",
                            CategoryId = 6,
                            Description = "A science fiction masterpiece set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice.",
                            DiscountRate = 0.2f,
                            DiscountedPrice = 639.99000000000001,
                            ISBN = "9780441013593",
                            Name = "Dune",
                            Price = 799.99000000000001,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 6,
                            Author = "Stephen King",
                            CategoryId = 8,
                            Description = "A chilling horror novel that follows Jack Torrance as he becomes the winter caretaker of the Overlook Hotel and descends into madness.",
                            DiscountRate = 0.1f,
                            DiscountedPrice = 449.99000000000001,
                            ISBN = "9780307743657",
                            Name = "The Shining",
                            Price = 499.99000000000001,
                            Quantity = 35
                        },
                        new
                        {
                            Id = 7,
                            Author = "Rupi Kaur",
                            CategoryId = 9,
                            Description = "A collection of poetry and prose about survival, love, and the healing power of femininity.",
                            DiscountRate = 0.1f,
                            DiscountedPrice = 1124.99,
                            ISBN = "9781449474256",
                            Name = "Milk and Honey",
                            Price = 1249.99,
                            Quantity = 45
                        });
                });

            modelBuilder.Entity("BiblioRepo.Web.Models.Product", b =>
                {
                    b.HasOne("BiblioRepo.Web.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
