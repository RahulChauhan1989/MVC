using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQProfileMap:EntityTypeConfiguration<PQProfile>
    {
        public PQProfileMap()
        {
            this.HasKey(p => p.PQProfileRowID);
            this.Property(p => p.PQProfileRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



              this.Property(p=>p.PC_Cand_Name           ).HasMaxLength(100);
              this.Property(p=>p.PC_Sec_Ref_Id          ).HasMaxLength(100);
              this.Property(p=>p.PC_Address             ).HasMaxLength(200);
              this.Property(p=>p.PC_Age                 ).HasMaxLength(100);
              this.Property(p=>p.PC_Applcnt_Age_DOB     ).HasMaxLength(100);
              this.Property(p=>p.PC_Applcnt_Health_Cond ).HasMaxLength(200);
              this.Property(p=>p.PC_Policy_No           ).HasMaxLength(100);
              this.Property(p=>p.PC_Premium             ).HasMaxLength(200);
              this.Property(p=>p.PC_Proposer_Name       ).HasMaxLength(200);
              this.Property(p=>p.PC_Reason_Check        ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails        ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails2       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails3       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails4       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails5       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails6       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails7       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails8       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails9       ).HasMaxLength(200);
              this.Property(p=>p.PC_OtherDetails10      ).HasMaxLength(200);
              this.Property(p=>p.ATA_CID_No             ).HasMaxLength(100);
              this.Property(p=>p.ATA_Cmpny_Addr         ).HasMaxLength(100);
            this.Property(p => p.PC_OtherProof).HasMaxLength(200);

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
