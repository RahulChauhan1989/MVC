using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class MasterDispositionMap : EntityTypeConfiguration<MasterDisposition>
    {
        public MasterDispositionMap()
        {
            this.HasKey(d => d.DispositionRowId);
            this.Property(d => d.DispositionRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.Disposition).HasMaxLength(300).IsRequired();

            this.HasRequired(b => b.MasterCheckFamily).WithMany().HasForeignKey(b => b.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(b => b.MasterSeverityGrid).WithMany().HasForeignKey(b => b.SeverityGridRowId).WillCascadeOnDelete(false);
        }
    }
}
