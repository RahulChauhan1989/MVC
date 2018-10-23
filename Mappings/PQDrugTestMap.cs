using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQDrugTestMap:EntityTypeConfiguration<PQDrugTest>
    {
        public PQDrugTestMap()
        {
            this.HasKey(d => d.DrugTestRowID);
            this.Property(d => d.DrugTestRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.UniqueComponentID).HasMaxLength(20);
            this.Property(d => d.DT_Cand_Name).HasMaxLength(100);
            this.Property(d => d.DT_Sec_Ref_Id).HasMaxLength(50);
            this.Property(d => d.DT_Others).HasMaxLength(200);
            this.Property(d => d.DT_Others2).HasMaxLength(200);
            this.Property(d => d.ATA_CID_No).HasMaxLength(50);
            this.Property(d => d.ATA_Cmpny_Addr).HasMaxLength(200);

            this.Property(d => d.CheckStatus).HasMaxLength(20);
            this.Property(d => d.CaseStatus).HasMaxLength(20);
            this.Property(d => d.Remarks).HasMaxLength(200);

            this.Property(d => d.Mailto).HasMaxLength(200);
            this.Property(d => d.MailtoClient).HasMaxLength(200);
            this.Property(d => d.MailedBy).HasMaxLength(100);
            this.Property(d => d.ClientComment).HasMaxLength(100);
            this.Property(d => d.INFRemarks).HasMaxLength(200);

            this.HasRequired(d => d.PQClientMaster).WithMany().HasForeignKey(d => d.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.PQPersonal).WithMany().HasForeignKey(d => d.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.MasterCheckFamily).WithMany().HasForeignKey(d => d.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.MasterSubCheckFamily).WithMany().HasForeignKey(d => d.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
