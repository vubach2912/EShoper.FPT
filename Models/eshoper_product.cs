namespace EShoper.FPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eshoper_product
    {
        public eshoper_product()
        {
            eshoper_rates = new HashSet<eshoper_rates>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int? imgID { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        public int categoryID { get; set; }

        public int quantities { get; set; }

        [Required]
        [StringLength(100)]
        public string manufactory { get; set; }

        [Required]
        [StringLength(10)]
        public string condition { get; set; }

        public float price { get; set; }

        public float rate { get; set; }

        public virtual eshoper_category eshoper_category { get; set; }

        public virtual ICollection<eshoper_rates> eshoper_rates { get; set; }
    }
}
