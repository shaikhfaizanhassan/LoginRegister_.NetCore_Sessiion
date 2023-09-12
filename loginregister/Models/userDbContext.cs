using Microsoft.EntityFrameworkCore;

namespace loginregister.Models
{
    public class userDbContext : DbContext
    {
        public userDbContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<usertb> usertbs { get; set; }
    }
}
