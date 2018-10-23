using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterStateMap : EntityTypeConfiguration<MasterState>
    {
        public MasterStateMap()
        {
            this.HasKey(s => s.StateRowID);
            this.Property(s => s.StateRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.StateName).HasMaxLength(100).IsRequired();

            this.HasRequired(s => s.MasterCountry).WithMany().HasForeignKey(s => s.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
