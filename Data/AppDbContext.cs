using csapi.Models;
using Microsoft.EntityFrameworkCore;

namespace csapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}