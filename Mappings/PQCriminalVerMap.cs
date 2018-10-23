using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQCriminalVerMap : EntityTypeConfiguration<PQCriminalVer>
    {
        public PQCriminalVerMap()
        {
            this.HasKey(t => t.CriminalVerRowId);
            this.Property(t => t.CriminalVerRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.CRV_Cand_Name).HasMaxLength(100);          
            this.Property(t => t.CRV_Father_Name).HasMaxLength(100);
            this.Property(t => t.CRV_First_Name).HasMaxLength(100);
            this.Property(t => t.CRV_Last_Name).HasMaxLength(100);
            this.Property(t => t.CRV_Nationality).HasMaxLength(100);
            this.Property(t => t.CRV_Name_Chngd_Effect_Frm).HasMaxLength(100);
            this.Property(t => t.CRV_Nationality_On_Passport).HasMaxLength(100);
            this.Property(t => t.CRV_Country_of_Issue).HasMaxLength(100);
            this.Property(t => t.CRV_Addr_Type).HasMaxLength(200);
            this.Property(t => t.CRV_Current_Addr).HasMaxLength(100);
            this.Property(t => t.CRV_Prev_Addr1).HasMaxLength(200);
            this.Property(t => t.CRV_Prev_Addr2).HasMaxLength(200);
            this.Property(t => t.CRV_Prev_Addr3).HasMaxLength(200);
            this.Property(t => t.CRV_Prev_Addr4).HasMaxLength(200);
            this.Property(t => t.CRV_Permanent_Addr).HasMaxLength(100);
            this.Property(t => t.CRV_Gender).HasMaxLength(30);
            this.Property(t => t.CRV_Identity_No).HasMaxLength(100);
            this.Property(t => t.CRV_Identity_Prov).HasMaxLength(100);
            this.Property(t => t.CRV_Doc_Received).HasMaxLength(100);
            this.Property(t => t.CRV_Dur_Yr_Covered).HasMaxLength(100);
            this.Property(t => t.CRV_Pol_Station_Name).HasMaxLength(100);
            this.Property(t => t.CRV_Pol_Authority_Name).HasMaxLength(100);
            this.Property(t => t.CRV_Pol_Authority_Desg).HasMaxLength(100);
            this.Property(t => t.CRV_Criminal_Verf).HasMaxLength(100);
            this.Property(t => t.CRV_Type_of_Revert).HasMaxLength(100);            
            this.Property(t => t.CRV_Verfier_Cmmnts).HasMaxLength(200);
            this.Property(t => t.CRV_St_Pol_Most_Wanted).HasMaxLength(100);
            this.Property(t => t.CRV_CBI_Most_Wanted).HasMaxLength(100);
            this.Property(t => t.CRV_Interpol_Most_Wanted).HasMaxLength(100);
            this.Property(t => t.CRV_Allied_Terrorist_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Crimes_Dishonest_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Corruption_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Financ_Rgltry_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Fraud_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Law_Enforce_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Sex_Crime_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Violent_Crime_Dataset).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Terrorist_Risk).HasMaxLength(100);
            this.Property(t => t.CRV_Global_Money_Laund).HasMaxLength(100);
            this.Property(t => t.CRV_Civil_Court_Action).HasMaxLength(100);
            this.Property(t => t.CRV_District_Court).HasMaxLength(100);
            this.Property(t => t.CRV_State_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Civil_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Special_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Session_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Tribunals).HasMaxLength(100);
            this.Property(t => t.CRV_Any_Other_Cmmnts_CRV).HasMaxLength(200);
            this.Property(t => t.CRV_Magistrate_Court).HasMaxLength(100);
            this.Property(t => t.CRV_District_Civil_Court).HasMaxLength(100);
            this.Property(t => t.CRV_St_High_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Supreme_Court).HasMaxLength(100);
            this.Property(t => t.CRV_Criminal_Appeal).HasMaxLength(100);
            this.Property(t => t.CRV_Private_Complain_Rpt).HasMaxLength(100);
            this.Property(t => t.CRV_Others6).HasMaxLength(100);
            this.Property(t => t.CRV_Others7).HasMaxLength(100);
            this.Property(t => t.CRV_Others8).HasMaxLength(100);
            this.Property(t => t.CRV_Others9).HasMaxLength(100);
            this.Property(t => t.CRV_Others10).HasMaxLength(100);
            this.Property(t => t.CRV_Others11).HasMaxLength(100);
            this.Property(t => t.CRV_Others12).HasMaxLength(100);
            this.Property(t => t.CRV_Others13).HasMaxLength(100);
            this.Property(t => t.CRV_Others14).HasMaxLength(100);
            this.Property(t => t.CRV_Others15).HasMaxLength(100);
            this.Property(t => t.ATA_Reverse_Directory).HasMaxLength(200);
            this.Property(t => t.ATA_Residcl_Commrcl).HasMaxLength(200);
            this.Property(t => t.ATA_Stock_Exchnge).HasMaxLength(200);
            this.Property(t => t.ATA_Telphne_Directry_Srch).HasMaxLength(200);
            this.Property(t => t.ATA_Yellow_Pages).HasMaxLength(200);
            this.Property(t => t.ATA_Who_Domain).HasMaxLength(200);
            this.Property(t => t.ATA_GoogleSearch).HasMaxLength(200);
            this.Property(t => t.ATA_InfrastructureOfCmp).HasMaxLength(200);
            this.Property(t => t.ATA_Just_Dial).HasMaxLength(200);
            this.Property(t => t.ATA_Neighbor_Check1).HasMaxLength(200);
            this.Property(t => t.ATA_NASCOM_Empanelment).HasMaxLength(100);
            this.Property(t => t.ATA_Photograph).HasMaxLength(200);
            this.Property(t => t.ATA_Physical_Site).HasMaxLength(200);
            this.Property(t => t.ATA_Reg_Company).HasMaxLength(200);
            this.Property(t => t.ATA_PO_Courier_Check).HasMaxLength(200);
            this.Property(t => t.ATA_Network_Sol).HasMaxLength(200);
            this.Property(t => t.ATA_ApprxEmpWorking).HasMaxLength(200);
            this.Property(t => t.ATA_CID_No).HasMaxLength(200);
            this.Property(t => t.ATA_Cmpny_Addr).HasMaxLength(200);
            this.Property(t => t.ATA_Decoy_Call).HasMaxLength(200);
            this.Property(t => t.ATA_Cmpny_Website).HasMaxLength(200);

            this.Property(t => t.TypeRevert).HasMaxLength(50);
            this.Property(t => t.CheckStatus).HasMaxLength(50);
            this.Property(t => t.Severity).HasMaxLength(50);
            this.Property(t => t.ColorName).HasMaxLength(50);
            this.Property(t => t.ReportComments).HasMaxLength(3000);

            this.Property(t => t.VerifierDesignation).HasMaxLength(100);
            this.Property(t => t.VerifierContactNo).HasMaxLength(20);
            this.Property(t => t.VerifierMobileNo).HasMaxLength(20);
            this.Property(t => t.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQCriminal).WithMany().HasForeignKey(c => c.CriminalRowID).WillCascadeOnDelete(false);
        }
    }
}


































