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
    public class UniversityRepository : IUniversityRepository
    {
        DataContext db;
        public UniversityRepository()
        {
            db = new DataContext();
        }

        public void ActiveUniversity(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterUniversities.Single(b => b.UniversityRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Branch office could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddUniversity(AddUniversityViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterUniversity entity = new MasterUniversity();
                    entity.UniversityName = model.UniversityName;
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
                    entity.UniversityStatus = model.UniversityStatus;
                    entity.UniversityAddress = model.UniversityAddress;
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
                    //entity.DDFavourOf = model.DDFavourOf;
                    //entity.VerificationProcessTAT = model.VerificationProcessTAT;
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

                    db.MasterUniversities.Add(entity);
                }
                else
                {
                    throw new Exception("University could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUniversity(short CRowID)
        {
            try
            {
                var entity = db.MasterUniversities.Find(CRowID);
                if (entity != null)
                {
                    db.MasterUniversities.Remove(entity);
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

        public IEnumerable<UniversityViewModel> GetUniversities()
        {
            try
            {
                return db.MasterUniversities.Select(item => new UniversityViewModel
                {
                    UniversityRowID = item.UniversityRowID,
                    UniversityName = item.UniversityName,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    AdditionalComments = item.AdditionalComments,
                    AdditionalCost = item.AdditionalCost,
                    AdditionalCosting = item.AdditionalCosting,
                    AffliatiatedFrom = item.AffiliatedFrom,
                    ConcernPersonName = item.ConcernPersonName,
                    DegreeCertificate = item.DegreeCertificate,
                    DesigConcernPerson = item.DesigConcernPerson,
                    FinalYearMarksSheet = item.FinalYearMarksSheet,
                    LocationRowID = item.LocationRowID,
                    //CityRowID = item.CityRowID,
                    ProvisionalCertificate = item.ProvisionalCertificate,
                    Website = item.Website,
                    UniversityStatus = item.UniversityStatus,
                    UniversityAddress = item.UniversityAddress,
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
                    OtherAffliatiated = item.OtherAffiliated,
                    OtherInitiation = item.OtherInitiation,
                    OtherStatus = item.OtherStatus,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    Snapshot = item.Snapshot,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2,

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<UniversityExportViewModel> GetUniversitiesForExport()
        {
            try
            {
                return db.MasterUniversities.Select(c => new UniversityExportViewModel
                {
                    RowID = c.UniversityRowID
                    ,AccountNumber=c.AccountNumber
                    ,AdditionalComments=c.AdditionalComments
                    ,AdditionalCost=c.AdditionalCost
                    ,AdditionalCosting=c.AdditionalCosting
                    ,Address=c.UniversityAddress
                    ,AffliatiatedFrom=c.AffiliatedFrom
                    //,City=c.MasterCity.CityName
                    ,ConcernPersonName=c.ConcernPersonName
                    ,Country=c.MasterCountry.CountryName
                    ,DegreeCertificate=c.DegreeCertificate
                    ,DesigConcernPerson=c.DesigConcernPerson
                    ,District=c.MasterDistrict.DistrictName
                    ,FavourOf=c.FavourOf
                    ,FinalYearMarksSheet=c.FinalYearMarksSheet
                    ,IFSCCode=c.IFSCCode
                    ,Location=c.MasterLocation.LocationName
                    ,MobileNo=c.MobileNo
                    ,ModeOfInitiation=c.ModeOfInitiation
                    ,ModeOfPayment=c.ModeOfPayment
                    ,OfficialEmailId=c.OfficialEmailId
                    ,OfficialLandlineNo=c.OfficialLandlineNo
                    ,Other1=c.Other1
                    ,Other2=c.Other2
                    ,Other3=c.Other3
                    ,Other4=c.Other4
                    ,Other5=c.Other5
                    ,OtherAffliatiated=c.OtherAffiliated
                    ,OtherDocument=c.OtherDocument
                    ,OtherDocumentDetail=c.OtherDocumentDetail
                    ,OtherInitiation=c.OtherInitiation
                    ,OtherStatus=c.OtherStatus
                    ,PassingCertificate=c.PassingCertificate
                    ,PayableAT=c.PayableAT
                    ,ProvisionalCertificate=c.ProvisionalCertificate
                    ,ResultLink=c.ResultLink
                    ,Snapshot=c.Snapshot
                    ,SpecialInstruction=c.SpecialInstruction
                    ,State=c.MasterState.StateName
                    ,University=c.UniversityName
                    ,VerificationTATLevel1=c.VerificationTATLevel1
                    ,VerificationTATLevel2=c.VerificationTATLevel2
                    ,Website=c.Website
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UniversityListPagedModel GetUniversity(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterUniversity> data = db.MasterUniversities;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.UniversityName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "UniversityName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.UniversityName) : data.OrderByDescending(d => d.UniversityName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.UniversityRowID) : data.OrderByDescending(d => d.UniversityRowID);
                        break;
                }

                UniversityListPagedModel model = new UniversityListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Universities = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new UniversityListViewModel
                {
                    UniversityRowID = item.UniversityRowID,
                    UniversityName = item.UniversityName,                   
                    AffliatiatedFrom = item.AffiliatedFrom.ToLower().Trim() == "others" ? item.OtherAffiliated : item.AffiliatedFrom,
                    ConcernPersonName = item.ConcernPersonName,                     
                    UniversityStatus = item.UniversityStatus.ToLower().Trim() == "others" ? item.OtherStatus : item.UniversityStatus,
                    UniversityAddress = item.UniversityAddress,                    
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

        public UniversityViewModel GetUniversityForDetailsById(short UniversityRowID)
        {
            try
            {
                UniversityViewModel model = new UniversityViewModel();
                var entity = db. MasterUniversities.Find(UniversityRowID);
                if (entity != null)
                {
                    model.UniversityRowID = entity.UniversityRowID;
                    model.UniversityName = entity.UniversityName;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    //if (model.AdditionalCosting=="1")
                    //    model.AdditionalCostYN = "Yes";
                    //else
                    //    model.AdditionalCostYN = "No";
                    model.AffliatiatedFrom = entity.AffiliatedFrom;
                    model.ConcernPersonName = entity.ConcernPersonName;
                    model.DegreeCertificate = entity.DegreeCertificate;
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.FinalYearMarksSheet = entity.FinalYearMarksSheet;
                    model.LocationRowID = entity.LocationRowID;
                    model.ProvisionalCertificate = entity.ProvisionalCertificate;
                    model.Website = entity.Website;
                    model.UniversityStatus = entity.UniversityStatus;
                    model.UniversityAddress = entity.UniversityAddress;
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
                    model.OtherAffliatiated = entity.OtherAffiliated;
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

        public UpdateUniversityViewModel GetUniversityForUpdateById(short UniversityRowID)
        {
            try
            {
                UpdateUniversityViewModel model = new UpdateUniversityViewModel();
                var entity = db.MasterUniversities.Find(UniversityRowID);

                if (entity != null)
                {
                    model.UniversityRowID = entity.UniversityRowID;
                    model.UniversityName = entity.UniversityName;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.AffliatiatedFrom = entity.AffiliatedFrom;
                    model.ConcernPersonName = entity.ConcernPersonName;
                    model.DegreeCertificate = Convert.ToBoolean(entity.DegreeCertificate);
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.FinalYearMarksSheet = Convert.ToBoolean(entity.FinalYearMarksSheet);
                    model.LocationRowID = entity.LocationRowID;
                   // model.CityRowID = entity.CityRowID;
                    model.ProvisionalCertificate = Convert.ToBoolean(entity.ProvisionalCertificate);
                     model.Website = entity.Website;
                    model.UniversityStatus = entity.UniversityStatus;
                    model.UniversityAddress = entity.UniversityAddress;
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
                    model.OtherAffliatiated = entity.OtherAffiliated;
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

        public bool IsUniversityExist(string UniversityName)
        {
            try
            {
                var University = db.MasterUniversities.Where(c => c.UniversityName.Trim().ToLower() == UniversityName.Trim().ToLower()).FirstOrDefault();
                if (University != null && University.UniversityName.Length > 0)
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

        public bool IsUniversityExist(short UniversityRowID, string UniversityName)
        {
            try
            {
                var University = db.MasterUniversities
                    .Where(c => c.UniversityName.Trim().ToLower() == UniversityName.Trim().ToLower() && c.UniversityRowID != UniversityRowID)
                    .FirstOrDefault();
                if (University != null && University.UniversityName.Length > 0)
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

        public void UpdateUniversity(UpdateUniversityViewModel model)
        {
            try
            {
                if (model != null && model.UniversityRowID > 0)
                {
                    MasterUniversity entity = new MasterUniversity();
                    entity.UniversityRowID = model.UniversityRowID;
                    entity.UniversityName = model.UniversityName;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AffiliatedFrom = model.AffliatiatedFrom;
                    entity.ConcernPersonName = model.ConcernPersonName;                   
                    entity.DegreeCertificate = Convert.ToByte(model.DegreeCertificate);
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.FinalYearMarksSheet = Convert.ToByte(model.FinalYearMarksSheet);
                    entity.LocationRowID = model.LocationRowID;                   
                    entity.ProvisionalCertificate = Convert.ToByte(model.ProvisionalCertificate);                  
                    entity.Website = model.Website;
                    entity.UniversityStatus = model.UniversityStatus;
                    entity.UniversityAddress = model.UniversityAddress;
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

                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("University could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
