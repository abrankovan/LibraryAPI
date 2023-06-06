using StudentApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.DbContexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
    }
}
