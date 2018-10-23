using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQReferenceMap : EntityTypeConfiguration<PQReference>
    {
        public PQReferenceMap()
        {
            this.HasKey(r => r.ReferenceRowID);
            this.Property(r => r.ReferenceRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(r => r.UniqueComponentID).HasMaxLength(20);
            this.Property(r => r.RV_CandidateName).HasMaxLength(100);
            this.Property(r => r.RV_Sec_Ref_Id).HasMaxLength(50);
            this.Property(r => r.RV_OrganisationName).HasMaxLength(100);
            this.Property(r => r.RV_RefereeName).HasMaxLength(100);
            this.Property(r => r.RV_Refere_Desig).HasMaxLength(100);
            this.Property(r => r.RV_Refere_Add).HasMaxLength(200);
            this.Property(r => r.RV_Refre_MobNo).HasMaxLength(20);
            this.Property(r => r.RV_Refre_Eid).HasMaxLength(100);
            this.Property(r => r.RV_Know_Long).HasMaxLength(200);
            this.Property(r => r.RV_Tenure_Emp).HasMaxLength(100);
            this.Property(r => r.RV_Dsg_RC).HasMaxLength(100);
            this.Property(r => r.RV_CTC).HasMaxLength(50);
            this.Property(r => r.RV_Reason_Leav).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails2).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails3).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails4).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails5).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails6).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails7).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails8).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails9).HasMaxLength(200);
            this.Property(r => r.RV_OtherDetails10).HasMaxLength(200);
            this.Property(r => r.ATA_CID_No).HasMaxLength(50);
            this.Property(r => r.ATA_Cmpny_Addr).HasMaxLength(200);

            this.Property(r => r.CheckStatus).HasMaxLength(20);
            this.Property(r => r.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(r => r.Remarks).HasMaxLength(200);

            //this.Property(r => r.Mailto).HasMaxLength(200);
            //this.Property(r => r.MailtoClient).HasMaxLength(200);
            //this.Property(r => r.MailedBy).HasMaxLength(100);
            //this.Property(r => r.ClientComment).HasMaxLength(100);
            //this.Property(r => r.INFRemarks).HasMaxLength(200);

            this.HasRequired(r => r.PQClientMaster).WithMany().HasForeignKey(r => r.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(r => r.PQPersonal).WithMany().HasForeignKey(r => r.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(r => r.MasterCheckFamily).WithMany().HasForeignKey(r => r.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(r => r.MasterSubCheckFamily).WithMany().HasForeignKey(r => r.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
