using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQEmploymentMap : EntityTypeConfiguration<PQEmployment>
    {
        public PQEmploymentMap()
        {
            this.HasKey(t => t.EmploymentRowId);
            this.Property(t => t.EmploymentRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(a => a.UniqueComponentID).HasMaxLength(20);
            this.Property(t => t.EV_CandidateName).HasMaxLength(100).IsRequired();
            this.Property(t => t.EV_SecuritasReferenceID).HasMaxLength(50);
            this.Property(t => t.EV_OrganisationName).HasMaxLength(100);
            this.Property(t => t.EV_CmpLocation).HasMaxLength(100);
            this.Property(t => t.EV_CmpNameAddress).HasMaxLength(200);
            this.Property(t => t.EV_EmployeeName).HasMaxLength(100);
            this.Property(t => t.EV_EmployeeCode).HasMaxLength(50);
            this.Property(t => t.EV_EmploymentPeriod).HasMaxLength(100);
            this.Property(t => t.EV_CandidateTenureWorked).HasMaxLength(100);
            this.Property(t => t.EV_EmployeeTenure).HasMaxLength(100);
            this.Property(t => t.EV_Designation).HasMaxLength(50);           
            this.Property(t => t.EV_EmpType).HasMaxLength(50);
            this.Property(t => t.EV_Department).HasMaxLength(100);
            this.Property(t => t.EV_CmpCost).HasMaxLength(50);
            this.Property(t => t.EV_last_sal).HasMaxLength(50);
            this.Property(t => t.EV_leavingReason).HasMaxLength(100);          
            this.Property(t => t.EV_DiscontinueServiceReason).HasMaxLength(100);         
            this.Property(t => t.EV_ReportingManagerName).HasMaxLength(100);           
            this.Property(t => t.EV_Rptng_Mgr_Name_Ph).HasMaxLength(100);
            this.Property(t => t.EV_Rptng_Mgr_Name_ConDet).HasMaxLength(100);
            this.Property(t => t.EV_Sub_Rptng_Mgr_Name_Dsg_EidPh).HasMaxLength(200);
            this.Property(t => t.EV_Supervisor).HasMaxLength(100);
            this.Property(t => t.EV_Sup_Name_Dsg).HasMaxLength(150);
            this.Property(t => t.EV_FormalitiesExit).HasMaxLength(100);
            this.Property(t => t.EV_FullFinalFormalities).HasMaxLength(100);
            this.Property(t => t.EV_ExitFormalitiesPending).HasMaxLength(100);
            this.Property(t => t.EV_HandledResponsibilities).HasMaxLength(200);
            this.Property(t => t.EV_ResponsibilitiesHandled).HasMaxLength(200);
            
            this.Property(t => t.EV_OtherDetails).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails2).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails3).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails4).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails5).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails6).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails7).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails8).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails9).HasMaxLength(200);
            this.Property(t => t.EV_OtherDetails10).HasMaxLength(200);

            this.Property(a => a.ATA_CID_No).HasMaxLength(50);
            this.Property(a => a.ATA_Cmpny_Addr).HasMaxLength(200);

            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            //this.Property(a => a.Mailto).HasMaxLength(200);
            //this.Property(a => a.MailtoClient).HasMaxLength(200);
            //this.Property(a => a.MailedBy).HasMaxLength(100);
            //this.Property(a => a.ClientComment).HasMaxLength(100);
            //this.Property(a => a.INFRemarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);


        }
    }
}
