using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class PQAddressVarPartener
    {
        public int PQAddressVarPtrRowId { get; set; }

        public int AddressRowID { get; set; }
        public virtual PQAddress PQAddress { get; set; }

        public int VendorLoginRowID { get; set; }
        public virtual MasterVendorLogin MasterVendorLogin { get; set; }

        public int PersonalRowID { get; set; }  
        public int SubCheckRowId { get; set; }
        public string   SubCheckName          { get; set; }
        public string   AV_Cand_Name          { get; set; }
        public string   AV_Add                { get; set; }
        public string   AV_AddLine1           { get; set; }
        public string   AV_AddLine2           { get; set; }
        public string   AV_Buldng_Street_Name { get; set; }
        public string   AV_State              { get; set; }
        public string   AV_District           { get; set; }
        public string   AV_City               { get; set; }
        public int      AV_Pincode               { get; set; }
        public string   AV_Landmark           { get; set; }
        public DateTime?    InternalOutDate    { get; set; }
        public string       CheckStatus           { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsSynced { get; set; }           //Used for Web to Mobile Sync
        public int SyncedBy { get; set; }            //Used for Web to Mobile Sync
        public DateTime? SyncedOn { get; set; }      //Used for Web to Mobile Sync
        public string IsAddressChanged      { get; set; }//Yes/No
        public string Address               { get; set; }
        public string Landmark { get; set; }
        public string DurationOfStay        { get; set; }
        public string AccomodationType      { get; set; }
        public string RespName              { get; set; }        
        public string RespIdDetails         { get; set; }
        public string RespRelation          { get; set; }
        public string RespContactDetails    { get; set; }//Drop Down
        public string NeighbourNameAndNos   { get; set; }
        public string AnyOtherComments      { get; set; }
        public string PtrStatus             { get; set; } //Verified/Refused/Shifted/Un Traceable
        public int UpdatedBy             { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool IsMSynced { get; set; }             //Used for Mobile to Web Sync
        public int MSyncedBy { get; set; }              //Used for Mobile to Web Sync
        public DateTime? MSyncedOn { get; set; }        //Used for Mobile to Web Sync
    }
}
