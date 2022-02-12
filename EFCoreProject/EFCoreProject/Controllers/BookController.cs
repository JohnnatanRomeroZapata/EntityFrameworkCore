using EFCoreDataAccess.Data;
using EFCoreModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Controllers
{
    public class BookController : Controller
    {
        private readonly EFCoreProjectDbContext _eFCoreProjectDbContext;

        public BookController(EFCoreProjectDbContext eFCoreProjectDbContext)
        {
            _eFCoreProjectDbContext = eFCoreProjectDbContext;
        }

        [HttpGet]
        public IActionResult IndexBook()
        {
            IEnumerable<Book> books = _eFCoreProjectDbContext.Books;

            return View(books);
        }

        [HttpGet]
        public IActionResult CreateUpdateBook(int? id)
        {
            Book book = new Book();

            if(id == null)
            {
                return View(book);
            }
            else
            {
                book = _eFCoreProjectDbContext.Books.FirstOrDefault(b => b.Id == id);

                if(book == null)
                {
                    return RedirectToAction(nameof(IndexBook));
                }

                return View(book);
            }
        }
    }
}
