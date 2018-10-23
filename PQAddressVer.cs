using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQAddressVer
    {
        public PQAddressVer()
        {
            AddressVerRowID = 0;
            AddressRowID = 0;
            
            AV_Add = string.Empty;
            AV_Add_Line1 = string.Empty;
            AV_Add_Line2 = string.Empty;
            AV_Buldng_Street_name = string.Empty;
            AV_City = 0;
            AV_District = 0;
            AV_State = 0;
            AV_Pincode = 0;
            AV_Landmark = string.Empty;
            AV_Add_Type = string.Empty;
            AV_Dur_of_Stay = string.Empty;
            AV_2_3BHK = string.Empty;
            AV_Applcnt_Known_Hw_Mny_Yrs = string.Empty;
            AV_Resp_Name = string.Empty;
            AV_Resp_Relation_With_Cand = string.Empty;
            AV_Resp_ConDet = string.Empty;
            AV_Resp_ConNo = string.Empty;
            AV_Neighbour_Name_No1 = string.Empty;
            AV_Neighbour_Name_No2 = string.Empty;
            AV_Resp_Remarks = string.Empty;
            AV_Security_Confirm = string.Empty;
            AV_Owned_Rent_Hypoth = string.Empty;
            AV_New_Add_Det_Obtain = string.Empty;
            AV_House_Photo_taken = string.Empty;
            HousePhotographName = string.Empty;
            AV_Buldng_Status = string.Empty;
            AV_Family_Member = 0;
            AV_Color_of_Buldng = string.Empty;
            AV_Interior_Condition = string.Empty;
            AV_Total_Earning_Member = 0;
            AV_Ease_Locating = string.Empty;
            AV_Gate_Color = string.Empty;
            AV_No_Vech = 0;
            AV_Applcnt_Demons_Unsual_Behv = string.Empty;
            AV_Idproof_Prov_Resp = string.Empty;
            AV_Income_Source = string.Empty;
            AV_Applcnt_Habitul_Borrow_Neigh = string.Empty;
            AV_Any_Union_Poltcl_Affl_Fmly = string.Empty;
            AV_Locality = string.Empty;
            AV_Moral_Charac_Applcnt = string.Empty;
            AV_Sec_field_Exe_Name = string.Empty;
            AV_Date_Verification = DateTime.Now;
            AV_Time_Verification = string.Empty;
            AV_Any_Other_Cmmnts_AV = string.Empty;
            AV_OtherDetails6 = string.Empty;
            AV_OtherDetails7 = string.Empty;
            AV_OtherDetails8 = string.Empty;
            AV_OtherDetails9 = string.Empty;
            AV_OtherDetails10 = string.Empty;
            AV_OtherDetails11 = string.Empty;
            AV_OtherDetails12 = string.Empty;
            AV_OtherDetails13 = string.Empty;
            AV_OtherDetails14 = string.Empty;
            AV_OtherDetails15 = string.Empty;

            ATA_CID_No = string.Empty;
            ATA_Cmpny_Addr = string.Empty;
            ATA_ApprxEmpWorking = string.Empty;
            ATA_Cmpny_Website = string.Empty;
            ATA_Decoy_Call = string.Empty;
            ATA_Reverse_Directory = string.Empty;
            ATA_Residcl_Commrcl = string.Empty;
            ATA_Stock_Exchnge = string.Empty;
            ATA_Telphne_Directry_Srch = string.Empty;
            ATA_Yellow_Pages = string.Empty;
            ATA_Who_Domain = string.Empty;
            ATA_GoogleSearch = string.Empty;
            ATA_InfrastructureOfCmp = string.Empty;
            ATA_Just_Dial = string.Empty;
            ATA_Neighbor_Check1 = string.Empty;
            ATA_NASCOM_Empanelment = string.Empty;
            ATA_Photograph = string.Empty;
            ATA_Physical_Site = string.Empty;
            ATA_Reg_Company = string.Empty;
            ATA_PO_Courier_Check = string.Empty;
            ATA_Network_Sol = string.Empty;

            TypeRevert = string.Empty;
            CheckStatus = string.Empty;
            Severity = string.Empty;
            ColorName = string.Empty;
            ReportComments = string.Empty;
            Status = 1;

            VerifiedBy = 0;
            VerifierDesignation = string.Empty;
            VerifierContactNo = string.Empty;
            VerifierMobileNo = string.Empty;
            VerifierEmailId = string.Empty;
        }

        public int AddressVerRowID { get; set; }

        public int AddressRowID { get; set; }
        public virtual PQAddress PQAddress { get; set; }

        #region Address Verification Antecedents

        public string       AV_Add                                { get; set; }                          //TextArea
        public string       AV_Add_Line1                          { get; set; }                    //TextArea
        public string       AV_Add_Line2                          { get; set; }                    //TextArea
        public string       AV_Buldng_Street_name                 { get; set; }           //TextBox
        public short        AV_State                              { get; set; }                         // Drop Down - State ref id drop down//change add string to short  5-12-2016
        public short        AV_District                           { get; set; }                      // Drop Down - District ref id drop down //change add string to short  5-12-2016
        public int          AV_City                               { get; set; }                            // Drop Down - City Master
        public int          AV_Pincode                            { get; set; }                         //TextBox - Pincode ref id drop down//change add string to short  5-12-2016
        public string       AV_Landmark                           { get; set; }                     //TextBox
        public string       AV_Add_Type                           { get; set; }                     // Drop Down - Own/Rented/company provide/PG/Relative house/Others
        public string       AV_Dur_of_Stay                        { get; set; }                  //To & From Calender
        public string       AV_2_3BHK                             { get; set; }                       //TextBox
        public string       AV_Applcnt_Known_Hw_Mny_Yrs           { get; set; }     //TextBox
        public string       AV_Resp_Name                          { get; set; }                     //TextBox
        public string       AV_Resp_Relation_With_Cand            { get; set; }      //drop down Respondent Relationship with candidate -Relationship master
        public string       AV_Resp_ConDet                        { get; set; }                  //TextBox
        public string       AV_Resp_ConNo                         { get; set; }                   //TextBox
        public string       AV_Neighbour_Name_No1                 { get; set; }           //TextArea
        public string       AV_Neighbour_Name_No2                 { get; set; }           //TextArea
        public string       AV_Resp_Remarks                       { get; set; }                 //TextArea
        public string       AV_Security_Confirm                   { get; set; }             //Dropdown -security type
        public string       AV_Owned_Rent_Hypoth                  { get; set; }            // Dropdown -Owned or Rented or Hypothecated --
        public string       AV_New_Add_Det_Obtain                 { get; set; }           //TextArea       
        public string       AV_House_Photo_taken                  { get; set; }            //Drop Down Yes/No
        public string       HousePhotographName                   { get; set; }             //Not show on page
        public string       AV_Buldng_Status                      { get; set; }                //TextBox        
        public byte         AV_Family_Member                        { get; set; }                  // Drop Down - Nos dropdown 
        public string       AV_Color_of_Buldng                    { get; set; }              // Drop Down- color master
        public string       AV_Interior_Condition                 { get; set; }             //Drop Down -Good/Bad 
        public byte         AV_Total_Earning_Member                 { get; set; }           //Drop Down -Nos dropdown //change add byte to string 5-12-2016
        public string       AV_Ease_Locating                      { get; set; }                // Drop Down-Ease type
        public string       AV_Gate_Color                         { get; set; }                   //Drop Down-color master
        public byte         AV_No_Vech                              { get; set; }                        //Drop Down -Nos dropdown //change add byte to string 5-12-2016
        public string       AV_Applcnt_Demons_Unsual_Behv         { get; set; }   //Drop Down -yes/No/cant Say
        public string       AV_Idproof_Prov_Resp                  { get; set; }            //Drop Down -yes/Not available/refused
        public string       AV_Income_Source                      { get; set; }                //TextBox 
        public string       AV_Applcnt_Habitul_Borrow_Neigh       { get; set; }  // Drop Down yes/No/cant Say
        public string       AV_Any_Union_Poltcl_Affl_Fmly         { get; set; }    // Drop Down yes/No/cant Say
        public string       AV_Locality                           { get; set; }                      // Drop Down -Middle 
        public string       AV_Moral_Charac_Applcnt               { get; set; }          // Drop Down Good/Bad
        public string       AV_Sec_field_Exe_Name                 { get; set; }            //TextBox
        public DateTime?    AV_Date_Verification               { get; set; }           //Date 
        public string       AV_Time_Verification                  { get; set; }            // Time slot (store time only without date)
        public string       AV_Any_Other_Cmmnts_AV                { get; set; }          //TextArea

        public string       AV_OtherDetails6                      { get; set; }                //TextArea
        public string       AV_OtherDetails7                      { get; set; }                //TextArea
        public string       AV_OtherDetails8                      { get; set; }                //TextArea
        public string       AV_OtherDetails9                      { get; set; }                //TextArea
        public string       AV_OtherDetails10                     { get; set; }               //TextArea
        public string       AV_OtherDetails11                     { get; set; }               //TextArea
        public string       AV_OtherDetails12                     { get; set; }               //TextArea
        public string       AV_OtherDetails13                     { get; set; }               //TextArea
        public string       AV_OtherDetails14                     { get; set; }               //TextArea
        public string       AV_OtherDetails15                     { get; set; }               //TextArea

        public string       ATA_CID_No                            { get; set; }                      //TextBox
        public string       ATA_Cmpny_Addr                        { get; set; }                  //TextArea
        public string       ATA_ApprxEmpWorking                   { get; set; }             //TextBox
        public string       ATA_Cmpny_Website                     { get; set; }               //TextArea
        public string       ATA_Decoy_Call                        { get; set; }                  //TextArea
        public string       ATA_Reverse_Directory                 { get; set; }           //TextArea
        public string       ATA_Residcl_Commrcl                   { get; set; }             //TextArea
        public string       ATA_Stock_Exchnge                     { get; set; }               //TextArea
        public string       ATA_Telphne_Directry_Srch             { get; set; }       //TextArea
        public string       ATA_Yellow_Pages                      { get; set; }                //TextArea
        public string       ATA_Who_Domain                        { get; set; }                  //TextArea
        public string       ATA_GoogleSearch                      { get; set; }                //TextArea
        public string       ATA_InfrastructureOfCmp               { get; set; }         //TextArea
        public string       ATA_Just_Dial                         { get; set; }                   //TextArea
        public string       ATA_Neighbor_Check1                   { get; set; }             //TextArea
        public string       ATA_NASCOM_Empanelment                { get; set; }          //TextArea
        public string       ATA_Photograph                        { get; set; }                  //TextArea
        public string       ATA_Physical_Site                     { get; set; }               //TextArea
        public string       ATA_Reg_Company                       { get; set; }                 //TextArea
        public string       ATA_PO_Courier_Check                  { get; set; }            //TextArea
        public string       ATA_Network_Sol                       { get; set; }                 //TextArea

        #endregion

        public string       TypeRevert                            { get; set; }
        public string       CheckStatus                           { get; set; }
        public string       Severity                            { get; set; }
        public string       ColorName                             { get; set; }
        public string       ReportComments                               { get; set; }
        public byte         Status                                  { get; set; }

        public short        VerifiedBy                             { get; set; }
        public string       VerifierDesignation                   { get; set; }
        public string       VerifierContactNo                     { get; set; }
        public string       VerifierMobileNo                      { get; set; }
        public string       VerifierEmailId                       { get; set; }
        public DateTime?    VerifiedDate                       { get; set; }
    }
}
