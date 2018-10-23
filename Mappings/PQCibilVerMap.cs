using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQCibilVerMap:EntityTypeConfiguration<PQCibilVer>
    {
        public PQCibilVerMap()
        {
            this.HasKey(c => c.CibilVerRowID            );
            this.Property(c => c.CibilRowID             ).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c=>c.CC_Cand_Name             ).HasMaxLength(200);
            this.Property(c=>c.CC_PanNo                 ).HasMaxLength(200);
            this.Property(c=>c.CC_CIBIL_Rpt             ).HasMaxLength(200);
            this.Property(c=>c.CC_CIBIL_Score           ).HasMaxLength(200);
            this.Property(c=>c.CC_CIBIL_Score1          ).HasMaxLength(200);
            this.Property(c=>c.CC_CIBIL_Rpt1            ).HasMaxLength(200);
            this.Property(c=>c.CC_Others                ).HasMaxLength(200);
            this.Property(c=>c.CC_Others2               ).HasMaxLength(200);
            this.Property(c=>c.CC_Others3               ).HasMaxLength(200);
            this.Property(c=>c.CC_Others4               ).HasMaxLength(200);
            this.Property(c=>c.CC_Others5               ).HasMaxLength(200);
            this.Property(c=>c.CC_Others6               ).HasMaxLength(200);
            this.Property(c => c.CC_Others7             ).HasMaxLength(200);
            this.Property(c=>c.ATA_CID_No               ).HasMaxLength(100);
            this.Property(c=>c.ATA_Cmpny_Addr           ).HasMaxLength(100);
            this.Property(c=>c.ATA_ApprxEmpWorking      ).HasMaxLength(200);
            this.Property(c=>c.ATA_Cmpny_Website        ).HasMaxLength(200);
            this.Property(c=>c.ATA_Decoy_Call           ).HasMaxLength(200);
            this.Property(c=>c.ATA_Reverse_Directory    ).HasMaxLength(200);
            this.Property(c=>c.ATA_Residcl_Commrcl      ).HasMaxLength(200);
            this.Property(c=>c.ATA_Stock_Exchnge        ).HasMaxLength(200);
            this.Property(c=>c.ATA_Telphne_Directry_Srch).HasMaxLength(200);
            this.Property(c=>c.ATA_Yellow_Pages         ).HasMaxLength(200);
            this.Property(c=>c.ATA_Who_Domain           ).HasMaxLength(200);
            this.Property(c=>c.ATA_GoogleSearch         ).HasMaxLength(200);
            this.Property(c=>c.ATA_InfrastructureOfCmp  ).HasMaxLength(200);
            this.Property(c=>c.ATA_Just_Dial            ).HasMaxLength(200);
            this.Property(c=>c.ATA_Neighbor_Check1      ).HasMaxLength(200);
            this.Property(c=>c.ATA_NASCOM_Empanelment   ).HasMaxLength(200);
            this.Property(c=>c.ATA_Photograph           ).HasMaxLength(200);
            this.Property(c=>c.ATA_Physical_Site        ).HasMaxLength(200);
            this.Property(c=>c.ATA_Reg_Company          ).HasMaxLength(200);
            this.Property(c=>c.ATA_PO_Courier_Check     ).HasMaxLength(200);
            this.Property(c => c.ATA_Network_Sol        ).HasMaxLength(200);


            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQCibil).WithMany().HasForeignKey(c => c.CibilRowID).WillCascadeOnDelete(false);
        }
    }
}
