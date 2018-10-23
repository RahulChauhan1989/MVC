using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQCVValidationMap:EntityTypeConfiguration<PQCVValidation>
    {
        public PQCVValidationMap()
        {
            this.HasKey(c => c.CVValidationRowID);
            this.Property(c => c.CVValidationRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(c=>c.CV_Qualification  ).HasMaxLength(100);
           this.Property(c=>c.ATA_CID_No        ).HasMaxLength(100);
           this.Property(c=>c.ATA_Cmpny_Addr    ).HasMaxLength(100);
           this.Property(c=>c.CV_Others         ).HasMaxLength(200);
           this.Property(c=>c.CV_Others2        ).HasMaxLength(200);
           this.Property(c=>c.CV_Others3        ).HasMaxLength(200);
           this.Property(c=>c.CV_Others4        ).HasMaxLength(200);
           this.Property(c=>c.CV_Others5        ).HasMaxLength(200);
            this.Property(c => c.CV_OtherProof).HasMaxLength(200);


            this.Property(a => a.Mailto).HasMaxLength(200);
            this.Property(a => a.MailtoClient).HasMaxLength(200);
            this.Property(a => a.MailedBy).HasMaxLength(100);
            this.Property(a => a.ClientComment).HasMaxLength(100);
            this.Property(a => a.INFRemarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
