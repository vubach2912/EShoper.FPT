namespace EShoper.FPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eshoper_rates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rate_id { get; set; }

        public int rate_productID { get; set; }

        public int rate_number { get; set; }

        public int rate_userID { get; set; }

        public virtual eshoper_product eshoper_product { get; set; }

        public virtual eshoper_users eshoper_users { get; set; }
    }
}
