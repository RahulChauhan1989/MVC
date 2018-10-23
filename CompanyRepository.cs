using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public class CompanyRepository : ICompanyRepository
    {
        DataContext db;

        public CompanyRepository()
        {
            db = new DataContext();
        }

        public void AddCompany(AddCompanyViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterCompany entity = new MasterCompany();
                    entity.CompanyName = model.CompanyName;
                    entity.CompanyAddress = model.CompanyAddress;
                    entity.CompanyLogo = model.CmpLogo;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.GeneralEmail = model.GeneralEmail;
                    entity.MobileNo = model.MobileNo;
                    entity.PhoneNo = model.PhoneNo;
                    entity.FaxNo = model.FaxNo;
                    entity.BillingEmail = model.BillingEmail;
                    entity.BillingDName = model.BillingDName;
                    entity.InitiationEmail = model.InitiationEmail;
                    entity.InitiationDName = model.InitiationDisplay;
                    entity.InsuffDName = model.InsuffDName;
                    entity.InsuffEmail = model.InsuffEmail;
                    entity.ReportEmail = model.ReportEmail;
                    entity.ReportDName = model.ReportDName;
                    entity.MISDName = model.MISDName;
                    entity.MISEmail = model.MISEmail;
                    entity.OtherDName = model.OtherDName;
                    entity.OtherEmail = model.OtherEmail;
                    entity.BillingEmail = model.BillingEmail;
                    entity.SMTPServer = model.SMTPServer;
                    entity.SMTPPort = model.Port;
                    entity.SMTPUserName = model.SMTPUserName;
                    entity.SMTPPassword = model.SMTPPassword;
                    entity.EnableSsl = Convert.ToByte(model.EnableSsl);
                    entity.Status = model.Status;

                    db.MasterCompanies.Add(entity);
                }
                else
                {
                    throw new Exception("Company could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCompany(short CompanyRowID)
        {
            try
            {
                var entity = db.MasterCompanies.Find(CompanyRowID);
                if (entity != null)
                {
                    db.MasterCompanies.Remove(entity);
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

        public CompanyListPagedModel GetCompanies(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCompany> data = db.MasterCompanies;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CompanyName.ToString().Contains(Search));
                }
                switch (sort)
                {
                    case "companyname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CompanyName) : data.OrderByDescending(d => d.CompanyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CompanyName) : data.OrderByDescending(d => d.CompanyName);
                        break;
                }

                CompanyListPagedModel model = new CompanyListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Companies = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CompanyViewModel
                {
                    CompanyRowID = item.CompanyRowID,
                    CompanyName = item.CompanyName,
                    LocationRowID = item.LocationRowID,
                    CompanyAddress = item.CompanyAddress,                   
                    CountryRowID = item.CountryRowID,
                    DistrictRowID = item.DistrictRowID,
                    GeneralEmail = item.GeneralEmail,
                    EnableSsl = item.EnableSsl,
                    Password = item.SMTPPassword,
                    PhoneNo = item.PhoneNo,
                    SMTPPort = item.SMTPPort,
                    SMTPServer = item.SMTPServer,
                    StateRowID = item.StateRowID,
                    UserName = item.SMTPUserName,                  
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CompanyViewModel> GetCompany()
        {
            return db.MasterCompanies.Select(c => new CompanyViewModel {
                  GeneralEmail = c.GeneralEmail
                 ,LocationName=c.MasterLocation.LocationName
                , CompanyAddress = c.CompanyAddress
                , CompanyName = c.CompanyName
                , CompanyRowID = c.CompanyRowID
                , CountryName = c.MasterCountry.CountryName
                , DistrictName = c.MasterDistrict.DistrictName
                , EnableSsl = c.EnableSsl
                , Password = c.SMTPPassword
                , PhoneNo = c.PhoneNo
                , SMTPPort = c.SMTPPort
                ,SMTPServer = c.SMTPServer
                , StateName = c.MasterState.StateName
                , UserName = c.SMTPUserName
                , BillingDName = c.BillingDName
                , BillingEmail = c.BillingDName
                , MISEmail = c.MISEmail
                ,MISDName = c.MISDName
                ,SMTPUserName = c.SMTPUserName
                , InitiationDName = c.InitiationDName
                , InitiationEmail = c.InitiationEmail
                , InsuffEmail = c.InsuffEmail
                , ReportDName = c.ReportDName
                , OtherDName = c.OtherDName
                , OtherEmail=c.OtherEmail
                , ReportEmail=c.ReportEmail
                , InsuffDName=c.InsuffDName
                , Status = c.Status }).ToList();
        }

        public IEnumerable<CompanyExportViewModel> GetCompaniesForExport()
        {
            return db.MasterCompanies.Select(c => new CompanyExportViewModel {
                GeneralEmail = c.GeneralEmail
                ,LocationName= c.MasterLocation.LocationName
                ,
                CompanyAddress = c.CompanyAddress
                ,
                CompanyName = c.CompanyName
                ,
                CompanyRowID = c.CompanyRowID
                ,
                CountryName = c.MasterCountry.CountryName
                ,
                DistrictName = c.MasterDistrict.DistrictName
                ,
                EnableSsl = c.EnableSsl
                ,
                Password = c.SMTPPassword
                ,
                PhoneNo = c.PhoneNo
                ,
                MobileNo = c.MobileNo
                ,
                FaxNo = c.FaxNo
                ,
                SMTPPort = c.SMTPPort
                ,
                SMTPHost = c.SMTPServer
                ,
                StateName = c.MasterState.StateName
                ,
                UserName = c.SMTPUserName
                ,
                BillingDName = c.BillingDName
                ,
                BillingEmail = c.BillingDName
                ,
                MISEmail = c.MISEmail
                 ,
                MISDName = c.MISDName
                ,
                SMTPUserName = c.SMTPUserName
                ,
                InitiationDName = c.InitiationDName
                ,
                InitiationEmail = c.InitiationEmail
                ,
                InsuffEmail = c.InsuffEmail
                ,
                ReportDName = c.ReportDName
                ,
                OtherDName = c.OtherDName
                ,
                OtherEmail = c.OtherEmail
                ,
                ReportEmail = c.ReportEmail
                ,
                InsuffDName = c.InsuffDName
               

            }).ToList();
        }

        public UpdateCompanyViewModel GetCompanyForUpdateById(short CompanyRowID)
        {
            try
            {
                UpdateCompanyViewModel model = new UpdateCompanyViewModel();

                var entity = db.MasterCompanies.Find(CompanyRowID);
                if (entity != null)
                {
                    model.CompanyRowID = entity.CompanyRowID;
                    model.CompanyName = entity.CompanyName;
                    model.CompanyAddress = entity.CompanyAddress;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.LocationRowID = entity.LocationRowID;
                    model.GeneralEmail = entity.GeneralEmail;
                    model.MobileNo = entity.MobileNo;
                    model.PhoneNo = entity.PhoneNo;
                    model.FaxNo = entity.FaxNo;
                    model.BillingEmail = entity.BillingEmail;
                    model.BillingDName = entity.BillingDName;
                    model.InitiationEmail = entity.InitiationEmail;
                    model.InitiationDisplay = entity.InitiationDName;
                    model.InsuffDName = entity.InsuffDName;
                    model.InsuffEmail = entity.InsuffEmail;
                    model.ReportEmail = entity.ReportEmail;
                    model.ReportDName = entity.ReportDName;
                    model.MISDName = entity.MISDName;
                    model.MISEmail = entity.MISEmail;
                    model.OtherDName = entity.OtherDName;
                    model.OtherEmail = entity.OtherEmail;
                    model.BillingEmail = entity.BillingEmail;
                    model.SMTPServer = entity.SMTPServer;
                    model.SMTPPort = entity.SMTPPort;
                    model.SMTPUserName = entity.SMTPUserName;
                    //model.SMTPPassword = entity.SMTPPassword;
                    model.EnableSsl = Convert.ToBoolean(entity.EnableSsl);
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

        public CompanyViewModel GetCompanyForDetailsById(short CompanyRowID)
        {
            try
            {
                CompanyViewModel model = new CompanyViewModel();

                var entity = db.MasterCompanies.Find(CompanyRowID);
                if (entity != null)
                {
                    model.CompanyRowID = entity.CompanyRowID;
                    model.CompanyName = entity.CompanyName;
                    model.CompanyAddress = entity.CompanyAddress;
                    model.CountryName = entity.MasterCountry.CountryName;
                    model.StateName = entity.MasterState.StateName;
                    model.DistrictName = entity.MasterDistrict.DistrictName;
                    model.LocationName = entity.MasterLocation.LocationName;
                    model.CmpLogo = entity.CompanyLogo;
                    model.GeneralEmail = entity.GeneralEmail;
                    model.MobileNo = entity.MobileNo;
                    model.PhoneNo = entity.PhoneNo;
                    model.FaxNo = entity.FaxNo;
                    model.EnableSsl = Convert.ToByte(entity.EnableSsl);
                    if (model.EnableSsl == 1)model.EnableSslYN = "Yes";
                    else model.EnableSslYN = "No";
                    model.BillingEmail = entity.BillingEmail;
                    model.BillingDName = entity.BillingDName;
                    model.InitiationEmail = entity.InitiationEmail;
                    model.InitiationDName = entity.InitiationDName;
                    model.InsuffDName = entity.InsuffDName;
                    model.InsuffEmail = entity.InsuffEmail;
                    model.ReportEmail = entity.ReportEmail;
                    model.ReportDName = entity.ReportDName;
                    model.MISDName = entity.MISDName;
                    model.MISEmail = entity.MISEmail;
                    model.OtherDName = entity.OtherDName;
                    model.OtherEmail = entity.OtherEmail;
                    model.BillingEmail = entity.BillingEmail;
                    model.SMTPServer = entity.SMTPServer;
                    model.SMTPPort = entity.SMTPPort;
                    model.SMTPUserName = entity.SMTPUserName;
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

        public bool IsCompanyExist(string CompanyName)
        {
            try
            {
                var entity = db.MasterCompanies.Where(c => c.CompanyName.Trim().ToLower() == CompanyName.Trim().ToLower()).FirstOrDefault();
                if (entity != null)
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

        public bool IsCompanyExist(string CompanyName, short CmpId)
        {
            try
            {
                var entity = db.MasterCompanies.Where(c => c.CompanyName.Trim().ToLower() == CompanyName.Trim().ToLower() && c.CompanyRowID != CmpId).FirstOrDefault();
                if (entity != null)
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

        public void UpdateCompany(UpdateCompanyViewModel model)
        {
            try
            {
                if (model != null)
                {
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).CompanyName = model.CompanyName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).CompanyAddress = model.CompanyAddress;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).LocationRowID = model.LocationRowID;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).CountryRowID = model.CountryRowID;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).StateRowID = model.StateRowID;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).DistrictRowID = model.DistrictRowID;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).GeneralEmail = model.GeneralEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).MobileNo = model.MobileNo;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).PhoneNo = model.PhoneNo;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).FaxNo = model.FaxNo;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).BillingEmail = model.BillingEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).BillingDName = model.BillingDName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).InitiationEmail = model.InitiationEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).InitiationDName = model.InitiationDisplay;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).InsuffDName = model.InsuffDName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).InsuffEmail = model.InsuffEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).ReportEmail = model.ReportEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).ReportDName = model.ReportDName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).MISDName = model.MISDName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).MISEmail = model.MISEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).OtherDName = model.OtherDName;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).OtherEmail = model.OtherEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).BillingEmail = model.BillingEmail;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).SMTPServer = model.SMTPServer;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).SMTPPort = model.SMTPPort;
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).SMTPUserName = model.SMTPUserName;

                    if (!string.IsNullOrEmpty(model.SMTPPassword))
                    {
                        db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).SMTPPassword = model.SMTPPassword;
                    }

                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).EnableSsl = Convert.ToByte(model.EnableSsl);
                    db.MasterCompanies.Single(c => c.CompanyRowID == model.CompanyRowID).CompanyLogo = model.CmpLogo;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveCompany(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterCompanies.Single(b => b.CompanyRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Company could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CompanyMailAuthenticationViewModel GetMailAuthenticationById(short CompanyRowID)
        {
            try
            {
                return db.MasterCompanies.Where(c => c.CompanyRowID == CompanyRowID && c.Status == 1).Select(cmp => new CompanyMailAuthenticationViewModel
                {
                    CompanyRowID = cmp.CompanyRowID,
                    SMTPServer = cmp.SMTPServer,
                    Port = cmp.SMTPPort,
                    SMTPUserName = cmp.SMTPUserName,
                    SMTPPassword = cmp.SMTPPassword,
                    EnableSsl = cmp.EnableSsl == 1 ? true : false
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CompanyMailSignatureViewModel GetDefaultSignatureDetails(short CompanyRowID)
        {
            try
            {
                return db.MasterCompanies.Where(c => c.CompanyRowID == CompanyRowID && c.Status == 1).Select(cmp => new CompanyMailSignatureViewModel
                {
                    CompanyRowID = cmp.CompanyRowID,
                    CompanyName = cmp.CompanyName,
                    GeneralEmail = cmp.GeneralEmail,
                    PhoneNo = cmp.PhoneNo,
                    MobileNo = cmp.MobileNo,
                    FaxNo = cmp.FaxNo
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

