using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCandidateLoginMap : EntityTypeConfiguration<PQCandidateLogin>
    {
        public PQCandidateLoginMap()
        {
            this.HasKey(c => c.CandidateUserRowID);
            this.Property(c => c.CandidateUserRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.CandidateName).HasMaxLength(100);
            this.Property(d => d.CandidateEmail).HasMaxLength(100);
            this.Property(d => d.CandidateEmailCC).HasMaxLength(100);
            this.Property(d => d.UserID).HasMaxLength(100).IsRequired();          
            this.Property(d => d.UPass).HasMaxLength(100).IsRequired();
            this.Property(d => d.CreatedBy).HasMaxLength(100);          
            this.Property(d => d.EmployeeID).HasMaxLength(100);
            this.Property(d => d.Remarks).HasMaxLength(150);
            this.Property(d => d.CantactNo).HasMaxLength(30);
            this.Property(d => d.AlternatvieNo).HasMaxLength(30);
            this.Property(d => d.Remarks).HasMaxLength(300);
            this.Property(d => d.Department).HasMaxLength(100);

            this.HasRequired(d => d.PQClientMaster).WithMany().HasForeignKey(d => d.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.TempPQPersonal).WithMany().HasForeignKey(d => d.TempPersonalRowID).WillCascadeOnDelete(false);
        }
    }
}
