using BAL.VerificationRepository;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;
using ViewModels.VerificationViewModel;

namespace BAL.ClientRepository
{
    public class ClientServicingRepository : IClientServicingRepository
    {
        DataContext db;
        public ClientServicingRepository()
        {
            db = new DataContext();
        }

        public DashboardManagerClientServicingViewModel GetManagerClientServicingDashBoardInfo(short TeamMemberRowId, short ClientRowID, string SpocEmailID)
        {
            try
            {
                DateTime todayTATDate = DateTime.Now;
                DateTime totDueinNext3days = todayTATDate.AddDays(3);
                DateTime totInTAT4days = todayTATDate.AddDays(4);
                DateTime totInTAT7days = todayTATDate.AddDays(7);
                DateTime totBT1days = todayTATDate.AddDays(-1);
                DateTime totBT3days = todayTATDate.AddDays(-2);
                DateTime totBT5days = todayTATDate.AddDays(-5);
                DateTime totBT10days = todayTATDate.AddDays(-10);

                IQueryable<PQPersonal> CaseList = db.PQPersonals.Include("PQClientMaster");
                IQueryable<TempPQPersonal> CaseList1 = db.TempPQPersonals;
                bool flag = false;

                if (ClientRowID > 0)
                {
                    flag = true;
                    CaseList = CaseList.Where(a => a.ClientRowID == ClientRowID);
                    CaseList1 = CaseList1.Where(a => a.ClientRowID == ClientRowID && a.OtherDetails != "DEC");
                }
                else
                {
                    flag = true;
                    var Clients = db.PQClientMasters.Where(s => s.SpocEmailID.Contains(SpocEmailID)).Select(s => s.ClientRowID).ToList();

                    CaseList = CaseList.Where(a => Clients.Contains(a.ClientRowID));
                    CaseList1 = CaseList1.Where(a => Clients.Contains(a.ClientRowID) && a.OtherDetails != "DEC");
                }

                if (flag)
                {
                    return new DashboardManagerClientServicingViewModel
                    {
                        totWIP = CaseList.Where(t => t.CaseStatus == "WIP").Count(),
                        totPendingwithcandidate = CaseList1.Count(),
                        totPendingwithHR = CaseList1.Where(t => t.PQClientMaster.HRApprovalRequired == 1).Count(),
                        totNonInitiated = 0,
                        totYTRHold = CaseList.Where(t => t.CaseStatus == "YTR").Count(),
                        totRejectionWIP = CaseList.Where(t => t.CaseStatus == "Rejected").Count(),
                        totReOpen = CaseList.Where(t => t.CaseStatus == "ReOpen").Count(),
                        totPriority = CaseList.Where(t => t.CaseType == "Priority").Count(),
                        totInsuffWIP = CaseList.Where(t => t.CaseStatus == "Insufficent").Count(),

                        totTodaysDue = CaseList.Where(t =>
                     DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate)
                                ).ToList().Count,

                        totDueinNext3days = CaseList.Where(t =>
                        DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(todayTATDate) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totDueinNext3days)
                                ).ToList().Count,

                        totInTAT4to7days = CaseList.Where(t =>
                          DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(totInTAT4days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totInTAT7days)
                                ).ToList().Count,

                        totBT1to2days = CaseList.Where(t =>
                      DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(totBT1days) &&
                        DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT3days)
                                ).ToList().Count,

                        totBT3to5days = CaseList.Where(t =>
                       DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(totBT3days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT5days)
                                ).ToList().Count,

                        totBT5to10days = CaseList.Where(t =>
                       DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(totBT5days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT10days)
                                ).ToList().Count,

                        totBT10daysPlus = CaseList.Where(t =>
                        DbFunctions.TruncateTime(t.DeliveryDate) < DbFunctions.TruncateTime(totBT10days)
                                ).ToList().Count,

                        tot1checkPending = 0,
                        totInsuffPending5Day = 0,
                        totInsufficiency = CaseList.Where(t => t.CaseStatus == "Insufficent").Count(),
                        totEscalated = 0,  //CaseList.Where(t => t.CaseStatus == "PrecallingWIP").Count(),
                        totExprted = 0,    //CaseList.Where(t => t.CaseStatus == "PrecallingWIP").Count(),
                        totQCPending = CaseList.Where(t => t.CaseStatus == "Allocated" && t.AllocatedToDEQC > 0).Count(),
                        totFundApproval = CaseList.Where(t => t.CaseStatus == "Funds Pending").Count(),
                        totOutTatInPercent = 0,//CaseList.Where(t => t.MgrCheckStatus == "RW-Approval-Mgr" && t.PQAddress.CheckStatus == "RW-Approval-Mgr" && t.MgrAllocatedTo > 0).Count(),

                    };
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DashboardClientCandidateListViewModel GetClientServicingDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingDate = "", string CompletedDate = "", byte tatdays = 0, string SpocEmailID = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQPersonal> data = db.PQPersonals.Include("PQClientMaster");

                if (ClientRowID > 0)
                {
                    data = data.Where(b => b.ClientRowID == ClientRowID);
                }
                else
                {
                    var Clients = db.PQClientMasters.Where(s => s.SpocEmailID.Contains(SpocEmailID)).Select(s => s.ClientRowID).ToList();
                    data = data.Where(a => Clients.Contains(a.ClientRowID));
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => (b.Name + " " + b.MiddleName + " " + b.LastName).Replace(" ", String.Empty).Contains(Search.Replace(" ", String.Empty)) || b.CompanyRefNo.ToLower().Trim() == Search.ToLower().Trim());
                }
                if (!string.IsNullOrEmpty(RecievingDate))
                {
                    DateTime startDate = Convert.ToDateTime(RecievingDate);
                    data = data.Where(b => DbFunctions.TruncateTime(b.OrderDate) == startDate.Date);
                }
                if (!string.IsNullOrEmpty(CompletedDate))
                {
                    DateTime startDate = Convert.ToDateTime(CompletedDate);
                    data = data.Where(b => DbFunctions.TruncateTime(b.DeliveryDate) == startDate.Date);
                }

                if (!string.IsNullOrEmpty(CaseStatus))
                {
                    if (CaseStatus == "WIP")
                    {
                        data = data.Where(p => p.CaseStatus == "WIP");
                    }
                    if (CaseStatus == "NonInitiated")
                    {
                        data = data.Where(p => p.AllocatedToDEScan == 0 && p.AllocatedToDE == 0 && p.AllocatedToDEQC == 0);
                    }
                    if (CaseStatus == "YTRHold")
                    {
                        data = data.Where(p => p.CaseStatus == "YTR");
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
                    if (CaseStatus == "Insufficiency" || CaseStatus == "InsuffWIP")
                    {
                        data = data.Where(p => p.CaseStatus == "Insufficent");
                    }
                    if (CaseStatus == "WIPRevenue")
                    {
                        data = data.Where(p => p.CaseStatus == "WIPRevenue");
                    }
                    if (CaseStatus == "WIPYTR")
                    {
                        data = data.Where(p => p.CaseStatus == "WIPYTR");
                    }
                    if (CaseStatus == "FundApproval")
                    {
                        data = data.Where(p => p.CaseStatus == "Funds Pending");
                    }
                    if (CaseStatus == "ApprovalPending")
                    {
                        data = data.Where(p => p.PQClientMaster.HRApprovalRequired == 1);
                    }
                    if (CaseStatus == "WIPDEQC")
                    {
                        data = data.Where(p => p.CaseStatus == "Allocated" && p.AllocatedToDEQC > 0);
                    }
                    if (CaseStatus == "Escalated")
                    {
                        data = data.Where(p => p.CaseStatus == "Escalated");
                    }
                    if (CaseStatus == "Closed")
                    {
                        data = data.Where(p => p.CaseStatus == "Closed");
                    }
                    if (CaseStatus == "OutTAT")
                    {
                        data = data.Where(p => p.CaseStatus == "OutTAT");
                    }
                }

                if (tatdays > 0)
                {
                    data = GetPersonalInfoByTATHours(data, tatdays);
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
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DashboardClientCandidateListViewModel GetClientServicingDashBoardTempPQPersonalInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingDate = "", string SpocEmailID = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<TempPQPersonal> data = db.TempPQPersonals;

                if (ClientRowID > 0)
                {
                    data = data.Where(a => a.ClientRowID == ClientRowID);
                }
                else
                {
                    var Clients = db.PQClientMasters.Where(s => s.SpocEmailID.Contains(SpocEmailID)).Select(s => s.ClientRowID).ToList();
                    data = data.Where(a => Clients.Contains(a.ClientRowID));
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => (b.Name + " " + b.MiddleName + " " + b.LastName).Replace(" ", String.Empty).Contains(Search.Replace(" ", String.Empty)) || b.CompanyRefNo.ToLower().Trim() == Search.ToLower().Trim());
                }
                if (!string.IsNullOrEmpty(RecievingDate))
                {
                    DateTime startDate = Convert.ToDateTime(RecievingDate);
                    data = data.Where(b => DbFunctions.TruncateTime(b.CreatedDate) == startDate.Date);
                }

                if (CaseStatus == "Pendingwithcandidate")
                {
                    data = data.Where(p => p.OtherDetails != "DEC");
                }
                if (CaseStatus == "PendingwithHR")
                {
                    data = data.Where(p => p.OtherDetails != "DEC" && p.PQClientMaster.HRApprovalRequired == 1);
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
                    CaseStatus = item.OtherDetails,
                    CreatedDate = item.CreatedDate,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private IQueryable<PQPersonal> GetPersonalInfoByTATHours(IQueryable<PQPersonal> data, byte tatdays)
        {
            DateTime todayTATDate = DateTime.Now;
            DateTime totDueinNext3days = todayTATDate.AddDays(3);
            DateTime totInTAT4days = todayTATDate.AddDays(4);
            DateTime totInTAT7days = todayTATDate.AddDays(7);
            DateTime totBT1days = todayTATDate.AddDays(-1);
            DateTime totBT3days = todayTATDate.AddDays(-2);
            DateTime totBT5days = todayTATDate.AddDays(-5);
            DateTime totBT10days = todayTATDate.AddDays(-10);

            if (tatdays == 1)
            {
                data = data.Where(t => DbFunctions.TruncateTime(t.DeliveryDate) == DbFunctions.TruncateTime(todayTATDate));
            }
            else if (tatdays == 2)
            {
                data = data.Where(t =>
                DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(todayTATDate) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totDueinNext3days));
            }
            else if (tatdays == 3)
            {
                data = data.Where(t => DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(totInTAT4days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totInTAT7days));
            }
            else if (tatdays == 4)
            {
                data = data.Where(t =>
               DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(totBT1days) &&
                        DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT3days));
            }
            else if (tatdays == 5)
            {
                data = data.Where(t =>
                  DbFunctions.TruncateTime(t.DeliveryDate) >= DbFunctions.TruncateTime(totBT3days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT5days));
            }
            else if (tatdays == 6)
            {
                data = data.Where(t =>
               DbFunctions.TruncateTime(t.DeliveryDate) > DbFunctions.TruncateTime(totBT5days) &&
                          DbFunctions.TruncateTime(t.DeliveryDate) <= DbFunctions.TruncateTime(totBT10days));
            }
            else if (tatdays == 7)
            {
                data = data.Where(t =>
               DbFunctions.TruncateTime(t.DeliveryDate) < DbFunctions.TruncateTime(totBT10days));
            }
            return data;
        }
    }

}
