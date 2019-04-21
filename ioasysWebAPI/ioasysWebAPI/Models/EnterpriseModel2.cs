namespace ioasysWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnterpriseModel2 : DbContext
    {
        public EnterpriseModel2()
            : base("name=EnterpriseModel2")
        {
        }

        public virtual DbSet<EnterpriseTypeV1> enterprise_types { get; set; }
        public virtual DbSet<EnterpriseV1> enterprises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<enterprise_types>()
            //    .HasMany(e => e.enterprises)
            //    .WithOptional(e => e.enterprise_types)
            //    .HasForeignKey(e => e.enterprise_type);
        }
    }
}
