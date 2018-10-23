using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQClientDispositionMap : EntityTypeConfiguration<PQClientDisposition>
    {
        public PQClientDispositionMap()
        {
            this.HasKey(d => d.ClientDispositionRowId);
            this.Property(d => d.ClientDispositionRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(s => s.PQClientMaster).WithMany().HasForeignKey(s => s.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(b => b.MasterCheckFamily).WithMany().HasForeignKey(b => b.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(b => b.MasterDisposition).WithMany().HasForeignKey(b => b.DispositionRowId).WillCascadeOnDelete(false);
            this.HasRequired(b => b.MasterSeverityGrid).WithMany().HasForeignKey(b => b.SeverityGridRowId).WillCascadeOnDelete(false);
        }
    }
}
