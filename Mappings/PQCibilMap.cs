using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQCibilMap : EntityTypeConfiguration<PQCibil>
    {
        public PQCibilMap()
        {
            this.HasKey(a => a.CibilRowID);
            this.Property(a => a.CibilRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.UniqueComponentID).HasMaxLength(20);
            this.Property(a => a.CC_Cand_Name).HasMaxLength(100);
            this.Property(a => a.CC_Sec_Ref_Id).HasMaxLength(50);
            this.Property(a => a.CC_PanNo).HasMaxLength(20);
            this.Property(a => a.CC_CIBIL_Rpt).HasMaxLength(200);
            this.Property(a => a.CC_CIBIL_Score).HasMaxLength(100);
            this.Property(a => a.CC_Others).HasMaxLength(200);
            this.Property(a => a.CC_Others2).HasMaxLength(200);
            this.Property(a => a.ATA_CID_No).HasMaxLength(50);
            this.Property(a => a.ATA_Cmpny_Addr).HasMaxLength(200);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

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
