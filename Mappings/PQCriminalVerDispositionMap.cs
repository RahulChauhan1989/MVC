using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCriminalVerDispositionMap : EntityTypeConfiguration<PQCriminalVerDisposition>
    {
        public PQCriminalVerDispositionMap()
        {
            this.HasKey(d => d.CriminalVerDispositionRowID);
            this.Property(d => d.CriminalVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQCriminalVer).WithMany().HasForeignKey(d => d.CriminalVerRowId).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
