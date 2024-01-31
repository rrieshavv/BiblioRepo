using BiblioRepo.Web.Data;
using BiblioRepo.Web.Models;
using BiblioRepo.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BiblioRepo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await db.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Id == Id);
            if(product is not null)
            {
                var category = await db.Categories.SingleOrDefaultAsync(c => c.Id == product.CategoryId);

                if(category == null)
                {
                    return RedirectToAction("Index", "Product");
                }

                var detail = new ProductDetailViewModel
                {
                    Category = category,
                    Product = product
                };
                return View(detail);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await db.Categories.ToListAsync();
            ViewBag.Categories = categories ?? new List<Category>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product obj, IFormFile? file)
        {
            var status = await db.Products.FirstOrDefaultAsync(x => x.Name == obj.Name);
            
            if(status is not null)
            {
                //same product existing 
                return View();
            }

            //image handling
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                //discounted price calculation
                double CalcDiscountedPrice = obj.Price - (obj.Price * obj.DiscountRate / 100);

                var product = new Product
                {
                    Name = obj.Name,
                    Author = obj.Author,
                    ISBN = obj.ISBN,
                    Description = obj.Description,
                    Quantity = obj.Quantity,
                    Price = obj.Price,
                    DiscountRate = obj.DiscountRate,
                    DiscountedPrice = CalcDiscountedPrice,
                    CategoryId = obj.CategoryId,
                    ImageUrl = @"\images\product\" + fileName
                };
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Detail", "Product", new { Id = obj.Id });
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await db.Products.FindAsync(Id);

            if (product is not null)
            {
                var categories = await db.Categories.ToListAsync();
                ViewBag.Categories = categories;

                return View(product);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task <IActionResult> Edit (Product obj, IFormFile? file)
        {

            var product = await db.Products.FindAsync(obj.Id);

            if (product is not null)
            {
                product.Name = obj.Name;
                product.Description = obj.Description;
                product.CategoryId = obj.CategoryId;
                product.ISBN= obj.ISBN;
                product.Price= obj.Price;
                product.Quantity= obj.Quantity;
                product.DiscountRate= obj.DiscountRate;

                double final_price = obj.Price - (obj.Price * obj.DiscountRate / 100);
                product.DiscountedPrice = final_price;

                //image handling
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    product.ImageUrl = @"\images\product\" + fileName;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Detail","Product", new { Id = obj.Id });
            }
            return View(obj);

        }

        [HttpPost]

        public IActionResult Delete(int Id)
        {
            var product = db.Products.Find(Id);

            if (product == null)
            {
                return RedirectToAction("Detail", "Product", new { Id = Id });
            }

            if(product.ImageUrl is not null)
            {
                var oldImagePath =
                           Path.Combine(_webHostEnvironment.WebRootPath,
                           product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            db.Products.Remove(product);
            db.SaveChanges();
            
            return RedirectToAction("Index", "Product");
        }


    }
}
