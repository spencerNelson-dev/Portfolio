using System;
using System.Collections.Generic;

namespace Portfolio.Shared.Projects.ReadingLog
{
    public class ReadingLog
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Status
        {
            get
            {
                return FinishDate == null ? "Reading" : "Finished";
            }
        }
        public IEnumerable<Note> Notes { get; set; }
        public Book Book { get; set; }
    }
}
