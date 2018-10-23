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
    public class PoliceStationRepository : IPoliceStationRepository
    {
        DataContext db;

        public PoliceStationRepository()
        {
            db = new DataContext();
        }

        public void ActivePoliceStation(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterPoliceStations.Single(b => b.PoliceStationRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Police Station could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddStationRepository(AddPoliceStationViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterPoliceStation entity = new MasterPoliceStation();
                    entity.PoliceStationName = model.PoliceStationName;
                    entity.PoliceStationAddress = model.PoliceStationAddress;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    // entity.CityRowID = model.CityRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.Coverage = model.Coverage;
                    entity.Website = model.Website;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.MandatoryDocument = model.MandatoryDocument;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.ModeOfPayment = model.ModeOfPayment;
                    entity.ConcernPersonName = model.ConcernPersonName;
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.OfficialLandlineNo = model.OfficialLandlineNo;
                    entity.OfficialEmailId = model.OfficialEmailId;
                    entity.MobileNo = model.MobileNo;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.Other1 = model.Other1;
                    entity.Other2 = model.Other2;
                    entity.Other3 = model.Other3;
                    entity.Other4 = model.Other4;
                    entity.Other5 = model.Other5;
                    entity.FavourOf = model.FavourOf;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;

                    db.MasterPoliceStations.Add(entity);
                }
                else
                {
                    throw new Exception("Police Station could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletePoliceStation(short CRowID)
        {
            try
            {
                var entity = db.MasterPoliceStations.Find(CRowID);
                if (entity != null)
                {
                    db.MasterPoliceStations.Remove(entity);
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

        public PoliceStationListPagedModel GetPoliceStation(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterPoliceStation> data = db.MasterPoliceStations;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.PoliceStationName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "PoliceStationName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.PoliceStationName) : data.OrderByDescending(d => d.PoliceStationName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.PoliceStationName) : data.OrderByDescending(d => d.PoliceStationName);
                        break;
                }
                PoliceStationListPagedModel model = new PoliceStationListPagedModel();

                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.PoliceStations = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PoliceStationListViewModel
                {
                    PoliceStationRowID = item.PoliceStationRowID,
                    PoliceStationName = item.PoliceStationName,                   
                    ConcernPersonName = item.ConcernPersonName,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    OfficialEmailId = item.OfficialEmailId,
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

        public PoliceStationViewModel GetPoliceStationForDetailsById(short PoliceStationRowID)
        {
            try
            {
                PoliceStationViewModel model = new PoliceStationViewModel();
                var entity = db.MasterPoliceStations.Find(PoliceStationRowID);
                if (entity != null)
                {
                    model.PoliceStationRowID = entity.PoliceStationRowID;
                    model.PoliceStationName = entity.PoliceStationName;
                    model.PoliceStationAddress = entity.PoliceStationAddress;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;                  
                    model.Location = entity.MasterLocation.LocationName;
                    model.Coverage = entity.Coverage; 
                    model.Website = entity.Website;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.MandatoryDocument = entity.MandatoryDocument;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.ConcernPersonName = entity.ConcernPersonName;
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.MobileNo = entity.MobileNo;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;                   
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
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

        public UpdatePoliceStationViewModel GetPoliceStationrForUpdateById(short PoliceStationRowID)
        {
            try
            {
                UpdatePoliceStationViewModel model = new UpdatePoliceStationViewModel();
                var entity = db.MasterPoliceStations.Find(PoliceStationRowID);
                if (entity != null)
                {
                    model.PoliceStationRowID = entity.PoliceStationRowID;
                    model.PoliceStationName = entity.PoliceStationName;
                    model.PoliceStationAddress = entity.PoliceStationAddress;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.LocationRowID = entity.LocationRowID;
                    model.Coverage = entity.Coverage;
                    model.Website = entity.Website;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.MandatoryDocument = entity.MandatoryDocument;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.ConcernPersonName = entity.ConcernPersonName;
                    model.DesigConcernPerson = entity.DesigConcernPerson;
                    model.OfficialLandlineNo = entity.OfficialLandlineNo;
                    model.OfficialEmailId = entity.OfficialEmailId;
                    model.MobileNo = entity.MobileNo;
                    model.AdditionalComments = entity.AdditionalComments;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
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

        public IEnumerable<PoliceStationViewModel> GetPoliceStations()
        {
            try
            {
                return db.MasterPoliceStations.Select(item => new PoliceStationViewModel
                {
                    PoliceStationName = item.PoliceStationName,
                    PoliceStationAddress = item.PoliceStationAddress,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    //  CityRowID = item.CityRowID,
                    LocationRowID = item.LocationRowID,
                    Coverage = item.Coverage,
                    Website = item.Website,
                    ModeOfInitiation = item.ModeOfInitiation,
                    SpecialInstruction = item.SpecialInstruction,
                    MandatoryDocument = item.MandatoryDocument,
                    AdditionalCosting = item.AdditionalCosting,
                    AdditionalCost = item.AdditionalCost,
                    ModeOfPayment = item.ModeOfPayment,
                    ConcernPersonName = item.ConcernPersonName,
                    DesigConcernPerson = item.DesigConcernPerson,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    OfficialEmailId = item.OfficialEmailId,
                    MobileNo = item.MobileNo,
                    AdditionalComments = item.AdditionalComments,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    //VerificationProcessTAT = item.VerificationProcessTAT,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2,
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PoliceStationExportViewModel> GetPoliceStationsForExport()
        {
            try
            {
                return db.MasterPoliceStations.Select(item => new PoliceStationExportViewModel
                {
                    Name = item.PoliceStationName,
                    Address = item.PoliceStationAddress,
                    Country = item.MasterCountry.CountryName,
                    State = item.MasterState.StateName,
                    District = item.MasterDistrict.DistrictName,
                    //City = item.MasterCity.CityName,
                    Location = item.MasterLocation.LocationName,
                    Coverage = item.Coverage,
                    Website = item.Website,
                    ModeOfInitiation = item.ModeOfInitiation,
                    SpecialInstruction = item.SpecialInstruction,
                    MandatoryDocument = item.MandatoryDocument,
                    AdditionalCosting = item.AdditionalCosting,
                    AdditionalCost = item.AdditionalCost,
                    ModeOfPayment = item.ModeOfPayment,
                    ConcernPersonName = item.ConcernPersonName,
                    DesigConcernPerson = item.DesigConcernPerson,
                    OfficialLandlineNo = item.OfficialLandlineNo,
                    OfficialEmailId = item.OfficialEmailId,
                    MobileNo = item.MobileNo,
                    AdditionalComments = item.AdditionalComments,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    VerificationTATLevel1 = item.VerificationTATLevel1,
                    VerificationTATLevel2 = item.VerificationTATLevel2,
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPoliceStationExist(string PoliceStationName)
        {
            try
            {
                var PoliceStations = db.MasterPoliceStations.Where(p => p.PoliceStationName.Trim().ToLower() == PoliceStationName.Trim().ToLower()).FirstOrDefault();
                if (PoliceStations != null && PoliceStations.PoliceStationName.Length > 0)
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

        public bool IsPoliceStationExist(short PoliceStationRowID, string PoliceStationName)
        {
            try
            {
                var PoliceStations = db.MasterPoliceStations
                    .Where(c => c.PoliceStationName.Trim().ToLower() == PoliceStationName.Trim().ToLower() && c.PoliceStationRowID != PoliceStationRowID)
                    .FirstOrDefault();
                if (PoliceStations != null && PoliceStations.PoliceStationName.Length > 0)
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

        public void UpdatePoliceStation(UpdatePoliceStationViewModel model)
        {
            try
            {
                if (model != null && model.PoliceStationRowID > 0)
                {
                    MasterPoliceStation entity = new MasterPoliceStation();
                    entity.PoliceStationRowID = model.PoliceStationRowID;
                    entity.PoliceStationName = model.PoliceStationName;
                    entity.PoliceStationAddress = model.PoliceStationAddress;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.Coverage = model.Coverage;
                    entity.Website = model.Website;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.MandatoryDocument = model.MandatoryDocument;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.ModeOfPayment = model.ModeOfPayment;
                    entity.ConcernPersonName = model.ConcernPersonName;
                    entity.DesigConcernPerson = model.DesigConcernPerson;
                    entity.OfficialLandlineNo = model.OfficialLandlineNo;
                    entity.OfficialEmailId = model.OfficialEmailId;
                    entity.MobileNo = model.MobileNo;
                    entity.AdditionalComments = model.AdditionalComments;
                    entity.Other1 = model.Other1;
                    entity.Other2 = model.Other2;
                    entity.Other3 = model.Other3;
                    entity.Other4 = model.Other4;
                    entity.Other5 = model.Other5;
                    //entity.VerificationProcessTAT = model.VerificationProcessTAT;
                    entity.FavourOf = model.FavourOf;
                    entity.OtherDocumentDetail = model.OtherDocumentDetail;
                    entity.OtherInitiation = model.OtherInitiation;
                    entity.PayableAT = model.PayableAT;
                    entity.AccountNumber = model.AccountNumber;
                    entity.IFSCCode = model.IFSCCode;
                    entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    entity.VerificationTATLevel2 = model.VerificationTATLevel2;

                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Police Station could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
