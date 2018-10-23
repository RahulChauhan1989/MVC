using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQAddressVerMap : EntityTypeConfiguration<PQAddressVer>
    {
        public PQAddressVerMap()
        {
            this.HasKey(a => a.AddressVerRowID);
            this.Property(a => a.AddressVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.AV_Add).HasMaxLength(200);
            this.Property(a => a.AV_Add_Line1).HasMaxLength(200);
            this.Property(a => a.AV_Add_Line2).HasMaxLength(200);
            this.Property(a => a.AV_Buldng_Street_name).HasMaxLength(100);
            this.Property(a => a.AV_Landmark).HasMaxLength(100);
            this.Property(a => a.AV_Add_Type).HasMaxLength(100);
            this.Property(a => a.AV_Dur_of_Stay).HasMaxLength(100);
            this.Property(a => a.AV_2_3BHK).HasMaxLength(50);
            this.Property(a => a.AV_Applcnt_Known_Hw_Mny_Yrs).HasMaxLength(50);
            this.Property(a => a.AV_Resp_Name).HasMaxLength(100);
            this.Property(a => a.AV_Resp_Relation_With_Cand).HasMaxLength(50);
            this.Property(a => a.AV_Resp_ConDet).HasMaxLength(200);
            this.Property(a => a.AV_Resp_ConNo).HasMaxLength(20);
            this.Property(a => a.AV_Neighbour_Name_No1).HasMaxLength(100);
            this.Property(a => a.AV_Neighbour_Name_No2).HasMaxLength(100);
            this.Property(a => a.AV_Resp_Remarks).HasMaxLength(200);
            this.Property(a => a.AV_Security_Confirm).HasMaxLength(100);
            this.Property(a => a.AV_Owned_Rent_Hypoth).HasMaxLength(100);
            this.Property(a => a.AV_New_Add_Det_Obtain).HasMaxLength(200);
            this.Property(a => a.AV_House_Photo_taken).HasMaxLength(20);
            this.Property(a => a.HousePhotographName).HasMaxLength(100);
            this.Property(a => a.AV_Buldng_Status).HasMaxLength(100);
            this.Property(a => a.AV_Color_of_Buldng).HasMaxLength(30);
            this.Property(a => a.AV_Interior_Condition).HasMaxLength(50);
            this.Property(a => a.AV_Ease_Locating).HasMaxLength(100);
            this.Property(a => a.AV_Gate_Color).HasMaxLength(30);
            this.Property(a => a.AV_Applcnt_Demons_Unsual_Behv).HasMaxLength(20);
            this.Property(a => a.AV_Idproof_Prov_Resp).HasMaxLength(30);
            this.Property(a => a.AV_Income_Source).HasMaxLength(100);
            this.Property(a => a.AV_Applcnt_Habitul_Borrow_Neigh).HasMaxLength(30);
            this.Property(a => a.AV_Any_Union_Poltcl_Affl_Fmly).HasMaxLength(30);
            this.Property(a => a.AV_Locality).HasMaxLength(50);
            this.Property(a => a.AV_Moral_Charac_Applcnt).HasMaxLength(20);
            this.Property(a => a.AV_Sec_field_Exe_Name).HasMaxLength(100);
            this.Property(a => a.AV_Time_Verification).HasMaxLength(20);
            this.Property(a => a.AV_Any_Other_Cmmnts_AV).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails6).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails7).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails8).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails9).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails10).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails11).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails12).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails13).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails14).HasMaxLength(200);
            this.Property(a => a.AV_OtherDetails15).HasMaxLength(200);

            this.Property(a => a.ATA_CID_No).HasMaxLength(50);
            this.Property(a => a.ATA_Cmpny_Addr).HasMaxLength(200);
            this.Property(a => a.ATA_ApprxEmpWorking).HasMaxLength(100);
            this.Property(a => a.ATA_Cmpny_Website).HasMaxLength(200);
            this.Property(a => a.ATA_Decoy_Call).HasMaxLength(200);
            this.Property(a => a.ATA_Reverse_Directory).HasMaxLength(200);
            this.Property(a => a.ATA_Residcl_Commrcl).HasMaxLength(200);
            this.Property(a => a.ATA_Stock_Exchnge).HasMaxLength(200);
            this.Property(a => a.ATA_Telphne_Directry_Srch).HasMaxLength(200);
            this.Property(a => a.ATA_Yellow_Pages).HasMaxLength(200);
            this.Property(a => a.ATA_Who_Domain).HasMaxLength(200);
            this.Property(a => a.ATA_GoogleSearch).HasMaxLength(200);
            this.Property(a => a.ATA_InfrastructureOfCmp).HasMaxLength(200);
            this.Property(a => a.ATA_Just_Dial).HasMaxLength(200);
            this.Property(a => a.ATA_Neighbor_Check1).HasMaxLength(200);
            this.Property(a => a.ATA_NASCOM_Empanelment).HasMaxLength(200);
            this.Property(a => a.ATA_Photograph).HasMaxLength(200);
            this.Property(a => a.ATA_Physical_Site).HasMaxLength(200);
            this.Property(a => a.ATA_Reg_Company).HasMaxLength(200);
            this.Property(a => a.ATA_PO_Courier_Check).HasMaxLength(200);
            this.Property(a => a.ATA_Network_Sol).HasMaxLength(200);

            this.Property(a => a.TypeRevert).HasMaxLength(50);
            this.Property(a => a.CheckStatus).HasMaxLength(50);
            this.Property(a => a.Severity).HasMaxLength(50);
            this.Property(a => a.ColorName).HasMaxLength(50);
            this.Property(a => a.ReportComments).HasMaxLength(3000);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);
            
            this.HasRequired(c => c.PQAddress).WithMany().HasForeignKey(c => c.AddressRowID).WillCascadeOnDelete(false);
        }
    }
}
