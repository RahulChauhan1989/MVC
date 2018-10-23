using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQGapCheckVerMap:EntityTypeConfiguration<PQGapCheckVer>
    {
        public PQGapCheckVerMap()
        {
            this.HasKey(g => g.GapCheckVerRowID);
            this.Property(g => g.GapCheckVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(g=>g.GC_Father_Name_PVerification  ).HasMaxLength(100);
            this.Property(g=>g.GC_Father_Name_Pverification1 ).HasMaxLength(100);
            this.Property(g=>g.GC_Landmark                   ).HasMaxLength(100);
            this.Property(g=>g.GC_ID_Proof_No                ).HasMaxLength(200);
            this.Property(g=>g.GC_Period_To                  ).HasMaxLength(200);
            this.Property(g=>g.GC_Period_Frm                 ).HasMaxLength(200);
            this.Property(g=>g.GC_Own_Rent_Hypoth            ).HasMaxLength(200);
            this.Property(g=>g.GC_Particulars                ).HasMaxLength(200);
            this.Property(g=>g.GC_Particulars1               ).HasMaxLength(200);
            this.Property(g=>g.GC_Neighbor_Check2            ).HasMaxLength(200);
            this.Property(g=>g.GC_Neighbor_Check4            ).HasMaxLength(200);
            this.Property(g=>g.GC_Police_Verif               ).HasMaxLength(200);
            this.Property(g=>g.GC_Any_Other_Commnts          ).HasMaxLength(200);
            this.Property(g=>g.GC_Building_Status            ).HasMaxLength(200);
            this.Property(g=>g.GC_Color_Building             ).HasMaxLength(200);
            this.Property(g=>g.GC_DOB_Sub_Police_Verif       ).HasMaxLength(200);
            this.Property(g=>g.GC_DOB_Sub_Police_Verif1      ).HasMaxLength(200);
            this.Property(g=>g.GC_ConNo                      ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Dur_Gap               ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Line1                 ).HasMaxLength(200);
            this.Property(g=>g.GC_Addr_Line2                 ).HasMaxLength(200);
            this.Property(g=>g.GC_Refre_Name_Detail          ).HasMaxLength(200);
            this.Property(g=>g.GC_Stated_Reason_Gap          ).HasMaxLength(200);
            this.Property(g=>g.GC_Verified_As                ).HasMaxLength(200);
            this.Property(g=>g.ATA_Reverse_Directory         ).HasMaxLength(200);
            this.Property(g=>g.ATA_Residcl_Commrcl           ).HasMaxLength(200);
            this.Property(g=>g.ATA_Stock_Exchnge             ).HasMaxLength(200);
            this.Property(g=>g.ATA_Telphne_Directry_Srch     ).HasMaxLength(200);
            this.Property(g=>g.ATA_Yellow_Pages              ).HasMaxLength(200);
            this.Property(g=>g.ATA_Who_Domain                ).HasMaxLength(200);
            this.Property(g=>g.ATA_GoogleSearch              ).HasMaxLength(200);
            this.Property(g=>g.ATA_InfrastructureOfCmp       ).HasMaxLength(200);
            this.Property(g=>g.ATA_Just_Dial                 ).HasMaxLength(200);
            this.Property(g=>g.ATA_Neighbor_Check1           ).HasMaxLength(200);
            this.Property(g=>g.ATA_NASCOM_Empanelment        ).HasMaxLength(200);
            this.Property(g=>g.ATA_Photograph                ).HasMaxLength(200);
            this.Property(g=>g.ATA_Physical_Site             ).HasMaxLength(200);
            this.Property(g=>g.ATA_Reg_Company               ).HasMaxLength(200);
            this.Property(g=>g.ATA_PO_Courier_Check          ).HasMaxLength(200);
            this.Property(g=>g.ATA_Network_Sol               ).HasMaxLength(200);
            this.Property(g=>g.ATA_ApprxEmpWorking           ).HasMaxLength(200);
            this.Property(g=>g.ATA_CID_No                    ).HasMaxLength(200);
            this.Property(g=>g.ATA_Cmpny_Addr                ).HasMaxLength(100);
            this.Property(g=>g.ATA_Decoy_Call                ).HasMaxLength(200);
            this.Property(g=>g.ATA_Cmpny_Website             ).HasMaxLength(200);
            this.Property(g=>g.GC_Others                     ).HasMaxLength(200);
            this.Property(g=>g.GC_Others2                    ).HasMaxLength(200);
            this.Property(g=>g.GC_Others3                    ).HasMaxLength(200);
            this.Property(g=>g.GC_Others4                    ).HasMaxLength(200);
            this.Property(g=>g.GC_Others5                    ).HasMaxLength(200);
            this.Property(g => g.GC_OtherProof               ).HasMaxLength(200);


            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQGapCheck).WithMany().HasForeignKey(c => c.GapCheckRowID).WillCascadeOnDelete(false);
        }

    }
}
