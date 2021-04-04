using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.ProjectIdeas
{
    public class ProjectIdea
    {
        public int ProjectIdeaId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }
    }

    public enum ProjectStatus
    { 
        New,
        Planning,
        Implementing,
        Finished,
        Abandoned

    }

}
