using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterPoliceStation
    {
        public MasterPoliceStation()
        {
            PoliceStationRowID = 0;
            PoliceStationName = string.Empty;
            PoliceStationAddress = string.Empty;
            CountryRowID = 0;
            StateRowID = 0;
            DistrictRowID = 0;
            LocationRowID = 0;
            Coverage = string.Empty;
            Website = string.Empty;
            ModeOfInitiation = string.Empty;
            OtherInitiation = string.Empty;
            SpecialInstruction = string.Empty;
            MandatoryDocument = string.Empty;
            OtherDocumentDetail = string.Empty;
            AdditionalCosting = string.Empty;
            AdditionalCost = 0.00;
            ModeOfPayment = string.Empty;
            PayableAT = string.Empty;
            FavourOf = string.Empty;
            AccountNumber = string.Empty;
            IFSCCode = string.Empty;
            VerificationTATLevel1 = 0;
            VerificationTATLevel2 = 0;
            ConcernPersonName = string.Empty;
            DesigConcernPerson = string.Empty;
            OfficialEmailId = string.Empty;
            OfficialLandlineNo = string.Empty;
            MobileNo = string.Empty;
            AdditionalComments = string.Empty;
            Other1 = string.Empty;
            Other2 = string.Empty;
            Other3 = string.Empty;
            Other4 = string.Empty;
            Other5 = string.Empty;
            Status = 1;
        }

        public short PoliceStationRowID { get; set; }
        public string PoliceStationName { get; set; }
        public string PoliceStationAddress { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }

        public int LocationRowID { get; set; }
        public virtual MasterLocation MasterLocation { get; set; }

        public string Coverage { get; set; }
        public string Website { get; set; }
        public string ModeOfInitiation { get; set; }
        public string OtherInitiation { get; set; }
        public string SpecialInstruction { get; set; }
        public string MandatoryDocument { get; set; }
        public string OtherDocumentDetail { get; set; }
        public string AdditionalCosting { get; set; }
        public double AdditionalCost { get; set; }
        public string ModeOfPayment { get; set; }
        public string PayableAT { get; set; }
        public string FavourOf { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public byte VerificationTATLevel1 { get; set; }
        public byte VerificationTATLevel2 { get; set; }
        public string ConcernPersonName { get; set; }
        public string DesigConcernPerson { get; set; }
        public string OfficialEmailId { get; set; }
        public string OfficialLandlineNo { get; set; }
        public string MobileNo { get; set; }
        public string AdditionalComments { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public byte Status { get; set; }
    }
}
