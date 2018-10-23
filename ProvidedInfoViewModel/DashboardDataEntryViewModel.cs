using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class DashboardManagerDEViewModel
    {
        public int totRefereceGenByTL { get; set; }
        public int totAllocated { get; set; }
        public int totUnAllocated { get; set; }
        public int totPriority { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpen { get; set; }

        public int totWithin1Hr { get; set; }
        public int totBetween2To4Hrs { get; set; }
        public int totBeyond4Hrs { get; set; }
        public int totDelayBy2Hrs { get; set; }
        public int totDelayBy2To5Hrs { get; set; }
        public int totDelayBeyond5Hrs { get; set; }

        public int totInsufficiency { get; set; }
        public int totResearch { get; set; }
        public int totDEScanPending { get; set; }
        public int totDEPending { get; set; }
        public int totQCPending { get; set; }
        public int totClosed { get; set; }
        public int totInsuffResolved { get; set; }

        public string CaseStatus { get; set; }
    }

    public class DashboardDataEntryTLViewModel
    {
        public int totRefereceGenByTL { get; set; }
        public int totAllocated { get; set; }
        public int totUnAllocated { get; set; }
        public int totPriority { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpen { get; set; }

        public int totWithin1Hr { get; set; }
        public int totBetween2To4Hrs { get; set; }
        public int totBeyond4Hrs { get; set; }
        public int totDelayBy2Hrs { get; set; }
        public int totDelayBy2To5Hrs { get; set; }
        public int totDelayBeyond5Hrs { get; set; }

        public int totInsufficiency { get; set; }
        public int totResearch { get; set; }
        public int totDEScanPending { get; set; }
        public int totDEPending { get; set; }
        public int totQCPending { get; set; }
        public int totClosed { get; set; }

        public int totInsuffResolved { get; set; }
    }

    public class DashboardDETeamMemberDEScanViewModel
    {
        public int totReceived { get; set; }
        public int totPending { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpenWIP { get; set; }
        public int totPriority { get; set; }
        public int totClosed { get; set; }

        public int totWithin1Hr { get; set; }
        public int totBetween2To4Hrs { get; set; }
        public int totBeyond4Hrs { get; set; }
        public int totDelayBy2Hrs { get; set; }
        public int totDelayBy2To5Hrs { get; set; }
        public int totDelayBeyond5Hrs { get; set; }
    }

    public class DashboardDETeamMemberDEViewModel
    {
        public int totReceived { get; set; }
        public int totPending { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpenWIP { get; set; }
        public int totPriority { get; set; }
        public int totClosed { get; set; }

        public int totWithin1Hr { get; set; }
        public int totBetween2To4Hrs { get; set; }
        public int totBeyond4Hrs { get; set; }
        public int totDelayBy2Hrs { get; set; }
        public int totDelayBy2To5Hrs { get; set; }
        public int totDelayBeyond5Hrs { get; set; }

        public int totInsuffRaised { get; set; }
        public int totInsuffResolved { get; set; }
        public int totResearch { get; set; }
        public int totYTR { get; set; }
        public int totDEPending { get; set; }
    }

    public class DashboardDETeamMemberDEQCViewModel
    {
        public int totReceived { get; set; }
        public int totPending { get; set; }
        public int totRejectionWIP { get; set; }
        public int totReOpenWIP { get; set; }
        public int totPriority { get; set; }
        public int totClosed { get; set; }

        public int totWithin1Hr { get; set; }
        public int totBetween2To4Hrs { get; set; }
        public int totBeyond4Hrs { get; set; }
        public int totDelayBy2Hrs { get; set; }
        public int totDelayBy2To5Hrs { get; set; }
        public int totDelayBeyond5Hrs { get; set; }

        public int totInsuffRaised { get; set; }
        public int totInsuffResolved { get; set; }
        public int totResearch { get; set; }
        public int totYTR { get; set; }
        public int totDEPending { get; set; }
    }

    public class DashboardDataEntryViewModel
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
    }

    public class DashboardDEListViewModel
    {
        public IEnumerable<DashboardDataEntryViewModel> DashboardDetailsDE { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    
    public class ExportExcelDEViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName  { get; set; }
        public string SecuritasID  { get; set; }
        public string CandidateName  { get; set; }
        public DateTime? CreatedDate  { get; set; }
        public string Status { get; set; }

    }

    public class ExportExcelAlocationDEViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string SecuritasID { get; set; }
        public string CandidateName { get; set; }      
        public string AllocatedScanner { get; set; }
        public string AllocatedDE { get; set; }
        public string AllocatedQC { get; set; }
        public string Status { get; set; }

    }

    public class DashboardDEExportViewModel
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
        public string SubCheckName { get; set; }
        public string CaseStatus { get; set; }
    }

    public class DashboardExportDEListViewModel
    {
        public IEnumerable<DashboardDEExportViewModel> ExportExDetailsDE { get; set; }
       
    }

    public class ExportExcelDEYTRViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string SecuritasID { get; set; }
        public string CandidateName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CheckName { get; set; }
        public string Status { get; set; }

    }

    public class ExportExcelREAllocationByDEViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string SecuritasID { get; set; }
        public string CandidateName { get; set; }
        public string AllocatedScanner { get; set; }
        public string AllocatedDE { get; set; }
        public string AllocatedDEQC { get; set; }
        public DateTime? CreatedDate { get; set; }     
        
    }

    public class ExportExcelDEQCViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string SecuritasID { get; set; }
        public string CandidateName { get; set; }
        public string AllocatedScanner { get; set; }
        public string AllocatedDE { get; set; }
        public string Status { get; set; }

    }

    public class ExportExcelDEScannerViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string SecuritasID { get; set; }
        public string CandidateName { get; set; }
        public DateTime? AllocatedOn { get; set; }
        public string UploadedByClient { get; set; }

    }
}
