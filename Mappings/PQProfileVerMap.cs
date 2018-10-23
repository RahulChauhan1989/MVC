using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQProfileVerMap:EntityTypeConfiguration<PQProfileVer>
    {
        public PQProfileVerMap()
        {
            this.HasKey(p => p.PQProfileVerRowID);
            this.Property(p => p.PQProfileVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(p=>p.PC_Cand_Name                      ).HasMaxLength(100);
           this.Property(p=>p.PC_Address                        ).HasMaxLength(200);
           this.Property(p=>p.PC_Age                            ).HasMaxLength(100);
           this.Property(p=>p.PC_Agnt_Name                      ).HasMaxLength(100);
           this.Property(p=>p.PC_Applcnt_Age_DOB                ).HasMaxLength(100);
           this.Property(p=>p.PC_Applcnt_Health_Cond            ).HasMaxLength(100);
           this.Property(p=>p.PC_Applied_Policy                 ).HasMaxLength(100);
           this.Property(p=>p.PC_Cmpny_Name                     ).HasMaxLength(100);
           this.Property(p=>p.PC_Criminal_Back                  ).HasMaxLength(100);
           this.Property(p=>p.PC_Dsg                            ).HasMaxLength(100);
           this.Property(p=>p.PC_Edu                            ).HasMaxLength(100);
           this.Property(p=>p.PC_Employer                       ).HasMaxLength(100);
           this.Property(p=>p.PC_Existence_Addr                 ).HasMaxLength(100);
           this.Property(p=>p.PC_Fmly_History                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Habits                         ).HasMaxLength(100);
           this.Property(p=>p.PC_Income                         ).HasMaxLength(100);
           this.Property(p=>p.PC_InsurancePolicy_Taken          ).HasMaxLength(100);
           this.Property(p=>p.PC_Investigator                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Locality                       ).HasMaxLength(100);
           this.Property(p=>p.PC_Mode                           ).HasMaxLength(200);
           this.Property(p=>p.PC_Modern_Appliance_Seen          ).HasMaxLength(200);
           this.Property(p=>p.PC_Name_Field_Executive           ).HasMaxLength(200);
           this.Property(p=>p.PC_Name_Met_Per                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Neigh_Check                    ).HasMaxLength(100);
           this.Property(p=>p.PC_Neigh_Check2                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Neigh_Check3                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Neigh_Check4                   ).HasMaxLength(100);
           this.Property(p=>p.PC_New_Addr_Obtain                ).HasMaxLength(200);
           this.Property(p=>p.PC_No_Yrs_Current_Residence       ).HasMaxLength(200);
           this.Property(p=>p.PC_Occupation                     ).HasMaxLength(200);
           this.Property(p=>p.PC_Occupation_Addr                ).HasMaxLength(200);
           this.Property(p=>p.PC_Office_Shop_Appearance         ).HasMaxLength(200);
           this.Property(p=>p.PC_Policy_No                      ).HasMaxLength(100);
           this.Property(p=>p.PC_Premium                        ).HasMaxLength(100);
           this.Property(p=>p.PC_Proposer_Name                  ).HasMaxLength(100);
           this.Property(p=>p.PC_Reason_Check                   ).HasMaxLength(100);
           this.Property(p=>p.PC_Received_Policy                ).HasMaxLength(100);
           this.Property(p=>p.PC_Relation_With_Applcnt          ).HasMaxLength(100);
           this.Property(p=>p.PC_Remarks_PC                     ).HasMaxLength(100);
           this.Property(p=>p.PC_Residence_Area                 ).HasMaxLength(100);
           this.Property(p=>p.PC_Residence_Status               ).HasMaxLength(100);
           this.Property(p=>p.PC_Residence_Type                 ).HasMaxLength(100);
           this.Property(p=>p.PC_Self_Emplyd_Remarks            ).HasMaxLength(100);
           this.Property(p=>p.PC_Standard_Living                ).HasMaxLength(100);
           this.Property(p=>p.PC_Status                         ).HasMaxLength(100);
           this.Property(p=>p.PC_Sum_Assured                    ).HasMaxLength(100);
           this.Property(p=>p.PC_Time_Verf                      ).HasMaxLength(100);
           this.Property(p=>p.PC_Vech_Owned                     ).HasMaxLength(100);
           this.Property(p=>p.PC_Verf_Grid                      ).HasMaxLength(100);
           this.Property(p=>p.PC_Yrly_Premium                   ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails6                  ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails7                  ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails8                  ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails9                  ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails10                 ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails11                 ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails12                 ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails13                 ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails14                 ).HasMaxLength(200);
           this.Property(p=>p.PC_OtherDetails15                 ).HasMaxLength(200);
           this.Property(p=>p.ATA_Reverse_Directory             ).HasMaxLength(200);
           this.Property(p=>p.ATA_Residcl_Commrcl               ).HasMaxLength(200);
           this.Property(p=>p.ATA_Stock_Exchnge                 ).HasMaxLength(200);
           this.Property(p=>p.ATA_Telphne_Directry_Srch         ).HasMaxLength(200);
           this.Property(p=>p.ATA_Yellow_Pages                  ).HasMaxLength(200);
           this.Property(p=>p.ATA_Who_Domain                    ).HasMaxLength(200);
           this.Property(p=>p.ATA_GoogleSearch                  ).HasMaxLength(200);
           this.Property(p=>p.ATA_InfrastructureOfCmp           ).HasMaxLength(200);
           this.Property(p=>p.ATA_Just_Dial                     ).HasMaxLength(200);
           this.Property(p=>p.ATA_Neighbor_Check1               ).HasMaxLength(200);
           this.Property(p=>p.ATA_NASCOM_Empanelment            ).HasMaxLength(200);
           this.Property(p=>p.ATA_Photograph                    ).HasMaxLength(200);
           this.Property(p=>p.ATA_Physical_Site                 ).HasMaxLength(200);
           this.Property(p=>p.ATA_Reg_Company                   ).HasMaxLength(200);
           this.Property(p=>p.ATA_PO_Courier_Check              ).HasMaxLength(200);
           this.Property(p=>p.ATA_Network_Sol                   ).HasMaxLength(200);
           this.Property(p=>p.ATA_ApprxEmpWorking               ).HasMaxLength(200);
           this.Property(p=>p.ATA_CID_No                        ).HasMaxLength(200);
           this.Property(p=>p.ATA_Cmpny_Addr                    ).HasMaxLength(200);
           this.Property(p=>p.ATA_Decoy_Call                    ).HasMaxLength(200);
           this.Property(p=>p.ATA_Cmpny_Website                 ).HasMaxLength(200);
            this.Property(p => p.PC_OtherProof).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQProfile).WithMany().HasForeignKey(c => c.PQProfileRowID).WillCascadeOnDelete(false);
        }
    }
}
