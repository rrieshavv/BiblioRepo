using BiblioRepo.Web.Data;
using BiblioRepo.Web.Models;
using BiblioRepo.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioRepo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;

        public CategoryController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await db.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                var status = await db.Categories.FirstOrDefaultAsync(c => c.Title == obj.Title);

                if (status is not null)
                {
                    //category already present
                    TempData["error"] = "Category already exists.";
                    return RedirectToAction("Create", "Category");
                }

                var category = new Category
                {
                    Title = obj.Title
                };

                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int Id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Category obj)
        {
            var category = await db.Categories.FindAsync(obj.Id);

            if (category is not null)
            {
                var existingCategory = await db.Categories.FirstOrDefaultAsync(c => c.Title.Equals(obj.Title));
                if (existingCategory is not null)
                {
                    TempData["error"] = "Category already exists.";
                    return View(existingCategory);
                }
                category.Title = obj.Title;
                await db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category is not null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index", "Category");
            }
            TempData["error"] = "Category not found. Couldnot Delete.";
            return RedirectToAction("Index", "Category");
        }

    }
}
