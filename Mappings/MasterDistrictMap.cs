using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterDistrictMap : EntityTypeConfiguration<MasterDistrict>
    {
        public MasterDistrictMap()
        {
            this.HasKey(d => d.DistrictRowID);
            this.Property(d => d.DistrictRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.DistrictName).HasMaxLength(100).IsRequired();

            this.HasRequired(d => d.MasterState).WithMany().HasForeignKey(d => d.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.MasterCountry).WithMany().HasForeignKey(d => d.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
