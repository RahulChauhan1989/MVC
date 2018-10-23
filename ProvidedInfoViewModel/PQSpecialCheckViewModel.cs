using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQSpecialCheckViewModel
    {
        public int SpecialCheckRowId { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }
    }

    public class AddSpecialCheckViewModel
    {
        [ScaffoldColumn(false)]
        public int SpecialCheckRowId { get; set; } 
            
        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        public int ClientPackageRowID { get; set; }

        [ScaffoldColumn(false)]
        public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)] 
        public short SubCheckRowID { get; set; }

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }
       
        [MaxLength(100)]
        public string SC_Cand_Name { get; set; }        // Text Field - Auto Capture
        [MaxLength(100)]
        public string SC_Father_Name { get; set; }      // Text Field - Auto Capture
        [MaxLength(100)]
        public string SC_SecuritasID { get; set; }      // Text Field - Auto Capture

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SC_DOB { get; set; }           // date  Text Field - Auto Capture

        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        //Following not show on page. It is for future use only
        [MaxLength(200)]
        public string SC_Others1 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others2 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others3 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others4 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others5 { get; set; }       // Text Field 


        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        [MaxLength(20)]
        public string CheckStatus { get; set; }
        [MaxLength(20)]
        public string ReWorkCheckStatus { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
        public byte Status { get; set; }


    }

    public class UpdateSpecialCheckViewModel
    {
        [ScaffoldColumn(false)]
        public int SpecialCheckRowId { get; set; }

        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        public int ClientPackageRowID { get; set; }

        [ScaffoldColumn(false)]
        public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)]
        public short SubCheckRowID { get; set; }

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }
        [MaxLength(100)]
        public string SC_Cand_Name { get; set; }        // Text Field - Auto Capture
        [MaxLength(100)]
        public string SC_Father_Name { get; set; }      // Text Field - Auto Capture
        [MaxLength(100)]
        public string SC_SecuritasID { get; set; }      // Text Field - Auto Capture

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SC_DOB { get; set; }           // date  Text Field - Auto Capture

        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        //Following not show on page. It is for future use only
        [MaxLength(200)]
        public string SC_Others1 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others2 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others3 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others4 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others5 { get; set; }       // Text Field 


        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public short MgrAllocatedBy { get; set; }

        public short MgrAllocatedTo { get; set; }

        public DateTime? MgrAllocatedDate { get; set; }

        [MaxLength(20)]
        public string CheckStatus { get; set; }
        [MaxLength(20)]
        public string ReWorkCheckStatus { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
        public byte Status { get; set; }


    }

    public class UpdateSpecialCheckRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int SpecialCheckRowId { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQSpecialCheckInsuffViewModel
    {
        public int SpecialCheckRowId { get; set; }

        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }

        public string CompanyRefNo { get; set; }

        public int ClientPackageRowID { get; set; }
        public string ClientPackageName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }


        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public string UniqueComponentID { get; set; }

        #endregion     

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public string InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }

    public class PQSpecialCheckInsuffListPagedModel
    {
        public IEnumerable<PQSpecialCheckInsuffViewModel> PQAllInsuffSpecialCheckes { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UpdatePQSpecialCheckInsuffClearViewModel
    {
        public int SpecialCheckRowId { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }
        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public short InfSuffClearBy { get; set; }
        public DateTime? InfSuffClearDate { get; set; }

        [Display(Name = "Insuff Remarks : ")]
        public string INFRemarks { get; set; }
        
    }
    public class ViewSpecialCheckViewModel 
                
    {
        [ScaffoldColumn(false)]
        [Required]
        public int SpecialCheckRowId { get; set; }

        [Required]
        public short ClientRowID { get; set; }

        [Required]
        public int PersonalRowID { get; set; }

        [Required]
        public int ClientPackageRowID { get; set; }

        [Required]
        public short CheckFamilyRowID { get; set; }

        [Required]
        public short SubCheckRowID { get; set; }

        [MaxLength(200)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(200)]
        [Required]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

    }
}
