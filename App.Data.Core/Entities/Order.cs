namespace App.Data.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            DiscountUsageHistories = new HashSet<DiscountUsageHistory>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }

        public int OrderStatus { get; set; }

        public bool OnlineOrderFlag { get; set; }

        [Column(TypeName = "money")]
        public decimal OrderTotal { get; set; }

        public int? CustomerId { get; set; }

        public int? BillingAddressId { get; set; }

        public int? ShippingAddressId { get; set; }

        public decimal? OrderShipping { get; set; }

        public decimal? OrderDiscount { get; set; }

        public decimal? RefundedAmount { get; set; }

        public string CustomerIp { get; set; }

        public string ShippingMethod { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal OrderSubTotal { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountUsageHistory> DiscountUsageHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
