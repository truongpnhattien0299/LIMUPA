using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TruongPhamNhatTien_3117410256.Data;
using System;
using System.Linq;

namespace TruongPhamNhatTien_3117410256.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CommerceDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CommerceDbContext>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Name = "Truong Tien",
                        Username = "admin",
                        Password = "admin"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}