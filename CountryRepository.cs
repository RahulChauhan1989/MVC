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
    public class CountryRepository : ICountryRepository
    {
        DataContext db;

        public CountryRepository()
        {
            db = new DataContext();
        }

        public bool IsCountryExist(string CountryCode, string CountryName)
        {
            try
            {
                var country = db.MasterCountries.Where(c => c.CountryName.Trim().ToLower() == CountryName.Trim().ToLower() || c.CountryCode.Trim().ToLower() == CountryCode.Trim().ToLower()).FirstOrDefault();

                if (country != null && country.CountryCode.Length > 0 && country.CountryName.Length > 0)
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

        public bool IsCountryExist( string CountryCode, string CountryName ,short CountryID)
        {
            try
            {
                var country = db.MasterCountries.Where(c =>
                (
                (c.CountryName.Trim().ToLower() == CountryName.Trim().ToLower() && c.CountryRowID != CountryID)
                || (c.CountryCode.Trim().ToLower() == CountryCode.Trim().ToLower() && c.CountryRowID != CountryID))
                ).FirstOrDefault();

                if (country != null)
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

        public void AddCountry(AddCountryViewModel model)
        {
            try
            {
                if (model!=null)
                {
                    MasterCountry entity = new MasterCountry();
                    entity.CountryCode = model.CountryCode;
                    entity.CountryName = model.CountryName;
                    entity.CountryCallingCode = model.CountryCallingCode;
                    entity.InternationalDialingPrefix = model.InternationalDialingPrefix;


                    db.MasterCountries.Add(entity);
                }
                else
                {
                    throw new Exception("Country could not be blank!");
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCountry(short CoRowID)
        {
            try
            {
                var entity = db.MasterCountries.Find(CoRowID);
                if (entity!=null)
                {
                    db.MasterCountries.Remove(entity);
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

        public CountryListPagedModel GetCountries(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCountry> data = db.MasterCountries;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(c => c.CountryName.ToString().Contains(Search) || c.CountryCode.ToString().Contains(Search) || c.CountryCallingCode.ToString().Contains(Search) || c.InternationalDialingPrefix.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "countryname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CountryName) : data.OrderByDescending(d => d.CountryName);
                        break;
                    case "countrycode":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CountryCode) : data.OrderByDescending(d => d.CountryCode);
                        break;
                    case "CountryCallingCode":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CountryCallingCode) : data.OrderByDescending(d => d.CountryCallingCode);
                        break;
                    case "InternationalDialingPrefix":
                        data = sortDir == "asc" ? data.OrderBy(d => d.InternationalDialingPrefix) : data.OrderByDescending(d => d.InternationalDialingPrefix);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CountryName) : data.OrderByDescending(d => d.CountryName);
                        break;
                }

                CountryListPagedModel model = new CountryListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Countries = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CountryViewModel
                {
                    CountryRowID = item.CountryRowID,
                    CountryName = item.CountryName,
                    CountryCode = item.CountryCode,
                    CountryCallingCode = item.CountryCallingCode,
                    InternationalDialingPrefix = item.InternationalDialingPrefix,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CountryViewModel> GetCountry()
        {
            try
            {
                return db.MasterCountries.Select(c => new CountryViewModel { CountryRowID = c.CountryRowID, CountryName = c.CountryName, CountryCode = c.CountryCode,CountryCallingCode=c.CountryCallingCode,InternationalDialingPrefix=c.InternationalDialingPrefix, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CountryExportViewModel> GetCountriesForExport()
        {
            try
            {
                return db.MasterCountries.Select(c => new CountryExportViewModel { CountryRowID = c.CountryRowID, CountryName = c.CountryName, CountryCode = c.CountryCode, CountryCallingCode = c.CountryCallingCode, InternationalDialingPrefix = c.InternationalDialingPrefix }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateCountryViewModel GetCountryForUpdateById(short CountryID)
        {
            try
            {
                UpdateCountryViewModel model = new UpdateCountryViewModel();

                var entity = db.MasterCountries.Find(CountryID);
                if (entity != null)
                {
                    model.CountryRowID = entity.CountryRowID;
                    model.CountryCode = entity.CountryCode;
                    model.CountryName = entity.CountryName;
                    model.CountryCallingCode = entity.CountryCallingCode;
                    model.InternationalDialingPrefix = entity.InternationalDialingPrefix;
                    model.Status = entity.Status;
                }
                else
                {
                    throw new Exception("Invalid Id");
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCountry(UpdateCountryViewModel model)
        {
            try
            {
                if (model != null && model.CountryRowID > 0)
                {
                    db.MasterCountries.Single(c => c.CountryRowID == model.CountryRowID).CountryName = model.CountryName;
                    db.MasterCountries.Single(c => c.CountryRowID == model.CountryRowID).CountryCode = model.CountryCode;
                    db.MasterCountries.Single(c => c.CountryRowID == model.CountryRowID).CountryCallingCode = model.CountryCallingCode;
                    db.MasterCountries.Single(c => c.CountryRowID == model.CountryRowID).InternationalDialingPrefix = model.InternationalDialingPrefix;

                }
                else
                {
                    throw new Exception("Country could not be blank!");
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

        public void ActiveCountry(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterCountries.Single(b => b.CountryRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Country could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
