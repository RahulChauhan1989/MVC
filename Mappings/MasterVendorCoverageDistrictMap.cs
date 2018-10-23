using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterVendorCoverageDistrictMap : EntityTypeConfiguration<MasterVendorCoverageDistrict>
    {
        public MasterVendorCoverageDistrictMap()
        {
            this.HasKey(ct => ct.VCDistrictRowID);
            this.Property(ct => ct.VCDistrictRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(ct => ct.MasterVendorCoverage).WithMany().HasForeignKey(ct => ct.VendorCoverageRowID).WillCascadeOnDelete(false);
            this.HasRequired(ct => ct.MasterDistrict).WithMany().HasForeignKey(ct => ct.DistrictRowID).WillCascadeOnDelete(false);

        }
    }
}
