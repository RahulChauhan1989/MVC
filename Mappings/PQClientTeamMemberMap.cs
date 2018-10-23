using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientTeamMemberMap : EntityTypeConfiguration<PQClientTeamMember>
    {
        public PQClientTeamMemberMap()
        {
            this.HasKey(r => r.ClientTMemberRowID);
            this.Property(r => r.ClientTMemberRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(t => t.PQClientMaster).WithMany().HasForeignKey(t => t.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(t => t.TeamDepartment).WithMany().HasForeignKey(t => t.TeamDepartmentRowID).WillCascadeOnDelete(false);
        }
    }
}
