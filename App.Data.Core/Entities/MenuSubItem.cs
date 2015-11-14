namespace App.Data.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuSubItem")]
    public partial class MenuSubItem
    {
        [Key]
        public int SubMenuId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string NamTranslationKey { get; set; }

        public int MenuId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}
