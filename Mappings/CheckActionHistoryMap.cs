using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class CheckActionHistoryMap : EntityTypeConfiguration<CheckActionHistory>
    {
        public CheckActionHistoryMap()
        {
            this.HasKey(i => i.CheckAHRowID);
            this.Property(i => i.CheckAHRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(i => i.Remarks).HasMaxLength(5000);
            this.Property(i => i.CheckStatus).HasMaxLength(50);
            this.Property(i => i.UpdatedByNameDesig).HasMaxLength(100);

            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
