using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCandidateCheckMap : EntityTypeConfiguration<PQCandidateCheck>
    {
        public PQCandidateCheckMap()
        {
            this.HasKey(a => a.CandCheckRowID);
            this.Property(a => a.CandCheckRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
        }
    }
}
