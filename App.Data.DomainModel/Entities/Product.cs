using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace App.Data.DomainModel.Entities
{
    [DataContract]
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.Deleted = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        [DataMember(Name="id")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName="nvarchar")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }

        [Column(TypeName="money")]
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [DataMember(Name = "color")]
        public string Color { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [StringLength(400)]
        [Column(TypeName = "nvarchar")]
        [DataMember(Name = "metaKeyWords")]
        public string MetaKeywords { get; set; }

        [StringLength(400)]
        [Column(TypeName = "nvarchar")]
        [DataMember(Name = "metaDescription")]
        public string MetaDescription { get; set; }

        [StringLength(400)]
        [Column(TypeName = "nvarchar")]
        [DataMember(Name = "metaTitle")]
        public string MetaTitle { get; set; }

        [DataMember(Name = "displayOrder")]
        public int? DisplayOrder { get; set; }

        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        [StringLength(400)]
        [DataMember(Name = "imagePath")]
        public string ImagePath { get; set; }
    }
}
