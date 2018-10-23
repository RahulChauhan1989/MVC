using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{ 
    public class PQEducationResearchMap : EntityTypeConfiguration<PQEducationResearch>
    {
        public PQEducationResearchMap()
        {

            this.HasKey(e => e.EduResearchRowID);
            this.Property(e => e.EduResearchRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.OtherInstitute).HasMaxLength(5000);
            this.Property(e => e.AddedNameDesig).HasMaxLength(100);
            this.Property(e => e.UpdatedNameDesig).HasMaxLength(100);

            this.HasRequired(e => e.PQEducation).WithMany().HasForeignKey(e => e.EducationRowId).WillCascadeOnDelete(false);
        }
    }
}
