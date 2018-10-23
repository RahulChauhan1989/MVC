using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQInsuranceViewModel
    {
        public int InsuranceRowID { get; set; }
        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }

        #endregion
        public string IV_State { get; set; }            //text Area
        public string IV_Yrly_Premium { get; set; }     //text Area
        public string IV_Sum_Assured { get; set; }      //text Area
        public string IV_Insured_Name { get; set; }     //text Area
        public string IV_Policy_No { get; set; }        //text Area
        public string IV_Proposer_Name { get; set; }    //text Area
        public string IV_Pincode { get; set; }          //text Area
        public string IV_Premium { get; set; }          //text Area
        public string IV_Reason_Check { get; set; }     //text Area
        public string IV_Office_Addr { get; set; }      //text Area
        public string IV_Action_Req { get; set; }       //text Area
        public string IV_Address { get; set; }          //text Area
        public string IV_Age { get; set; }              //text Area
        public string IV_Agent_Name { get; set; }       //text Area
        public string IV_Check_Type { get; set; }       //text Filed
        public string ATA_CID_No { get; set; }          //text Filed
        public string ATA_Cmpny_Addr { get; set; }      //text Area
        public string IV_Others { get; set; }           //text Area
        public string IV_Others2 { get; set; }          //text Area
        public string IV_Others3 { get; set; }          //text Area
        public string IV_Others4 { get; set; }          //text Area
        public string IV_Others5 { get; set; }          //text Area
        public string IV_OtherProof { get; set; }       //text Area

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        public string CheckStatus { get; set; }
        public string CaseStatus { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
        
    }
    public class PQInsuranceList
    {
        //public short PQAddressListRowID { get; set; }


        public short AntecedentRowId { get; set; }

        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
        //public short ClientRowID { get; set; }      

        //public int PersonalRowID { get; set; }       

        //public int ClientPackageRowID { get; set; }        

        //public short CheckFamilyRowID { get; set; }       

        //public short SubCheckRowID { get; set; }       

        //public string UniqueComponentID { get; set; }
    }
    
}
