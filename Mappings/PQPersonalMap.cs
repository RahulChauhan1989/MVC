using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQPersonalMap : EntityTypeConfiguration<PQPersonal>
    {
        public PQPersonalMap()
        {
            this.HasKey(t => t.PersonalRowID);
            this.Property(t => t.PersonalRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.ClientRefID).HasMaxLength(100);
            this.Property(t => t.CompanyRefNo).HasMaxLength(100);
            this.Property(t => t.CandidateCode).HasMaxLength(100);
            this.Property(t => t.CandTitle).HasMaxLength(15).IsRequired();
            this.Property(t => t.Name).HasMaxLength(50).IsRequired();
            this.Property(t => t.MiddleName).HasMaxLength(50);
            this.Property(t => t.LastName).HasMaxLength(50);
            this.Property(t => t.FatherTitle).HasMaxLength(15);
            this.Property(t => t.FatherName).HasMaxLength(50);
            this.Property(t => t.FatherMiddleName).HasMaxLength(50);
            this.Property(t => t.FatherLastName).HasMaxLength(50);
            this.Property(t => t.Gender).HasMaxLength(10).IsRequired();
            this.Property(t => t.MaritalStatus).HasMaxLength(15);
            this.Property(t => t.MobileNo).HasMaxLength(20);
            this.Property(t => t.AlternateNo).HasMaxLength(20);
            this.Property(t => t.EmailID).HasMaxLength(100);
            this.Property(t => t.AlternateEmailID).HasMaxLength(100);
            this.Property(t => t.STD).HasMaxLength(10);
            this.Property(t => t.ResidencePhoneNo).HasMaxLength(20);
            this.Property(t => t.PanCardNo).HasMaxLength(100);
            this.Property(t => t.PassportNo).HasMaxLength(100);
            this.Property(t => t.AadhaarCardNo).HasMaxLength(100);
            this.Property(t => t.DrivingLicenseNo).HasMaxLength(100);
            this.Property(t => t.VoterIDCardNo).HasMaxLength(100);
            this.Property(t => t.CandidateType).HasMaxLength(50);
            this.Property(t => t.Catagory).HasMaxLength(50);
            this.Property(t => t.Nationality).HasMaxLength(50);
            this.Property(t => t.EmployeeID).HasMaxLength(100);
            this.Property(t => t.Designation).HasMaxLength(100);
            this.Property(t => t.PlaceofJoining).HasMaxLength(100);
            this.Property(t => t.NationalSkills).HasMaxLength(100);
            this.Property(t => t.SSNNo).HasMaxLength(50);
            this.Property(t => t.CaseType).HasMaxLength(20);
            this.Property(t => t.Remark).HasMaxLength(200);
            this.Property(t => t.FinalColor).HasMaxLength(50);
            this.Property(t => t.FromType).HasMaxLength(50);
            this.Property(t => t.DetailsEnteredBy).HasMaxLength(50);
            this.Property(t => t.ProcessName).HasMaxLength(70);
            this.Property(t => t.BusinessName).HasMaxLength(50);
            this.Property(t => t.Type).HasMaxLength(50);
            this.Property(t => t.SpouseName).HasMaxLength(80);
            this.Property(t => t.SpouseMiddleName).HasMaxLength(80);
            this.Property(t => t.SpouseLastName).HasMaxLength(80);
            this.Property(t => t.OtherDetails).HasMaxLength(100);
            this.Property(t => t.OtherDetails1).HasMaxLength(100);
            this.Property(t => t.OtherDetails2).HasMaxLength(100);
            this.Property(t => t.CaseStatus).HasMaxLength(30);
            this.Property(t => t.FinalStatus).HasMaxLength(30);

            this.Property(t => t.DEScanCaseStatus).HasMaxLength(20);
            this.Property(t => t.DECaseStatus).HasMaxLength(20);
            this.Property(t => t.DEQCCaseStatus).HasMaxLength(20);
            this.Property(t => t.RWQCMgrCaseStatus).HasMaxLength(20);
            this.Property(t => t.RWQCTLCaseStatus).HasMaxLength(20);
            this.Property(t => t.RWQCTMCaseStatus).HasMaxLength(20);
            this.Property(t => t.FinalRptSendStatus).HasMaxLength(20);
            this.Property(t => t.InterimRptSendStatus).HasMaxLength(20);
            this.Property(t => t.ReportUploadedName).HasMaxLength(100);

            this.HasRequired(t => t.PQClientMaster).WithMany().HasForeignKey(t => t.ClientRowID).WillCascadeOnDelete(false);
        }
    }
}
