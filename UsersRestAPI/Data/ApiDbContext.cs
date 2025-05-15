using Microsoft.EntityFrameworkCore;
using UsersRestAPI.Models;

namespace UsersRestAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }
    }
}
