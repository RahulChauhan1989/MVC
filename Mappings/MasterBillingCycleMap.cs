using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterBillingCycleMap : EntityTypeConfiguration<MasterBillingCycle>
    {
        public MasterBillingCycleMap()
        {
            this.HasKey(b => b.BillingRowID);
            this.Property(b => b.BillingRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(b => b.BillingCycle).HasMaxLength(100).IsRequired();
        }
    }
}
