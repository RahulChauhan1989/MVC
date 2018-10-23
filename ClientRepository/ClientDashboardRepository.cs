using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class ClientDashboardRepository : IClientDashboardRepository
    {
        DataContext db;
        public ClientDashboardRepository()
        {
            db = new DataContext();
        }

        public ClientDashboardViewModel GetClientDashBoardInfo(short ClientRowId, int ClientUserRowID = 0)
        {
            try
            {
                #region ****** Count YTR Hold Days from Employment ******

                DateTime todayTATDate = DateTime.Now;
                DateTime YTRHoldOr10DaysDate = todayTATDate.AddDays(-10);

                var data = db.PQEmploymentStatus.Where(p => p.DETMCheckStatus == "YTR" && p.PQEmployment.ClientRowID == ClientRowId);
                if (ClientUserRowID > 0)
                {
                    data = data.Where(p => p.PQEmployment.PQPersonal.ClientUserRowID == ClientUserRowID);
                }
                int YTRHold = data.ToList().Count;
                
                data = data.Where(t => DbFunctions.TruncateTime(t.DETMAllocatedDate) <= DbFunctions.TruncateTime(YTRHoldOr10DaysDate));
                int YTRHoldOr10Days = data.ToList().Count; 

                #endregion

                IQueryable <PQPersonal> CaseList = db.PQPersonals.Where(a => a.ClientRowID == ClientRowId);
                if (ClientUserRowID > 0)
                {
                    CaseList = CaseList.Where(p => p.ClientUserRowID == ClientUserRowID);
                }

                IQueryable<TempPQPersonal> TempCaseList = db.TempPQPersonals.Where(p => p.ClientRowID == ClientRowId && p.Status == 1);
                if (ClientUserRowID > 0)
                {
                    TempCaseList = TempCaseList.Where(p => p.ClientUserRowID == ClientUserRowID);
                }

                return new ClientDashboardViewModel
                {
                    //totReportReceived = CaseList.Where(t => t.CaseStatus == "Closed").ToList().Count,
                    //totWIP = CaseList.Where(t => t.CaseStatus == "WIP").ToList().Count,
                    totReportReceived = CaseList.Where(t => t.RWQCManagerTo > 0 && t.IsReportUploaded && !string.IsNullOrEmpty(t.ReportUploadedName)).ToList().Count,
                    totWIP = CaseList.ToList().Count,
                    totPendingwithcandidate = TempCaseList.Where(t => t.OtherDetails != "DEC" && t.OtherDetails != "Approved" && t.OtherDetails == "Pending").ToList().Count,
                    totCaseApprovalpending = TempCaseList.Where(t => t.PQClientMaster.HRApprovalRequired == 1 && t.OtherDetails == "DEC").ToList().Count,
                    totInsuffWIP = CaseList.Where(t => t.CaseStatus == "Insufficent").ToList().Count,
                    totYTRWIP = CaseList.Where(t => t.CaseStatus == "YTR").ToList().Count,
                    totRejectionWIP = CaseList.Where(t => t.CaseStatus == "Rejected").ToList().Count,
                    totReOpen = CaseList.Where(t => t.CaseStatus == "ReOpen").ToList().Count,
                    totPriority = CaseList.Where(t => t.CaseType == "Priority").ToList().Count,

                    totYTRHold = YTRHold, // CaseList.Where(t => t.CaseStatus == "YTR").ToList().Count,
                    totYTRHoldOr10Days = YTRHoldOr10Days, // CaseList.Where(t => t.CaseStatus == "YTR").ToList().Count,
                    totInsufficiency = CaseList.Where(t => t.CaseStatus == "Insufficent").ToList().Count,
                    totInsuffOr5Day = CaseList.Where(t => t.CaseStatus == "Insufficent").ToList().Count,
                    totFundApproval = CaseList.Where(t => t.CaseStatus == "Funds Pending").ToList().Count,
                    totEscalated = 0,//CaseList.Where(t => t.CaseStatus == "WIP").ToList().Count,
                    totInterim = CaseList.Where(t => t.RWQCManagerTo > 0 && t.IsReportUploaded && !string.IsNullOrEmpty(t.ReportUploadedName)).ToList().Count,
                    totFinal = 0,// CaseList.Where(t => t.CaseStatus == "Closed").ToList().Count,
                    totOtherthanGreen = CaseList.Where(t => !string.IsNullOrEmpty(t.FinalColor) && t.FinalColor != "Green").ToList().Count,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DashboardClientCandidateListViewModel GetClientDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", byte tatHours = 0, int ClientUserRowID = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<PQPersonal> data = db.PQPersonals.Include("PQClientMaster").Where(p => p.ClientRowID == ClientRowID);

                if (ClientRowID > 0)
                {
                    data = data.Where(b => b.ClientRowID == ClientRowID);
                }

                if (ClientUserRowID > 0)
                {
                    data = data.Where(p => p.ClientUserRowID == ClientUserRowID);
                }

                if (!string.IsNullOrEmpty(CaseStatus))
                {
                    if (CaseStatus == "ReportReceived")
                    {
                        data = data.Where(p => p.RWQCManagerTo > 0 && p.IsReportUploaded && !string.IsNullOrEmpty(p.ReportUploadedName));
                    }
                    if (CaseStatus == "WIP")
                    {
                        data = data.Where(p => p.ClientRowID == ClientRowID);
                    }
                    if (CaseStatus == "Pendingcandidate")
                    {
                        data = data.Where(p => p.CaseStatus == "WIP" || p.CaseStatus == "Allocated");
                    }
                    if (CaseStatus == "CaseApprpending")
                    {
                        data = data.Where(p => p.CaseStatus == "CaseApprpending");
                    }
                    if (CaseStatus == "InsuffWIP")
                    {
                        data = data.Where(p => p.CaseStatus == "Insufficent");
                    }
                    if (CaseStatus == "YTRWIP")
                    {
                        data = data.Where(p => p.CaseStatus == "YTRWIP");
                    }
                    if (CaseStatus == "RejectionWIP")
                    {
                        data = data.Where(p => p.CaseStatus == "Rejected");
                    }
                    if (CaseStatus == "ReOpen")
                    {
                        data = data.Where(p => p.CaseStatus == "ReOpen");
                    }
                    if (CaseStatus == "Priority")
                    {
                        data = data.Where(p => p.CaseType == "Priority");
                    }
                    if (CaseStatus == "YTRHold")
                    {
                        data = data.Where(p => p.CaseStatus == "YTR");
                    }
                    if (CaseStatus == "YTRHold10Days")
                    {
                        data = data.Where(p => p.CaseStatus == "YTR");
                    }
                    if (CaseStatus == "Insufficiency")
                    {
                        data = data.Where(p => p.CaseStatus == "Insufficent");
                    }
                    if (CaseStatus == "InsuffOr5Day")
                    {
                        data = data.Where(p => p.CaseStatus == "Insufficent");
                    }
                    if (CaseStatus == "FundApproval")
                    {
                        data = data.Where(p => p.CaseStatus == "Funds Pending");
                    }
                    if (CaseStatus == "Escalated")
                    {
                        data = data.Where(p => p.CaseStatus == "Escalated");
                    }
                    if (CaseStatus == "Interim")
                    {
                        data = data.Where(p => p.RWQCManagerTo > 0 && p.IsReportUploaded && !string.IsNullOrEmpty(p.ReportUploadedName));
                    }
                    if (CaseStatus == "Final")
                    {
                        data = data.Where(p => p.CaseStatus == "Final");
                    }
                    if (CaseStatus == "OtherthanGreen")
                    {
                        data = data.Where(p => !string.IsNullOrEmpty(p.FinalColor) && p.FinalColor != "Green");
                    }
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => (b.Name + " " + b.MiddleName + " " + b.LastName).ToString().Replace(" ", "").Contains(Search.Replace(" ", "")) || b.ClientRefID == Search || b.CompanyRefNo == Search || b.CaseStatus == Search || b.CandidateCode == Search);
                }

                if (tatHours > 0)
                {
                    data = GetPersonalInfoTLByTATHours(data, tatHours);
                }

                switch (sort)
                {
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.PersonalRowID) : data.OrderByDescending(d => d.PersonalRowID);
                        break;
                }

                DashboardClientCandidateListViewModel model = new DashboardClientCandidateListViewModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.DashboardClientCandidates = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientCandidateViewModel
                {
                    PersonalRowID = item.PersonalRowID,
                    ClientRowID = item.ClientRowID,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    CandidateName = item.Name + " " + item.MiddleName + " " + item.LastName,
                    CandidateCode = item.CandidateCode,//copy
                    CompanyRefNo = item.CompanyRefNo,
                    OutDate = item.DeliveryDate,
                    CaseStatus = item.CaseStatus,
                    CreatedDate = item.CreatedDate,
                    FinalStatus = item.FinalStatus,
                    FinalColor = item.FinalColor,
                    InterimReport = item.PQClientMaster.InterimReport,
                    IsReportUploaded=item.IsReportUploaded,
                    ReportUploadedName=item.ReportUploadedName,
                    ReportUploadedDate=item.ReportUploadedDate,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DashboardClientCandidateListViewModel GetClientTempDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", int ClientUserRowID = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<TempPQPersonal> data = db.TempPQPersonals.Include("PQClientMaster").Where(p => p.ClientRowID == ClientRowID);

                if (ClientRowID > 0)
                {
                    data = data.Where(b => b.ClientRowID == ClientRowID);
                }

                if (ClientUserRowID > 0)
                {
                    data = data.Where(p => p.ClientUserRowID == ClientUserRowID);
                }

                if (!string.IsNullOrEmpty(CaseStatus))
                {

                    if (CaseStatus == "Pendingcandidate")
                    {
                        data = data.Where(p => p.OtherDetails != "DEC" && p.OtherDetails != "Approved" && p.OtherDetails == "Pending");
                    }
                    if (CaseStatus == "CaseApprpending")
                    {
                        data = data.Where(p => p.PQClientMaster.HRApprovalRequired == 1 && p.OtherDetails == "DEC");
                    }
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => (b.Name + " " + b.MiddleName + " " + b.LastName).ToString().Contains(Search) || b.ClientRefID == Search || b.CompanyRefNo == Search);
                }
                if (!string.IsNullOrEmpty(RecievingToDate) && !string.IsNullOrEmpty(RecievingFromDate))
                {
                    DateTime startDate = Convert.ToDateTime(RecievingFromDate);
                    DateTime EndDate = Convert.ToDateTime(RecievingToDate);

                    data = data.Where(b => DbFunctions.TruncateTime(b.CreatedDate) >= startDate.Date && DbFunctions.TruncateTime(b.CreatedDate) <= EndDate.Date);
                }

                switch (sort)
                {
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.PersonalRowID) : data.OrderByDescending(d => d.PersonalRowID);
                        break;
                }

                DashboardClientCandidateListViewModel model = new DashboardClientCandidateListViewModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.DashboardClientCandidates = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientCandidateViewModel
                {
                    PersonalRowID = item.PersonalRowID,
                    ClientRowID = item.ClientRowID,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    CandidateName = item.Name + " " + item.MiddleName + " " + item.LastName,
                    CandidateCode = item.CandidateCode,//copy
                    CompanyRefNo = item.CompanyRefNo,
                    //OutDate = item.DeliveryDate,
                    CaseStatus = "DataEntry By Candidate",
                    CreatedDate = item.CreatedDate,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IQueryable<PQPersonal> GetPersonalInfoTLByTATHours(IQueryable<PQPersonal> data, byte tatHours)
        {
            DateTime todayTATDate = DateTime.Now;

            if (tatHours == 1)
            {
                DateTime InTAT4Hrs = todayTATDate.AddHours(-8);
                data = data.Where(t => DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(InTAT4Hrs));
            }
            else if (tatHours == 2)
            {
                DateTime InTAT4Hrs = todayTATDate.AddHours(-4);
                DateTime InTAT8Hrs = todayTATDate.AddHours(-8);
                data = data.Where(t => DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                            DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(InTAT4Hrs) &&
                            DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(InTAT8Hrs));
            }
            else if (tatHours == 3)
            {
                DateTime InTAT1Hrs = todayTATDate.AddHours(-4);
                data = data.Where(t =>
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(InTAT1Hrs));
            }
            else if (tatHours == 4)
            {
                DateTime InTAT12Hrs = todayTATDate.AddHours(-12);
                data = data.Where(t =>
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                DbFunctions.TruncateTime(t.DeliveryDate) < DbFunctions.TruncateTime(InTAT12Hrs));
            }
            else if (tatHours == 5)
            {
                DateTime InTAT24Hrs = todayTATDate.AddHours(-24);
                data = data.Where(t =>
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                            DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(InTAT24Hrs));
            }
            else if (tatHours == 6)
            {
                DateTime InTAT36Hrs = todayTATDate.AddHours(-36);
                data = data.Where(t =>
                DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate) &&
                DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(InTAT36Hrs));
            }

            return data;
        }

    }
}
