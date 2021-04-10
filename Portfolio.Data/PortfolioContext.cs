using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Shared.Projects.ReadingLog;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<ReadingLog> ReadingLogs { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=Portfolio");
        }
    }
}
