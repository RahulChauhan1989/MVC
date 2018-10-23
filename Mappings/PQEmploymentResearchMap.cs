using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEmploymentResearchMap : EntityTypeConfiguration<PQEmploymentResearch>
    {
        public PQEmploymentResearchMap()
        {

            this.HasKey(e => e.EmpResearchRowID);
            this.Property(e => e.EmpResearchRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.OtherEmployer).HasMaxLength(5000);
            this.Property(e => e.AddedNameDesig).HasMaxLength(100);
            this.Property(e => e.UpdatedNameDesig).HasMaxLength(100);

            this.HasRequired(e => e.PQEmployment).WithMany().HasForeignKey(e => e.EmploymentRowId).WillCascadeOnDelete(false);
        }
    }
}
