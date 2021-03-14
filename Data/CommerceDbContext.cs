using Microsoft.EntityFrameworkCore;
using TruongPhamNhatTien_3117410256.Models;

namespace TruongPhamNhatTien_3117410256.Data
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext (DbContextOptions<CommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}