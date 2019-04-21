namespace ioasysWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnterpriseModel : DbContext
    {
        public EnterpriseModel()
            : base("name=EnterpriseModel")
        {
        }

        public virtual DbSet<EnterpriseTypeV1> enterprise_types { get; set; }
        public virtual DbSet<EnterpriseV1> enterprises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
