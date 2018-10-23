using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCandidateInsuffLoginMap : EntityTypeConfiguration<PQCandidateInsuffLogin>
    {
        public PQCandidateInsuffLoginMap()
        {
            this.HasKey(c => c.CInsuffUserRowID);
            this.Property(c => c.CInsuffUserRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CandidateName).HasMaxLength(100);
            this.Property(c => c.UserID).HasMaxLength(100).IsRequired();
            this.Property(c => c.UPass).HasMaxLength(100).IsRequired();
            this.Property(c => c.CreatedBy).HasMaxLength(50);

            this.HasRequired(d => d.PQClientMaster).WithMany().HasForeignKey(d => d.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.PQPersonal).WithMany().HasForeignKey(d => d.PersonalRowID).WillCascadeOnDelete(false);
        }
    }
}
