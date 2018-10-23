using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientDashboardViewModel
    {
        public int totReportReceived { get; set; }
        public int totWIP { get; set; }
        public int totPendingwithcandidate { get; set; }
        public int totCaseApprovalpending { get; set; }
        public int totInsuffWIP { get; set; }
        public int totYTRWIP { get; set; }
        public int totRejectionWIP { get; set; }        
        public int totReOpen { get; set; }
        public int totPriority { get; set; }

        public int totYTRHold { get; set; }
        public int totYTRHoldOr10Days { get; set; }
        public int totInsufficiency { get; set; }
        public int totInsuffOr5Day { get; set; }
        public int totFundApproval { get; set; }
        public int totEscalated { get; set; }
        public int totInterim { get; set; }
        public int totFinal { get; set; }
        public int totOtherthanGreen { get; set; }
    }

    public class ClientCandidateViewModel
    {
        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public string CompanyRefNo { get; set; }
        public string CandidateCode { get; set; }

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }

        public string CaseStatus { get; set; }

        public string FinalStatus { get; set; }
        public string FinalColor { get; set; }
        public byte InterimReport { get; set; }

        public bool IsReportUploaded { get; set; }
        public string ReportUploadedName { get; set; }
        public DateTime? ReportUploadedDate { get; set; }
    }

    public class ExcelClientCandidateViewModel
    {
        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public string CompanyRefNo { get; set; }
        public string CandidateCode { get; set; }

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }

        public string CaseStatus { get; set; }

        public string FinalStatus { get; set; }
        public string FinalColor { get; set; }
        public byte InterimReport { get; set; }

        public bool IsReportUploaded { get; set; }
        public string ReportUploadedName { get; set; }
        public DateTime? ReportUploadedDate { get; set; }
    }


    public class DashboardClientCandidateListViewModel
    {
        public IEnumerable<ClientCandidateViewModel> DashboardClientCandidates { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    #region ***** CS Dashboard View Model *****

    public class DashboardManagerClientServicingViewModel
    {
        public int totWIP { get; set; }
        public int totPendingwithcandidate { get; set; }
        public int totPendingwithHR { get; set; }
        public int totNonInitiated { get; set; }
        public int totYTRHold { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpen { get; set; }
        public int totPriority { get; set; }
        public int totInsuffWIP { get; set; }

        public int totTodaysDue { get; set; }
        public int totDueinNext3days { get; set; }
        public int totInTAT4to7days { get; set; }       
        public int totBT1to2days { get; set; }
        public int totBT3to5days { get; set; }
        public int totBT5to10days { get; set; }
        public int totBT10daysPlus { get; set; }
        public int tot1checkPending { get; set; }
        public int totInsuffPending5Day { get; set; }  
        
        public int totWIPRevenue { get; set; }
        public int totInsufficiency { get; set; }
        public int totWIPYTR { get; set; }
        public int totQCPending { get; set; }
        public int totFundApproval { get; set; }
        public int totApprovalPending { get; set; }
        public int totEscalated { get; set; }
        public int totExprted { get; set; }        
        public int totOutTatInPercent { get; set; }

        public short ClientRowID { get; set; }
    }

    #endregion
}
