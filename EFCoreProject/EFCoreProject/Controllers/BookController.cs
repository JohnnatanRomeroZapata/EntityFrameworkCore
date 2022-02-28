using EFCoreDataAccess.Data;
using EFCoreModels.Models;
using EFCoreModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<Book> books = _eFCoreProjectDbContext.Books.Include(b => b.Publisher)
                                                                    .Include(b => b.Authors);

            return View(books);
        }

        [HttpGet]
        public IActionResult CreateUpdateBook(int? id)
        {
            BookVM bookVM = new BookVM();

            bookVM.PublisherList = _eFCoreProjectDbContext.Publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            if (id == null)
            {
                return View(bookVM);
            }
            else
            {
                bookVM.Book = _eFCoreProjectDbContext.Books.FirstOrDefault(b => b.Id == id);

                if (bookVM == null)
                {
                    return RedirectToAction(nameof(IndexBook));
                }

                return View(bookVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdateBook(BookVM bookVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(bookVM);
            //}

            if (bookVM.Book.Id == 0)
            {
                _eFCoreProjectDbContext.Books.Add(bookVM.Book);
            }
            else
            {
                _eFCoreProjectDbContext.Books.Update(bookVM.Book);
            }

            _eFCoreProjectDbContext.SaveChanges();

            return RedirectToAction(nameof(IndexBook));
        }

        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            if(id != 0)
            {
                Book book = _eFCoreProjectDbContext.Books.FirstOrDefault(b => b.Id == id);

                if(book == null)
                {
                    return RedirectToAction(nameof(IndexBook));
                }

                _eFCoreProjectDbContext.Books.Remove(book);

                _eFCoreProjectDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(IndexBook));
        }

        [HttpGet]
        public IActionResult CreateUpdateBookDetails(int? id)
        {
            BookVM bookVM = new BookVM();

            if (id == null || id == 0)
            {
                return RedirectToAction(nameof(IndexBook));
            }

            bookVM.Book = _eFCoreProjectDbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Id == id);
       
            if(bookVM.Book == null)
            {
                return RedirectToAction(nameof(IndexBook));
            }

            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdateBookDetails(BookVM bookVM)
        {
            //if (!ModelState.IsValid)
            //{ 
            //    return View(bookVM);
            //}

            if (bookVM.Book.BookDetail.Id == 0)
            {
                _eFCoreProjectDbContext.BookDetails.Add(bookVM.Book.BookDetail);
                _eFCoreProjectDbContext.SaveChanges();

                var bookFromDb = _eFCoreProjectDbContext.Books.FirstOrDefault(b => b.Id == bookVM.Book.Id);
                bookFromDb.BookDetailId = bookVM.Book.BookDetail.Id;

                _eFCoreProjectDbContext.SaveChanges();
            }
            else
            {
                _eFCoreProjectDbContext.BookDetails.Update(bookVM.Book.BookDetail);
                _eFCoreProjectDbContext.SaveChanges();

            }

            return RedirectToAction(nameof(IndexBook));
        }

        public IActionResult PlayGround()
        {
            var bookTemp = _eFCoreProjectDbContext.Books.FirstOrDefault();
            bookTemp.Price = 100;

            //---

            var bookCollection = _eFCoreProjectDbContext.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            //---

            var bookList = _eFCoreProjectDbContext.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            //---

            var bookCollection2 = _eFCoreProjectDbContext.Books;
            var bookCount1 = bookCollection2.Count();

            //---

            var bookCount2 = _eFCoreProjectDbContext.Books.Count();

            //---

            IEnumerable<Book> BookList1 = _eFCoreProjectDbContext.Books;
            var FilteredBook1 = BookList1.Where(b => b.Price > 500).ToList();

            IQueryable<Book> BookList2 = _eFCoreProjectDbContext.Books;
            var FilteredBook2 = BookList2.Where(b => b.Price > 500).ToList();


            return RedirectToAction(nameof(IndexBook));
        }

        [HttpGet]
        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM bookAuthorVM = new BookAuthorVM();

            bookAuthorVM.Book = _eFCoreProjectDbContext.Books.Include(a => a.Authors).FirstOrDefault(b => b.Id == id);

            List<int> assignedAuthors = bookAuthorVM.Book.Authors.Select(a => a.Id).ToList();

            var noAssignedAuthors = _eFCoreProjectDbContext.Authors.Where(a => !assignedAuthors.Contains(a.Id)).ToList();

            bookAuthorVM.AuthorList = noAssignedAuthors.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString(),
            });

            return View(bookAuthorVM);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if(bookAuthorVM.Book.Id != 0 && bookAuthorVM.Author.Id != 0)
            {
                var book = _eFCoreProjectDbContext.Books.Include(a => a.Authors).FirstOrDefault(b => b.Id == bookAuthorVM.Book.Id);
                var author = _eFCoreProjectDbContext.Authors.FirstOrDefault(a => a.Id == bookAuthorVM.Author.Id);

                book.Authors.Add(author);
                _eFCoreProjectDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(ManageAuthors) , new { @id = bookAuthorVM.Book.Id});
        }

        [HttpPost]
        public IActionResult DeleteReferencedAuthor(int authorId, BookAuthorVM bookAuthorVM)
        {
            if (bookAuthorVM.Book.Id != 0 && authorId != 0)
            {
                var book = _eFCoreProjectDbContext.Books.Include(a => a.Authors).FirstOrDefault(b => b.Id == bookAuthorVM.Book.Id);
                var author = _eFCoreProjectDbContext.Authors.FirstOrDefault(a => a.Id == authorId);

                book.Authors.Remove(author);
                _eFCoreProjectDbContext.SaveChanges();
            }
                
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.Book.Id });
        }
    }
}
