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
        private PortfolioContext _context;

        public ReadingLogController(PortfolioContext portfolioContext)
        {
            _context = portfolioContext;
        }

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

        [HttpGet("{id}")]
        public IActionResult GetReadingLogById(int id)
        {
            var readingLog = _context.ReadingLogs.Where(rl => rl.Id == id).Include(rl => rl.Book);

            if(readingLog != null)
            {
                return new JsonResult(readingLog);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public IActionResult PostReadingLogs(ReadingLog readingLog)
        {

            _context.ReadingLogs.Add(readingLog);
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut]

        public IActionResult UpdateReadingLog(ReadingLog readingLog)
        {
            var currentReadingLog = _context.ReadingLogs.Find(readingLog.Id);

            if(currentReadingLog == null)
            {
                return NotFound();
            }

            //readingLog.

            _context.SaveChanges();

            return Ok();
        }





    }
}
