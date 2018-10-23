using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQInsuranceVerMap:EntityTypeConfiguration<PQInsuranceVer>
    {
        public PQInsuranceVerMap()
        {
            this.HasKey(i => i.InsuranceVerRowID);
            this.Property(i => i.InsuranceVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            this.Property(i=>i.IV_Standard_Living                   ).HasMaxLength(200);
            this.Property(i=>i.IV_State                             ).HasMaxLength(200);
            this.Property(i=>i.IV_Self_Emplyd_Remarks               ).HasMaxLength(200);
            this.Property(i=>i.IV_Remarks_IV                        ).HasMaxLength(200);
            this.Property(i=>i.IV_Relation_Applcnt                  ).HasMaxLength(200);
            this.Property(i=>i.IV_Report_Shared_date                ).HasMaxLength(200);
            this.Property(i=>i.IV_Resdnce_Area                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Resdnce_Status                    ).HasMaxLength(200);
            this.Property(i=>i.IV_Resdnce_Type                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Vech_Owned                        ).HasMaxLength(200);
            this.Property(i=>i.IV_Verif_Grid                        ).HasMaxLength(200);
            this.Property(i=>i.IV_Yrly_Premium                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Sum_Assured                       ).HasMaxLength(200);
            this.Property(i=>i.IV_Time_Verification                 ).HasMaxLength(200);
            this.Property(i=>i.IV_Status                            ).HasMaxLength(200);
            this.Property(i=>i.IV_Medical_Test_Insurance_App        ).HasMaxLength(200);
            this.Property(i=>i.IV_ID_CardNo                         ).HasMaxLength(200);
            this.Property(i=>i.IV_ID_Card_Seen                      ).HasMaxLength(200);
            this.Property(i=>i.IV_ID_Proof_Relation_Life_Ass        ).HasMaxLength(200);
            this.Property(i=>i.IV_Applcnt_Other_Loc_frm_Addr        ).HasMaxLength(200);
            this.Property(i=>i.IV_Income                            ).HasMaxLength(200);
            this.Property(i=>i.IV_InsurancePolicy_Taken             ).HasMaxLength(200);
            this.Property(i=>i.IV_Insured_Name                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Investigator                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Locality                          ).HasMaxLength(200);
            this.Property(i=>i.IV_Mode_Of_Verif                     ).HasMaxLength(200);
            this.Property(i=>i.IV_Modern_Appliance_Seen             ).HasMaxLength(200);
            this.Property(i=>i.IV_Name_Field_Executive              ).HasMaxLength(200);
            this.Property(i=>i.IV_Name_Met_Person                   ).HasMaxLength(200);
            this.Property(i=>i.IV_Physical_Disability               ).HasMaxLength(200);
            this.Property(i=>i.IV_Policy_No                         ).HasMaxLength(200);
            this.Property(i=>i.IV_Proposer_Name                     ).HasMaxLength(200);
            this.Property(i=>i.IV_Pincode                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Premium                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Reason_Check                      ).HasMaxLength(200);
            this.Property(i=>i.IV_Received_Policy                   ).HasMaxLength(200);
            this.Property(i=>i.IV_Near_Landmark                     ).HasMaxLength(200);
            this.Property(i=>i.IV_Neighbor_Check                    ).HasMaxLength(200);
            this.Property(i=>i.IV_New_Addr_Obtain                   ).HasMaxLength(200);
            this.Property(i=>i.IV_No_Yrs_Current_Residence          ).HasMaxLength(200);
            this.Property(i=>i.IV_Office_Addr                       ).HasMaxLength(200);
            this.Property(i=>i.IV_Office_Locality                   ).HasMaxLength(200);
            this.Property(i=>i.IV_Office_Appearance                 ).HasMaxLength(200);
            this.Property(i=>i.IV_Original_Doc_Seen                 ).HasMaxLength(200);
            this.Property(i=>i.IV_Applcnt_DOB_Age                   ).HasMaxLength(200);
            this.Property(i=>i.IV_Applcnt_Health_Cond               ).HasMaxLength(200);
            this.Property(i=>i.IV_Applied_Policy                    ).HasMaxLength(200);
            this.Property(i=>i.IV_Action_Req                        ).HasMaxLength(200);
            this.Property(i=>i.IV_Address                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Age                               ).HasMaxLength(200);
            this.Property(i=>i.IV_Agent_Name                        ).HasMaxLength(200);
            this.Property(i=>i.IV_Check_Type                        ).HasMaxLength(200);
            this.Property(i=>i.ATA_Reverse_Directory                ).HasMaxLength(200);
            this.Property(i=>i.ATA_Residcl_Commrcl                  ).HasMaxLength(200);
            this.Property(i=>i.ATA_Stock_Exchnge                    ).HasMaxLength(200);
            this.Property(i=>i.ATA_Telphne_Directry_Srch            ).HasMaxLength(200);
            this.Property(i=>i.ATA_Yellow_Pages                     ).HasMaxLength(200);
            this.Property(i=>i.ATA_Who_Domain                       ).HasMaxLength(200);
            this.Property(i=>i.ATA_GoogleSearch                     ).HasMaxLength(200);
            this.Property(i=>i.ATA_InfrastructureOfCmp              ).HasMaxLength(200);
            this.Property(i=>i.ATA_Just_Dial                        ).HasMaxLength(200);
            this.Property(i=>i.ATA_Neighbor_Check1                  ).HasMaxLength(200);
            this.Property(i=>i.ATA_NASCOM_Empanelment               ).HasMaxLength(200);
            this.Property(i=>i.ATA_Photograph                       ).HasMaxLength(200);
            this.Property(i=>i.ATA_Physical_Site                    ).HasMaxLength(200);
            this.Property(i=>i.ATA_Reg_Company                      ).HasMaxLength(200);
            this.Property(i=>i.ATA_PO_Courier_Check                 ).HasMaxLength(200);
            this.Property(i=>i.ATA_Network_Sol                      ).HasMaxLength(200);
            this.Property(i=>i.ATA_ApprxEmpWorking                  ).HasMaxLength(200);
            this.Property(i=>i.ATA_CID_No                           ).HasMaxLength(200);
            this.Property(i=>i.ATA_Cmpny_Addr                       ).HasMaxLength(200);
            this.Property(i=>i.ATA_Decoy_Call                       ).HasMaxLength(200);
            this.Property(i=>i.ATA_Cmpny_Website                    ).HasMaxLength(200);
            this.Property(i=>i.IV_Others                            ).HasMaxLength(200);
            this.Property(i=>i.IV_Others2                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others3                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others4                           ).HasMaxLength(200);
            this.Property(i=>i.IV_Others5                           ).HasMaxLength(200);
            this.Property(i => i.IV_OtherProof                      ).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQInsurance).WithMany().HasForeignKey(c => c.InsuranceRowID).WillCascadeOnDelete(false);
        }
    }
}
