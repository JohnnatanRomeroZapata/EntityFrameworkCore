using EFCoreDataAccess.Data;
using EFCoreModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Controllers
{
    public class PublisherController : Controller
    {
        private readonly EFCoreProjectDbContext _eFCoreProjectDbContext;

        public PublisherController(EFCoreProjectDbContext eFCoreProjectDbContext)
        {
            _eFCoreProjectDbContext = eFCoreProjectDbContext;
        }

        [HttpGet]
        public IActionResult IndexPublisher()
        {
            IEnumerable<Publisher> publishers = _eFCoreProjectDbContext.Publishers;

            return View(publishers);
        }

        [HttpGet]
        public IActionResult CreateUpdatePublisher(int? id)
        {
            Publisher publisher = new Publisher();

            if(id == null)
            {
                return View(publisher);
            }
            else
            {
                publisher = _eFCoreProjectDbContext.Publishers.FirstOrDefault(p => p.Id == id);

                if(publisher == null)
                {
                    return NotFound();
                }

                return View(publisher);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdatePublisher(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            if(publisher.Id == 0)
            {
                _eFCoreProjectDbContext.Publishers.Add(publisher);
            }
            else
            {
                _eFCoreProjectDbContext.Publishers.Update(publisher);
            }

            _eFCoreProjectDbContext.SaveChanges();
            return RedirectToAction(nameof(IndexPublisher));
        }

        [HttpGet]
        public IActionResult DeletePublisher(int id)
        {
            if (id != 0)
            {
                Publisher publisher = _eFCoreProjectDbContext.Publishers.FirstOrDefault(p => p.Id == id);

                if(publisher == null)
                {
                    return RedirectToAction(nameof(IndexPublisher));
                }

                _eFCoreProjectDbContext.Publishers.Remove(publisher);

                _eFCoreProjectDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(IndexPublisher));
        }
    }
}
