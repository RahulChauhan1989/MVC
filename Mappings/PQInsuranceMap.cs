using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQInsuranceMap:EntityTypeConfiguration<PQInsurance>
    {
        public PQInsuranceMap()
        {
            this.HasKey(i => i.InsuranceRowID);
            this.Property(i => i.InsuranceRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(i=>i.IV_State             ).HasMaxLength(200);
            this.Property(i=>i.IV_Yrly_Premium      ).HasMaxLength(200);
            this.Property(i=>i.IV_Sum_Assured       ).HasMaxLength(200);
            this.Property(i=>i.IV_Insured_Name      ).HasMaxLength(200);
            this.Property(i=>i.IV_Policy_No         ).HasMaxLength(200);
            this.Property(i=>i.IV_Proposer_Name     ).HasMaxLength(200);
            this.Property(i=>i.IV_Pincode           ).HasMaxLength(200);
            this.Property(i=>i.IV_Premium           ).HasMaxLength(200);
            this.Property(i=>i.IV_Reason_Check      ).HasMaxLength(200);
            this.Property(i=>i.IV_Office_Addr       ).HasMaxLength(200);
            this.Property(i=>i.IV_Action_Req        ).HasMaxLength(200);
            this.Property(i=>i.IV_Address           ).HasMaxLength(200);
            this.Property(i=>i.IV_Age               ).HasMaxLength(200);
            this.Property(i=>i.IV_Agent_Name        ).HasMaxLength(200);
            this.Property(i=>i.IV_Check_Type        ).HasMaxLength(200);
            this.Property(i=>i.ATA_CID_No           ).HasMaxLength(100);
            this.Property(i=>i.ATA_Cmpny_Addr       ).HasMaxLength(100);
            this.Property(i=>i.IV_Others            ).HasMaxLength(200);
            this.Property(i=>i.IV_Others2           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others3           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others4           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others5           ).HasMaxLength(200);
            this.Property(i => i.IV_OtherProof).HasMaxLength(200);

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
