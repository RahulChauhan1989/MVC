using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterDegreeTypeMap : EntityTypeConfiguration<MasterDegreeType>
    {
        public MasterDegreeTypeMap()
        {
            this.HasKey(d => d.DegreeRowID);
            this.Property(d => d.DegreeRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.DegreeType).HasMaxLength(100).IsRequired();
        }
    }
}
