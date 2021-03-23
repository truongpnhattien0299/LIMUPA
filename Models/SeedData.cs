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
                // Look for any thing.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Name = "Truong Tien",
                        Username = "admin",
                        Password = "admin"
                    }
                );
                context.SaveChanges();

                context.Products.AddRange(
                    new Product
                    {
                        Title = "Iphone 11 pro",
                        Image = "https://res.cloudinary.com/summonersrift/image/upload/v1616489223/Picture/iPhone_11_Pro_Max_256GB_d19ax9.jpg",
                        Price = 999,
                        Sale = 799,
                        Quantity = 1000,
                        Description = "abc xyz 123"
                    }
                );
                context.SaveChanges();
                
                context.Pictures.AddRange(
                    new Picture
                    {
                        IdProduct = 1,
                        Image = "https://res.cloudinary.com/summonersrift/image/upload/v1616489721/Picture/iPhone_11_Pro_Max_64GB_yrrmiz.jpg",
                    },
                    new Picture
                    {
                        IdProduct = 1,
                        Image = "https://res.cloudinary.com/summonersrift/image/upload/v1616489733/Picture/iPhone_11_Pro_Max_512GB_u9udnt.jpg",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}