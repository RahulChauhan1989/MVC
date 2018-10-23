using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQNationalIdentityVerMap : EntityTypeConfiguration<PQNationalIdentityVer>
    {
        public PQNationalIdentityVerMap()
        {
            this.HasKey(n => n.NationalIdentityVerRowID);
            this.Property(n => n.NationalIdentityVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(n => n.NIC_Cand_Name).HasMaxLength(100);
            this.Property(n => n.NIC_Any_Other_Cmmnts_NIC).HasMaxLength(200);
            this.Property(n => n.NIC_ID_No).HasMaxLength(100);
            this.Property(n => n.NIC_Verified_By).HasMaxLength(100);
            this.Property(n => n.NIC_Date_Issue).HasMaxLength(100);
            this.Property(n => n.NIC_Expiry_Date).HasMaxLength(100);
            this.Property(n => n.NIC_Validity_Status).HasMaxLength(100);
            this.Property(n => n.NIC_Passport_No).HasMaxLength(100);
            this.Property(n => n.NIC_SSN_NO).HasMaxLength(100);
            this.Property(n => n.NIC_Pan_No).HasMaxLength(100);
            this.Property(n => n.NIC_Voter_Id_No).HasMaxLength(100);
            this.Property(n => n.NIC_Dvng_Liscense_No).HasMaxLength(100);
            this.Property(n => n.NIC_Aadhar_Card_No).HasMaxLength(100);
            this.Property(n => n.NIC_Place_Issue).HasMaxLength(100);
            this.Property(n => n.NIC_Place_Residnce).HasMaxLength(100);
            this.Property(n => n.NIC_Time_Verf).HasMaxLength(100);
            this.Property(n => n.NIC_Type_Id_Card).HasMaxLength(100);
            this.Property(n => n.NIC_Reg_Doc_Type).HasMaxLength(100);
            this.Property(n => n.NIC_RegNo).HasMaxLength(100);
            this.Property(n => n.NIC_Name_Field_Executive).HasMaxLength(100);
            this.Property(n => n.NIC_PinCode).HasMaxLength(100);
            this.Property(n => n.NIC_Relation_Key_Personal).HasMaxLength(100);
            this.Property(n => n.NIC_Verified_Frm).HasMaxLength(100);
            this.Property(n => n.NIC_Auth_Details_Name).HasMaxLength(100);
            this.Property(n => n.NIC_Dsg).HasMaxLength(100);
            this.Property(n => n.NIC_Eid).HasMaxLength(100);
            this.Property(n => n.NIC_MobNo).HasMaxLength(100);
            this.Property(n => n.NIC_Name_Key_Personnel).HasMaxLength(100);
            this.Property(n => n.NIC_AliasFname).HasMaxLength(100);
            this.Property(n => n.NIC_Alias_Lname).HasMaxLength(100);
            this.Property(n => n.NIC_Country_Iss_Passport).HasMaxLength(100);
            this.Property(n => n.NIC_Id_CardNo).HasMaxLength(100);
            this.Property(n => n.NIC_Identity_Prov).HasMaxLength(100);
            this.Property(n => n.NIC_Name_Changed_Effect_Frm).HasMaxLength(100);
            this.Property(n => n.NIC_Nationality).HasMaxLength(100);
            this.Property(n => n.NIC_PhotoID_Verif).HasMaxLength(100);
            this.Property(n => n.NIC_Any_Other_Remarks_NIC).HasMaxLength(100);
            this.Property(n => n.NIC_OtherDetails6).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails7).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails8).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails9).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails10).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails11).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails12).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails13).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails14).HasMaxLength(200);
            this.Property(n => n.NIC_OtherDetails15).HasMaxLength(200);
            this.Property(n => n.ATA_Reverse_Directory).HasMaxLength(200);
            this.Property(n => n.ATA_Residcl_Commrcl).HasMaxLength(200);
            this.Property(n => n.ATA_Stock_Exchnge).HasMaxLength(200);
            this.Property(n => n.ATA_Telphne_Directry_Srch).HasMaxLength(200);
            this.Property(n => n.ATA_Yellow_Pages).HasMaxLength(200);
            this.Property(n => n.ATA_Who_Domain).HasMaxLength(200);
            this.Property(n => n.ATA_GoogleSearch).HasMaxLength(200);
            this.Property(n => n.ATA_InfrastructureOfCmp).HasMaxLength(200);
            this.Property(n => n.ATA_Just_Dial).HasMaxLength(200);
            this.Property(n => n.ATA_Neighbor_Check1).HasMaxLength(200);
            this.Property(n => n.ATA_NASCOM_Empanelment).HasMaxLength(200);
            this.Property(n => n.ATA_Photograph).HasMaxLength(200);
            this.Property(n => n.ATA_Physical_Site).HasMaxLength(200);
            this.Property(n => n.ATA_Reg_Company).HasMaxLength(200);
            this.Property(n => n.ATA_PO_Courier_Check).HasMaxLength(200);
            this.Property(n => n.ATA_Network_Sol).HasMaxLength(200);
            this.Property(n => n.ATA_ApprxEmpWorking).HasMaxLength(200);
            this.Property(n => n.ATA_CID_No).HasMaxLength(200);
            this.Property(n => n.ATA_Cmpny_Addr).HasMaxLength(200);
            this.Property(n => n.ATA_Decoy_Call).HasMaxLength(200);
            this.Property(n => n.ATA_Cmpny_Website).HasMaxLength(200);

            this.Property(n => n.TypeRevert).HasMaxLength(50);
            this.Property(n => n.CheckStatus).HasMaxLength(50);
            this.Property(n => n.Severity).HasMaxLength(50);
            this.Property(n => n.ColorName).HasMaxLength(50);
            this.Property(n => n.ReportComments).HasMaxLength(3000);

            this.Property(n => n.VerifierDesignation).HasMaxLength(100);
            this.Property(n => n.VerifierContactNo).HasMaxLength(20);
            this.Property(n => n.VerifierMobileNo).HasMaxLength(20);
            this.Property(n => n.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(n => n.PQNationalIdentity).WithMany().HasForeignKey(n => n.NationalIdentityRowID).WillCascadeOnDelete(false);
        }
    }
}
