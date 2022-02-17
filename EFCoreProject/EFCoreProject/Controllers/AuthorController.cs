using EFCoreDataAccess.Data;
using EFCoreModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly EFCoreProjectDbContext _eFCoreProjectDbContext;

        public AuthorController(EFCoreProjectDbContext eFCoreProjectDbContext)
        {
            _eFCoreProjectDbContext = eFCoreProjectDbContext;
        }

        [HttpGet]
        public IActionResult IndexAuthor()
        {
            IEnumerable<Author> authors = _eFCoreProjectDbContext.Authors;

            return View(authors);
        }

        [HttpGet]
        public IActionResult CreateUpdateAuthor(int? id)
        {
            Author author = new Author();

            if(id == null)
            {
                return View(author);
            }
            else
            {
                author = _eFCoreProjectDbContext.Authors.FirstOrDefault(a => a.Id == id);

                if(author == null)
                {
                    return NotFound();
                }

                return View(author);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdateAuthor(Author author)
        {
            if(!ModelState.IsValid)
            {
                return View(author);
            }

            if(author.Id == 0)
            {
                _eFCoreProjectDbContext.Authors.Add(author);
            }
            else
            {
                _eFCoreProjectDbContext.Authors.Update(author);
            }

            _eFCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexAuthor));
        }

        [HttpGet]
        public IActionResult DeleteAuthor(int id)
        {
            if(id != 0)
            {
                Author author = _eFCoreProjectDbContext.Authors.FirstOrDefault(a => a.Id == id);

                if(author == null)
                {
                    return RedirectToAction(nameof(IndexAuthor));
                }

                _eFCoreProjectDbContext.Authors.Remove(author);

                _eFCoreProjectDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(IndexAuthor));
        }

    }
}
