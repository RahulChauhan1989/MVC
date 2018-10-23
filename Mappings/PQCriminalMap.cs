using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCriminalMap : EntityTypeConfiguration<PQCriminal>
    {
        public PQCriminalMap()
        {
            this.HasKey  (c => c.CriminalRowId);
            this.Property(c => c.CriminalRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.UniqueComponentID).HasMaxLength(20);
            this.Property(c => c.CRV_Cand_Name).HasMaxLength(100).IsRequired();
            this.Property(c => c.CRV_Sec_Ref_No).HasMaxLength(50);
            this.Property(c => c.CRV_Father_Name).HasMaxLength(100);
            this.Property(c => c.CRV_First_Name).HasMaxLength(50);
            this.Property(c => c.CRV_Last_Name).HasMaxLength(50);
            this.Property(c => c.CRV_Nationality).HasMaxLength(50);
            this.Property(c => c.CRV_Nationality_On_Passport).HasMaxLength(50);
            this.Property(c => c.CRV_Country_of_Issue).HasMaxLength(100);
            this.Property(c => c.CRV_Addr_Type).HasMaxLength(50);
            this.Property(c => c.CRV_Current_Addr).HasMaxLength(200);
            this.Property(c => c.CRV_Prev_Addr1).HasMaxLength(200);
            this.Property(c => c.CRV_Prev_Addr2).HasMaxLength(200);
            this.Property(c => c.CRV_Prev_Addr3).HasMaxLength(200);
            this.Property(c => c.CRV_Prev_Addr4).HasMaxLength(200);
            this.Property(c => c.CRV_Permanent_Addr).HasMaxLength(200);
            this.Property(c => c.CRV_Period_Of_Stay).HasMaxLength(100);
            this.Property(c => c.CRV_Gender).HasMaxLength(20);
            this.Property(c => c.CRV_Identity_No).HasMaxLength(100);
            this.Property(c => c.CRV_Identity_Prov).HasMaxLength(200);
            this.Property(c => c.CRV_Doc_Received).HasMaxLength(200);            
            this.Property(c => c.CRV_Others).HasMaxLength(200);
            this.Property(c => c.CRV_Others2).HasMaxLength(200);
            this.Property(c => c.CRV_Others3).HasMaxLength(200);
            this.Property(c => c.CRV_Others4).HasMaxLength(200);
            this.Property(c => c.CRV_Others5).HasMaxLength(200);
            this.Property(c => c.CRV_Others6).HasMaxLength(200);
            this.Property(c => c.CRV_Others7).HasMaxLength(200);
            this.Property(c => c.CRV_Others8).HasMaxLength(200);
            this.Property(c => c.CRV_Others9).HasMaxLength(200);
            this.Property(c => c.CRV_Others10).HasMaxLength(200);
            this.Property(c => c.ATA_CID_No).HasMaxLength(50);
            this.Property(c => c.ATA_Cmpny_Addr).HasMaxLength(200);

            this.Property(c => c.CheckStatus).HasMaxLength(20);
            this.Property(c => c.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(c => c.Remarks).HasMaxLength(200);

            //this.Property(c => c.Mailto).HasMaxLength(200);
            //this.Property(c => c.MailtoClient).HasMaxLength(200);
            //this.Property(c => c.MailedBy).HasMaxLength(100);
            //this.Property(c => c.ClientComment).HasMaxLength(100);
            //this.Property(c => c.INFRemarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
