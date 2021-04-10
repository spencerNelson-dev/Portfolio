using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Shared.ProjectIdeas;
using Portfolio.Shared.Projects.ReadingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private static PortfolioContext _context = new PortfolioContext();

        [HttpGet]
        public JsonResult Get()
        {
            ProjectIdea idea = new ProjectIdea
            {
                ProjectIdeaId = 1,
                Title = "My First Idea",
                Description = "Create a project idea tracker",
                Status = ProjectStatus.New
            };
            return new JsonResult(idea);
        }

        [HttpGet]
        [Route("book")]
        public JsonResult GetBookByTitle(string title, string author)
        {
            // handle nulls
            title = title == null ? "" : title;
            author = author == null ? "" : author;

            List<Book> books = _context.Books.ToList();

            var searchResult = books.Where<Book>(b => b.Title.StartsWith(title, StringComparison.OrdinalIgnoreCase))
                                    .Where<Book>(b => b.Author.StartsWith(author, StringComparison.OrdinalIgnoreCase));

            return new JsonResult(searchResult);
        }

        [HttpPost]
        [Route("book")]
        public StatusCodeResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [RouteAttribute("readinglog")]
        public JsonResult GetReadingLogs()
        {
            Book book = new() { Id = 2, Title = "Book Log", Author = "Spencer", Description = "This book is part of a log" };

            Note note = new() { Id = 1, Title = "Test Note Title", Body = "Test Note Body" };

            List<Note> notes = new() { note };

            ReadingLog rLog = new ReadingLog { Id = 1, BookId = 1, StartDate = DateTime.Now, Notes = notes };

            return new JsonResult(rLog);
        }
    }
}
