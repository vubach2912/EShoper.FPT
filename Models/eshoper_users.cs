namespace EShoper.FPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class eshoper_users
    {
        public eshoper_users()
        {
            eshoper_rates = new HashSet<eshoper_rates>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userPwd { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(12)]
        public string user_phone { get; set; }

        [StringLength(50)]
        public string user_Add1 { get; set; }

        [StringLength(50)]
        public string user_Add2 { get; set; }

        [StringLength(50)]
        public string user_City { get; set; }

        public virtual ICollection<eshoper_rates> eshoper_rates { get; set; }
    }
}
