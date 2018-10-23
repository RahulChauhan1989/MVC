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
    public class CollegeRepository : ICollegeRepository
    {
        DataContext db;

        public CollegeRepository()
        {
            db = new DataContext();
        }

        public void AddCollege(AddCollegeViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterCollege entity = new MasterCollege();
                    entity.CollegeName = model.CollegeName;
                    entity.UniversityRowID = model.UniversityRowID;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AffiliatedFrom = model.AffliatiatedFrom;
                    entity.ConcernPersonName = model.ConcernPersonName;
                     entity.DegreeCertificate = Convert.ToByte(model.DegreeCertificate);
                    entity.ProvisionalCertificate = Convert.ToByte(model.ProvisionalCertificate);
                    entity.FinalYearMarksSheet = Convert.ToByte(model.FinalYearMarksSheet);
                    entity.PassingCertificate = Convert.ToByte(model.PassingCertificate);
                    entity.OtherDocument = Convert.ToByte(model.OtherDocument);
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.LocationRowID = model.LocationRowID;
                    //entity.CityRowID = model.CityRowID;
                    entity.Website = model.Website;
                    entity.CollegeStatus = model.CollegeStatus;
                    entity.CollegeAddress = model.CollegeAddress;
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
                    entity.ResultLink = model.ResultLink;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    entity.OtherAffiliated = model.OtherAffliatiated;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.OtherStatus = model.OtherStatus;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.Snapshot = model.Snapshot;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;
                    entity.ModifiedDate = model.ModifiedDate;

                    db.MasterColleges.Add(entity);
                }
                else
                {
                    throw new Exception("College could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCollege(short CRowID)
        {
            try
            {
                var entity = db.MasterColleges.Find(CRowID);
                if (entity != null)
                {
                    db.MasterColleges.Remove(entity);
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

        public IEnumerable<CollegeViewModel> GetColleges()
        {
            try
            {
                return db.MasterColleges.Select(item => new CollegeViewModel
                {
                    CollegeRowID = item.CollegeRowID,
                    UniversityRowID = item.UniversityRowID,
                    UniversityName = item.MasterUniversity.UniversityName,
                    CollegeName = item.CollegeName,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    AdditionalComments = item.AdditionalComments,
                    AdditionalCost = item.AdditionalCost,
                    AdditionalCosting = item.AdditionalCosting,
                   // AffliatiatedFrom = item.AffliatiatedFrom,
                    ConcernPersonName = item.ConcernPersonName,
                    //DDFavourOf = item.DDFavourOf,
                    DegreeCertificate = item.DegreeCertificate,
                    DesigConcernPerson = item.DesigConcernPerson,
                    FinalYearMarksSheet = item.FinalYearMarksSheet,
                    LocationRowID = item.LocationRowID,
                   // CityRowID = item.CityRowID,
                    ProvisionalCertificate = item.ProvisionalCertificate,
                   //// VerificationProcessTAT = item.VerificationProcessTAT,
                    Website = item.Website,
                    CollegeStatus = item.CollegeStatus,
                    CollegeAddress = item.CollegeAddress,
                    SpecialInstruction = item.SpecialInstruction,
                    PassingCertificate = item.PassingCertificate,
                    ModeOfInitiation = item.ModeOfInitiation,
                    ModeOfPayment = item.ModeOfPayment,
                    OfficialEmailId = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    MobileNo = item.MobileNo,
                    OtherDocument = item.OtherDocument,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    Status = item.Status,
                     FavourOf = item.FavourOf,
                    ResultLink = item.ResultLink,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                   // OtherAffliatiated = item.OtherAffliatiated,
                    OtherInitiation = item.OtherInitiation,
                    OtherStatus = item.OtherStatus,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    Snapshot = item.Snapshot,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CollegeExportViewModel> GetCollegesForExport()
        {
            try
            {
                return db.MasterColleges.Select(item => new CollegeExportViewModel {
                    RowID = item.CollegeRowID,                   
                    UniversityName = item.MasterUniversity.UniversityName,
                    College = item.CollegeName,
                    CountryName = item.MasterCountry.CountryName,
                    StateName = item.MasterState.StateName,
                    DistrictName = item.MasterDistrict.DistrictName,
                    AdditionalComments = item.AdditionalComments,
                    AdditionalCost = item.AdditionalCost,
                    AdditionalCosting = item.AdditionalCosting,
                   // AffliatiatedFrom = item.AffliatiatedFrom,
                    ConcernPersonName = item.ConcernPersonName,
                    DegreeCertificate = item.DegreeCertificate,
                    DesigConcernPerson = item.DesigConcernPerson,
                    FinalYearMarksSheet = item.FinalYearMarksSheet,
                    LocationName = item.MasterLocation.LocationName,
                    //CityName= item.MasterCity.CityName,
                    ProvisionalCertificate = item.ProvisionalCertificate,
                    Website = item.Website,
                    Status = item.CollegeStatus,
                    Address = item.CollegeAddress,
                    SpecialInstruction = item.SpecialInstruction,
                    PassingCertificate = item.PassingCertificate,
                    ModeOfInitiation = item.ModeOfInitiation,
                    ModeOfPayment = item.ModeOfPayment,
                    OfficialEmailId = item.OfficialEmailId,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    MobileNo = item.MobileNo,
                    OtherDocument = item.OtherDocument,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    FavourOf = item.FavourOf,
                    ResultLink = item.ResultLink,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                   // OtherAffliatiated = item.OtherAffliatiated,
                    OtherInitiation = item.OtherInitiation,
                    OtherStatus = item.OtherStatus,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    Snapshot = item.Snapshot,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2

                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CollegeListPagedModel GetCollege(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCollege> data = db.MasterColleges;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CollegeName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CollegeName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CollegeName) : data.OrderByDescending(d => d.CollegeName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CollegeRowID) : data.OrderByDescending(d => d.CollegeRowID);
                        break;
                }

                CollegeListPagedModel model = new CollegeListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Colleges = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CollegeListViewModel
                {
                    CollegeRowID = item.CollegeRowID,
                    CollegeName = item.CollegeName,
                    UniversityRowID=item.UniversityRowID,
                    UniversityName=item.MasterUniversity.UniversityName,                    
                    AffliatiatedFrom = item.AffiliatedFrom,
                    ConcernPersonName = item.ConcernPersonName,                   
                    CollegeStatus = item.CollegeStatus,                    
                    OfficialEmailId = item.OfficialEmailId,                    
                    Status = item.Status,                       
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CollegeListPagedModel GetBeyondCollege(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                DateTime todayDate = DateTime.Now;

                IQueryable<MasterCollege> data = db.MasterColleges.Where(c=>DbFunctions.DiffDays(c.ModifiedDate, todayDate) > 180);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CollegeName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CollegeName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CollegeName) : data.OrderByDescending(d => d.CollegeName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CollegeRowID) : data.OrderByDescending(d => d.CollegeRowID);
                        break;
                }

                CollegeListPagedModel model = new CollegeListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Colleges = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CollegeListViewModel
                {
                    CollegeRowID = item.CollegeRowID,
                    CollegeName = item.CollegeName,
                    UniversityRowID = item.UniversityRowID,
                    UniversityName = item.MasterUniversity.UniversityName,
                    AffliatiatedFrom = item.AffiliatedFrom,
                    ConcernPersonName = item.ConcernPersonName,
                    CollegeStatus = item.CollegeStatus,
                    OfficialEmailId = item.OfficialEmailId,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateCollegeViewModel GetCollegeForUpdateById(short CollegeRowID)
        {
            try
            {
                UpdateCollegeViewModel model = new UpdateCollegeViewModel();
                var entity = db.MasterColleges.Find(CollegeRowID);

                if (entity != null)
                {
                    model.CollegeRowID = entity.CollegeRowID;
                    model.UniversityRowID = entity.UniversityRowID;
                    model.CollegeName = entity.CollegeName;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.AffliatiatedFrom = entity.AffiliatedFrom;
                    model.ConcernPersonName = entity.ConcernPersonName;
                    //model.DDFavourOf = entity.DDFavourOf;
                    model.DegreeCertificate = Convert.ToBoolean(entity.DegreeCertificate);
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.FinalYearMarksSheet = Convert.ToBoolean(entity.FinalYearMarksSheet);
                    model.LocationRowID = entity.LocationRowID;
                  //  model.CityRowID = entity.CityRowID;
                    model.ProvisionalCertificate = Convert.ToBoolean(entity.ProvisionalCertificate);
                   // model.VerificationProcessTAT = entity.VerificationProcessTAT;
                    model.Website = entity.Website;
                    model.CollegeStatus = entity.CollegeStatus;
                    model.CollegeAddress = entity.CollegeAddress;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.PassingCertificate = Convert.ToBoolean(entity.PassingCertificate);
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.MobileNo = entity.MobileNo;
                    model.OtherDocument = Convert.ToBoolean(entity.OtherDocument);
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;
                    model.FavourOf = entity.FavourOf;
                    model.ResultLink = entity.ResultLink;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                   // model.OtherAffliatiated = entity.OtherAffliatiated;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.OtherStatus = entity.OtherStatus;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
                    model.Snapshot = entity.Snapshot;
                    model.VerificationTATLevel1 = entity.VerificationTATLevel1;
                    model.VerificationTATLevel2 = entity.VerificationTATLevel2;
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

        public bool IsCollegeExist(string CollegeName)
        {
            try
            {
                var College = db.MasterColleges.Where(c => c.CollegeName.Trim().ToLower() == CollegeName.Trim().ToLower()).FirstOrDefault();
                if (College != null && College.CollegeName.Length > 0)
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

        public bool IsCollegeExist(int CollegeRowID, string CollegeName)
        {
            try
            {
                var College = db.MasterColleges
                    .Where(c => c.CollegeName.Trim().ToLower() == CollegeName.Trim().ToLower() && c.CollegeRowID != CollegeRowID)
                    .FirstOrDefault();
                if (College != null && College.CollegeName.Length > 0)
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

        public void UpdateCollege(UpdateCollegeViewModel model)
        {
            try
            {
                if (model != null && model.CollegeRowID > 0)
                {
                    MasterCollege entity = new MasterCollege();
                    entity.CollegeRowID = model.CollegeRowID;
                    entity.UniversityRowID = model.UniversityRowID;
                    entity.CollegeName = model.CollegeName;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AffiliatedFrom = model.AffliatiatedFrom;
                    entity.ConcernPersonName = model.ConcernPersonName;
                    //entity.DDFavourOf = model.DDFavourOf;
                    entity.DegreeCertificate = Convert.ToByte(model.DegreeCertificate);
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.FinalYearMarksSheet = Convert.ToByte(model.FinalYearMarksSheet);
                    entity.LocationRowID = model.LocationRowID;
                    //entity.CityRowID = model.CityRowID;
                    entity.ProvisionalCertificate = Convert.ToByte(model.ProvisionalCertificate);
                    //entity.VerificationProcessTAT = model.VerificationProcessTAT;
                    entity.Website = model.Website;
                    entity.CollegeStatus = model.CollegeStatus;
                    entity.CollegeAddress = model.CollegeAddress;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.PassingCertificate = Convert.ToByte(model.PassingCertificate);
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.ModeOfPayment = model.ModeOfPayment;
                    entity.OfficialEmailId = model.OfficialEmailId;
                    entity.OfficialLandlineNo = model.OfficialLandlineNo;
                    entity.MobileNo = model.MobileNo;
                    entity.OtherDocument = Convert.ToByte(model.OtherDocument);
                    entity.Other1 = model.Other1;
                    entity.Other2 = model.Other2;
                    entity.Other3 = model.Other3;
                    entity.Other4 = model.Other4;
                    entity.Other5 = model.Other5;
                    //entity.Status = model.Status;
                    entity.FavourOf = model.FavourOf;
                    entity.ResultLink = model.ResultLink;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    //entity.OtherAffliatiated = model.OtherAffliatiated;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.OtherStatus = model.OtherStatus;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.Snapshot = model.Snapshot;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;
                    entity.ModifiedDate = model.ModifiedDate;

                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("College could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveCollege(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterColleges.Single(b => b.CollegeRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("College could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CollegeViewModel GetCollegeForDetailsById(short CollegeRowID)
        {
            try
            {   CollegeViewModel model = new CollegeViewModel();
                var entity = db.MasterColleges.Find(CollegeRowID);
                if (entity != null)
                {
                    model.CollegeRowID = entity.CollegeRowID;
                    model.UniversityName = entity.MasterUniversity.UniversityName;
                    model.CollegeName = entity.CollegeName;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost = entity.AdditionalCost;
                    //if (model.AdditionalCost == 1)
                    //    model.AdditionalCostYN = "Yes";
                    //else model.AdditionalCostYN = "No";                    
                    model.AdditionalCosting = entity.AdditionalCosting;                    
                    model.ConcernPersonName = entity.ConcernPersonName;                
                    model.DegreeCertificate = entity.DegreeCertificate;
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.FinalYearMarksSheet = entity.FinalYearMarksSheet;
                    model.ProvisionalCertificate = entity.ProvisionalCertificate;                   
                    model.Website = entity.Website;
                    model.CollegeStatus = entity.CollegeStatus;
                    model.CollegeAddress = entity.CollegeAddress;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.PassingCertificate = entity.PassingCertificate;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.MobileNo = entity.MobileNo;
                    model.OtherDocument = entity.OtherDocument;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;
                    model.FavourOf = entity.FavourOf;
                    model.ResultLink = entity.ResultLink;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;                   
                    model.OtherInitiation = entity.OtherInitiation;
                    model.OtherStatus = entity.OtherStatus;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
                    model.Snapshot = entity.Snapshot;
                    model.VerificationTATLevel1 = entity.VerificationTATLevel1;
                    model.VerificationTATLevel2 = entity.VerificationTATLevel2;
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
