using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEducationVerMap : EntityTypeConfiguration<PQEducationVer>
    {
        public PQEducationVerMap()
        {
            this.HasKey(e => e.EducationVerRowID);
            this.Property(e => e.EducationVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.EV_Cand_Name).HasMaxLength(100);
            this.Property(e => e.EV_Cand_Name_Supp_Edu_Doc).HasMaxLength(100);
            this.Property(e => e.EV_Colg_Schl_Inst_Name).HasMaxLength(100);
            this.Property(e => e.EV_Colg_Schl_Inst_Add_ConDet).HasMaxLength(100);
            this.Property(e => e.EV_Affl_University_Name).HasMaxLength(100);
            this.Property(e => e.EV_Degree_Name).HasMaxLength(100);
            this.Property(e => e.EV_Mode_Of_Edu).HasMaxLength(100);
            this.Property(e => e.EV_Enroll_RollNo).HasMaxLength(100);
            this.Property(e => e.EV_RegNo_RegCode).HasMaxLength(100);
            this.Property(e => e.EV_Dur_Course).HasMaxLength(100);
            this.Property(e => e.EV_Course_Status).HasMaxLength(100);
            this.Property(e => e.EV_Specialization).HasMaxLength(200);
            this.Property(e => e.EV_Period_Course).HasMaxLength(100);
            this.Property(e => e.EV_Yr_Passing).HasMaxLength(100);
            this.Property(e => e.EV_Rslt_Obtain).HasMaxLength(100);
            this.Property(e => e.EV_Mode_of_Verf).HasMaxLength(100);
            this.Property(e => e.EV_Refre_Name_Dsg).HasMaxLength(100);
            this.Property(e => e.EV_Refre_Eid).HasMaxLength(100);
            this.Property(e => e.EV_Refre_ConNo).HasMaxLength(100);
            this.Property(e => e.EV_Attch_Doc_Genuine).HasMaxLength(100);
            this.Property(e => e.EV_Any_Other_Cmmnts_EduV).HasMaxLength(100);
            this.Property(e => e.EV_Other_Remarks).HasMaxLength(100);
            this.Property(e => e.EV_Division_CGPA).HasMaxLength(100);
            this.Property(e => e.EV_Official_Fee_Proof).HasMaxLength(100);
            this.Property(e => e.EV_Colg_Unvrsty_Affl).HasMaxLength(100);
            this.Property(e => e.EV_Others).HasMaxLength(200);
            this.Property(e => e.EV_Others2).HasMaxLength(200);
            this.Property(e => e.EV_Others3).HasMaxLength(200);
            this.Property(e => e.EV_Others4).HasMaxLength(200);
            this.Property(e => e.EV_Others5).HasMaxLength(200);
            this.Property(e => e.EV_Others6).HasMaxLength(200);
            this.Property(e => e.EV_Others7).HasMaxLength(200);
            this.Property(e => e.EV_Others8).HasMaxLength(200);
            this.Property(e => e.EV_Others9).HasMaxLength(200);
            this.Property(e => e.EV_Others10).HasMaxLength(200);
            this.Property(e => e.EV_Others11).HasMaxLength(200);
            this.Property(e => e.EV_Others12).HasMaxLength(200);
            this.Property(e => e.EV_Others13).HasMaxLength(200);
            this.Property(e => e.EV_Others14).HasMaxLength(200);
            this.Property(e => e.EV_Others15).HasMaxLength(200);
            this.Property(e => e.ATA_Reverse_Directory).HasMaxLength(200);
            this.Property(e => e.ATA_Residcl_Commrcl).HasMaxLength(200);
            this.Property(e => e.ATA_Stock_Exchnge).HasMaxLength(200);
            this.Property(e => e.ATA_Telphne_Directry_Srch).HasMaxLength(200);
            this.Property(e => e.ATA_Yellow_Pages).HasMaxLength(200);
            this.Property(e => e.ATA_Who_Domain).HasMaxLength(200);
            this.Property(e => e.ATA_GoogleSearch).HasMaxLength(200);
            this.Property(e => e.ATA_InfrastructureOfCmp).HasMaxLength(200);
            this.Property(e => e.ATA_Just_Dial).HasMaxLength(200);
            this.Property(e => e.ATA_Neighbor_Check1).HasMaxLength(200);
            this.Property(e => e.ATA_NASCOM_Empanelment).HasMaxLength(200);
            this.Property(e => e.ATA_Photograph).HasMaxLength(200);
            this.Property(e => e.ATA_Physical_Site).HasMaxLength(200);
            this.Property(e => e.ATA_Reg_Company).HasMaxLength(200);
            this.Property(e => e.ATA_PO_Courier_Check).HasMaxLength(200);
            this.Property(e => e.ATA_Network_Sol).HasMaxLength(200);
            this.Property(e => e.ATA_ApprxEmpWorking).HasMaxLength(200);
            this.Property(e => e.ATA_CID_No).HasMaxLength(200);
            this.Property(e => e.ATA_Cmpny_Addr).HasMaxLength(200);
            this.Property(e => e.ATA_Decoy_Call).HasMaxLength(200);
            this.Property(e => e.ATA_Cmpny_Website).HasMaxLength(100);

            this.Property(e => e.TypeRevert).HasMaxLength(50);
            this.Property(e => e.CheckStatus).HasMaxLength(50);
            this.Property(e => e.Severity).HasMaxLength(50);
            this.Property(e => e.ColorName).HasMaxLength(50);
            this.Property(e => e.ReportComments).HasMaxLength(3000);

            this.Property(e => e.VerifierDesignation).HasMaxLength(100);
            this.Property(e => e.VerifierContactNo).HasMaxLength(20);
            this.Property(e => e.VerifierMobileNo).HasMaxLength(20);
            this.Property(e => e.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(e => e.PQEducation).WithMany().HasForeignKey(e => e.EducationRowID).WillCascadeOnDelete(false);
        }
    }
}
