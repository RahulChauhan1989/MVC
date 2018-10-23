using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCompanyInvestigationVerMap: EntityTypeConfiguration<PQCompanyInvestigationVer>
    {
        public PQCompanyInvestigationVerMap()
        {
            this.HasKey(c => c.CompanyInvestigationVarRowID);
            this.Property(c => c.CompanyInvestigationVarRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c=>c.CI_Owner_Name                    ).HasMaxLength(100);
            this.Property(c=>c.CI_Any_Other_Commnts_FDdback     ).HasMaxLength(200);
            this.Property(c=>c.CI_Apptmnt_Details               ).HasMaxLength(200);
            this.Property(c=>c.CI_Area_Of_Business              ).HasMaxLength(100);
            this.Property(c=>c.CI_Company_IdentityNO            ).HasMaxLength(100);
            this.Property(c=>c.CI_Dur_Existence                 ).HasMaxLength(200);
            this.Property(c=>c.CI_Exp_During_Business_Dealing   ).HasMaxLength(200);
            this.Property(c=>c.CI_Exp_During_Financ_Dealing     ).HasMaxLength(200);
            this.Property(c=>c.CI_Name_Cmpny                    ).HasMaxLength(200);
            this.Property(c=>c.CI_Property                      ).HasMaxLength(200);
            this.Property(c=>c.CI_Quality_Recognition           ).HasMaxLength(200);
            this.Property(c=>c.CI_Reg_Name_Cmpny                ).HasMaxLength(200);
            this.Property(c=>c.CI_Reg_Doc_Type                  ).HasMaxLength(200);
            this.Property(c=>c.CI_RegNo                         ).HasMaxLength(200);
            this.Property(c=>c.CI_Relation_Business_Entity      ).HasMaxLength(200);
            this.Property(c=>c.CI_Rent_Own                      ).HasMaxLength(200);
            this.Property(c=>c.CI_Tax_IdentityNo                ).HasMaxLength(200);
            this.Property(c=>c.CI_Type_Org_Legal_Status         ).HasMaxLength(200);
            this.Property(c=>c.CI_Yr_Incorporation              ).HasMaxLength(200);
            this.Property(c=>c.CI_Dur_Business_Relation_Cmpny   ).HasMaxLength(200);
            this.Property(c=>c.ATA_Reverse_Directory            ).HasMaxLength(200);
            this.Property(c=>c.ATA_Residcl_Commrcl              ).HasMaxLength(200);
            this.Property(c=>c.ATA_Stock_Exchnge                ).HasMaxLength(200);
            this.Property(c=>c.ATA_Telphne_Directry_Srch        ).HasMaxLength(200);
            this.Property(c=>c.ATA_Yellow_Pages                 ).HasMaxLength(200);
            this.Property(c=>c.ATA_Who_Domain                   ).HasMaxLength(200);
            this.Property(c=>c.ATA_GoogleSearch                 ).HasMaxLength(200);
            this.Property(c=>c.ATA_InfrastructureOfCmp          ).HasMaxLength(200);
            this.Property(c=>c.ATA_Just_Dial                    ).HasMaxLength(200);
            this.Property(c=>c.ATA_Neighbor_Check1              ).HasMaxLength(200);
            this.Property(c=>c.ATA_NASCOM_Empanelment           ).HasMaxLength(200);
            this.Property(c=>c.ATA_Photograph                   ).HasMaxLength(200);
            this.Property(c=>c.ATA_Physical_Site                ).HasMaxLength(200);
            this.Property(c=>c.ATA_Reg_Company                  ).HasMaxLength(200);
            this.Property(c=>c.ATA_PO_Courier_Check             ).HasMaxLength(200);
            this.Property(c=>c.ATA_Network_Sol                  ).HasMaxLength(200);
            this.Property(c=>c.ATA_ApprxEmpWorking              ).HasMaxLength(200);
            this.Property(c=>c.ATA_CID_No                       ).HasMaxLength(100);
            this.Property(c=>c.ATA_Cmpny_Addr                   ).HasMaxLength(100);
            this.Property(c=>c.ATA_Decoy_Call                   ).HasMaxLength(100);
            this.Property(c=>c.ATA_Cmpny_Website                ).HasMaxLength(200);
            this.Property(c=>c.CI_Others                        ).HasMaxLength(200);
            this.Property(c=>c.CI_Others2                       ).HasMaxLength(200);
            this.Property(c=>c.CI_Others3                       ).HasMaxLength(200);
            this.Property(c=>c.CI_Others4                       ).HasMaxLength(200);
            this.Property(c=>c.CI_Others5                       ).HasMaxLength(200);
            this.Property(c => c.CI_OtherProof).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQCompanyInvestigation).WithMany().HasForeignKey(c => c.CompanyInvestigationRowID).WillCascadeOnDelete(false);
        }
    }
}
