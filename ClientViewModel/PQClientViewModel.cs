using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class PQClientViewModel
    {
        // public string strClientCode { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        [Display(Name = "Client Code :")]
        public string ClientCode { get; set; }

        [Display(Name = "ClientCode 1 :")]
        public string ClientCode1 { get; set; }

        [Display(Name = "Client Name :")]
        public short ClientAbbRowID { get; set; }

        public string ClientName { get; set; }

        [Display(Name = "Client SubGroup :")]
        public short ClientSubgroupID { get; set; }

        public string ClientSubGroup { get; set; }

        [Display(Name = "Address :")]
        public string Address { get; set; }

        [Display(Name = "Registered Address :")]
        public string RegisteredAddress { get; set; }

        [Display(Name = "Corporate Office Address :")]
        public string CorporateOfficeAddress { get; set; }

        [Display(Name = "Country :")]
        public short CountryRowID { get; set; }

        [Display(Name = "State :")]
        public short StateRowID { get; set; }

        [Display(Name = "District :")]
        public short DistrictRowID { get; set; }

        [Display(Name = "Location :")]
        public int LocationRowID { get; set; }

        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }


        [Display(Name = "Code Generation :")]
        public byte CodeGeneration { get; set; }    //{1-Yes & 0-No}


        [Display(Name = "Branch Office :")]
        public short BORowID { get; set; }


        [Display(Name = "Billing Cycle :")]
        public byte BillingRowID { get; set; }


        [Display(Name = "Report Sent by :")]
        public byte ReportSentBy { get; set; }      //{1-Mail & 2-Physical Copy, 3-Both}

        [Display(Name = "Interim Report :")]
        public byte InterimReport { get; set; }     //{1-Yes or 0-No)


        [Display(Name = "Contract Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractDate { get; set; }

        [Display(Name = "Cont. Complition Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractComplitionDate { get; set; }

        [Display(Name = "Pricing Type :")]
        public byte PricingType { get; set; }               //{1-Package wise or 2-Check wise or 3-Both}

        [Display(Name = "Payment Term ( days ) :")]
        public byte PaymentTermIndays { get; set; }

        [Display(Name = "Special Instructions :")]
        public string SpecialInstructions { get; set; }

        [Display(Name = "Remark :")]
        public string Remark { get; set; }


        //Conditions

        [Display(Name = "Antecedent Map :")]
        public byte MapAntecedent { get; set; }         //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Disposition Map :")]
        public byte MapDisposition { get; set; }        //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Severity Grid :")]
        public byte MapSeverity { get; set; }           //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Holidays :")]
        public byte MapHolidays { get; set; }           //{1-Client or 0-Default) (All ask for manage screen if selected client)

        [Display(Name = "Mail Send By :")]
        public byte MailSendBy { get; set; }            //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "HRApproval Required :")]
        public byte HRApprovalRequired { get; set; }    //HRApproval Required {1-Yes or 0-No)

        [Display(Name = "Days Calculation :")]
        public byte DaysCalculation { get; set; }       //{1-Working Days or 0-Calendar Days)

        [Display(Name = "Re-Open Cases :")]
        public byte ReOpenCases { get; set; }               //{1-Billable & 0-Not Billable}        

        [Display(Name = "Re-Open Billing :")]
        public byte ReOpenBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Insuff Billing :")]
        public byte InsuffBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Other Than Green Billing :")]
        public byte OtherThanGreenBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Stop Case Billing :")]
        public byte StopCaseBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "WIP / Closed Billing :")]
        public byte WIPOrClosedBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "PO Applicable :")]
        public byte POApplicable { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Employment PV :")]
        public byte EmploymentPV { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "YTR Status :")]
        public byte YTRStatus { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Verbal Report Status :")]
        public byte VerbalReportStatus { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Candidate Contact :")]
        public byte CandidateContact { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Client Name Disclosure :")]
        public byte ClientNameDisclosure { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Client Status :")]
        public byte ClientStatus { get; set; }             //{1-Active or 0-InActive)

        //Conditions with Remarks

        [Display(Name = "Extra Expenses :")]
        public byte ExtraExpenses { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "EEAllowed Amount :")]
        public double EEAllowedAmount { get; set; }

        [Display(Name = "Business Commitment :")]
        public byte BusinessCommitment { get; set; }        //{1-Yes or 0-No)

        [Display(Name = "Business Commitment NoOf Case :")]
        public short BusinsComtntNoOfCase { get; set; }

        [Display(Name = "Insuff Client Report :")]
        public byte InsuffClientReport { get; set; }        //{1-Accepted & 0-Not Accepted}

        [Display(Name = "Insuff Hold Days :")]
        public byte InsuffHoldDays { get; set; }

        [Display(Name = "Incentive :")]
        public byte Incentive { get; set; }                 //{1-Yes or 0-No)

        [Display(Name = "Incentive Instruction :")]
        public string IncentiveInstruction { get; set; }

        [Display(Name = "Penalty :")]
        public byte Penalty { get; set; }                   //{1-Yes or 0-No)

        [Display(Name = "PenaltyD etails :")]
        public string PenaltyDetails { get; set; }

        [Display(Name = "Liability ")]
        public byte Liability { get; set; }                 //{1-Yes or 0-No)

        [Display(Name = "Liability Details :")]
        public string LiabilityDetails { get; set; }

        [Display(Name = "Billing Aprvl :")]
        public byte BillingAprvl { get; set; }           //{1-Yes or 0-No)

        [Display(Name = "Billing Aprvl Details :")]
        public string BillingAprvlDetails { get; set; }

        [Display(Name = "SpocName :")]
        public string SpocName { get; set; }                //this field can accept multiple names

        [Display(Name = " SpocEmailID :")]
        public string SpocEmailID { get; set; }             //this field can accept multiple email ids

        [Display(Name = "Spoc Name :")]
        public string CSpocName { get; set; }

        [Display(Name = "Spoc Designation :")]
        public string CSpocDesignation { get; set; }

        [Display(Name = "Spoc Contact No :")]
        public string CSpocContactNo { get; set; }

        [Display(Name = "Spoc Mobile No :")]
        public string CSpocMobileNo { get; set; }

        [Display(Name = "Spoc EmailID :")]
        public string CSpocEmailID { get; set; }                //this field can accept multiple email ids (means TextArea)

        [Display(Name = "Billing Spoc Name :")]
        public string CBillingSpocName { get; set; }

        [Display(Name = "Billing Spoc Designation :")]
        public string CBillingSpocDesignation { get; set; }

        [Display(Name = "Billing Spoc Mobile No :")]
        public string CBillingSpocMobileNo { get; set; }

        [Display(Name = "Billing Spoc EmailID :")]
        public string CBillingSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)

        [Display(Name = "Billing Instructions :")]
        public string CBillingInstructions { get; set; }

        [Display(Name = "Billing Address :")]
        public string CBillingAddress { get; set; }

        [Display(Name = "Esclation Spoc Name :")]
        public string CEsclationSpocName { get; set; }

        [Display(Name = "Esclation Spoc Designation :")]
        public string CEsclationSpocDesignation { get; set; }

        [Display(Name = "Esclation Spoc MobileNo :")]
        public string CEsclationSpocMobileNo { get; set; }

        [Display(Name = "Esclation Spoc EmailID :")]
        public string CEsclationSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)

        [Display(Name = "Send Insuff Display :")]
        public string CSendInsuffDisplay { get; set; }

        [Display(Name = "Send Insuff Email :")]
        public string CSendInsuffEmail { get; set; }

        [Display(Name = "Send Report Display :")]
        public string CSendReportDisplay { get; set; }

        [Display(Name = "Send Report Email :")]
        public string CSendReportEmail { get; set; }

        [Display(Name = "Send RedReport Display :")]
        public string CSendRedReportDisplay { get; set; }

        [Display(Name = "Send Red Report Email :")]
        public string CSendRedReportEmail { get; set; }

        [Display(Name = "Send Billing Aprvl Display :")]
        public string SendBillingAprvlDisplay { get; set; }

        [Display(Name = "Send Billing Aprvl Display :")]
        public string CSendBillingAprvlDisplay { get; set; }

        [Display(Name = "Send Billing Aprvl Email :")]
        public string CSendBillingAprvlEmail { get; set; }

        //For Client Mail Configuration

        [Display(Name = "SMTP Server ;")]
        public string SMTPServer { get; set; }

        [Display(Name = "SMTP Port ")]
        public string SMTPPort { get; set; }

        [Display(Name = "SMTP User Name :")]
        public string SMTPUserName { get; set; }

        [Display(Name = "SMTP Password :")]
        public string SMTPPassword { get; set; }

        [Display(Name = "Enable Ssl :")]
        public byte EnableSsl { get; set; }

        //For internal use only Not Show on client creation page
        [ScaffoldColumn(false)]
        [Display(Name = "Status :")]
        public byte Status { get; set; }                    //Status 1 or 0

        [Display(Name = "Created Date :")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "SLA Uploaded :")]
        public byte SLAUploaded { get; set; }               //{1-Yes or 0-No) By Default 0 and update when client contact uploaded

        [Display(Name = "Cover Page :")]
        public byte CoverPage { get; set; }                 //{for Select Template}

        [Display(Name = "Agreement Type :")]
        public byte AgreementType { get; set; }             //Dropdown(1-New, 2-Re-New, 3-Expired, 4-OnHold) By Default 'New'

        [Display(Name = "Prev Client :")]
        public short PrevClientRowID { get; set; }           //If (Re-New) then Previous ClientRowID

        [Display(Name = "Hard Copy :")]
        public byte HardCopy { get; set; }                  //{1-Yes or 0-No)

        [Display(Name = "Client Category :")]
        public string ClientCategory { get; set; }          //Dropdown(Platinum,Gold,Silver,Bronze)

        [Display(Name = "Sales SPOC Name :")]
        public string CSalesSPOCName { get; set; }

        public string SLAUploadedDisYesNo { get; set; }

        [Display(Name = "Sales Status :")]
        public byte CSalesStatus { get; set; }              //ClientSalesStatus 1 or 0 

        [Display(Name = "Sales Count :")]
        public short CSalesCount { get; set; }

        [Display(Name = "Other 1 :")]
        public string Other1 { get; set; }

        [Display(Name = "Other 2 :")]
        public string Other2 { get; set; }

        [Display(Name = "Other 3 :")]
        public string Other3 { get; set; }

        [Display(Name = "Other 4 :")]
        public string Other4 { get; set; }

        [Display(Name = "Other 5 :")]
        public string Other5 { get; set; }

        [Display(Name = "Ramco Client Id")]
        public string RamcoId { get; set; }

        [Display(Name = "Ramco Spoc Id")]
        public string SpocId { get; set; }
    }

    public class AddPQClientViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Client Code :")]
        public string ClientCode { get; set; }

        [MaxLength(20)]
        [Display(Name = "ClientCode 1 :")]
        public string ClientCode1 { get; set; }

        [Required]
        [Display(Name = "Client Name :")]
        public short ClientAbbRowID { get; set; }

        [Required]
        [Display(Name = "Client SubGroup :")]
        public short ClientSubgroupID { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Address :")]
        public string Address { get; set; }

        [MaxLength(300)]
        [Display(Name = "Registered Address :")]
        public string RegisteredAddress { get; set; }

        [MaxLength(300)]
        [Display(Name = "Corporate Office Address :")]
        public string CorporateOfficeAddress { get; set; }

        [Required]
        [Display(Name = "Country :")]
        public short CountryRowID { get; set; }

        [Required]
        [Display(Name = "State :")]
        public short StateRowID { get; set; }

        [Required]
        [Display(Name = "District :")]
        public short DistrictRowID { get; set; }

        [Required]
        [Display(Name = "Location :")]
        public int LocationRowID { get; set; }

        [Required]
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }

        [Required]
        [Display(Name = "Code Generation :")]
        public byte CodeGeneration { get; set; }    //{1-Yes & 0-No}

        [Required]
        [Display(Name = "Branch Office :")]
        public short BORowID { get; set; }

        [Required]
        [Display(Name = "Billing Cycle :")]
        public byte BillingRowID { get; set; }

        [Required]
        [Display(Name = "Report Sent by :")]
        public byte ReportSentBy { get; set; }      //{1-Mail & 2-Physical Copy, 3-Both}

        [Required]
        [Display(Name = "Interim Report :")]
        public byte InterimReport { get; set; }     //{1-Yes or 0-No)

        [Required]
        [Display(Name = "Contract Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractDate { get; set; }

        [Required]
        [Display(Name = "Cont. Complition Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractComplitionDate { get; set; }

        [Required]
        [Display(Name = "Pricing Type :")]
        public byte PricingType { get; set; }               //{1-Package wise or 2-Check wise or 3-Both}     

        [Display(Name = "Payment Term ( days ) :")]
        public byte PaymentTermIndays { get; set; }

        [MaxLength(200)]
        [Display(Name = "Special Instructions :")]
        public string SpecialInstructions { get; set; }

        [MaxLength(100)]
        [Display(Name = "Ramco Client Id : ")]
        public string RamcoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Ramco Spoc Id : ")]
        public string SpocId { get; set; }

        //Conditions
        [Display(Name = "Antecedent :")]
        public byte MapAntecedent { get; set; }         //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Disposition :")]
        public byte MapDisposition { get; set; }        //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Severity :")]
        public byte MapSeverity { get; set; }           //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Holidays :")]
        public byte MapHolidays { get; set; }           //{1-Client or 0-Default) (All ask for manage screen if selected client)

        [Display(Name = "Mail Send From Client :")]
        public byte MailSendBy { get; set; }            //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "HRApproval Required :")]
        public byte HRApprovalRequired { get; set; }    //HRApproval Required {1-Yes or 0-No)

        [Display(Name = "Days Calculation :")]
        public byte DaysCalculation { get; set; }       //{1-Working Days or 0-Calendar Days)

        [Display(Name = "Re Open Cases :")]
        public byte ReOpenCases { get; set; }               //{1-Billable & 0-Not Billable}        

        [Display(Name = "Re Open Billing :")]
        public byte ReOpenBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Insuff Billing :")]
        public byte InsuffBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Other Than Green Billing :")]
        public byte OtherThanGreenBilling { get; set; }     //{1-Yes or 0-No)

        [Display(Name = "Stop Case Billing :")]
        public byte StopCaseBilling { get; set; }           //{1-Yes or 0-No)

        [Display(Name = "WIP / Closed Billing :")]
        public byte WIPOrClosedBilling { get; set; }        //{1-Yes or 0-No)

        [Display(Name = "PO Applicable :")]
        public byte POApplicable { get; set; }              //{1-Yes or 0-No)

        [Display(Name = "Employment PV :")]
        public byte EmploymentPV { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "YTR Status :")]
        public byte YTRStatus { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Verbal Report Status :")]
        public byte VerbalReportStatus { get; set; }    //{1-Yes or 0-No)

        [Display(Name = "Candidate Contact :")]
        public byte CandidateContact { get; set; }      //{1-Yes or 0-No)

        [Display(Name = "Client Name Disclosure :")]
        public byte ClientNameDisclosure { get; set; }   //{1-Yes or 0-No)

        [Display(Name = "Client Status :")]
        public byte ClientStatus { get; set; }           //{1-Active or 0-InActive)

        //Conditions with Remarks

        [Display(Name = "Extra Expenses :")]
        public byte ExtraExpenses { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "EEAllowed Amount :")]
        public double EEAllowedAmount { get; set; }

        [Display(Name = "Business Commitment :")]
        public byte BusinessCommitment { get; set; }        //{1-Yes or 0-No)

        [Display(Name = "No of Cases :")]
        public short BusinsComtntNoOfCase { get; set; }

        [Display(Name = "Insuff Client Report :")]
        public byte InsuffClientReport { get; set; }        //{1-Accepted & 0-Not Accepted}

        [Display(Name = "Insuff Hold Days :")]
        public byte InsuffHoldDays { get; set; }

        [Display(Name = "Incentive Instruction :")]
        public byte Incentive { get; set; }                 //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Incentive Instruction ( if yes) :")]
        public string IncentiveInstruction { get; set; }

        [Display(Name = "Penalty :")]
        public byte Penalty { get; set; }                   //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Penalty Details ( if yes )  :")]
        public string PenaltyDetails { get; set; }

        [Display(Name = "Liability :")]
        public byte Liability { get; set; }                 //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Liability Details ( if yes ):")]
        public string LiabilityDetails { get; set; }

        [Display(Name = "Billing Aprvl :")]
        public byte BillingAprvl { get; set; }           //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Billing Approval ( if yes ) :")]
        public string BillingAprvlDetails { get; set; }

        [Required]
        [MaxLength(3000)]
        [Display(Name = "SpocName :")]
        public string SpocName { get; set; }                //this field can accept multiple names

        [Required]
        [MaxLength(5000)]
        [Display(Name = " SpocEmailID :")]
        public string SpocEmailID { get; set; }             //this field can accept multiple email ids

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CSpocDesignation { get; set; }

        [MaxLength(20)]
        [Display(Name = "Contact No :")]
        public string CSpocContactNo { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CSpocMobileNo { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CSpocEmailID { get; set; }                //this field can accept multiple email ids (means TextArea)

        // BillingSpoc
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CBillingSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CBillingSpocDesignation { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CBillingSpocMobileNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CBillingSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)

        [MaxLength(200)]
        [Display(Name = "Billing Instructions :")]
        public string CBillingInstructions { get; set; }

        [MaxLength(300)]
        [Display(Name = "Billing Address :")]
        public string CBillingAddress { get; set; }

        // BillingSpoc end

        // Esclation SPOC Details
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CEsclationSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CEsclationSpocDesignation { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CEsclationSpocMobileNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CEsclationSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)
        // Esclation SPOC Details End

        // Send Mail Ids
        [MaxLength(100)]
        [Display(Name = "Insuff Display :")]
        public string CSendInsuffDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Insuff Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendInsuffEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Report Display :")]
        public string CSendReportDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Report Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendReportEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Red Report Display :")]
        public string CSendRedReportDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Red Report Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendRedReportEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Billing Approval Display :")]
        public string CSendBillingAprvlDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Billing Approval Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendBillingAprvlEmail { get; set; }

        //For Client Mail Configuration ----not show in view page --- 
        //[MaxLength(100)]
        //[Display(Name = "SMTP Server :")]
        //public string SMTPServer { get; set; }

        //[MaxLength(5)]
        //[Display(Name = "SMTP Port :")]
        //public string SMTPPort { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "SMTP User Name :")]
        //[RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        //public string SMTPUserName { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "SMTP Password :")]
        //public string SMTPPassword { get; set; }

        //[Display(Name = "Enable Ssl :")]
        //public byte EnableSsl { get; set; }

        //For internal use only Not Show on client creation page
        [ScaffoldColumn(false)]
        [Display(Name = "Status :")]
        public byte Status { get; set; }                    //Status 1 or 0

        [Display(Name = "Created Date :")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "SLA Uploaded :")]
        public byte SLAUploaded { get; set; }               //{1-Yes or 0-No) By Default 0 and update when client contact uploaded

        [Display(Name = "Report Template :")]
        public byte CoverPage { get; set; }                 //{for Select Template}

        [Display(Name = "Agreement Type :")]
        public byte AgreementType { get; set; }             //Dropdown(1-New, 2-Re-New, 3-Expired, 4-OnHold) By Default 'New'

        //[Display(Name = "Prev Client :")]
        //public short PrevClientRowID { get; set; }           //If (Re-New) then Previous ClientRowID

        //[Display(Name = "Hard Copy :")]
        //public byte HardCopy { get; set; }                  //{1-Yes or 0-No)

        //[MaxLength(50)]
        //[Display(Name = "Client Category :")]
        //public string ClientCategory { get; set; }          //Dropdown(Platinum,Gold,Silver,Bronze)

        //[MaxLength(100)]
        //[Display(Name = "Sales SPOC Name :")]
        //public string CSalesSPOCName { get; set; }

        //[Display(Name = "Sales Status :")]
        //public byte CSalesStatus { get; set; }              //ClientSalesStatus 1 or 0 

        //[Display(Name = "Sales Count :")]
        //public short CSalesCount { get; set; }

        //[Display(Name = "Remark :")]
        //public string Remark { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 1 :")]
        //public string Other1 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 2 :")]
        //public string Other2 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 3 :")]
        //public string Other3 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 4 :")]
        //public string Other4 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 5 :")]
        //public string Other5 { get; set; }
    }
    
    public class PQClientAntDispositionViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        //Conditions
        [Display(Name = "Antecedent :")]
        public byte MapAntecedent { get; set; }         //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Disposition :")]
        public byte MapDisposition { get; set; }        //{1-Client or 0-Default)   (All ask for manage screen if selected client)
             }

    public class UpdatePQClientViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Client Code :")]
        public string ClientCode { get; set; }

        [MaxLength(20)]
        [Display(Name = "ClientCode 1 :")]
        public string ClientCode1 { get; set; }

        [Required]
        [Display(Name = "Client Name :")]
        public short ClientAbbRowID { get; set; }

        [Required]
        [Display(Name = "Client SubGroup :")]
        public short ClientSubgroupID { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Address :")]
        public string Address { get; set; }

        [MaxLength(300)]
        [Display(Name = "Registered Address :")]
        public string RegisteredAddress { get; set; }

        [MaxLength(300)]
        [Display(Name = "Corporate Office Address :")]
        public string CorporateOfficeAddress { get; set; }

        [Required]
        [Display(Name = "Country :")]
        public short CountryRowID { get; set; }

        [Required]
        [Display(Name = "State :")]
        public short StateRowID { get; set; }

        [Required]
        [Display(Name = "District :")]
        public short DistrictRowID { get; set; }

        [Required]
        [Display(Name = "Location :")]
        public int LocationRowID { get; set; }

        [Required]
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }

        [Required]
        [Display(Name = "Code Generation :")]
        public byte CodeGeneration { get; set; }    //{1-Yes & 0-No}

        [Required]
        [Display(Name = "Branch Office :")]
        public short BORowID { get; set; }

        [Required]
        [Display(Name = "Billing Cycle :")]
        public byte BillingRowID { get; set; }

        [Required]
        [Display(Name = "Report Sent by :")]
        public byte ReportSentBy { get; set; }      //{1-Mail & 2-Physical Copy, 3-Both}

        [Required]
        [Display(Name = "Interim Report :")]
        public byte InterimReport { get; set; }     //{1-Yes or 0-No)

        [Required]
        [Display(Name = "Contract Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractDate { get; set; }

        [Required]
        [Display(Name = "Cont. Complition Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ContractComplitionDate { get; set; }

        [Required]
        [Display(Name = "Pricing Type :")]
        public byte PricingType { get; set; }               //{1-Package wise or 2-Check wise or 3-Both}     

        [Display(Name = "Payment Term ( days ) :")]
        public byte PaymentTermIndays { get; set; }

        [MaxLength(200)]
        [Display(Name = "Special Instructions :")]
        public string SpecialInstructions { get; set; }

        [MaxLength(100)]
        [Display(Name = "Ramco Client Id : ")]
        public string RamcoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Ramco Spoc Id : ")]
        public string SpocId { get; set; }

        //Conditions
        [Display(Name = "Antecedent :")]
        public byte MapAntecedent { get; set; }         //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Disposition :")]
        public byte MapDisposition { get; set; }        //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Severity :")]
        public byte MapSeverity { get; set; }           //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "Holidays :")]
        public byte MapHolidays { get; set; }           //{1-Client or 0-Default) (All ask for manage screen if selected client)

        [Display(Name = "Mail Send From Client :")]
        public byte MailSendBy { get; set; }            //{1-Client or 0-Default)   (All ask for manage screen if selected client)

        [Display(Name = "HRApproval Required :")]
        public byte HRApprovalRequired { get; set; }    //HRApproval Required {1-Yes or 0-No)

        [Display(Name = "Days Calculation :")]
        public byte DaysCalculation { get; set; }       //{1-Working Days or 0-Calendar Days)

        [Display(Name = "Re Open Cases :")]
        public byte ReOpenCases { get; set; }               //{1-Billable & 0-Not Billable}        

        [Display(Name = "Re Open Billing :")]
        public byte ReOpenBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Insuff Billing :")]
        public byte InsuffBilling { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Other Than Green Billing :")]
        public byte OtherThanGreenBilling { get; set; }     //{1-Yes or 0-No)

        [Display(Name = "Stop Case Billing :")]
        public byte StopCaseBilling { get; set; }           //{1-Yes or 0-No)

        [Display(Name = "WIP / Closed Billing :")]
        public byte WIPOrClosedBilling { get; set; }        //{1-Yes or 0-No)

        [Display(Name = "PO Applicable :")]
        public byte POApplicable { get; set; }              //{1-Yes or 0-No)

        [Display(Name = "Employment PV :")]
        public byte EmploymentPV { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "YTR Status :")]
        public byte YTRStatus { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "Verbal Report Status :")]
        public byte VerbalReportStatus { get; set; }    //{1-Yes or 0-No)

        [Display(Name = "Candidate Contact :")]
        public byte CandidateContact { get; set; }      //{1-Yes or 0-No)

        [Display(Name = "Client Name Disclosure :")]
        public byte ClientNameDisclosure { get; set; }   //{1-Yes or 0-No)

        [Display(Name = "Client Status :")]
        public byte ClientStatus { get; set; }           //{1-Active or 0-InActive)

        //Conditions with Remarks

        [Display(Name = "Extra Expenses :")]
        public byte ExtraExpenses { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "EEAllowed Amount :")]
        public double EEAllowedAmount { get; set; }

        [Display(Name = "Business Commitment :")]
        public byte BusinessCommitment { get; set; }        //{1-Yes or 0-No)

        [Display(Name = "No of Cases :")]
        public short BusinsComtntNoOfCase { get; set; }

        [Display(Name = "Insuff Client Report :")]
        public byte InsuffClientReport { get; set; }        //{1-Accepted & 0-Not Accepted}

        [Display(Name = "Insuff Hold Days :")]
        public byte InsuffHoldDays { get; set; }

        [Display(Name = "Incentive Instruction :")]
        public byte Incentive { get; set; }                 //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Incentive Instruction ( if yes) :")]
        public string IncentiveInstruction { get; set; }

        [Display(Name = "Penalty :")]
        public byte Penalty { get; set; }                   //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Penalty Details ( if yes )  :")]
        public string PenaltyDetails { get; set; }

        [Display(Name = "Liability :")]
        public byte Liability { get; set; }                 //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Liability Details ( if yes ):")]
        public string LiabilityDetails { get; set; }

        [Display(Name = "Billing Aprvl :")]
        public byte BillingAprvl { get; set; }           //{1-Yes or 0-No)

        [MaxLength(100)]
        [Display(Name = "Billing Approval ( if yes ) :")]
        public string BillingAprvlDetails { get; set; }

        [Required]
        [MaxLength(3000)]
        [Display(Name = "SpocName :")]
        public string SpocName { get; set; }                //this field can accept multiple names

        [Required]
        [MaxLength(5000)]
        [Display(Name = " SpocEmailID :")]
        public string SpocEmailID { get; set; }             //this field can accept multiple email ids

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CSpocDesignation { get; set; }

        [MaxLength(20)]
        [Display(Name = "Contact No :")]
        public string CSpocContactNo { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CSpocMobileNo { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CSpocEmailID { get; set; }                //this field can accept multiple email ids (means TextArea)

        // BillingSpoc
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CBillingSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CBillingSpocDesignation { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CBillingSpocMobileNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CBillingSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)

        [MaxLength(200)]
        [Display(Name = "Billing Instructions :")]
        public string CBillingInstructions { get; set; }

        [MaxLength(300)]
        [Display(Name = "Billing Address :")]
        public string CBillingAddress { get; set; }

        // BillingSpoc end

        // Esclation SPOC Details
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CEsclationSpocName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string CEsclationSpocDesignation { get; set; }

        [MaxLength(15)]
        [Display(Name = "Mobile No :")]
        public string CEsclationSpocMobileNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email :")]
        public string CEsclationSpocEmailID { get; set; }         //this field can accept multiple email ids (means TextArea)
        // Esclation SPOC Details End

        // Send Mail Ids
        [MaxLength(100)]
        [Display(Name = "Insuff Display :")]
        public string CSendInsuffDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Insuff Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendInsuffEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Report Display :")]
        public string CSendReportDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Report Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendReportEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Red Report Display :")]
        public string CSendRedReportDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Red Report Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendRedReportEmail { get; set; }

        [MaxLength(100)]
        [Display(Name = "Billing Aprvl Display :")]
        public string CSendBillingAprvlDisplay { get; set; }

        [MaxLength(100)]
        [Display(Name = "Billing Aprvl Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CSendBillingAprvlEmail { get; set; }

        //For Client Mail Configuration --- not show in view page --- 
        //[MaxLength(100)]
        //[Display(Name = "SMTP Server :")]
        //public string SMTPServer { get; set; }

        //[MaxLength(5)]
        //[Display(Name = "SMTP Port :")]
        //public string SMTPPort { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "SMTP User Name :")]
        //[RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        //public string SMTPUserName { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "SMTP Password :")]
        //public string SMTPPassword { get; set; }

        //[Display(Name = "Enable Ssl :")]
        //public byte EnableSsl { get; set; }

        //For internal use only Not Show on client creation page
        //[ScaffoldColumn(false)]
        //[Display(Name = "Status :")]
        //public byte Status { get; set; }                    //Status 1 or 0

        //[Display(Name = "Created Date :")]
        //public DateTime? CreatedDate { get; set; }

        //[Display(Name = "SLA Uploaded :")]
        //public byte SLAUploaded { get; set; }               //{1-Yes or 0-No) By Default 0 and update when client contact uploaded

        [Display(Name = "Report Template :")]
        public byte CoverPage { get; set; }                 //{for Select Template}

        //[Display(Name = "Agreement Type :")]
        //public byte AgreementType { get; set; }             //Dropdown(1-New, 2-Re-New, 3-Expired, 4-OnHold) By Default 'New'

        //[Display(Name = "Prev Client :")]
        //public short PrevClientRowID { get; set; }           //If (Re-New) then Previous ClientRowID

        //[Display(Name = "Hard Copy :")]
        //public byte HardCopy { get; set; }                  //{1-Yes or 0-No)

        //[MaxLength(50)]
        //[Display(Name = "Client Category :")]
        //public string ClientCategory { get; set; }          //Dropdown(Platinum,Gold,Silver,Bronze)

        //[MaxLength(100)]
        //[Display(Name = "Sales SPOC Name :")]
        //public string CSalesSPOCName { get; set; }

        //[Display(Name = "Sales Status :")]
        //public byte CSalesStatus { get; set; }              //ClientSalesStatus 1 or 0 

        //[Display(Name = "Sales Count :")]
        //public short CSalesCount { get; set; }

        //[Display(Name = "Remark :")]
        //public string Remark { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 1 :")]
        //public string Other1 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 2 :")]
        //public string Other2 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 3 :")]
        //public string Other3 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 4 :")]
        //public string Other4 { get; set; }

        //[MaxLength(100)]
        //[Display(Name = "Other 5 :")]
        //public string Other5 { get; set; }
    }

    public class PQClientForCandiCodeGenViewModel
    {
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Client Code :")]
        public string ClientCode { get; set; }

        [Display(Name = "ClientCode 1 :")]
        public string ClientCode1 { get; set; }

        [Display(Name = "Client Name :")]
        public short ClientAbbRowID { get; set; }

        public string ClientAbbName { get; set; }
        
        [Display(Name = "Client SubGroup :")]
        public short ClientSubgroupID { get; set; }

        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Code Generation :")]
        public byte CodeGeneration { get; set; }    //{1-Yes & 0-No}

    }

    public class PQClientListPagedModel
    {
        public IEnumerable<PQClientListViewModel> PQClients { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    
    public class PQClientListViewModel
    {
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string ClientSubGroup { get; set; }
        public string LocationName { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? ContractComplitionDate { get; set; }
        public byte SLAUploaded { get; set; }
        public byte Status { get; set; }

    }

    public class PQClientMailConfig
    {
        [Required]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }

        [Required]
        [Display(Name = "SMTP Server ;")]
        public string SMTPServer { get; set; }

        [Required]
        [Display(Name = "SMTP Port ")]
        public string SMTPPort { get; set; }

        [Required]
        [Display(Name = "SMTP User Name :")]
        public string SMTPUserName { get; set; }

        [Required]
        [Display(Name = "SMTP Password :")]
        public string SMTPPassword { get; set; }

        [Display(Name = "Is SSL Enable : ")]
        public byte EnableSsl { get; set; }
        [NotMapped]
        public bool EnableSslBool
        {
            get { return EnableSsl > 0; }
            set { EnableSsl = value ? (byte)1 : (byte)0; }
        }
    }

    public class ClientCheckPackageViewModel
    {
        //public int PackageCheckRowId { get; set; }
        public short ClientRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public string CheckOrPackageName { get; set; }
        public int ClientCheckRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        //public string CheckFamilyName { get; set; }
        //public short SubCheckRowID { get; set; }
        //public string SubCheckFamillyName { get; set; }
    }

    public class PQClientCodeHolidaysViewModel
    {
        public short ClientRowID { get; set; }

        public string ClientCode { get; set; }

        public string ClientCode1 { get; set; }

        public short ClientAbbRowID { get; set; }

        public short ClientSubgroupID { get; set; }

        public byte MapHolidays { get; set; }

        public byte DaysCalculation { get; set; }

        public byte Status { get; set; }
    }

    public class PQClientMailFromViewModel
    {        
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string SpocEmailID { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public byte EnableSsl { get; set; }
        public byte MailSendBy { get; set; }

        public string CSendInsuffDisplay { get; set; }
        public string CSendInsuffEmail { get; set; }
        public string CSendReportDisplay { get; set; }
        public string CSendReportEmail { get; set; }
        public string CSendRedReportDisplay { get; set; }
        public string CSendRedReportEmail { get; set; }
        public string CSendBillingAprvlDisplay { get; set; }
        public string CSendBillingAprvlEmail { get; set; }
    }

    public class ClientContractConditions
    {
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public byte PricingType { get; set; }
        public byte MapAntecedent { get; set; }
        public byte MapDisposition { get; set; }
        public byte MapSeverity { get; set; }
        public byte MapHolidays { get; set; }
        public byte MailSendBy { get; set; }
        public byte CandidateContact { get; set; }
    }

    public class PQClientForExtraExpViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short ClientRowID { get; set; }
    
        [Display(Name = "Extra Expenses :")]
        public byte ExtraExpenses { get; set; }             //{1-Yes or 0-No)

        [Display(Name = "EEAllowed Amount :")]
        public double EEAllowedAmount { get; set; }   
    }

    public class ExportClientViewModel
    {
        public short ClientRowID { get; set; }       
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string SubGroup { get; set; }
        public string Location { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public byte SLAUploaded { get; set; }       
    }
}
