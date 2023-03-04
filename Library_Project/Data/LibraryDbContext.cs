using Library_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Project.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
