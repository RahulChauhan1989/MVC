using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQGapCheckMap:EntityTypeConfiguration<PQGapCheck>
    {
        public PQGapCheckMap()
        {
            this.HasKey(g => g.GapCheckRowID);
            this.Property(g => g.GapCheckRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(g=>g.GC_Father_Name_PVerification     ).HasMaxLength(200);
            this.Property(g=>g.GC_Father_Name_Pverification1    ).HasMaxLength(200);
            this.Property(g=>g.GC_Landmark                      ).HasMaxLength(200);
            this.Property(g=>g.GC_Period_To                     ).HasMaxLength(200);
            this.Property(g=>g.GC_Period_Frm                    ).HasMaxLength(200);
            this.Property(g=>g.GC_DOB_Sub_Police_Verif          ).HasMaxLength(200);
            this.Property(g=>g.GC_DOB_Sub_Police_Verif1         ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Dur_Gap                  ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Line1                    ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Line2                    ).HasMaxLength(200);
            this.Property(g=>g.GC_Stated_Reason_Gap             ).HasMaxLength(200);
            this.Property(g=>g.ATA_CID_No                       ).HasMaxLength(200);
            this.Property(g=>g.ATA_Cmpny_Addr                   ).HasMaxLength(200);
            this.Property(g=>g.GC_Others                        ).HasMaxLength(200);
            this.Property(g=>g.GC_Others2                       ).HasMaxLength(200);
            this.Property(g=>g.GC_Others3                       ).HasMaxLength(200);
            this.Property(g=>g.GC_Others4                       ).HasMaxLength(200);
            this.Property(g=>g.GC_Others5                       ).HasMaxLength(200);
            this.Property(g => g.GC_OtherProof).HasMaxLength(200);

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
