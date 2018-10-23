using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEducationVerDispositionMap : EntityTypeConfiguration<PQEducationVerDisposition>
    {
        public PQEducationVerDispositionMap()
        {
            this.HasKey(d => d.EducationVerDispositionRowID);
            this.Property(d => d.EducationVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQEducationVer).WithMany().HasForeignKey(d => d.EducationVerRowID).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
