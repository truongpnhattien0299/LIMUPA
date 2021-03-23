using Microsoft.EntityFrameworkCore;
using TruongPhamNhatTien_3117410256.Models;

namespace TruongPhamNhatTien_3117410256.Data
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}