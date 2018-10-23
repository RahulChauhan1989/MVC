using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQClientPackageMap : EntityTypeConfiguration<PQClientPackage>
    {
        public PQClientPackageMap()
        {
            this.HasKey(p => p.ClientPackageRowID);
            this.Property(p => p.ClientPackageRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ClientPackageName).HasMaxLength(100).IsRequired();
            this.Property(p => p.TAT).IsRequired();
            this.Property(p => p.InternalTAT).IsRequired();
            this.Property(p => p.BillingPerCheck).IsRequired();
            this.Property(p => p.ReportSequence).IsRequired();

            this.HasRequired(p => p.PQClientMaster).WithMany().HasForeignKey(p => p.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterCheckFamily).WithMany().HasForeignKey(p => p.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterSubCheckFamily).WithMany().HasForeignKey(p => p.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
