using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterLocationMap : EntityTypeConfiguration<MasterLocation>
    {
        public MasterLocationMap()
        {
            this.HasKey  (l => l.LocationRowID);
            this.Property(l => l.LocationRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(l => l.LocationName).HasMaxLength(100).IsRequired();
            this.Property(l => l.PinCode);
                        
            this.HasRequired(l => l.MasterDistrict).WithMany().HasForeignKey(l => l.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(l => l.MasterState).WithMany().HasForeignKey(l => l.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(l => l.MasterCountry).WithMany().HasForeignKey(l => l.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
