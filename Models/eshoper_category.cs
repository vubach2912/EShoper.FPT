namespace EShoper.FPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eshoper_category
    {
        public eshoper_category()
        {
            eshoper_product = new HashSet<eshoper_product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categoryID { get; set; }

        public int? categoryImgID { get; set; }

        [Required]
        [StringLength(20)]
        public string categoryName { get; set; }

        public virtual ICollection<eshoper_product> eshoper_product { get; set; }
    }
}
