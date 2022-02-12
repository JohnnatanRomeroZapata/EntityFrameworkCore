using EFCoreDataAccess.Data;
using EFCoreModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EFCoreProjectDbContext _efCoreProjectDbContext;

        public CategoryController(EFCoreProjectDbContext efCoreProjectDbContext)
        {
            _efCoreProjectDbContext = efCoreProjectDbContext;
        }

        [HttpGet]
        public IActionResult IndexCategory()
        {
            IEnumerable<Category> categories = _efCoreProjectDbContext.Categories;

            return View(categories);
        }
        
        [HttpGet]
        public IActionResult CreateUpdateCategory(int? id)
        {
            Category category = new Category();

            if(id == null)
            {
                return View(category);
            }
            else
            {
                category = _efCoreProjectDbContext.Categories.FirstOrDefault(c => c.Id == id);

                if(category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if(category.Id == 0)
            {
                _efCoreProjectDbContext.Categories.Add(category);                
            }
            else
            {
                _efCoreProjectDbContext.Categories.Update(category);
            }

            _efCoreProjectDbContext.SaveChanges();
            return RedirectToAction(nameof(IndexCategory));
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            if(id != 0)
            {
                Category category = _efCoreProjectDbContext.Categories.FirstOrDefault(c => c.Id == id);

                if(category == null)
                {
                    return RedirectToAction(nameof(IndexCategory));
                }

                _efCoreProjectDbContext.Categories.Remove(category);
                _efCoreProjectDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(IndexCategory));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> listOfCategories = new List<Category>();

            for (int i = 1; i <= 2; i++)
            {
                var random = new Random();
                int randomNumber = random.Next(100);

                listOfCategories.Add(new Category {
                    Name = $"Category{randomNumber}"
                });
            }

            _efCoreProjectDbContext.Categories.AddRange(listOfCategories);
            _efCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexCategory));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> listOfCategories = new List<Category>();

            for (int i = 1; i <= 5; i++)
            {
                var random = new Random();
                int randomNumber = random.Next(100);

                listOfCategories.Add(new Category
                {
                    Name = $"Category{randomNumber}"
                });
            }

            _efCoreProjectDbContext.Categories.AddRange(listOfCategories);
            _efCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexCategory));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> listOfCategories = _efCoreProjectDbContext.Categories.OrderByDescending(c => c.Id).Take(2);
        
            _efCoreProjectDbContext.Categories.RemoveRange(listOfCategories);
            _efCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexCategory));
        }

        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> listOfCategories = _efCoreProjectDbContext.Categories.OrderByDescending(c => c.Id).Take(5);

            _efCoreProjectDbContext.Categories.RemoveRange(listOfCategories);
            _efCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexCategory));
        }
    }
}
