using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEducationMap : EntityTypeConfiguration<PQEducation>
    {
        public PQEducationMap()
        {

            this.HasKey(e => e.EducationRowId);
            this.Property(e => e.EducationRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.UniqueComponentID).HasMaxLength(20);
            this.Property(e => e.EV_Cand_Name).HasMaxLength(100).IsRequired();
            this.Property(e => e.EV_Sec_Ref_Id).HasMaxLength(50);
            this.Property(e => e.EV_Cand_Name_Supp_Edu_Doc).HasMaxLength(100);
            this.Property(e => e.EV_Colg_Schl_Inst_Add_ConDet).HasMaxLength(200);
            this.Property(e => e.EV_Mode_Of_Edu).HasMaxLength(50);
            this.Property(e => e.EV_Enroll_RollNo).HasMaxLength(50);
            this.Property(e => e.EV_RegNo_RegCode).HasMaxLength(50);
            this.Property(e => e.EV_Dur_Course).HasMaxLength(50);
            this.Property(e => e.EV_Course_Status).HasMaxLength(50);
            this.Property(e => e.EV_Specialization).HasMaxLength(100);
            this.Property(e => e.EV_Period_Course).HasMaxLength(100);
            this.Property(e => e.EV_Yr_Passing).HasMaxLength(10);
            this.Property(e => e.EV_Division_CGPA).HasMaxLength(50);
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
            this.Property(e => e.ATA_CID_No).HasMaxLength(50);
            this.Property(e => e.ATA_Cmpny_Addr).HasMaxLength(200);

            this.Property(e => e.CheckStatus).HasMaxLength(20);
            this.Property(e => e.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(e => e.Remarks).HasMaxLength(200);

            //this.Property(e => e.Mailto).HasMaxLength(200);
            //this.Property(e => e.MailtoClient).HasMaxLength(200);
            //this.Property(e => e.MailedBy).HasMaxLength(100);
            //this.Property(e => e.ClientComment).HasMaxLength(100);
            //this.Property(e => e.INFRemarks).HasMaxLength(200);

            this.HasRequired(e => e.PQClientMaster).WithMany().HasForeignKey(e => e.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.PQPersonal).WithMany().HasForeignKey(e => e.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.MasterCheckFamily).WithMany().HasForeignKey(e => e.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.MasterSubCheckFamily).WithMany().HasForeignKey(e => e.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
