using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class PQClientRepository : IPQClientRepository
    {
        DataContext db;

        public PQClientRepository()
        {
            db = new DataContext();
        }

        public bool IsPQClientData(string ClientCode, short ClientSubgroupID)
        {
            try
            {
                var data = db.PQClientMasters.Where(a => a.ClientCode.ToLower().Trim() == ClientCode.ToLower().Trim() && a.ClientSubgroupID == ClientSubgroupID).FirstOrDefault();
                if (data != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetClientAbbName(short ClientAbbRowID)
        {
            try
            {
                return db.MasterClientAbbreviations.Where(a => a.ClientAbbRowID == ClientAbbRowID).FirstOrDefault().ClientAbbreviation.Trim();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetSubGroupName(short ClientSubgroupID)
        {
            try
            {
                return db.MasterClientSubGroups.Where(a => a.ClientSubGroupID == ClientSubgroupID).FirstOrDefault().ClientSubGroupName.Trim();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddPQClient(AddPQClientViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientMaster entity = new PQClientMaster();
                    entity.ClientCode = model.ClientCode;
                    entity.ClientRowID = model.ClientRowID;
                    entity.ClientCode1 = model.ClientCode1;
                    entity.ClientAbbRowID = model.ClientAbbRowID;
                    entity.ClientSubgroupID = model.ClientSubgroupID;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.PinCode = model.PinCode;
                    entity.Address = model.Address;
                    entity.RegisteredAddress = model.RegisteredAddress;
                    entity.CorporateOfficeAddress = model.CorporateOfficeAddress;
                    entity.CodeGeneration = model.CodeGeneration;
                    entity.BORowID = model.BORowID;
                    entity.BillingRowID = model.BillingRowID;
                    entity.ReportSentBy = model.ReportSentBy;
                    entity.InterimReport = model.InterimReport;
                    entity.ContractDate = model.ContractDate;
                    entity.ContractComplitionDate = model.ContractComplitionDate;
                    entity.PricingType = model.PricingType;
                    entity.PaymentTermIndays = model.PaymentTermIndays;
                    entity.SpecialInstructions = model.SpecialInstructions;
                    entity.RamcoId = model.RamcoId;
                    entity.SpocId = model.SpocId;
                    entity.MapAntecedent = model.MapAntecedent;
                    entity.MapDisposition = model.MapDisposition;
                    entity.MapSeverity = model.MapSeverity;
                    entity.MapHolidays = model.MapHolidays;
                    entity.MailSendBy = model.MailSendBy;
                    entity.HRApprovalRequired = model.HRApprovalRequired;
                    entity.DaysCalculation = model.DaysCalculation;
                    entity.ReOpenCases = model.ReOpenCases;
                    entity.ReOpenBilling = model.ReOpenBilling;
                    entity.InsuffBilling = model.InsuffBilling;
                    entity.OtherThanGreenBilling = model.OtherThanGreenBilling;
                    entity.StopCaseBilling = model.StopCaseBilling;
                    entity.WIPOrClosedBilling = model.WIPOrClosedBilling;
                    entity.POApplicable = model.POApplicable;
                    entity.EmploymentPV = model.EmploymentPV;
                    entity.YTRStatus = model.YTRStatus;
                    entity.VerbalReportStatus = model.VerbalReportStatus;
                    entity.CandidateContact = model.CandidateContact;
                    entity.ClientNameDisclosure = model.ClientNameDisclosure;
                    entity.ClientStatus = model.ClientStatus;
                    entity.ExtraExpenses = model.ExtraExpenses;
                    entity.EEAllowedAmount = model.EEAllowedAmount;
                    entity.BusinessCommitment = model.BusinessCommitment;
                    entity.BusinsComtntNoOfCase = model.BusinsComtntNoOfCase;
                    entity.InsuffClientReport = model.InsuffClientReport;
                    entity.InsuffHoldDays = model.InsuffHoldDays;
                    entity.Incentive = model.Incentive;
                    entity.IncentiveInstruction = model.IncentiveInstruction;
                    entity.Penalty = model.Penalty;
                    entity.PenaltyDetails = model.PenaltyDetails;
                    entity.Liability = model.Liability;
                    entity.LiabilityDetails = model.LiabilityDetails;
                    entity.BillingAprvl = model.BillingAprvl;
                    entity.BillingAprvlDetails = model.BillingAprvlDetails;
                    entity.SpocName = model.SpocName;
                    entity.SpocEmailID = model.SpocEmailID;
                    entity.CSpocName = model.CSpocName;
                    entity.CSpocDesignation = model.CSpocDesignation;
                    entity.CSpocContactNo = model.CSpocContactNo;
                    entity.CSpocMobileNo = model.CSpocMobileNo;
                    entity.CSpocEmailID = model.CSpocEmailID;
                    entity.CBillingSpocName = model.CBillingSpocName;
                    entity.CBillingSpocDesignation = model.CBillingSpocDesignation;
                    entity.CBillingSpocMobileNo = model.CBillingSpocMobileNo;
                    entity.CBillingSpocEmailID = model.CBillingSpocEmailID;
                    entity.CBillingInstructions = model.CBillingInstructions;
                    entity.CBillingAddress = model.CBillingAddress;
                    entity.CEsclationSpocName = model.CEsclationSpocName;
                    entity.CEsclationSpocDesignation = model.CEsclationSpocDesignation;
                    entity.CEsclationSpocMobileNo = model.CEsclationSpocMobileNo;
                    entity.CEsclationSpocEmailID = model.CEsclationSpocEmailID;
                    entity.CSendInsuffDisplay = model.CSendInsuffDisplay;
                    entity.CSendInsuffEmail = model.CSendInsuffEmail;
                    entity.CSendReportDisplay = model.CSendReportDisplay;
                    entity.CSendReportEmail = model.CSendReportEmail;
                    entity.CSendRedReportDisplay = model.CSendRedReportDisplay;
                    entity.CSendRedReportEmail = model.CSendRedReportEmail;
                    entity.CSendBillingAprvlDisplay = model.CSendBillingAprvlDisplay;
                    entity.CSendBillingAprvlEmail = model.CSendBillingAprvlEmail;
                    //entity.Remark = model.Remark;
                    //entity.SMTPServer = model.SMTPServer;
                    //entity.SMTPPort = model.SMTPPort;
                    //entity.SMTPUserName = model.SMTPUserName;
                    //entity.SMTPPassword = model.SMTPPassword;
                    //entity.EnableSsl = model.EnableSsl;
                    entity.Status = model.Status;
                    entity.CreatedDate = model.CreatedDate;
                    entity.SLAUploaded = model.SLAUploaded;
                    entity.CoverPage = model.CoverPage;
                    entity.AgreementType = model.AgreementType;
                    //entity.PrevClientRowID = model.PrevClientRowID;
                    //entity.HardCopy = model.HardCopy;
                    //entity.ClientCategory = model.ClientCategory;
                    //entity.CSalesSPOCName = model.CSalesSPOCName;
                    //entity.CSalesStatus = model.CSalesStatus;
                    //entity.CSalesCount = model.CSalesCount;
                    //entity.Other1 = model.Other1;
                    //entity.Other2 = model.Other2;
                    //entity.Other3 = model.Other3;
                    //entity.Other4 = model.Other4;
                    //entity.Other5 = model.Other5;

                    db.PQClientMasters.Add(entity);

                }
                else
                {
                    throw new Exception("All * fields are mandatory!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddClientSevirityDetails(string ClientCode = "", short ClientSubgroupID = 0)
        {
            try
            {
                short ClientRowID = db.PQClientMasters.Where(c => c.ClientCode.Trim() == ClientCode.Trim() && c.ClientSubgroupID == ClientSubgroupID).FirstOrDefault().ClientRowID;
                var mstrSvrtyList = db.MasterSeverityGrids.Where(s => s.Status == 1).ToList();
                PQClientSeverity entity = new PQClientSeverity();
                foreach (var item in mstrSvrtyList)
                {
                    entity.ClientColorName = item.ColorName;
                    entity.ClientColorCode = item.ColorCode;
                    entity.ClientRowID = ClientRowID;
                    entity.SeverityGridRowId = item.SeverityGridRowId;
                    db.PQClientSeverities.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddClientDefaultHolidays(string ClientCode = "", short ClientSubgroupID = 0)
        {
            try
            {
                short ClientRowID = db.PQClientMasters.Where(c => c.ClientCode.Trim() == ClientCode.Trim() && c.ClientSubgroupID == ClientSubgroupID).FirstOrDefault().ClientRowID;
                var mstrHoliList = db.MasterHolidays.Where(h => h.Status == 1 && h.IsDefault == 1).ToList();
                PQClientHoliday entity = new PQClientHoliday();
                foreach (var item in mstrHoliList)
                {
                    entity.ClientRowID = ClientRowID;
                    entity.HoliRowID = item.HoliRowID;
                    db.PQClientHolidays.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PQClientAntDispositionViewModel GetClientSelectedAntAndDisposition(short ClientRowId = 0)
        {
            try
            {
                if (ClientRowId > 0)
                {
                    return db.PQClientMasters.Where(c => c.ClientRowID == ClientRowId && c.Status == 1).Select(c => new PQClientAntDispositionViewModel
                    { ClientRowID = c.ClientRowID, MapAntecedent = c.MapAntecedent, MapDisposition = c.MapDisposition }).FirstOrDefault();
                }
                else
                {
                    throw new Exception("Invalid ClientRowId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePQClient(short CRowID)
        {
            try
            {
                var entity = db.PQClientMasters.Find(CRowID);
                if (entity != null)
                {
                    db.PQClientMasters.Remove(entity);
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PQClientListPagedModel GetPQClient(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientMaster> data = db.PQClientMasters.Include("MasterAbbreviation").Include("MasterClientSubGroup").Include("MasterLocation");

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.MasterAbbreviation.ClientName.ToString().Contains(Search) || b.MasterClientSubGroup.ClientSubGroupName.ToString().Contains(Search) || b.ClientCode.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "clientname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterAbbreviation.ClientName) : data.OrderByDescending(d => d.MasterAbbreviation.ClientName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CreatedDate) : data.OrderByDescending(d => d.CreatedDate);
                        break;
                }

                PQClientListPagedModel model = new PQClientListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.PQClients = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQClientListViewModel
                {
                    ClientRowID = item.ClientRowID,
                    ClientCode = item.ClientCode,
                    ClientName = item.MasterAbbreviation.ClientName,
                    ClientSubGroup = item.MasterClientSubGroup.ClientSubGroupName,
                    LocationName = item.MasterLocation.LocationName.Trim(),
                    ContractDate = item.ContractDate,
                    ContractComplitionDate = item.ContractComplitionDate,
                    Status = item.Status,
                    SLAUploaded = item.SLAUploaded
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdatePQClientViewModel GetPQClientForUpdateById(short ClientRowID)
        {
            try
            {
                UpdatePQClientViewModel model = new UpdatePQClientViewModel();
                var item = db.PQClientMasters.Find(ClientRowID);
                if (item != null)
                {
                    model.ClientRowID = item.ClientRowID;
                    model.ClientCode = item.ClientCode;
                    model.ClientCode1 = item.ClientCode1;
                    model.ClientAbbRowID = item.ClientAbbRowID;
                    model.ClientSubgroupID = item.ClientSubgroupID;
                    model.CountryRowID = item.CountryRowID;
                    model.StateRowID = item.StateRowID;
                    model.DistrictRowID = item.DistrictRowID;
                    model.LocationRowID = item.LocationRowID;
                    model.PinCode = item.PinCode;
                    model.Address = item.Address;
                    model.RegisteredAddress = item.RegisteredAddress;
                    model.CorporateOfficeAddress = item.CorporateOfficeAddress;
                    model.CodeGeneration = item.CodeGeneration;
                    model.BORowID = item.BORowID;
                    model.BillingRowID = item.BillingRowID;
                    model.ReportSentBy = item.ReportSentBy;
                    model.InterimReport = item.InterimReport;
                    model.ContractDate = item.ContractDate;
                    model.ContractComplitionDate = item.ContractComplitionDate;
                    model.PricingType = item.PricingType;
                    model.PaymentTermIndays = item.PaymentTermIndays;
                    model.SpecialInstructions = item.SpecialInstructions;
                    model.RamcoId = item.RamcoId;
                    model.SpocId = item.SpocId;
                    model.MapAntecedent = item.MapAntecedent;
                    model.MapDisposition = item.MapDisposition;
                    model.MapSeverity = item.MapSeverity;
                    model.MapHolidays = item.MapHolidays;
                    model.MailSendBy = item.MailSendBy;
                    model.HRApprovalRequired = item.HRApprovalRequired;
                    model.DaysCalculation = item.DaysCalculation;
                    model.ReOpenCases = item.ReOpenCases;
                    model.ReOpenBilling = item.ReOpenBilling;
                    model.InsuffBilling = item.InsuffBilling;
                    model.OtherThanGreenBilling = item.OtherThanGreenBilling;
                    model.StopCaseBilling = item.StopCaseBilling;
                    model.WIPOrClosedBilling = item.WIPOrClosedBilling;
                    model.POApplicable = item.POApplicable;
                    model.EmploymentPV = item.EmploymentPV;
                    model.YTRStatus = item.YTRStatus;
                    model.VerbalReportStatus = item.VerbalReportStatus;
                    model.CandidateContact = item.CandidateContact;
                    model.ClientNameDisclosure = item.ClientNameDisclosure;
                    model.ClientStatus = item.ClientStatus;
                    model.ExtraExpenses = item.ExtraExpenses;
                    model.EEAllowedAmount = item.EEAllowedAmount;
                    model.BusinessCommitment = item.BusinessCommitment;
                    model.BusinsComtntNoOfCase = item.BusinsComtntNoOfCase;
                    model.InsuffClientReport = item.InsuffClientReport;
                    model.InsuffHoldDays = item.InsuffHoldDays;
                    model.Incentive = item.Incentive;
                    model.IncentiveInstruction = item.IncentiveInstruction;
                    model.Penalty = item.Penalty;
                    model.PenaltyDetails = item.PenaltyDetails;
                    model.Liability = item.Liability;
                    model.LiabilityDetails = item.LiabilityDetails;
                    model.BillingAprvl = item.BillingAprvl;
                    model.BillingAprvlDetails = item.BillingAprvlDetails;
                    model.SpocName = item.SpocName;
                    model.SpocEmailID = item.SpocEmailID;
                    model.CSpocName = item.CSpocName;
                    model.CSpocDesignation = item.CSpocDesignation;
                    model.CSpocContactNo = item.CSpocContactNo;
                    model.CSpocMobileNo = item.CSpocMobileNo;
                    model.CSpocEmailID = item.CSpocEmailID;
                    model.CBillingSpocName = item.CBillingSpocName;
                    model.CBillingSpocDesignation = item.CBillingSpocDesignation;
                    model.CBillingSpocMobileNo = item.CBillingSpocMobileNo;
                    model.CBillingSpocEmailID = item.CBillingSpocEmailID;
                    model.CBillingInstructions = item.CBillingInstructions;
                    model.CBillingAddress = item.CBillingAddress;
                    model.CEsclationSpocName = item.CEsclationSpocName;
                    model.CEsclationSpocDesignation = item.CEsclationSpocDesignation;
                    model.CEsclationSpocMobileNo = item.CEsclationSpocMobileNo;
                    model.CEsclationSpocEmailID = item.CEsclationSpocEmailID;
                    model.CSendInsuffDisplay = item.CSendInsuffDisplay;
                    model.CSendInsuffEmail = item.CSendInsuffEmail;
                    model.CSendReportDisplay = item.CSendReportDisplay;
                    model.CSendReportEmail = item.CSendReportEmail;
                    model.CSendRedReportDisplay = item.CSendRedReportDisplay;
                    model.CSendRedReportEmail = item.CSendRedReportEmail;
                    model.CSendBillingAprvlDisplay = item.CSendBillingAprvlDisplay;
                    model.CSendBillingAprvlEmail = item.CSendBillingAprvlEmail;
                    //model.SMTPServer = item.SMTPServer;
                    //model.SMTPPort = item.SMTPPort;
                    //model.SMTPUserName = item.SMTPUserName;
                    //model.SMTPPassword = item.SMTPPassword;
                    //model.EnableSsl = item.EnableSsl;
                    //model.Status = item.Status;
                    //model.CreatedDate = item.CreatedDate;
                    //model.SLAUploaded = item.SLAUploaded;
                    model.CoverPage = item.CoverPage;
                    //model.AgreementType = item.AgreementType;
                    //model.PrevClientRowID = item.PrevClientRowID;
                    //model.HardCopy = item.HardCopy;
                    //model.ClientCategory = item.ClientCategory;
                    //model.CSalesSPOCName = item.CSalesSPOCName;
                    //model.CSalesStatus = item.CSalesStatus;
                    //model.CSalesCount = item.CSalesCount;
                    //model.Remark = item.Remark;
                    //model.Other1 = item.Other1;
                    //model.Other2 = item.Other2;
                    //model.Other3 = item.Other3;
                    //model.Other4 = item.Other4;
                    //model.Other5 = item.Other5;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PQClientForCandiCodeGenViewModel GetPQClientForCadiCodeGenById(short ClientRowID = 0)
        {
            try
            {
                PQClientForCandiCodeGenViewModel model = new PQClientForCandiCodeGenViewModel();
                var item = db.PQClientMasters.Find(ClientRowID);
                if (item != null)
                {
                    model.ClientRowID = item.ClientRowID;
                    model.ClientCode = item.ClientCode;
                    model.ClientCode1 = item.ClientCode1;
                    model.ClientAbbRowID = item.ClientAbbRowID;
                    model.ClientAbbName = item.MasterAbbreviation.ClientAbbreviation;
                    model.ClientName = item.MasterAbbreviation.ClientName + " " + item.MasterClientSubGroup.ClientSubGroupName;
                    model.ClientSubgroupID = item.ClientSubgroupID;
                    model.CodeGeneration = item.CodeGeneration;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetClientPricingTypeById(short ClientRowID = 0)
        {
            try
            {
                return db.PQClientMasters.Find(ClientRowID).PricingType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PQClientCodeHolidaysViewModel GetPQClientCodeHolidaysById(short ClientRowID)
        {
            try
            {
                return db.PQClientMasters.Where(c => c.ClientRowID == ClientRowID)
                .Select(item => new PQClientCodeHolidaysViewModel
                {
                    ClientRowID = item.ClientRowID,
                    ClientCode = item.ClientCode,
                    ClientCode1 = item.ClientCode1,
                    ClientAbbRowID = item.ClientAbbRowID,
                    ClientSubgroupID = item.ClientSubgroupID,
                    MapHolidays = item.MapHolidays,
                    DaysCalculation = item.DaysCalculation,
                }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PQClientViewModel> GetPQClients()
        {
            try
            {
                return db.PQClientMasters.Select(item => new PQClientViewModel
                {
                    ClientRowID = item.ClientRowID,
                    ClientCode = item.ClientCode,
                    ClientCode1 = item.ClientCode1,
                    ClientName = item.MasterAbbreviation.ClientName,
                    ClientAbbRowID = item.ClientAbbRowID,
                    ClientSubGroup = item.MasterClientSubGroup.ClientSubGroupName,
                    ClientSubgroupID = item.ClientSubgroupID,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    LocationRowID = item.LocationRowID,
                    PinCode = item.PinCode,
                    Address = item.Address,
                    RegisteredAddress = item.RegisteredAddress,
                    CorporateOfficeAddress = item.CorporateOfficeAddress,
                    CodeGeneration = item.CodeGeneration,
                    BORowID = item.BORowID,
                    BillingRowID = item.BillingRowID,
                    ReportSentBy = item.ReportSentBy,
                    InterimReport = item.InterimReport,
                    ContractDate = item.ContractDate,
                    ContractComplitionDate = item.ContractComplitionDate,
                    PricingType = item.PricingType,
                    PaymentTermIndays = item.PaymentTermIndays,
                    SpecialInstructions = item.SpecialInstructions,
                    MapAntecedent = item.MapAntecedent,
                    MapDisposition = item.MapDisposition,
                    MapSeverity = item.MapSeverity,
                    MapHolidays = item.MapHolidays,
                    MailSendBy = item.MailSendBy,
                    HRApprovalRequired = item.HRApprovalRequired,
                    DaysCalculation = item.DaysCalculation,
                    ReOpenCases = item.ReOpenCases,
                    ReOpenBilling = item.ReOpenBilling,
                    InsuffBilling = item.InsuffBilling,
                    OtherThanGreenBilling = item.OtherThanGreenBilling,
                    StopCaseBilling = item.StopCaseBilling,
                    WIPOrClosedBilling = item.WIPOrClosedBilling,
                    POApplicable = item.POApplicable,
                    EmploymentPV = item.EmploymentPV,
                    YTRStatus = item.YTRStatus,
                    VerbalReportStatus = item.VerbalReportStatus,
                    CandidateContact = item.CandidateContact,
                    ClientNameDisclosure = item.ClientNameDisclosure,
                    ClientStatus = item.ClientStatus,
                    ExtraExpenses = item.ExtraExpenses,
                    EEAllowedAmount = item.EEAllowedAmount,
                    BusinessCommitment = item.BusinessCommitment,
                    BusinsComtntNoOfCase = item.BusinsComtntNoOfCase,
                    InsuffClientReport = item.InsuffClientReport,
                    InsuffHoldDays = item.InsuffHoldDays,
                    Incentive = item.Incentive,
                    IncentiveInstruction = item.IncentiveInstruction,
                    Penalty = item.Penalty,
                    PenaltyDetails = item.PenaltyDetails,
                    Liability = item.Liability,
                    LiabilityDetails = item.LiabilityDetails,
                    BillingAprvl = item.BillingAprvl,
                    BillingAprvlDetails = item.BillingAprvlDetails,
                    SpocName = item.SpocName,
                    SpocEmailID = item.SpocEmailID,
                    CSpocName = item.CSpocName,
                    CSpocDesignation = item.CSpocDesignation,
                    CSpocContactNo = item.CSpocContactNo,
                    CSpocMobileNo = item.CSpocMobileNo,
                    CSpocEmailID = item.CSpocEmailID,
                    CBillingSpocName = item.CBillingSpocName,
                    CBillingSpocDesignation = item.CBillingSpocDesignation,
                    CBillingSpocMobileNo = item.CBillingSpocMobileNo,
                    CBillingSpocEmailID = item.CBillingSpocEmailID,
                    CBillingInstructions = item.CBillingInstructions,
                    CBillingAddress = item.CBillingAddress,
                    CEsclationSpocName = item.CEsclationSpocName,
                    CEsclationSpocDesignation = item.CEsclationSpocDesignation,
                    CEsclationSpocMobileNo = item.CEsclationSpocMobileNo,
                    CEsclationSpocEmailID = item.CEsclationSpocEmailID,
                    CSendInsuffDisplay = item.CSendInsuffDisplay,
                    CSendInsuffEmail = item.CSendInsuffEmail,
                    CSendReportDisplay = item.CSendReportDisplay,
                    CSendReportEmail = item.CSendReportEmail,
                    CSendRedReportDisplay = item.CSendRedReportDisplay,
                    CSendRedReportEmail = item.CSendRedReportEmail,
                    CSendBillingAprvlDisplay = item.CSendBillingAprvlDisplay,
                    CSendBillingAprvlEmail = item.CSendBillingAprvlEmail,
                    Remark = item.Remark,
                    SMTPServer = item.SMTPServer,
                    SMTPPort = item.SMTPPort,
                    SMTPUserName = item.SMTPUserName,
                    SMTPPassword = item.SMTPPassword,
                    EnableSsl = item.EnableSsl,
                    Status = item.Status,
                    CreatedDate = item.CreatedDate,
                    SLAUploaded = item.SLAUploaded,
                    CoverPage = item.CoverPage,
                    AgreementType = item.AgreementType,
                    PrevClientRowID = item.PrevClientRowID,
                    HardCopy = item.HardCopy,
                    ClientCategory = item.ClientCategory,
                    CSalesSPOCName = item.CSalesSPOCName,
                    CSalesStatus = item.CSalesStatus,
                    CSalesCount = item.CSalesCount,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    RamcoId = item.RamcoId,
                    SpocId = item.SpocId,

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPQClientExist(string ClientCode)
        {
            try
            {
                var Client = db.PQClientMasters.Where(c => c.ClientCode.Trim().ToLower() == ClientCode.Trim().ToLower()).FirstOrDefault();
                if (Client != null && Client.ClientCode.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPQClientExist(short ClientRowID, string ClientCode)
        {
            try
            {
                var Client = db.PQClientMasters.Where(c => c.ClientCode.Trim().ToLower() == ClientCode.Trim().ToLower() && c.ClientRowID != ClientRowID).FirstOrDefault();
                if (Client != null && Client.ClientCode.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetClientSpecialInstructionByID(short ClientRowID = 0)
        {
            try
            {
                return db.PQClientMasters.Find(ClientRowID).SpecialInstructions;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PQClientForExtraExpViewModel GetClientExtraExpensesAllowedByID(short ClientRowID = 0)
        {
            try
            {
                return db.PQClientMasters.Where(c => c.ClientRowID == ClientRowID).Select(c => new PQClientForExtraExpViewModel
                {
                    ClientRowID = c.ClientRowID,
                    ExtraExpenses = c.ExtraExpenses,
                    EEAllowedAmount = c.EEAllowedAmount,
                }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public PQClientMailConfig GetClientMailById(short ClientRowID)
        {
            try
            {
                PQClientMailConfig model = new PQClientMailConfig();
                var item = db.PQClientMasters.Find(ClientRowID);
                if (item != null)
                {
                    model.ClientRowID = item.ClientRowID;
                    model.SMTPServer = item.SMTPServer;
                    model.SMTPPort = item.SMTPPort;
                    model.SMTPUserName = item.SMTPUserName;
                    model.SMTPPassword = item.SMTPPassword;
                    model.EnableSsl = item.EnableSsl;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdatePQClient(UpdatePQClientViewModel model)
        {
            try
            {
                if (model != null && model.ClientRowID > 0)
                {
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientRowID = model.ClientRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientCode = model.ClientCode;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientCode1 = model.ClientCode1;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientAbbRowID = model.ClientAbbRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientSubgroupID = model.ClientSubgroupID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CountryRowID = model.CountryRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).StateRowID = model.StateRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).DistrictRowID = model.DistrictRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).LocationRowID = model.LocationRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).PinCode = model.PinCode;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Address = model.Address;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).RegisteredAddress = model.RegisteredAddress;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CorporateOfficeAddress = model.CorporateOfficeAddress;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CodeGeneration = model.CodeGeneration;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BORowID = model.BORowID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BillingRowID = model.BillingRowID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ReportSentBy = model.ReportSentBy;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).InterimReport = model.InterimReport;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ContractDate = model.ContractDate;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ContractComplitionDate = model.ContractComplitionDate;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).PricingType = model.PricingType;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).PaymentTermIndays = model.PaymentTermIndays;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SpecialInstructions = model.SpecialInstructions;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).RamcoId = model.RamcoId;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SpocId = model.SpocId;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).MapAntecedent = model.MapAntecedent;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).MapDisposition = model.MapDisposition;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).MapSeverity = model.MapSeverity;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).MapHolidays = model.MapHolidays;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).MailSendBy = model.MailSendBy;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).HRApprovalRequired = model.HRApprovalRequired;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).DaysCalculation = model.DaysCalculation;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ReOpenCases = model.ReOpenCases;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ReOpenBilling = model.ReOpenBilling;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).InsuffBilling = model.InsuffBilling;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).OtherThanGreenBilling = model.OtherThanGreenBilling;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).StopCaseBilling = model.StopCaseBilling;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).WIPOrClosedBilling = model.WIPOrClosedBilling;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).POApplicable = model.POApplicable;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).EmploymentPV = model.EmploymentPV;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).YTRStatus = model.YTRStatus;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).VerbalReportStatus = model.VerbalReportStatus;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CandidateContact = model.CandidateContact;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientNameDisclosure = model.ClientNameDisclosure;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientStatus = model.ClientStatus;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ExtraExpenses = model.ExtraExpenses;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).EEAllowedAmount = model.EEAllowedAmount;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BusinessCommitment = model.BusinessCommitment;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BusinsComtntNoOfCase = model.BusinsComtntNoOfCase;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).InsuffClientReport = model.InsuffClientReport;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).InsuffHoldDays = model.InsuffHoldDays;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Incentive = model.Incentive;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).IncentiveInstruction = model.IncentiveInstruction;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Penalty = model.Penalty;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).PenaltyDetails = model.PenaltyDetails;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Liability = model.Liability;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).LiabilityDetails = model.LiabilityDetails;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BillingAprvl = model.BillingAprvl;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).BillingAprvlDetails = model.BillingAprvlDetails;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SpocName = model.SpocName;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SpocEmailID = model.SpocEmailID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSpocName = model.CSpocName;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSpocDesignation = model.CSpocDesignation;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSpocContactNo = model.CSpocContactNo;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSpocMobileNo = model.CSpocMobileNo;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSpocEmailID = model.CSpocEmailID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingSpocName = model.CBillingSpocName;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingSpocDesignation = model.CBillingSpocDesignation;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingSpocMobileNo = model.CBillingSpocMobileNo;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingSpocEmailID = model.CBillingSpocEmailID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingInstructions = model.CBillingInstructions;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CBillingAddress = model.CBillingAddress;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CEsclationSpocName = model.CEsclationSpocName;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CEsclationSpocDesignation = model.CEsclationSpocDesignation;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CEsclationSpocMobileNo = model.CEsclationSpocMobileNo;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CEsclationSpocEmailID = model.CEsclationSpocEmailID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendInsuffDisplay = model.CSendInsuffDisplay;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendInsuffEmail = model.CSendInsuffEmail;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendReportDisplay = model.CSendReportDisplay;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendReportEmail = model.CSendReportEmail;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendRedReportDisplay = model.CSendRedReportDisplay;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendRedReportEmail = model.CSendRedReportEmail;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendBillingAprvlDisplay = model.CSendBillingAprvlDisplay;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSendBillingAprvlEmail = model.CSendBillingAprvlEmail;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Remark = model.Remark;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPServer = model.SMTPServer;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPPort = model.SMTPPort;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPUserName = model.SMTPUserName;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPPassword = model.SMTPPassword;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).EnableSsl = model.EnableSsl;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Status = model.Status;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CreatedDate = model.CreatedDate;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SLAUploaded = model.SLAUploaded;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CoverPage = model.CoverPage;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).AgreementType = model.AgreementType;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).PrevClientRowID = model.PrevClientRowID;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).HardCopy = model.HardCopy;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientCategory = model.ClientCategory;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSalesSPOCName = model.CSalesSPOCName;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSalesStatus = model.CSalesStatus;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).CSalesCount = model.CSalesCount;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Other1 = model.Other1;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Other2 = model.Other2;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Other3 = model.Other3;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Other4 = model.Other4;
                    //db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).Other5 = model.Other5;


                }
                else
                {
                    throw new Exception("Invalid Client Details!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PQClientMailConfig(PQClientMailConfig model)
        {
            try
            {
                if (model != null && model.ClientRowID > 0)
                {
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).ClientRowID = model.ClientRowID;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPServer = model.SMTPServer;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPPort = model.SMTPPort;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPUserName = model.SMTPUserName;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).SMTPPassword = model.SMTPPassword;
                    db.PQClientMasters.Single(c => c.ClientRowID == model.ClientRowID).EnableSsl = model.EnableSsl;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ClientCheckPackageViewModel> GetChecksAndPackageByClientId(short cid = 0, byte PricingType = 0)
        {
            try
            {
                //byte PricingType = db.PQClientMasters.Where(pc => pc.ClientRowID == id).FirstOrDefault().PricingType;

                //Package" = "1" Check" = "2" Both" = "3"
                if (PricingType == 1)
                {
                    return db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == cid && p.AntecedentSelected == 1)
                    .Select(item => new ClientCheckPackageViewModel
                    {
                        ClientRowID = item.ClientRowID,
                        ClientPackageRowID = 0,
                        CheckFamilyRowID = 0,
                        CheckOrPackageName = item.ClientPackageName,
                    }).Distinct().ToList();
                }
                if (PricingType == 2)
                {
                    return db.PQClientChecks.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == cid && p.AntecedentSelected == 1)
                    .Select(item => new ClientCheckPackageViewModel
                    {
                        ClientRowID = item.ClientRowID,
                        ClientPackageRowID = 0,
                        CheckFamilyRowID = item.CheckFamilyRowID,
                        ClientCheckRowID = item.ClientCheckRowID,
                        CheckOrPackageName = item.MasterSubCheckFamily.SubCheckName,
                    }).ToList();
                }
                if (PricingType == 3)
                {
                    return db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == cid && p.AntecedentSelected == 1)
                    .Select(p => new ClientCheckPackageViewModel
                    {
                        ClientRowID = p.ClientRowID,
                        ClientPackageRowID = 0,
                        CheckFamilyRowID = 0,
                        CheckOrPackageName = p.ClientPackageName,
                    }).Distinct().Union(db.PQClientChecks.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == cid && p.AntecedentSelected == 1)
                    .Select(p => new ClientCheckPackageViewModel
                    {
                        ClientRowID = p.ClientRowID,
                        ClientPackageRowID = 0,
                        CheckFamilyRowID = p.CheckFamilyRowID,
                        ClientCheckRowID = p.ClientCheckRowID,
                        CheckOrPackageName = p.MasterSubCheckFamily.SubCheckName,
                    })).ToList();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PQClientMailFromViewModel GetPQClientSendMailFromById(short ClientRowID)
        {
            try
            {
                PQClientMailFromViewModel model = new PQClientMailFromViewModel();
                var item = db.PQClientMasters.Find(ClientRowID);
                if (item != null)
                {
                    model.ClientRowID = item.ClientRowID;
                    model.ClientName = item.MasterAbbreviation.ClientName;
                    model.SpocEmailID = item.SpocEmailID;
                    model.MailSendBy = item.MailSendBy;
                    model.SMTPServer = item.SMTPServer;
                    model.SMTPPort = item.SMTPPort;
                    model.SMTPUserName = item.SMTPUserName;
                    model.SMTPPassword = item.SMTPPassword;
                    model.EnableSsl = item.EnableSsl;

                    model.CSendInsuffDisplay = item.CSendInsuffDisplay;
                    model.CSendInsuffEmail = item.CSendInsuffEmail;
                    model.CSendReportDisplay = item.CSendReportDisplay;
                    model.CSendReportEmail = item.CSendReportEmail;
                    model.CSendRedReportDisplay = item.CSendRedReportDisplay;
                    model.CSendRedReportEmail = item.CSendRedReportEmail;
                    model.CSendBillingAprvlDisplay = item.CSendBillingAprvlDisplay;
                    model.CSendBillingAprvlEmail = item.CSendBillingAprvlEmail;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetCompanySPOCEmailIdFromPQClientMasterById(short ClientRowID)
        {
            try
            {
                return db.PQClientMasters.Find(ClientRowID).SpocEmailID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientContractConditions GetClientContractConditions(short ClientRowID)
        {
            try
            {
                return db.PQClientMasters.Where(c => c.ClientRowID == ClientRowID).Select(client => new ClientContractConditions
                {
                    ClientRowID = client.ClientRowID,
                    ClientName = client.MasterAbbreviation.ClientName,
                    PricingType = client.PricingType,
                    MapAntecedent = client.MapAntecedent,
                    MapDisposition = client.MapDisposition,
                    MapSeverity = client.MapSeverity,
                    MapHolidays = client.MapHolidays,
                    MailSendBy = client.MailSendBy,
                    CandidateContact = client.CandidateContact,
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportClientViewModel> GetClientForExport()
        {
            try
            {
                return db.PQClientMasters.Select(item => new ExportClientViewModel
                {
                    ClientRowID = item.ClientRowID,
                    ClientCode = item.ClientCode,
                    ClientName = item.MasterAbbreviation.ClientName,
                    SubGroup = item.MasterClientSubGroup.ClientSubGroupName,
                    Location = item.MasterLocation.LocationName.Trim(),
                    ValidFrom = item.ContractDate,
                    ValidTo = item.ContractComplitionDate,
                    SLAUploaded = item.SLAUploaded
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportClientCheckViewModel> GetClientChecksForExport(short CId = 0)
        {
            try
            {
                return db.PQClientChecks.Where(a => a.ClientRowID == CId).Select(item => new ExportClientCheckViewModel
                {
                    ClientCheckRowID = item.ClientRowID,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    SubCheckFamillyName = item.MasterSubCheckFamily.SubCheckName,
                    ReportSequence = item.ReportSequence,
                    AntecedentSelected = item.AntecedentSelected
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportClientPackageViewModel> GetClientPackageForExport(short CId = 0)
        {
            try
            {
                return db.PQClientPackages.Where(a => a.ClientRowID == CId).Select(item => new ExportClientPackageViewModel
                {
                    ClientPackageRowID = item.ClientRowID,
                    ClientPackageName = item.ClientPackageName,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    SubCheckFamillyName = item.MasterSubCheckFamily.SubCheckName,
                    ReportSequence = item.ReportSequence,
                    AntecedentSelected = item.AntecedentSelected
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportClientTMemberViewModel> GetClientTeamMemberForExport(short CId = 0)
        {
            try
            {
                return db.PQClientTeamMembers.Where(a => a.ClientRowID == CId).Select(item => new ExportClientTMemberViewModel
                {
                    ClientTMemberRowID = item.ClientTMemberRowID,
                    TeamMemberName = item.TeamDepartment.TeamMember.TMTitle + " " + item.TeamDepartment.TeamMember.TMFirstName + " " + item.TeamDepartment.TeamMember.TMLastName + " (" + item.TeamDepartment.MasterDesignation.DesignationName + ")",
                    Department = item.TeamDepartment.MasterDepartment.DepartmentName,
                    Designation = item.TeamDepartment.MasterDesignation.DesignationName
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportClientLoginViewModel> GetClientLoginForExport()
        {
            try
            {
                return db.PQClientLogins.Select(item => new ExportClientLoginViewModel
                {
                    ClientUserRowID = item.ClientUserRowID,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    UserID = item.UserID,
                    CreatedBy = item.CreatedBy,
                    SentMailStatus = item.SentMailStatus > 0 ? "Yes" : "No",
                    SentMailDate = item.SentMailDate
                }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
