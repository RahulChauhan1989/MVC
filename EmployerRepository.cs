using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public class EmployerRepository : IEmployerRepository
    {
        DataContext db;
        public EmployerRepository()
        {
            db = new DataContext();
        }

        public void AddEmployer(AddEmployerViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterEmployer entity = new MasterEmployer();
                    entity.CompanyName = model.CompanyName;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.ConcernPersonName = model.ConcernPersonName;
                    //entity.DDFavourOf = model.DDFavourOf;
                    entity.CompanyLegalStatus = model.CompanyLegalStatus;
                    entity.CINNumber = model.CINNumber;
                    entity.RegisteredOnMCA = model.RegisteredOnMCA;
                    entity.PaidUpCapital = model.PaidUpCapital;
                    entity.MandatoryDocument = model.MandatoryDocument;
                    entity.PVInitiated = model.PVInitiated;
                    entity.PVInitAtAddress = model.PVInitAtAddress;
                    entity.OtherDocumentNo = model.OtherDocumentNo;
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.LocationRowID = model.LocationRowID;
                   // entity.CityRowID = model.CityRowID;
                    entity.Website = model.Website;
                    entity.CompanyStatus = model.CompanyStatus;
                    entity.CompanyAddress = model.CompanyAddress;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.ModeOfPayment = model.ModeOfPayment;
                    entity.OfficialEmailId = model.OfficialEmailId;
                    entity.OfficialLandlineNo = model.OfficialLandlineNo;
                    entity.MobileNo = model.MobileNo;
                    entity.Other1 = model.Other1;
                    entity.Other2 = model.Other2;
                    entity.Other3 = model.Other3;
                    entity.Other4 = model.Other4;
                    entity.Other5 = model.Other5;
                    // entity.VerificationProcessTAT = model.VerificationProcessTAT;
                    entity.FavourOf = model.FavourOf;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    entity.COtherStatus = model.COtherStatus;
                    entity.COtherLegalStatus = model.COtherLegalStatus;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.CompanySnapshot = model.Snapshot;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;
                    entity.MCARegProof = model.MCARegProof;
                    entity.PVInitAtAddressProof = model.PVInitAtAddressProof;
                    entity.OtherDocumentAdded = model.OtherDocumentAdded;
                    entity.OtherDocProof = model.OtherDocProof;
                    entity.ModifiedDate = model.ModifiedDate;

                    db.MasterEmployers.Add(entity);
                }
                else
                {
                    throw new Exception("Employer could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteEmployer(short CRowID)
        {
            try
            {
                var entity = db.MasterEmployers.Find(CRowID);
                if (entity != null)
                {
                    db.MasterEmployers.Remove(entity);
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

        public IEnumerable<EmployerViewModel> GetEmployers()
        {
            try
            {
                return db.MasterEmployers.Select(item => new EmployerViewModel
                {
                    EmployerRowID = item.EmployerRowID,
                    CompanyName = item.CompanyName,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    AdditionalComments = item.AdditionalComments,
                    AdditionalCost = item.AdditionalCost,
                    AdditionalCosting = item.AdditionalCosting,
                    ConcernPersonName = item.ConcernPersonName,
                    //DDFavourOf = item.DDFavourOf,
                    CompanyLegalStatus = item.CompanyLegalStatus,
                    CINNumber = item.CINNumber,
                    RegisteredOnMCA = item.RegisteredOnMCA,
                    PaidUpCapital = item.PaidUpCapital,
                    MandatoryDocument = item.MandatoryDocument,
                    PVInitiated = item.PVInitiated,
                    PVInitAtAddress = item.PVInitAtAddress,
                    // MCAPVRegProof = item.MCAPVRegProof,
                    OtherDocumentNo = item.OtherDocumentNo,
                    DesigConcernPerson = item.DesigConcernPerson,
                    LocationRowID = item.LocationRowID,
                   // CityRowID = item.CityRowID,
                    // VerificationProcessTAT = item.VerificationProcessTAT,
                    Website = item.Website,
                    CompanyStatus = item.CompanyStatus,
                    CompanyAddress = item.CompanyAddress,
                    SpecialInstruction = item.SpecialInstruction,
                    ModeOfInitiation = item.ModeOfInitiation,
                    ModeOfPayment = item.ModeOfPayment,
                    OfficialEmailId = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    MobileNo = item.MobileNo,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    COtherStatus = item.COtherStatus,
                    COtherLegalStatus = item.COtherLegalStatus,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    Snapshot = item.CompanySnapshot,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2,
                    MCARegProof = item.MCARegProof,
                    PVInitAtAddressProof = item.PVInitAtAddressProof,
                    OtherDocumentAdded = item.OtherDocumentAdded,
                    OtherDocProof = item.OtherDocProof,
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EmployerExportViewModel> GetEmployeresForExport()
        {
            try
            {
                return db.MasterEmployers.Select(item => new EmployerExportViewModel
                {
                    RowID = item.EmployerRowID,
                    Name = item.CompanyName,
                    Country = item.MasterCountry.CountryName,
                    State = item.MasterState.StateName,
                    District = item.MasterDistrict.DistrictName,
                    AdditionalComments = item.AdditionalComments,
                    AdditionalCost = item.AdditionalCost,
                    AdditionalCosting = item.AdditionalCosting,
                    ConcernPersonName = item.ConcernPersonName,
                    LegalStatus = item.CompanyLegalStatus,
                    CINNumber = item.CINNumber,
                    RegisteredOnMCA = item.RegisteredOnMCA,
                    PaidUpCapital = item.PaidUpCapital,
                    MandatoryDocument = item.MandatoryDocument,
                    PVInitiated = item.PVInitiated,
                    PVInitAtAddress = item.PVInitAtAddress,
                    OtherDocumentNo = item.OtherDocumentNo,
                    DesigConcernPerson = item.DesigConcernPerson,
                    Location = item.MasterLocation.LocationName,
                   // City = item.MasterCity.CityName,
                    Website = item.Website,
                    Status = item.CompanyStatus,
                    Address = item.CompanyAddress,
                    SpecialInstruction = item.SpecialInstruction,
                    ModeOfInitiation = item.ModeOfInitiation,
                    ModeOfPayment = item.ModeOfPayment,
                    OfficialEmailId = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    MobileNo = item.MobileNo,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    COtherStatus = item.COtherStatus,
                    COtherLegalStatus = item.COtherLegalStatus,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    Snapshot = item.CompanySnapshot,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2,
                    MCARegProof = item.MCARegProof,
                    PVInitAtAddressProof = item.PVInitAtAddressProof,
                    OtherDocumentAdded = item.OtherDocumentAdded,
                    OtherDocProof = item.OtherDocProof,
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployerListPagedModel GetEmployer(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterEmployer> data = db.MasterEmployers;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CompanyName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CompanyName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CompanyName) : data.OrderByDescending(d => d.CompanyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.EmployerRowID) : data.OrderByDescending(d => d.EmployerRowID);
                        break;
                }

                EmployerListPagedModel model = new EmployerListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Employers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new AddEmployerListViewModel
                {
                    EmployerRowID      = item.EmployerRowID,
                    CompanyName        = item.CompanyName,
                    ConcernPersonName  = item.ConcernPersonName,                  
                    CompanyStatus      = item.CompanyStatus,                   
                    OfficialEmailId    = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo, 
                    MobileNo           = item.MobileNo,  
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployerListPagedModel GetBeyondEmployer(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                DateTime todayDate = DateTime.Now;

                IQueryable<MasterEmployer> data = db.MasterEmployers.Where(e => DbFunctions.DiffDays(e.ModifiedDate, todayDate) > 180);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CompanyName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CompanyName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CompanyName) : data.OrderByDescending(d => d.CompanyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.EmployerRowID) : data.OrderByDescending(d => d.EmployerRowID);
                        break;
                }

                EmployerListPagedModel model = new EmployerListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Employers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new AddEmployerListViewModel
                {
                    EmployerRowID = item.EmployerRowID,
                    CompanyName = item.CompanyName,
                    ConcernPersonName = item.ConcernPersonName,
                    CompanyStatus = item.CompanyStatus,
                    OfficialEmailId = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    MobileNo = item.MobileNo,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateEmployerViewModel GetEmployerForUpdateById(short EmployerRowID)
        {
            try
            {
                UpdateEmployerViewModel model = new UpdateEmployerViewModel();
                var entity = db.MasterEmployers.Find(EmployerRowID);

                if (entity != null)
                {
                    model.EmployerRowID      = entity.EmployerRowID;
                    model.CompanyName        = entity.CompanyName;
                    model.CountryRowID       = entity.CountryRowID;
                    model.StateRowID         = entity.StateRowID;
                    model.DistrictRowID      = entity.DistrictRowID;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost     = entity.AdditionalCost;
                    model.AdditionalCosting  = entity.AdditionalCosting;
                    model.ConcernPersonName  = entity.ConcernPersonName;
                    //model.DDFavourOf       = entity.DDFavourOf;
                    model.CompanyLegalStatus = entity.CompanyLegalStatus;
                    model.CINNumber          = entity.CINNumber;
                    model.RegisteredOnMCA    = entity.RegisteredOnMCA;
                    model.PaidUpCapital      = entity.PaidUpCapital;
                    model.MandatoryDocument  = entity.MandatoryDocument;
                    model.PVInitiated        = entity.PVInitiated;
                    model.PVInitAtAddress    = entity.PVInitAtAddress;
                    // model.MCAPVRegProof   = entity.MCAPVRegProof;
                    model.OtherDocumentNo    = entity.OtherDocumentNo;
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.LocationRowID      = entity.LocationRowID;
                    // model.CityRowID       = entity.CityRowID;
                    // model.VerificationProcessTAT = entity.VerificationProcessTAT;
                    model.Website = entity.Website;
                    model.CompanyStatus = entity.CompanyStatus;
                    model.CompanyAddress = entity.CompanyAddress;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.MobileNo = entity.MobileNo;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.COtherStatus = entity.COtherStatus;
                    model.COtherLegalStatus = entity.COtherLegalStatus;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
                    model.Snapshot = entity.CompanySnapshot;
                    model.VerificationTATLevel1 = entity.VerificationTATLevel1;
                    model.VerificationTATLevel2 = entity.VerificationTATLevel2;
                    model.MCARegProof = entity.MCARegProof;
                    model.PVInitAtAddressProof = entity.PVInitAtAddressProof;
                    model.OtherDocumentAdded = entity.OtherDocumentAdded;
                    model.OtherDocProof = entity.OtherDocProof;
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

        public bool IsEmployerExist(string CompanyName)
        {
            try
            {
                var Employer = db.MasterEmployers.Where(c => c.CompanyName.Trim().ToLower() == CompanyName.Trim().ToLower()).FirstOrDefault();
                if (Employer != null && Employer.CompanyName.Length > 0)
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

        public bool IsEmployerExist(int EmployerRowID, string CompanyName)
        {
            try
            {
                var Employer = db.MasterEmployers
                    .Where(c => c.CompanyName.Trim().ToLower() == CompanyName.Trim().ToLower() && c.EmployerRowID != EmployerRowID)
                    .FirstOrDefault();
                if (Employer != null && Employer.CompanyName.Length > 0)
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

        public void UpdateEmployer(UpdateEmployerViewModel model)
        {
            try
            {
                if (model != null && model.EmployerRowID > 0)
                {
                    MasterEmployer entity = new MasterEmployer();
                    entity.EmployerRowID = model.EmployerRowID;
                    entity.CompanyName = model.CompanyName;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.ConcernPersonName = model.ConcernPersonName;
                    //entity.DDFavourOf = model.DDFavourOf;
                    entity.CompanyLegalStatus = model.CompanyLegalStatus;
                    entity.CINNumber = model.CINNumber;
                    entity.RegisteredOnMCA = model.RegisteredOnMCA;
                    entity.PaidUpCapital = model.PaidUpCapital;
                    entity.MandatoryDocument = model.MandatoryDocument;
                    entity.PVInitiated = model.PVInitiated;
                    entity.PVInitAtAddress = model.PVInitAtAddress;
                    //entity.MCAPVRegProof = model.MCAPVRegProof;
                    entity.OtherDocumentNo = model.OtherDocumentNo;
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.LocationRowID = model.LocationRowID;
                    //entity.CityRowID = model.CityRowID;
                    //entity.VerificationProcessTAT = model.VerificationProcessTAT;
                    entity.Website = model.Website;
                    entity.CompanyStatus = model.CompanyStatus;
                    entity.CompanyAddress = model.CompanyAddress;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.ModeOfPayment = model.ModeOfPayment;
                    entity.OfficialEmailId = model.OfficialEmailId;
                    entity.OfficialLandlineNo = model.OfficialLandlineNo;
                    entity.MobileNo = model.MobileNo;
                    entity.Other1 = model.Other1;
                    entity.Other2 = model.Other2;
                    entity.Other3 = model.Other3;
                    entity.Other4 = model.Other4;
                    entity.Other5 = model.Other5;
                    //entity.Status = model.Status;
                    entity.FavourOf = model.FavourOf;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    entity.COtherStatus = model.COtherStatus;
                    entity.COtherLegalStatus = model.COtherLegalStatus;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.CompanySnapshot = model.Snapshot;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;
                    entity.MCARegProof = model.MCARegProof;
                    entity.PVInitAtAddressProof = model.PVInitAtAddressProof;
                    entity.OtherDocumentAdded = model.OtherDocumentAdded;
                    entity.OtherDocProof = model.OtherDocProof;
                    entity.ModifiedDate = model.ModifiedDate;

                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Employer could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveEmployer(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterEmployers.Single(b => b.EmployerRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Employer could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployerViewModel GetEmployerForDetailsById(short EmployerRowID)
        {
            try
            {
                EmployerViewModel model = new EmployerViewModel();

                var entity = db.MasterEmployers.Find(EmployerRowID);
                if (entity != null)
                {
                    model.EmployerRowID = entity.EmployerRowID;
                    model.CompanyName = entity.CompanyName;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.ConcernPersonName = entity.ConcernPersonName;                    
                    model.CompanyLegalStatus = entity.CompanyLegalStatus;
                    model.CINNumber = entity.CINNumber;
                    model.RegisteredOnMCA = entity.RegisteredOnMCA;
                    model.PaidUpCapital = entity.PaidUpCapital;
                    model.MandatoryDocument = entity.MandatoryDocument;
                    model.PVInitiated = entity.PVInitiated;
                    model.PVInitAtAddress = entity.PVInitAtAddress;                   
                    model.OtherDocumentNo = entity.OtherDocumentNo;
                    model.DesigConcernPerson = entity.DesigConcernPerson;                                  
                    model.Website = entity.Website;
                    model.CompanyStatus = entity.CompanyStatus;
                    model.CompanyAddress = entity.CompanyAddress;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.MobileNo = entity.MobileNo;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.COtherStatus = entity.COtherStatus;
                    model.COtherLegalStatus = entity.COtherLegalStatus;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;                  
                    model.VerificationTATLevel1 = entity.VerificationTATLevel1;
                    model.VerificationTATLevel2 = entity.VerificationTATLevel2;
                    model.MCARegProof = entity.MCARegProof;
                    model.PVInitAtAddressProof = entity.PVInitAtAddressProof;
                    model.OtherDocumentAdded = entity.OtherDocumentAdded;
                    model.OtherDocProof = entity.OtherDocProof;
                    model.Status = entity.Status;
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
    }
}
