using System.Data.Entity;

namespace RequestOnRevision.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet <Application> Applications { get; set; }
        public DbSet <Request> Requests { get; set; }
    }
}