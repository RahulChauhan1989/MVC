using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQAddress
    {
        public PQAddress()
        {
            AddressRowID = 0;
            ClientRowID = 0;
            PersonalRowID = 0;
            ClientPackageRowID = 0;
            CheckFamilyRowID = 0;
            SubCheckRowID = 0;
            UniqueComponentID = string.Empty;
            AV_Cand_Name = string.Empty;
            AV_Sec_Ref_No = string.Empty;
            AV_Add = string.Empty;
            AV_Add_Line1 = string.Empty;
            AV_Add_Line2 = string.Empty;
            AV_Buldng_Street_name = string.Empty;
            AV_State = 0;
            AV_District = 0;
            AV_City = 0;
            AV_Pincode = 0;
            AV_Landmark = string.Empty;
            AV_Add_Type = string.Empty;
            AV_Dur_of_Stay = string.Empty;
            AV_Owner_Name = string.Empty;
            AV_Owner_ConNo = string.Empty;
            AV_NickName = string.Empty;
            AV_Name_Chngd_Effect_Frm = string.Empty;
            AV_Doc_Prov_Proof_Add = string.Empty;
            AddressProofFileName = string.Empty;
            AV_Doc_Details = string.Empty;
            DocumentDetailsFileName = string.Empty;
            AV_RationCard = 0;
            AV_TelephoneBill = 0;
            AV_RentAgreement = 0;
            AV_Passport = 0;
            AV_ElectricityBill = 0;
            AV_GasSupplyBill = 0;
            AV_WaterBill = 0;
            AV_OtherProof = 0;
            AV_OtherDetails = string.Empty;
            AV_OtherDetails2 = string.Empty;
            AV_OtherDetails3 = string.Empty;
            AV_OtherDetails4 = string.Empty;
            AV_OtherDetails5 = string.Empty;
            AV_OtherDetails6 = string.Empty;
            AV_OtherDetails7 = string.Empty;
            AV_OtherDetails8 = string.Empty;
            AV_OtherDetails9 = string.Empty;
            AV_OtherDetails10 = string.Empty;
            ATA_CID_No = string.Empty;
            ATA_Cmpny_Addr = string.Empty;

            CreatedBy = 0;
            ModifiedBy = 0;
            Status = 1;

            CheckStatus = string.Empty;
            ReWorkCheckStatus = string.Empty;
            Remarks = string.Empty;
        }

        public int AddressRowID { get; set; }

        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }

        public int ClientPackageRowID { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short SubCheckRowID { get; set; }
        public virtual MasterSubCheckFamily MasterSubCheckFamily { get; set; }

        public string UniqueComponentID { get; set; } 

        #endregion
        
        #region Address Verification Antecedents

        public string AV_Cand_Name { get; set; }            //TextBox
        public string AV_Sec_Ref_No { get; set; }           //TextBox
        public string AV_Add { get; set; }                  //TextArea
        public string AV_Add_Line1 { get; set; }            //TextArea
        public string AV_Add_Line2 { get; set; }            //TextArea
        public string AV_Buldng_Street_name { get; set; }   //TextBox      
        public short AV_State { get; set; }                 // Drop Down - State ref id drop down//change add string to short  5-12-2016
        public short AV_District { get; set; }              // Drop Down - District ref id drop down //change add string to short  5-12-2016
        public int  AV_City { get; set; }                    // Drop Down - City Master
        public int AV_Pincode { get; set; }                 //TextBox - Pincode ref id drop down//change add string to short  5-12-2016
        public string AV_Landmark { get; set; }            //TextBox
        public string AV_Add_Type { get; set; }             // Drop Down - Own/Rented/company provide/PG/Relative house/Others
        public string AV_Dur_of_Stay { get; set; }          //To & From Calender
        public string AV_Owner_Name { get; set; }            //TextBox
        public string AV_Owner_ConNo { get; set; }            //TextBox
        public string AV_NickName { get; set; }                 //TextBox
        public string AV_Name_Chngd_Effect_Frm { get; set; }    //TextBox 
        public string AV_Doc_Prov_Proof_Add { get; set; }    // drop down Documents provided as proof of the address- List of address proof
        public string AddressProofFileName { get; set; }    //Not Show on Page
        public string AV_Doc_Details { get; set; }           //drop down Document Details - List of address proof        
        public string DocumentDetailsFileName { get; set; }    //Not Show on Page

        public byte AV_RationCard { get; set; }                  // CheckBox    Default- 0 otherwise 1
        public byte AV_TelephoneBill { get; set; }               // CheckBox    Default- 0 otherwise 1
        public byte AV_RentAgreement { get; set; }               // CheckBox    Default- 0 otherwise 1
        public byte AV_Passport { get; set; }                    // CheckBox    Default- 0 otherwise 1
        public byte AV_ElectricityBill { get; set; }             // CheckBox    Default- 0 otherwise 1
        public byte AV_GasSupplyBill { get; set; }               // CheckBox    Default- 0 otherwise 1
        public byte AV_WaterBill { get; set; }                   // CheckBox    Default- 0 otherwise 1
        public byte AV_OtherProof { get; set; }                  // CheckBox    Default- 0 otherwise 1

        public string AV_OtherDetails { get; set; }             //TextArea
        public string AV_OtherDetails2 { get; set; }            //TextArea
        public string AV_OtherDetails3 { get; set; }            //TextArea
        public string AV_OtherDetails4 { get; set; }            //TextArea
        public string AV_OtherDetails5 { get; set; }            //TextArea
        public string AV_OtherDetails6 { get; set; }            //TextArea
        public string AV_OtherDetails7 { get; set; }            //TextArea
        public string AV_OtherDetails8 { get; set; }            //TextArea
        public string AV_OtherDetails9 { get; set; }            //TextArea
        public string AV_OtherDetails10 { get; set; }           //TextArea
        public string ATA_CID_No { get; set; }                  //TextBox
        public string ATA_Cmpny_Addr { get; set; }              //TextArea

        #endregion
        
        //following properties not show on page
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }
}
