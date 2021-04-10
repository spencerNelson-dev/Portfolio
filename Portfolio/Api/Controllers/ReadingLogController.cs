using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Shared.Projects.ReadingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ReadingLogController : ControllerBase
    {
        private static PortfolioContext _context = new PortfolioContext();

        #region ReadingLog Methods

        [HttpGet]
        public JsonResult GetReadingLogs()
        {
            Book book = new() { Id = 2, Title = "Book Log", Author = "Spencer", Description = "This book is part of a log" };

            Note note = new() { Id = 1, Title = "Test Note Title", Body = "Test Note Body" };

            List<Note> notes = new() { note };

            ReadingLog rLog = new ReadingLog { Id = 1, BookId = 1, StartDate = DateTime.Now, Notes = notes };

            return new JsonResult(rLog);
        }

        #endregion

        #region Book Methods

        [HttpGet]
        [Route("book")]
        public JsonResult GetBookByTitle(bool startsWith, string title, string author)
        {
            // handle nulls
            title = title == null ? "" : title;
            author = author == null ? "" : author;

            List<Book> books = _context.Books.ToList();

            IEnumerable<Book> searchResult = new List<Book>();

            if(startsWith)
            {
                searchResult = books.Where<Book>(b => b.Title.StartsWith(title, StringComparison.OrdinalIgnoreCase))
                                        .Where<Book>(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                searchResult = books.Where<Book>(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                                        .Where<Book>(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            }


            return new JsonResult(searchResult);
        }

        [HttpPost]
        [Route("book")]
        public IActionResult AddBook(Book book)
        {
            // check validity of data
            if(string.IsNullOrWhiteSpace(book.Author) || string.IsNullOrWhiteSpace(book.Title))
            {
                return BadRequest("Title and Author must be provided");
            }

            // check if book already exists
            var sameBook = _context.Books.Where<Book>(b => b.Author == book.Author && b.Title == book.Title).FirstOrDefault();
            if(sameBook != null)
            {
                return BadRequest("This book already exists in the database");
            }

            // save it in the database
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest("Failed to save book into the database");
            }

            return Ok();
        }

        #endregion

        #region Notes Methos

        #endregion





    }
}
