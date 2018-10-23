using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterSeverityGridMap : EntityTypeConfiguration<MasterSeverityGrid>
    {
        public MasterSeverityGridMap()
        {
            this.HasKey(s => s.SeverityGridRowId);
            this.Property(s => s.SeverityGridRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.SeverityGrid).HasMaxLength(50).IsRequired();
            this.Property(s => s.ColorName).HasMaxLength(30);
            this.Property(s => s.ColorCode).HasMaxLength(10).IsRequired();
        }
    }
}
