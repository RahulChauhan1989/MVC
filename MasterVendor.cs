using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterVendor
    {
        public MasterVendor()
        {
            VendorRowID = 0;
            VendorName = string.Empty;
            Address = string.Empty;
            CountryRowID = 0;
            StateRowID = 0;
            DistrictRowID = 0;
            LocationRowID = 0;
            PinCode = 0;
            AuditStatus = string.Empty;
            ModeOfInitiation = string.Empty;
            OtherInitiation = string.Empty;
            VendorContactPerson = string.Empty;
            VendorEmaiID = string.Empty;
            VendorContactNo = string.Empty;
            VendorMobileNo = string.Empty;
            SPOCToName = string.Empty;
            SPOCToEmailId = string.Empty;
            SPOCToContactNo = string.Empty;
            SPOCToMobileNo = string.Empty;
            SpecialInstruction = string.Empty;
            ModeOfPayment = string.Empty;
            PayableAT = string.Empty;
            FavourOf = string.Empty;
            AccountNumber = string.Empty;
            IFSCCode = string.Empty;
            PanNo = string.Empty;
            PanDoc = string.Empty;
            IDProofNo = string.Empty;
            IDProofDoc = string.Empty;
            ServiceTaxCertificateNo = string.Empty;
            ServiceTaxCertificateDoc = string.Empty;
            RegistrationCertificateNo = string.Empty;
            RegistrationCertificateDoc = string.Empty;
            AgreementDocs = string.Empty;
            OtherDocumentDetail = string.Empty;
            Other1 = string.Empty;
            Other2 = string.Empty;
            Other3 = string.Empty;
            Other4 = string.Empty;
            Other5 = string.Empty;
            ReNewStatus = 0;
            PrevVendorRowID = 0;
            ExpiredStatus = 0;
            Status = 1;
        }

        public short VendorRowID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }

        public int LocationRowID { get; set; }
        public virtual MasterLocation MasterLocation { get; set; }

        public int PinCode { get; set; }

        public DateTime? EmpanelmentDate { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string AuditStatus { get; set; }
        public DateTime? AuditStatusDate { get; set; }
        public string ModeOfInitiation { get; set; }
        public string OtherInitiation { get; set; }
        public string VendorContactPerson { get; set; }
        public string VendorEmaiID { get; set; }
        public string VendorContactNo { get; set; }
        public string VendorMobileNo { get; set; }
        public string SPOCToName { get; set; }
        public string SPOCToEmailId { get; set; }
        public string SPOCToContactNo { get; set; }
        public string SPOCToMobileNo { get; set; }
        public string SpecialInstruction { get; set; }
        public string ModeOfPayment { get; set; }
        public string PayableAT { get; set; }
        public string FavourOf { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string PanNo { get; set; }
        public string PanDoc { get; set; }
        public string IDProofNo { get; set; }
        public string IDProofDoc { get; set; }
        public string ServiceTaxCertificateNo { get; set; }
        public string ServiceTaxCertificateDoc { get; set; }
        public string RegistrationCertificateNo { get; set; }
        public string RegistrationCertificateDoc { get; set; }
        public string AgreementDocs { get; set; }
        public string OtherDocumentDetail { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public byte ReNewStatus { get; set; }
        public short PrevVendorRowID { get; set; }
        public byte ExpiredStatus { get; set; }
        public byte Status { get; set; }
    }
}
