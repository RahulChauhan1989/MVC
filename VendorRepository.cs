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
    public class VendorRepository : IVendorRepository
    {
        DataContext db;
        public VendorRepository()
        {
            db = new DataContext();
        }

        public void AddVendor(AddVendorViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterVendor entity = new MasterVendor();
                    entity.VendorName = model.VendorName;
                    entity.Address = model.Address;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    //entity.CityRowID = model.CityRowID;
                    entity.LocationRowID = model.LocationRowID;
                    //entity.CoverageStateIds = model.CoverageStateIds;
                    //entity.CoverageDistrictIds = model.CoverageDistrictIds;
                    //entity.CoverageCityIds = model.CoverageCityIds;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.VendorContactPerson = model.VendorContactPerson;
                    entity.VendorEmaiID = model.VendorEmaiID;
                    entity.VendorMobileNo = model.VendorMobileNo;
                    entity.VendorContactNo = model.VendorContactNo;
                    entity.SPOCToName = model.SPOCToName;
                    entity.SPOCToEmailId = model.SPOCToEmailId;
                    entity.SPOCToContactNo = model.SPOCToContactNo;
                    entity.SPOCToMobileNo = model.SPOCToMobileNo;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    //entity.MandatoryDocument = model.MandatoryDocument;
                    //entity.AdditionalCosting = model.AdditionalCosting;
                    //entity.AdditionalCost = model.AdditionalCost;
                    entity.ModeOfPayment = model.ModeOfPayment;
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
                    //entity.VerificationTATLevel1 = model.VerificationTATLevel1;
                    //entity.VerificationTATLevel2 = model.VerificationTATLevel2;
                    entity.PinCode = model.PinCode;
                    //entity.CoverageChecks = model.CoverageChecks;
                    entity.AgreementDocs = model.AgreementDocs;
                    entity.EmpanelmentDate = model.EmpanelmentDate;
                    entity.RenewalDate = model.RenewalDate;
                    entity.AuditStatus = model.AuditStatus;
                    entity.AuditStatusDate = model.AuditStatusDate;
                    entity.PanNo = model.PanNo;
                    entity.PanDoc = model.PanDoc;
                    entity.IDProofNo = model.IDProofNo;
                    entity.IDProofDoc = model.IDProofDoc;
                    entity.RegistrationCertificateNo = model.RegistrationCertificateNo;
                    entity.RegistrationCertificateDoc = model.RegistrationCertificateDoc;
                    entity.ServiceTaxCertificateNo = model.ServiceTaxCertificateNo;
                    entity.ServiceTaxCertificateDoc = model.ServiceTaxCertificateDoc;

                    db.MasterVendors.Add(entity);
                }
                else
                {
                    throw new Exception("Vendor Name could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteVendor(short CRowID)
        {
            try
            {
                var entity = db.MasterVendors.Find(CRowID);
                if (entity != null)
                {
                    db.MasterVendors.Remove(entity);
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

        public IEnumerable<VendorViewModel> GetVendors()
        {
            try
            {
                return db.MasterVendors.Select(item => new VendorViewModel
                {
                    VendorRowID = item.VendorRowID,
                    VendorName = item.VendorName,
                    Address = item.Address,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    LocationRowID = item.LocationRowID,
                    ModeOfInitiation = item.ModeOfInitiation,
                    VendorContactPerson = item.VendorContactPerson,
                    VendorEmaiID = item.VendorEmaiID,
                    VendorMobileNo = item.VendorMobileNo,
                    VendorContactNo = item.VendorContactNo,
                    SPOCToName = item.SPOCToName,
                    SPOCToEmailId = item.SPOCToEmailId,
                    SPOCToContactNo = item.SPOCToContactNo,
                    SPOCToMobileNo = item.SPOCToMobileNo,
                    SpecialInstruction = item.SpecialInstruction,
                    ModeOfPayment = item.ModeOfPayment,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    Status = item.Status,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    PinCode = item.PinCode,
                    AgreementDocs = item.AgreementDocs,
                    EmpanelmentDate = item.EmpanelmentDate,
                    RenewalDate = item.RenewalDate,
                    AuditStatus = item.AuditStatus,
                    AuditStatusDate = item.AuditStatusDate,
                    PanNo = item.PanNo,
                    PanDoc = item.PanDoc,
                    IDProofNo = item.IDProofNo,
                    IDProofDoc = item.IDProofDoc,
                    RegistrationCertificateNo = item.RegistrationCertificateNo,
                    RegistrationCertificateDoc = item.RegistrationCertificateDoc,
                    ServiceTaxCertificateNo = item.ServiceTaxCertificateNo,
                    ServiceTaxCertificateDoc = item.ServiceTaxCertificateDoc,

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<VendorExportViewModel> GetVendoresForExport()
        {
            try
            {
                return db.MasterVendors.Select(item => new VendorExportViewModel
                {
                    RowID = item.VendorRowID,
                    VendorName = item.VendorName,
                    Address = item.Address,
                    Country = item.MasterCountry.CountryName,
                    State = item.MasterState.StateName,
                    District = item.MasterDistrict.DistrictName,
                    // City = item.MasterCity.CityName,
                    Location = item.MasterLocation.LocationName,
                    //CoverageStateIds = item.CoverageStateIds,
                    //CoverageDistrictIds = item.CoverageDistrictIds,
                    //CoverageCityIds = item.CoverageCityIds,
                    ModeOfInitiation = item.ModeOfInitiation,
                    VendorContactPerson = item.VendorContactPerson,
                    VendorEmaiID = item.VendorEmaiID,
                    VendorMobileNo = item.VendorMobileNo,
                    VendorContactNo = item.VendorContactNo,
                    SPOCToName = item.SPOCToName,
                    SPOCToEmailId = item.SPOCToEmailId,
                    SPOCToContactNo = item.SPOCToContactNo,
                    SPOCToMobileNo = item.SPOCToMobileNo,
                    SpecialInstruction = item.SpecialInstruction,
                    //AdditionalCosting = item.AdditionalCosting,
                    //AdditionalCost = item.AdditionalCost,
                    ModeOfPayment = item.ModeOfPayment,
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
                    //VerificationTATLevel1 = item.VerificationTATLevel1,
                    //VerificationTATLevel2 = item.VerificationTATLevel2,
                    PinCode = item.PinCode,
                    // CoverageChecks = item.CoverageChecks,
                    AgreementDocs = item.AgreementDocs,
                    EmpanelmentDate = item.EmpanelmentDate,
                    RenewalDate = item.RenewalDate,
                    AuditStatus = item.AuditStatus,
                    AuditStatusDate = item.AuditStatusDate,
                    PanNo = item.PanNo,
                    PanDoc = item.PanDoc,
                    IDProofNo = item.IDProofNo,
                    IDProofDoc = item.IDProofDoc,
                    RegistrationCertificateNo = item.RegistrationCertificateNo,
                    RegistrationCertificateDoc = item.RegistrationCertificateDoc,
                    ServiceTaxCertificateNo = item.ServiceTaxCertificateNo,
                    ServiceTaxCertificateDoc = item.ServiceTaxCertificateDoc,

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VendorListPagedModel GetVendor(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterVendor> data = db.MasterVendors;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.VendorName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "VendorName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.VendorName) : data.OrderByDescending(d => d.VendorName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.VendorRowID) : data.OrderByDescending(d => d.VendorRowID);
                        break;
                }

                VendorListPagedModel model = new VendorListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Vendors = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new VendorViewModel
                {
                    VendorRowID = item.VendorRowID,
                    VendorName = item.VendorName,
                    Address = item.Address,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    LocationRowID = item.LocationRowID,
                    ModeOfInitiation = item.ModeOfInitiation,
                    VendorContactPerson = item.VendorContactPerson,
                    VendorEmaiID = item.VendorEmaiID,
                    VendorMobileNo = item.VendorMobileNo,
                    VendorContactNo = item.VendorContactNo,
                    SPOCToName = item.SPOCToName,
                    SPOCToEmailId = item.SPOCToEmailId,
                    SPOCToContactNo = item.SPOCToContactNo,
                    SPOCToMobileNo = item.SPOCToMobileNo,
                    SpecialInstruction = item.SpecialInstruction,
                    ModeOfPayment = item.ModeOfPayment,
                    Other1 = item.Other1,
                    Other2 = item.Other2,
                    Other3 = item.Other3,
                    Other4 = item.Other4,
                    Other5 = item.Other5,
                    Status = item.Status,
                    FavourOf = item.FavourOf,
                    OtherDocumentDetail = item.OtherDocumentDetail,
                    OtherInitiation = item.OtherInitiation,
                    PayableAT = item.PayableAT,
                    AccountNumber = item.AccountNumber,
                    IFSCCode = item.IFSCCode,
                    PinCode = item.PinCode,
                    AgreementDocs = item.AgreementDocs,
                    EmpanelmentDate = item.EmpanelmentDate,
                    RenewalDate = item.RenewalDate,
                    AuditStatus = item.AuditStatus,
                    AuditStatusDate = item.AuditStatusDate,
                    PanNo = item.PanNo,
                    PanDoc = item.PanDoc,
                    IDProofNo = item.IDProofNo,
                    IDProofDoc = item.IDProofDoc,
                    RegistrationCertificateNo = item.RegistrationCertificateNo,
                    RegistrationCertificateDoc = item.RegistrationCertificateDoc,
                    ServiceTaxCertificateNo = item.ServiceTaxCertificateNo,
                    ServiceTaxCertificateDoc = item.ServiceTaxCertificateDoc,

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateVendorViewModel GetVendorForUpdateById(short VendorRowID)
        {
            try
            {
                UpdateVendorViewModel model = new UpdateVendorViewModel();
                var entity = db.MasterVendors.Find(VendorRowID);

                if (entity != null)
                {
                    model.VendorRowID = entity.VendorRowID;
                    model.VendorName = entity.VendorName;
                    model.Address = entity.Address;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.LocationRowID = entity.LocationRowID;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;                   
                    model.LocationName = entity.MasterLocation.LocationName;                    
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.VendorContactPerson = entity.VendorContactPerson;
                    model.VendorEmaiID = entity.VendorEmaiID;
                    model.VendorMobileNo = entity.VendorMobileNo;
                    model.VendorContactNo = entity.VendorContactNo;
                    model.SPOCToName = entity.SPOCToName;
                    model.SPOCToEmailId = entity.SPOCToEmailId;
                    model.SPOCToContactNo = entity.SPOCToContactNo;
                    model.SPOCToMobileNo = entity.SPOCToMobileNo;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;                   
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;                   
                    model.PinCode = entity.PinCode;                   
                    model.AgreementDocs = entity.AgreementDocs;
                    model.EmpanelmentDate = entity.EmpanelmentDate;
                    model.RenewalDate = entity.RenewalDate;
                    model.AuditStatus = entity.AuditStatus;
                    model.AuditStatusDate = entity.AuditStatusDate;
                    model.PanNo = entity.PanNo;
                    model.PanDoc = entity.PanDoc;
                    model.IDProofNo = entity.IDProofNo;
                    model.IDProofDoc = entity.IDProofDoc;
                    model.RegistrationCertificateNo = entity.RegistrationCertificateNo;
                    model.RegistrationCertificateDoc = entity.RegistrationCertificateDoc;
                    model.ServiceTaxCertificateNo = entity.ServiceTaxCertificateNo;
                    model.ServiceTaxCertificateDoc = entity.ServiceTaxCertificateDoc;
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

        public bool IsVendorExist(string VendorName)
        {
            try
            {
                var Vendor = db.MasterVendors.Where(c => c.VendorName.Trim().ToLower() == VendorName.Trim().ToLower()).FirstOrDefault();
                if (Vendor != null && Vendor.VendorName.Length > 0)
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

        public bool IsVendorExist(short VendorRowID, string VendorName)
        {
            try
            {
                var Vendor = db.MasterVendors
                    .Where(c => c.VendorName.Trim().ToLower() == VendorName.Trim().ToLower() && c.VendorRowID != VendorRowID)
                    .FirstOrDefault();
                if (Vendor != null && Vendor.VendorName.Length > 0)
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

        public short GetLastVendorIdByName(string VName = "")
        {
            try
            {
                short vid = 0;
                if (!string.IsNullOrEmpty(VName))
                {
                    vid = db.MasterVendors.Where(v => v.VendorName.ToLower().Trim() == VName.ToLower().Trim()).FirstOrDefault().VendorRowID;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return vid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateVendor(UpdateVendorViewModel model)
        {
            try
            {
                if (model != null && model.VendorRowID > 0)
                {
                    MasterVendor entity = new MasterVendor();
                    entity.VendorRowID = model.VendorRowID;
                    entity.VendorName = model.VendorName;
                    entity.Address = model.Address;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.ModeOfInitiation = model.ModeOfInitiation;
                    entity.VendorContactPerson = model.VendorContactPerson;
                    entity.VendorEmaiID = model.VendorEmaiID;
                    entity.VendorMobileNo = model.VendorMobileNo;
                    entity.VendorContactNo = model.VendorContactNo;
                    entity.SPOCToName = model.SPOCToName;
                    entity.SPOCToEmailId = model.SPOCToEmailId;
                    entity.SPOCToContactNo = model.SPOCToContactNo;
                    entity.SPOCToMobileNo = model.SPOCToMobileNo;
                    entity.SpecialInstruction = model.SpecialInstruction;
                    entity.ModeOfPayment = model.ModeOfPayment;
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
                    entity.PinCode = model.PinCode;
                    entity.AgreementDocs = model.AgreementDocs;
                    entity.EmpanelmentDate = model.EmpanelmentDate;
                    entity.RenewalDate = model.RenewalDate;
                    entity.AuditStatus = model.AuditStatus;
                    entity.AuditStatusDate = model.AuditStatusDate;
                    entity.PanNo = model.PanNo;
                    entity.PanDoc = model.PanDoc;
                    entity.IDProofNo = model.IDProofNo;
                    entity.IDProofDoc = model.IDProofDoc;
                    entity.RegistrationCertificateNo = model.RegistrationCertificateNo;
                    entity.RegistrationCertificateDoc = model.RegistrationCertificateDoc;
                    entity.ServiceTaxCertificateNo = model.ServiceTaxCertificateNo;
                    entity.ServiceTaxCertificateDoc = model.ServiceTaxCertificateDoc;

                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Vendor could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveVendor(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterVendors.Single(b => b.VendorRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Vendor could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VendorViewModel GetVendorForDetailsById(short VendorRowID)
        {
            try
            {
                VendorViewModel model = new VendorViewModel();

                var entity = db.MasterVendors.Find(VendorRowID);
                if (entity != null)
                {
                    model.VendorRowID = entity.VendorRowID;
                    model.VendorName = entity.VendorName;
                    model.Address = entity.Address;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterState.StateName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.ModeOfInitiation = entity.ModeOfInitiation;
                    model.VendorContactPerson = entity.VendorContactPerson;
                    model.VendorEmaiID = entity.VendorEmaiID;
                    model.VendorMobileNo = entity.VendorMobileNo;
                    model.VendorContactNo = entity.VendorContactNo;
                    model.SPOCToName = entity.SPOCToName;
                    model.SPOCToEmailId = entity.SPOCToEmailId;
                    model.SPOCToContactNo = entity.SPOCToContactNo;
                    model.SPOCToMobileNo = entity.SPOCToMobileNo;
                    model.SpecialInstruction = entity.SpecialInstruction;
                    model.ModeOfPayment = entity.ModeOfPayment;
                    model.Other1 = entity.Other1;
                    model.Other2 = entity.Other2;
                    model.Other3 = entity.Other3;
                    model.Other4 = entity.Other4;
                    model.Other5 = entity.Other5;
                    model.Status = entity.Status;
                    model.FavourOf = entity.FavourOf;
                    model.OtherDocumentDetail = entity.OtherDocumentDetail;
                    model.OtherInitiation = entity.OtherInitiation;
                    model.PayableAT = entity.PayableAT;
                    model.AccountNumber = entity.AccountNumber;
                    model.IFSCCode = entity.IFSCCode;
                    model.PinCode = entity.PinCode;
                    model.AgreementDocs = entity.AgreementDocs;
                    model.EmpanelmentDate = entity.EmpanelmentDate;
                    model.RenewalDate = entity.RenewalDate;
                    model.AuditStatus = entity.AuditStatus;
                    model.AuditStatusDate = entity.AuditStatusDate;
                    model.PanNo = entity.PanNo;
                    model.PanDoc = entity.PanDoc;
                    model.IDProofNo = entity.IDProofNo;
                    model.IDProofDoc = entity.IDProofDoc;
                    model.RegistrationCertificateNo = entity.RegistrationCertificateNo;
                    model.RegistrationCertificateDoc = entity.RegistrationCertificateDoc;
                    model.ServiceTaxCertificateNo = entity.ServiceTaxCertificateNo;
                    model.ServiceTaxCertificateDoc = entity.ServiceTaxCertificateDoc;
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
