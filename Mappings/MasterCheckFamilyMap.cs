using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCheckFamilyMap : EntityTypeConfiguration<MasterCheckFamily>
    {
        public MasterCheckFamilyMap()
        {
            this.HasKey(b => b.CheckFamilyRowID);
            this.Property(b => b.CheckFamilyRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(b => b.CheckFamilyName).HasMaxLength(100).IsRequired();
        }
    }
}
