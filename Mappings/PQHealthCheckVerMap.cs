using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQHealthCheckVerMap:EntityTypeConfiguration<PQHealthCheckVer>
    {
        public PQHealthCheckVerMap()
        {
            this.HasKey(h => h.HealthCheckVerRowID);
            this.Property(h => h.HealthCheckVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(h=>h.HC_DLC                           ).HasMaxLength(200);
            this.Property(h=>h.HC_Cholesterol                   ).HasMaxLength(200);
            this.Property(h=>h.HC_Blood_Group                   ).HasMaxLength(200);
            this.Property(h=>h.HC_ESR                           ).HasMaxLength(200);
            this.Property(h=>h.HC_HB                            ).HasMaxLength(200);
            this.Property(h=>h.HC_CT_Scan                       ).HasMaxLength(200);
            this.Property(h=>h.HC_BP_Check                      ).HasMaxLength(200);
            this.Property(h=>h.HC_Full_Body_Check               ).HasMaxLength(200);
            this.Property(h=>h.HC_Diabetes                      ).HasMaxLength(200);
            this.Property(h=>h.HC_Vision_Test                   ).HasMaxLength(200);
            this.Property(h=>h.HC_Other                         ).HasMaxLength(200);
            this.Property(h=>h.HC_Test_Conducted                ).HasMaxLength(200);
            this.Property(h=>h.HC_TLC                           ).HasMaxLength(200);
            this.Property(h=>h.HC_Urine                         ).HasMaxLength(200);
            this.Property(h=>h.HC_VDRL                          ).HasMaxLength(200);
            this.Property(h=>h.HC_Serum                         ).HasMaxLength(200);
            this.Property(h=>h.ATA_Reverse_Directory            ).HasMaxLength(200);
            this.Property(h=>h.ATA_Residcl_Commrcl              ).HasMaxLength(200);
            this.Property(h=>h.ATA_Stock_Exchnge                ).HasMaxLength(200);
            this.Property(h=>h.ATA_Telphne_Directry_Srch        ).HasMaxLength(200);
            this.Property(h=>h.ATA_Yellow_Pages                 ).HasMaxLength(200);
            this.Property(h=>h.ATA_Who_Domain                   ).HasMaxLength(200);
            this.Property(h=>h.ATA_GoogleSearch                 ).HasMaxLength(200);
            this.Property(h=>h.ATA_InfrastructureOfCmp          ).HasMaxLength(200);
            this.Property(h=>h.ATA_Just_Dial                    ).HasMaxLength(200);
            this.Property(h=>h.ATA_Neighbor_Check1              ).HasMaxLength(200);
            this.Property(h=>h.ATA_NASCOM_Empanelment           ).HasMaxLength(200);
            this.Property(h=>h.ATA_Photograph                   ).HasMaxLength(200);
            this.Property(h=>h.ATA_Physical_Site                ).HasMaxLength(200);
            this.Property(h=>h.ATA_Reg_Company                  ).HasMaxLength(200);
            this.Property(h=>h.ATA_PO_Courier_Check             ).HasMaxLength(200);
            this.Property(h=>h.ATA_Network_Sol                  ).HasMaxLength(200);
            this.Property(h=>h.ATA_ApprxEmpWorking              ).HasMaxLength(200);
            this.Property(h=>h.ATA_CID_No                       ).HasMaxLength(100);
            this.Property(h=>h.ATA_Cmpny_Addr                   ).HasMaxLength(100);
            this.Property(h=>h.ATA_Decoy_Call                   ).HasMaxLength(200);
            this.Property(h=>h.ATA_Cmpny_Website                ).HasMaxLength(200);
            this.Property(h=>h.HC_Others                        ).HasMaxLength(200);
            this.Property(h=>h.HC_Others2                       ).HasMaxLength(200);
            this.Property(h=>h.HC_Others3                       ).HasMaxLength(200);
            this.Property(h=>h.HC_Others4                       ).HasMaxLength(200);
            this.Property(h=>h.HC_Others5                       ).HasMaxLength(200);
            this.Property(h => h.HC_OtherProof).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQHealthCheck).WithMany().HasForeignKey(c => c.PQHealthCheck).WillCascadeOnDelete(false);


        }
    }
}
