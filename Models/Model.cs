namespace EShoper.FPT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=EShoper")
        {
        }

        public virtual DbSet<eshoper_category> eshoper_category { get; set; }
        public virtual DbSet<eshoper_product> eshoper_product { get; set; }
        public virtual DbSet<eshoper_rates> eshoper_rates { get; set; }
        public virtual DbSet<eshoper_users> eshoper_users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eshoper_category>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_category>()
                .HasMany(e => e.eshoper_product)
                .WithRequired(e => e.eshoper_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eshoper_product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_product>()
                .Property(e => e.manufactory)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_product>()
                .Property(e => e.condition)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_product>()
                .HasMany(e => e.eshoper_rates)
                .WithRequired(e => e.eshoper_product)
                .HasForeignKey(e => e.rate_productID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.userPwd)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.user_phone)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.user_Add1)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.user_Add2)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .Property(e => e.user_City)
                .IsUnicode(false);

            modelBuilder.Entity<eshoper_users>()
                .HasMany(e => e.eshoper_rates)
                .WithRequired(e => e.eshoper_users)
                .HasForeignKey(e => e.rate_userID)
                .WillCascadeOnDelete(false);
        }
    }
}
