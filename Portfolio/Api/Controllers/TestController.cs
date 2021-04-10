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

    }
}
