using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientCheckMap : EntityTypeConfiguration<PQClientCheck>
    {
        public PQClientCheckMap()
        {
            this.HasKey  (c => c.ClientCheckRowID);
            this.Property(c => c.ClientCheckRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            this.Property(c => c.TAT).IsRequired();
            this.Property(c => c.InternalTAT).IsRequired();
            this.Property(c => c.BillingPerCheck).IsRequired();
            this.Property(c => c.ReportSequence).IsRequired();

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
