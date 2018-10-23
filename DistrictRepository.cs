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
    public class DistrictRepository : IDistrictRepository
    {
        DataContext db;

        public DistrictRepository()
        {
            db = new DataContext();
        }

        public void AddDistrict(AddDistrictViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterDistrict entity = new MasterDistrict();
                    entity.DistrictName = model.DistrictName;
                    entity.StateRowID = model.StateRowID;
                    entity.CountryRowID = model.CountryRowID;

                    db.MasterDistricts.Add(entity);
                }
                else
                {
                    throw new Exception("District could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDistrict(short DistrictRowID)
        {
            try
            {
                var entity = db.MasterDistricts.Find(DistrictRowID);

                if (entity != null)
                {
                    db.MasterDistricts.Remove(entity);
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

        public UpdateDistrictViewModel GetDistrictForUpdateById(short DistrictRowID)
        {
            try
            {
                UpdateDistrictViewModel model = new UpdateDistrictViewModel();
                var entity = db.MasterDistricts.Find(DistrictRowID);

                if (entity != null)
                {
                    model.DistrictRowID = entity.DistrictRowID;
                    model.DistrictName = entity.DistrictName;
                    model.StateRowID = entity.StateRowID;
                    model.CountryRowID = entity.CountryRowID;

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

        public DistrictListPagedModel GetDistricts(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterDistrict> data = db.MasterDistricts;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(s => s.DistrictName.ToString().Contains(Search) || s.MasterState.StateName.ToString().Contains(Search) || s.MasterCountry.CountryName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "districtname":
                        data = sortDir == "asc" ? data.OrderBy(s => s.DistrictName) : data.OrderByDescending(s => s.DistrictName);
                        break;
                    case "statename":
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterState.StateName) : data.OrderByDescending(s => s.MasterState.StateName);
                        break;
                    case "countryname":
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterCountry.CountryName) : data.OrderByDescending(s => s.MasterCountry.CountryName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(s => s.DistrictName) : data.OrderByDescending(s => s.DistrictName);
                        break;
                }

                DistrictListPagedModel model = new DistrictListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Districts = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new DistrictViewModel
                {
                    DistrictRowID = item.DistrictRowID,
                    DistrictName = item.DistrictName,
                    StateName = item.MasterState.StateName,
                    StateRowID = item.MasterState.StateRowID,
                    CountryRowID = item.MasterCountry.CountryRowID,
                    CountryName = item.MasterCountry.CountryName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsDistrictExist(string DistrictName)
        {
            try
            {
                var district = db.MasterDistricts.Where(c => c.DistrictName.Trim().ToLower() == DistrictName.Trim().ToLower()).FirstOrDefault();
                if (district != null && district.DistrictName.Length > 0)
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

        public void UpdateDistrict(UpdateDistrictViewModel model)
        {
            try
            {
                if (model != null && model.DistrictRowID > 0)
                {
                    db.MasterDistricts.Single(b => b.DistrictRowID == model.DistrictRowID).DistrictName = model.DistrictName;
                    db.MasterDistricts.Single(b => b.DistrictRowID == model.DistrictRowID).StateRowID = model.StateRowID;
                    db.MasterDistricts.Single(b => b.DistrictRowID == model.DistrictRowID).CountryRowID = model.CountryRowID;
                }
                else
                {
                    throw new Exception("District could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DistrictForCheckBoxViewModel> GetDistrictForCheckbox(short countryRowID, short[] stateRowID)
        {
            IQueryable<MasterDistrict> data = db.MasterDistricts;


            var dlst = (from a in db.MasterDistricts
                        .Where (s => stateRowID.Contains(s.StateRowID) && s.CountryRowID==countryRowID)
                       select a 
                ).ToList();

            
            var model = dlst.Select(item =>
            {
                var dList = new DistrictForCheckBoxViewModel
                {
                    DistrictRowID = item.DistrictRowID,
                    DistrictName = item.DistrictName,
                    StateRowID=item.StateRowID,
                    StateName=item.MasterState.StateName,
                    DistrictIsChecked = false,
                };
                return dList;
            }).ToList();
            return model;










            // DistrictForCheckBoxViewModel model = new DistrictForCheckBoxViewModel();

            //var dstrcList = data.Where(s => s.CountryRowID == countryRowID && s.StateRowID == stateRowID).ToList();
            //var model = dstrcList.Select(item =>
            //           {
            //               var dList = new DistrictForCheckBoxViewModel
            //               {
            //                   DistrictRowID = item.DistrictRowID,
            //                   DistrictName = item.DistrictName,
            //                   DistrictIsChecked = false,
            //               };
            //               return dList;
            //           }).ToList();
            //return model;
        }

        public IEnumerable<DistrictExportViewModel> GetDistrictesForExport()
        {
            try
            {
                return db.MasterDistricts.Select(c => new DistrictExportViewModel { RowID = c.DistrictRowID, DistrictName = c.DistrictName, CountryName = c.MasterCountry.CountryName, StateName = c.MasterState.StateName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActiveDistrict(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterDistricts.Single(b => b.DistrictRowID == id).Status = Convert.ToByte(checkeds);
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
    }
}
