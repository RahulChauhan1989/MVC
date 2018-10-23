using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQNationalIdentityVerDispositionMap : EntityTypeConfiguration<PQNationalIdentityVerDisposition>
    {
        public PQNationalIdentityVerDispositionMap()
        {
            this.HasKey(d => d.IdentityVerDispositionRowID);
            this.Property(d => d.IdentityVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQNationalIdentityVer).WithMany().HasForeignKey(d => d.NationalIdentityVerRowID).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
