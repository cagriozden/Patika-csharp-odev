using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patika_week1_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private static List<Patika_week1_Book.Entities.Book> BookList = new List<Patika_week1_Book.Entities.Book>()
        {
            new Patika_week1_Book.Entities.Book()
            {
                Id = 1,
                Title = "x",
                GenreId = 1,
                PageCount = 223,
                PublishDate = new DateTime(1997,01,01)
            },

            new Patika_week1_Book.Entities.Book()
            {
                Id = 2,
                Title = "Da Vinci Şifresi",
                GenreId = 2,
                PageCount = 689,
                PublishDate = new DateTime(2003,02,02)
            },

             new Patika_week1_Book.Entities.Book()
            {
                Id = 3,
                Title = "Oniki Levha",
                GenreId = 3,
                PageCount = 509,
                PublishDate = new DateTime(2009,03,03)
            },

             new Patika_week1_Book.Entities.Book()
            {
                Id = 4,
                Title = "Şeker Portakalı",
                GenreId = 4,
                PageCount = 189,
                PublishDate = new DateTime(1968,04,04)
            },

        };

        [HttpGet]
        [Route("GetAll")]
        public List<Patika_week1_Book.Entities.Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Patika_week1_Book.Entities.Book>();

            return bookList;
        }

        [HttpGet]
        [Route("GetById")]
        public Patika_week1_Book.Entities.Book GetById([FromQuery] int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();

            return book;
        }


        [HttpPost]
        [Route("BookCreate")]
        public IActionResult AddBook([FromBody] Patika_week1_Book.Entities.Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();
            BookList.Add(newBook);

            return Ok();

        }

        [HttpPut]
        [Route("BookUpdate")]
        public IActionResult UpdateBook(int id, [FromBody] Patika_week1_Book.Entities.Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;

            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;

            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            return Ok();

        }


        [HttpDelete]
        [Route("BookDelete")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book is null)
                return BadRequest();

            BookList.Remove(book);

            return Ok();
        }
    }
}
