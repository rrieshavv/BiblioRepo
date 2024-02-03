using BiblioRepo.Web.Data;
using BiblioRepo.Web.Models;
using BiblioRepo.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BiblioRepo.Web.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var products = await db.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Id == Id);
            if (product is not null)
            {
                var category = await db.Categories.SingleOrDefaultAsync(c => c.Id == product.CategoryId);

                if (category == null)
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
            TempData["error"] = "Product not found!";
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
