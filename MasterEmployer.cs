using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterEmployer
    {
        public MasterEmployer()
        {
            EmployerRowID = 0;
            CompanyName = string.Empty;
            CompanyStatus = string.Empty;
            COtherStatus = string.Empty;
            CompanyLegalStatus = string.Empty;
            COtherLegalStatus = string.Empty;
            CompanyAddress = string.Empty;
            CountryRowID = 0;
            StateRowID = 0;
            DistrictRowID = 0;
            LocationRowID = 0;
            Website = string.Empty;
            CompanySnapshot = string.Empty;
            CINNumber = string.Empty;
            PaidUpCapital = 0.00;
            ModeOfInitiation = string.Empty;
            OtherInitiation = string.Empty;
            MandatoryDocument = string.Empty;
            OtherDocumentDetail = string.Empty;
            SpecialInstruction = string.Empty;
            AdditionalCosting = string.Empty;
            AdditionalCost = 0.00;
            ModeOfPayment = string.Empty;
            PayableAT = string.Empty;
            FavourOf = string.Empty;
            AccountNumber = string.Empty;
            IFSCCode = string.Empty;
            ConcernPersonName = string.Empty;
            DesigConcernPerson = string.Empty;
            OfficialEmailId = string.Empty;
            OfficialLandlineNo = string.Empty;
            MobileNo = string.Empty;
            PVInitiated = string.Empty;
            PVInitAtAddress = string.Empty;
            PVInitAtAddressProof = string.Empty;
            RegisteredOnMCA = string.Empty;
            MCARegProof = string.Empty;
            OtherDocumentAdded = string.Empty;
            OtherDocumentNo = string.Empty;
            OtherDocProof = string.Empty;
            VerificationTATLevel1 = 0;
            VerificationTATLevel2 = 0;
            AdditionalComments = string.Empty;
            Other1 = string.Empty;
            Other2 = string.Empty;
            Other3 = string.Empty;
            Other4 = string.Empty;
            Other5 = string.Empty;
            Status = 1;
        }

        public int EmployerRowID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStatus { get; set; }
        public string COtherStatus { get; set; }
        public string CompanyLegalStatus { get; set; }
        public string COtherLegalStatus { get; set; }
        public string CompanyAddress { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }

        public int LocationRowID { get; set; }
        public virtual MasterLocation MasterLocation { get; set; }
        
        public string Website { get; set; }
        public string CompanySnapshot { get; set; }
        public string CINNumber { get; set; }
        public double PaidUpCapital { get; set; }
        public string ModeOfInitiation { get; set; }
        public string OtherInitiation { get; set; }
        public string MandatoryDocument { get; set; }
        public string OtherDocumentDetail { get; set; }
        public string SpecialInstruction { get; set; }
        public string AdditionalCosting { get; set; }
        public double AdditionalCost { get; set; }
        public string ModeOfPayment { get; set; }
        public string PayableAT { get; set; }
        public string FavourOf { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string ConcernPersonName { get; set; }
        public string DesigConcernPerson { get; set; }
        public string OfficialEmailId { get; set; }
        public string OfficialLandlineNo { get; set; }
        public string MobileNo { get; set; }
        public string PVInitiated { get; set; }
        public string PVInitAtAddress { get; set; }
        public string PVInitAtAddressProof { get; set; }
        public string RegisteredOnMCA { get; set; }
        public string MCARegProof { get; set; }
        public string OtherDocumentAdded { get; set; }
        public string OtherDocumentNo { get; set; }
        public string OtherDocProof { get; set; }
        public byte VerificationTATLevel1 { get; set; }
        public byte VerificationTATLevel2 { get; set; }
        public string AdditionalComments { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public byte Status { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
