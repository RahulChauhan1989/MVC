using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQGlobalDatabaseVerMap:EntityTypeConfiguration<PQGlobalDatabaseVer>
    {
        public PQGlobalDatabaseVerMap()
        {
            this.HasKey(g => g.GlobalDatabaseVerRowID);
            this.Property(g => g.GlobalDatabaseRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(g=>g.GDC_Db_Verf_Facis__Lvl3              ).HasMaxLength(100);
            this.Property(g=>g.GDC_ASL_ACS_TFD                      ).HasMaxLength(100);
            this.Property(g=>g.GDC_Asian_Poltclly_Expsd_PerDb       ).HasMaxLength(100);          
            this.Property(g=>g.GDC_Date_Verification                ).HasMaxLength(100);
            this.Property(g=>g.GDC_Financ_Authorities_Db            ).HasMaxLength(100);
            this.Property(g=>g.GDC_Interpol_Most_Wanted             ).HasMaxLength(100);
            this.Property(g=>g.GDC_Regulatory_Authorities_Check     ).HasMaxLength(100);
            this.Property(g=>g.GDC_Time_Verf                        ).HasMaxLength(200);
            this.Property(g=>g.GDC_Verf_Cmmnts                      ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails6                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails7                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails8                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails9                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails10                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails11                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails12                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails13                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails14                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherDetails15                   ).HasMaxLength(200);
            this.Property(g=>g.GDC_OFAC_List                        ).HasMaxLength(200);
            this.Property(g=>g.GDC_Offcl_OFAC_Blckd_Country         ).HasMaxLength(200);
            this.Property(g=>g.GDC_USD_Treasury_Spec_Denied_Pr      ).HasMaxLength(200);
            this.Property(g=>g.GDC_Db_Verf_Facis                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_AML_ACS_TFD                      ).HasMaxLength(200);
            this.Property(g=>g.GDC_WC_Law_Enforce_Agncy             ).HasMaxLength(200);
            this.Property(g=>g.GDC_WC_Regulatory_Enforce_Agncy      ).HasMaxLength(200);
            this.Property(g=>g.GDC_InternationalSanctionsLaw        ).HasMaxLength(200);
            this.Property(g=>g.GDC_WC_Enforcement_Agncy             ).HasMaxLength(200);
            this.Property(g=>g.GDC_WC_Other_Regulatory_Bodies       ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks1                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks2                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks3                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks4                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks5                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks6                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks7                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks8                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks9                     ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks10                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks11                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks12                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks13                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks14                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks15                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks16                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks17                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks18                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks19                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks20                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks21                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks22                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks23                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks24                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks25                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks26                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks27                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks28                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks29                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks30                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks31                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks32                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks33                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks34                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks35                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks36                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks37                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks38                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks39                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks40                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks41                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks42                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks43                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks44                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks45                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks46                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks47                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks48                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks49                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherChecks50                    ).HasMaxLength(200);
            this.Property(g=>g.ATA_Reverse_Directory                ).HasMaxLength(200);
            this.Property(g=>g.ATA_Residcl_Commrcl                  ).HasMaxLength(200);
            this.Property(g=>g.ATA_Stock_Exchnge                    ).HasMaxLength(200);
            this.Property(g=>g.ATA_Telphne_Directry_Srch            ).HasMaxLength(200);
            this.Property(g=>g.ATA_Yellow_Pages                     ).HasMaxLength(200);
            this.Property(g=>g.ATA_Who_Domain                       ).HasMaxLength(200);
            this.Property(g=>g.ATA_GoogleSearch                     ).HasMaxLength(200);
            this.Property(g=>g.ATA_InfrastructureOfCmp              ).HasMaxLength(200);
            this.Property(g=>g.ATA_Just_Dial                        ).HasMaxLength(200);
            this.Property(g=>g.ATA_Neighbor_Check1                  ).HasMaxLength(200);
            this.Property(g=>g.ATA_NASCOM_Empanelment               ).HasMaxLength(200);
            this.Property(g=>g.ATA_Photograph                       ).HasMaxLength(200);
            this.Property(g=>g.ATA_Physical_Site                    ).HasMaxLength(200);
            this.Property(g=>g.ATA_Reg_Company                      ).HasMaxLength(200);
            this.Property(g=>g.ATA_PO_Courier_Check                 ).HasMaxLength(200);
            this.Property(g=>g.ATA_Network_Sol                      ).HasMaxLength(200);
            this.Property(g=>g.ATA_ApprxEmpWorking                  ).HasMaxLength(200);
            this.Property(g=>g.ATA_CID_No                           ).HasMaxLength(200);
            this.Property(g=>g.ATA_Cmpny_Addr                       ).HasMaxLength(100);
            this.Property(g=>g.ATA_Decoy_Call                       ).HasMaxLength(100);
            this.Property(g=>g.ATA_Cmpny_Website                    ).HasMaxLength(200);
            this.Property(g=>g.GDC_OtherProof                       ).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQGlobalDatabase).WithMany().HasForeignKey(c => c.GlobalDatabaseRowID).WillCascadeOnDelete(false);
        }
    }
}
