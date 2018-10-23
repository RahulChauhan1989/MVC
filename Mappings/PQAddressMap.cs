using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQAddressMap : EntityTypeConfiguration<PQAddress>
    {
        public PQAddressMap()
        {
            this.HasKey(a => a.AddressRowID);
            this.Property(a => a.AddressRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.UniqueComponentID).HasMaxLength(20);
            this.Property(a => a.AV_Cand_Name).HasMaxLength(100);
            this.Property(a => a.AV_Sec_Ref_No).HasMaxLength(50);
            this.Property(a => a.AV_Add).HasMaxLength(200);
            this.Property(a => a.AV_Add_Line1).HasMaxLength(200);
            this.Property(a => a.AV_Add_Line2).HasMaxLength(200);
            this.Property(a => a.AV_Buldng_Street_name).HasMaxLength(100);
            this.Property(a => a.AV_Landmark).HasMaxLength(100);
            this.Property(a => a.AV_Add_Type).HasMaxLength(100);
            this.Property(a => a.AV_Dur_of_Stay).HasMaxLength(100);
            this.Property(a => a.AV_Owner_Name).HasMaxLength(100);
            this.Property(a => a.AV_Owner_ConNo).HasMaxLength(20);
            this.Property(a => a.AV_NickName).HasMaxLength(50);
            this.Property(a => a.AV_Name_Chngd_Effect_Frm).HasMaxLength(50);
            this.Property(a => a.AV_Doc_Prov_Proof_Add).HasMaxLength(200);
            this.Property(a => a.AddressProofFileName).HasMaxLength(200);
            this.Property(a => a.AV_Doc_Details).HasMaxLength(200);
            this.Property(a => a.DocumentDetailsFileName).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails2).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails3).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails4).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails5).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails6).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails7).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails8).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails9).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails10).HasMaxLength(200);
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
