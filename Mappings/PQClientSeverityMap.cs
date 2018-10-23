using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQClientSeverityMap : EntityTypeConfiguration<PQClientSeverity>
    {
        public PQClientSeverityMap()
        {
            this.HasKey(s => s.ClientSeverityRowId);
            this.Property(s => s.ClientSeverityRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ClientColorName).HasMaxLength(30);
            this.Property(s => s.ClientColorCode).HasMaxLength(10).IsRequired();

            this.HasRequired(s => s.PQClientMaster).WithMany().HasForeignKey(s => s.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(s => s.MasterSeverityGrid).WithMany().HasForeignKey(s => s.SeverityGridRowId).WillCascadeOnDelete(false);
        }
    }
}
