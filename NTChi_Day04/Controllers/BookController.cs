using Microsoft.AspNetCore.Mvc;
using NTChi_Day04.Models;

namespace NTChi_Day04.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            var books = book.GetBookList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var bookDetail = book.GetBookById(id);
            if (bookDetail == null)
            {
                return NotFound();
            }
            return View(bookDetail);
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var bookDetail = book.GetBookById(id);
            if (bookDetail == null)
            {
                return NotFound();
            }
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            return View(bookDetail);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(model);
        }

    }
}
