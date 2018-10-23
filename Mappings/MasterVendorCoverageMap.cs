using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterVendorCoverageMap : EntityTypeConfiguration<MasterVendorCoverage>
    {
        public MasterVendorCoverageMap()
        {
            this.HasKey(ct => ct.VendorCoverageRowID);
            this.Property(ct => ct.VendorCoverageRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(ct => ct.Remarks).HasMaxLength(300);

            this.HasRequired(ct => ct.MasterVendor).WithMany().HasForeignKey(ct => ct.VendorRowID).WillCascadeOnDelete(false);
            this.HasRequired(ct => ct.MasterCheckFamily).WithMany().HasForeignKey(ct => ct.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(ct => ct.MasterState).WithMany().HasForeignKey(ct => ct.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(ct => ct.MasterCountry).WithMany().HasForeignKey(ct => ct.CountryRowID).WillCascadeOnDelete(false);

        }
    }
}
