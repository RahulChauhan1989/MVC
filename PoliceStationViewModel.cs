using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PoliceStationViewModel
    {
        [Display(Name ="ID")]
        public short PoliceStationRowID { get; set; }
       
        [Display(Name = "Police Station Name")]
        public string PoliceStationName { get; set; }

        [Display(Name = "Police Station Address")]
        public string PoliceStationAddress { get; set; }
        [Display(Name = "Country")]
        public short CountryRowID { get; set; }
        [Display(Name ="Country")]
        public string CountryName { get; set; }
        [Display(Name = "State")]
        public short StateRowID { get; set; }
        [Display(Name ="State")]
        public string StateName { get; set; }
        [Display(Name = "District")]
        public short DistrictRowID { get; set; }
        [Display(Name ="District")]
        public string DistrictName { get; set; }
        [Display(Name = "Location")]
        public int LocationRowID { get; set; }
        [Display(Name ="Location")]                                  
        public string Location { get; set; }

        [Display(Name ="Coverage")]
        public string Coverage { get; set; }

        [Display(Name = "Mandatory Requirements")]
        public string Requirements { get; set; }

        [Display(Name = "Mode of Initiation")]
        public string InitiationMode { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Mode Of Initiation")]
        public string ModeOfInitiation { get; set; }

        [Display(Name = "Special Instruction")]
        public string SpecialInstruction { get; set; }

        [Display(Name = "Mandatory Document")]
        public string MandatoryDocument { get; set; }

        [Display(Name = "Additional Costing")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost")]
        public double AdditionalCost { get; set; }

        public string AdditionalCostYN { get; set; }

        [Display(Name = "Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        [Display(Name = "Concern Person Name")]
        public string ConcernPersonName { get; set; }

        [Display(Name = "Designation")]
        public string DesigConcernPerson { get; set; }

        [Display(Name = "Official Landline No")]
        public string OfficialLandlineNo { get; set; }

        [Display(Name = "Official Email Id")]
        public string OfficialEmailId { get; set; }

        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        [Display(Name ="Other 1")]
        public string Other1 { get; set; }

        [Display(Name = "Other 2")]
        public string Other2 { get; set; }

        [Display(Name = "Other 3")]
        public string Other3 { get; set; }

        [Display(Name = "Other 4")]
        public string Other4 { get; set; }

        [Display(Name = "Other 5")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }

        //New Fields Add 9 Nov 2016
        [Display(Name = "Favour Of")]
        public string FavourOf { get; set; }

        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [Display(Name = "Other Initiation")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT")]
        public byte VerificationTATLevel2 { get; set; }

        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Display(Name = "IFSCCode")]
        public string IFSCCode { get; set; }

        [Display(Name = "Payable AT")]
        public string PayableAT { get; set; }
    }

    public class AddPoliceStationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID : ")]
        public short PoliceStationRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Name : ")]
        public string PoliceStationName { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address : ")]
        public string PoliceStationAddress { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [MaxLength(200)]
        [Display(Name = "Coverage : ")]
        public string Coverage { get; set; }

        //[MaxLength(200)]
        //[Display(Name = "Mandatory Requirements")]
        //public string Requirements { get; set; }

        //[MaxLength(50)]
        //[Display(Name = "Mode of Initiation")]
        //public string InitiationMode { get; set; }

        //[Display(Name = "Remarks")]
        //public string Remarks { get; set; }

        [MaxLength(100)]
        [Display(Name = "Website : ")]
        public string Website { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(500)]
        [Display(Name = "Mandatory Documents : ")]
        public string MandatoryDocument { get; set; }

        [MaxLength(3)]
        [Display(Name = "Additional Costing : ")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Concern Person Name : ")]
        public string ConcernPersonName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Designation : ")]
        public string DesigConcernPerson { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Official Landline No : ")]
        public string OfficialLandlineNo { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Official Email Id : ")]
        public string OfficialEmailId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Additional Comments : ")]
        public string AdditionalComments { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 1 : ")]
        public string Other1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 2 : ")]
        public string Other2 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 3 : ")]
        public string Other3 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 4 : ")]
        public string Other4 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 5 : ")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }

        //New Fields Add 8 Nov 2016
        [MaxLength(200)]
        [Display(Name = "Favour Of : ")]
        public string FavourOf { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte VerificationTATLevel2 { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable At : ")]
        public string PayableAT { get; set; }
    }

    public class UpdatePoliceStationViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public short PoliceStationRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Name : ")]
        public string PoliceStationName { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address : ")]
        public string PoliceStationAddress { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [MaxLength(200)]
        [Display(Name = "Coverage : ")]
        public string Coverage { get; set; }

        //[MaxLength(200)]
        //[Display(Name = "Mandatory Requirements")]
        //public string Requirements { get; set; }

        //[MaxLength(50)]
        //[Display(Name = "Mode of Initiation")]
        //public string InitiationMode { get; set; }

        //[Display(Name = "Remarks")]
        //public string Remarks { get; set; }

        [MaxLength(100)]
        [Display(Name = "Website : ")]
        public string Website { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(500)]
        [Display(Name = "Mandatory Documents : ")]
        public string MandatoryDocument { get; set; }

        [MaxLength(3)]
        [Display(Name = "Additional Costing : ")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Concern Person Name : ")]
        public string ConcernPersonName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Designation : ")]
        public string DesigConcernPerson { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Official Landline No : ")]
        public string OfficialLandlineNo { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Official Email Id : ")]
        public string OfficialEmailId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Additional Comments : ")]
        public string AdditionalComments { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 1 : ")]
        public string Other1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 2 : ")]
        public string Other2 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 3 : ")]
        public string Other3 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 4 : ")]
        public string Other4 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other 5 : ")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }

        //New Fields Add 8 Nov 2016
        [MaxLength(200)]
        [Display(Name = "Favour Of : ")]
        public string FavourOf { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents :")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte VerificationTATLevel2 { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable AT : ")]
        public string PayableAT { get; set; }
    }

    public class PoliceStationExportViewModel
    {        
        public short RowID { get; set; }
      
        public string Name { get; set; }
     
        public string Address { get; set; }
        
        public string Country { get; set; }
       
        public string State { get; set; }
       
        public string District { get; set; }

        public string City { get; set; }

        public string Location { get; set; }
        
        public string Coverage { get; set; }
       
        public string Requirements { get; set; }
        
        public string InitiationMode { get; set; }
       
        public string Remarks { get; set; }

        public string Website { get; set; }

        public string ModeOfInitiation { get; set; }

        public string SpecialInstruction { get; set; }
       
        public string MandatoryDocument { get; set; }
        
        public string AdditionalCosting { get; set; }
       
        public double AdditionalCost { get; set; }
       
        public string ModeOfPayment { get; set; }
      
        public string ConcernPersonName { get; set; }
       
        public string DesigConcernPerson { get; set; }
        
        public string OfficialLandlineNo { get; set; }
       
        public string OfficialEmailId { get; set; }
        
        public string MobileNo { get; set; }

        public string AdditionalComments { get; set; }
        
        public string Other1 { get; set; }

        public string Other2 { get; set; }

        public string Other3 { get; set; }

        public string Other4 { get; set; }

        public string Other5 { get; set; }

        public byte? Status { get; set; }
                
        public string FavourOf { get; set; }

        public string OtherDocumentDetail { get; set; }
        
        public string OtherInitiation { get; set; }
       
        public byte VerificationTATLevel1 { get; set; }
       
        public byte VerificationTATLevel2 { get; set; }
       
        public string AccountNumber { get; set; }
       
        public string IFSCCode { get; set; }
      
        public string PayableAT { get; set; }
    }
    public class PoliceStationListViewModel
    {     
        public short PoliceStationRowID { get; set; }
        
        public string PoliceStationName { get; set; }
       
        public string ConcernPersonName { get; set; }
              
        public string OfficialLandlineNo { get; set; }
       
        public string OfficialEmailId { get; set; }
              
        public string MobileNo { get; set; }
        
        [ScaffoldColumn(false)]
        public byte? Status { get; set; }        
    }

    public class PoliceStationListPagedModel
    {
        public IEnumerable<PoliceStationListViewModel> PoliceStations { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

}
