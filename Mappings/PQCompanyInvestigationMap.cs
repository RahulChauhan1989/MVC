using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
   public class PQCompanyInvestigationMap:EntityTypeConfiguration<PQCompanyInvestigation>
    {
        public PQCompanyInvestigationMap()
        {
            this.HasKey(c => c.CompanyInvestigationRowID);
            this.Property(c => c.CompanyInvestigationRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);           
            this.Property(c=>c.CI_Owner_Name                ).HasMaxLength(100);
            this.Property(c=>c.CI_Area_Of_Business          ).HasMaxLength(100);
            this.Property(c=>c.CI_Company_IdentityNO        ).HasMaxLength(100);
            this.Property(c=>c.CI_Name_Cmpny                ).HasMaxLength(100);
            this.Property(c=>c.CI_Quality_Recognition       ).HasMaxLength(100);
            this.Property(c=>c.CI_Reg_Name_Cmpny            ).HasMaxLength(100);
            this.Property(c=>c.CI_Tax_IdentityNo            ).HasMaxLength(100);
            this.Property(c=>c.CI_Type_Org_Legal_Status     ).HasMaxLength(100);
            this.Property(c=>c.CI_Yr_Incorporation          ).HasMaxLength(100);
            this.Property(c=>c.ATA_CID_No                   ).HasMaxLength(100);
            this.Property(c=>c.ATA_Cmpny_Addr               ).HasMaxLength(100);
            this.Property(c=>c.CI_Others                    ).HasMaxLength(200);
            this.Property(c=>c.CI_Others2                   ).HasMaxLength(200);
            this.Property(c=>c.CI_Others3                   ).HasMaxLength(200);
            this.Property(c=>c.CI_Others4                   ).HasMaxLength(200);
            this.Property(c=>c.CI_Others5                   ).HasMaxLength(200);
            this.Property(c => c.CI_OtherProof).HasMaxLength(200);

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
