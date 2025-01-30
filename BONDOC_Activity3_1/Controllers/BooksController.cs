using System.Diagnostics;
using BONDOC_Activity3_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BONDOC_Activity3_1.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Kang Kong Chips Original", Author = "Josh Mojica", Price = 1000, PublicationYear = 2023 },
            new Book { Id = 2, Title = "Ginulat Ang Mondu", Author = "Kai Sotto", Price = 850, PublicationYear = 2050 }
        };
        
        private static int nextId = 3;
        
        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Book book = null;
            foreach (var b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == book.Id)
                {
                    books[i].Title = book.Title;
                    books[i].Author = book.Author;
                    books[i].Price = book.Price;
                    books[i].PublicationYear = book.PublicationYear;
                    break;
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    books.RemoveAt(i);
                    break;
                }
            }

            return RedirectToAction("Index");
        }
    }
}

