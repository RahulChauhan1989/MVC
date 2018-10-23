using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQReferenceVerDispositionMap : EntityTypeConfiguration<PQReferenceVerDisposition>
    {
        public PQReferenceVerDispositionMap()
        {
            this.HasKey(d => d.ReferenceVerDispositionRowID);
            this.Property(d => d.ReferenceVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQReferenceVer).WithMany().HasForeignKey(d => d.ReferenceCheckVerRowID).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
