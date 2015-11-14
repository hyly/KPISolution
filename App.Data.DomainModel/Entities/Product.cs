using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.DomainModel.Entities
{
    [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName="nvarchar")]
        public string Name { get; set; }
        public bool Active { get; set; }
        [Column(TypeName="money")]
        public decimal Price { get; set; }
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Color { get; set; }
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }
    }
}
