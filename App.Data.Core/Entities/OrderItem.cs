namespace App.Data.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        public int OrderItemID { get; set; }

        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public int OrderQty { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPriceDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal LineTotal { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
