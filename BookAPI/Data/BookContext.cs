using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public BookContext(DbContextOptions<BookContext> option) : base(option)
        {
        }

        #region
        public DbSet<Book>? Books { get; set; }

        #endregion
    }
}
