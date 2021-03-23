using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace TruongPhamNhatTien_3117410256.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        [ForeignKey("IdProduct")]
        public ICollection<Picture> Pictures { get; set;}
    }
}