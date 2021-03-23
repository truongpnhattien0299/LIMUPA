using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TruongPhamNhatTien_3117410256.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public Product Product { get; set;}
        public int IdProduct { get; set; }
        public string Image { get; set; }
    }
}