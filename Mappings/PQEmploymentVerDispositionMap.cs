using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEmploymentVerDispositionMap : EntityTypeConfiguration<PQEmploymentVerDisposition>
    {
        public PQEmploymentVerDispositionMap()
        {
            this.HasKey(d => d.EmploymentVerDispositionRowID);
            this.Property(d => d.EmploymentVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQEmploymentVer).WithMany().HasForeignKey(d => d.EmploymentVerRowID).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
