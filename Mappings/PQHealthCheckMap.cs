using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
   public class PQHealthCheckMap:EntityTypeConfiguration<PQHealthCheck>
    {
        public PQHealthCheckMap()
        {
            this.HasKey(h => h.HealthCheckRowID);
            this.Property(h => h.HealthCheckRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(h=>h.HC_CT_Scan           ).HasMaxLength(200);
            this.Property(h=>h.HC_BP_Check          ).HasMaxLength(200);
            this.Property(h=>h.HC_Full_Body_Check   ).HasMaxLength(200);
            this.Property(h=>h.HC_Diabetes          ).HasMaxLength(200);
            this.Property(h=>h.HC_Vision_Test       ).HasMaxLength(200);
            this.Property(h=>h.HC_Other             ).HasMaxLength(200);
            this.Property(h=>h.ATA_CID_No           ).HasMaxLength(100);
            this.Property(h=>h.ATA_Cmpny_Addr       ).HasMaxLength(100);
            this.Property(h=>h.HC_Others            ).HasMaxLength(200);
            this.Property(h=>h.HC_Others2           ).HasMaxLength(200);
            this.Property(h=>h.HC_Others3           ).HasMaxLength(200);
            this.Property(h=>h.HC_Others4           ).HasMaxLength(200);
            this.Property(h=>h.HC_Others5           ).HasMaxLength(200);
            this.Property(h => h.HC_OtherProof).HasMaxLength(200);

            this.Property(a => a.Mailto).HasMaxLength(200);
            this.Property(a => a.MailtoClient).HasMaxLength(200);
            this.Property(a => a.MailedBy).HasMaxLength(100);
            this.Property(a => a.ClientComment).HasMaxLength(100);
            this.Property(a => a.INFRemarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }

    }
}
