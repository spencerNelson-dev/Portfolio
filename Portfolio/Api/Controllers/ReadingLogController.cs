using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public JsonResult GetReadingLogs(bool finished)
        {
            var readingLogs = _context.ReadingLogs.Include(rl => rl.Book).ToList();

            if(finished)
            {
                readingLogs = readingLogs.Where<ReadingLog>(rl => rl.Status == "Finished").ToList();
            }

            return new JsonResult(readingLogs);
        }

        [HttpPost]
        public IActionResult PostReadingLogs(ReadingLog readingLog)
        {

            _context.ReadingLogs.Add(readingLog);
            _context.SaveChanges();


            return Ok();
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
