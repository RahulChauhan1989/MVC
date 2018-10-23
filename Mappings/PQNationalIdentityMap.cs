using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQNationalIdentityMap : EntityTypeConfiguration<PQNationalIdentity>
    {
        public PQNationalIdentityMap()
        {
            this.HasKey(n => n.NationalIdentityRowID);
            this.Property(n => n.NationalIdentityRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(n => n.UniqueComponentID).HasMaxLength(20);
            this.Property(n => n.NIC_Cand_Name).HasMaxLength(100);
            this.Property(n => n.NIC_Sec_Ref_Id).HasMaxLength(50);
            this.Property(n => n.NIC_ID_No).HasMaxLength(50);
            this.Property(n => n.NIC_Passport_No).HasMaxLength(20);
            this.Property(n => n.NIC_SSN_NO).HasMaxLength(50);
            this.Property(n => n.NIC_Pan_No).HasMaxLength(20);
            this.Property(n => n.NIC_Voter_Id_No).HasMaxLength(20);
            this.Property(n => n.NIC_Dvng_Liscense_No).HasMaxLength(20);
            this.Property(n => n.NIC_Aadhar_Card_No).HasMaxLength(20);
            this.Property(n => n.NIC_Place_Issue).HasMaxLength(100);
            this.Property(n => n.NIC_Place_Residnce).HasMaxLength(100);
            this.Property(n => n.NIC_Type_Id_Card).HasMaxLength(100);
            this.Property(n => n.NIC_Reg_Doc_Type).HasMaxLength(100);
            this.Property(n => n.NIC_RegNo).HasMaxLength(100);
            this.Property(n => n.NIC_PinCode).HasMaxLength(10);
            this.Property(n => n.NIC_Name_Key_Personnel).HasMaxLength(100);
            this.Property(n => n.NIC_AliasFname).HasMaxLength(50);
            this.Property(n => n.NIC_Alias_Lname).HasMaxLength(50);
            this.Property(n => n.NIC_Country_Iss_Passport).HasMaxLength(100);
            this.Property(n => n.NIC_Gender).HasMaxLength(20);
            this.Property(n => n.NIC_Id_CardNo).HasMaxLength(50);
            this.Property(n => n.NIC_Identity_Prov).HasMaxLength(100);
            this.Property(n => n.NIC_Nationality).HasMaxLength(100);
            this.Property(n => n.NIC_OtherDetails).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails2).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails3).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails4).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails5).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails6).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails7).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails8).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails9).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails10).HasMaxLength(200);
            this.Property(n => n.ATA_CID_No).HasMaxLength(100);
            this.Property(n => n.ATA_Cmpny_Addr).HasMaxLength(100);

            this.Property(n => n.CheckStatus).HasMaxLength(20);
            this.Property(n => n.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(n => n.Remarks).HasMaxLength(200);

            //this.Property(n => n.Mailto).HasMaxLength(200);
            //this.Property(n => n.MailtoClient).HasMaxLength(200);
            //this.Property(n => n.MailedBy).HasMaxLength(100);
            //this.Property(n => n.ClientComment).HasMaxLength(100);
            //this.Property(n => n.INFRemarks).HasMaxLength(200);

            this.HasRequired(n => n.PQClientMaster).WithMany().HasForeignKey(n => n.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(n => n.PQPersonal).WithMany().HasForeignKey(n => n.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(n => n.MasterCheckFamily).WithMany().HasForeignKey(n => n.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(n => n.MasterSubCheckFamily).WithMany().HasForeignKey(n => n.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
