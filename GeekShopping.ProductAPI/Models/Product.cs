﻿using GeekShopping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Column("price")]
        [Range(1, 10000)]
        public int Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
