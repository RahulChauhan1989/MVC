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
    public class LocationRepository : ILocationRepository
    {
        DataContext db;
        public LocationRepository()
        {
            db = new DataContext();
        }

        public void AddLocation(AddLocationViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterLocation entity = new MasterLocation();
                    entity.LocationName = model.LocationName;
                    entity.PinCode = model.PinCode;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    //entity.CityRowID = model.CityRowID;

                    db.MasterLocations.Add(entity);
                }
                else
                {
                    throw new Exception("Location could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteLocation(short LRowID)
        {
            try
            {
                var entity = db.MasterLocations.Find(LRowID);

                if (entity != null)
                {
                    db.MasterLocations.Remove(entity);
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

        public LocationListPagedModel GetLocation(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterLocation> data = db.MasterLocations;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(l => l.LocationName.ToString().Contains(Search) || l.PinCode.ToString().Contains(Search) || l.MasterDistrict.DistrictName.ToString().Contains(Search) || l.MasterState.StateName.ToString().Contains(Search) || l.MasterCountry.CountryName.ToString().Contains(Search)
                    );
                }
                 
                switch (sort.ToLower())
                {
                    case "locationrowid":
                        data = sortDir == "asc" ? data.OrderBy(l => l.LocationRowID) : data.OrderByDescending(l => l.LocationRowID);
                        break;
                    case "pincode":
                        data = sortDir == "asc" ? data.OrderBy(l => l.PinCode) : data.OrderByDescending(l => l.PinCode);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(l => l.LocationRowID) : data.OrderByDescending(l => l.LocationRowID);
                        break;
                }

                LocationListPagedModel model = new LocationListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Locations = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new LocationViewModel
                {
                    LocationRowID = item.LocationRowID,
                    LocationName = item.LocationName,
                    PinCode = item.PinCode,
                    CountryName = item.MasterCountry.CountryName,
                    StateName=item.MasterState.StateName,
                    DistrictName=item.MasterDistrict.DistrictName,
                    //CityName=item.MasterCity.CityName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateLocationViewModel GetLocationForUpdateById(int LRowID)
        {
            try
            {
                UpdateLocationViewModel model = new UpdateLocationViewModel();
                var entity = db.MasterLocations.Find(LRowID);

                if (entity != null)
                {
                    model.LocationRowID = entity.LocationRowID;
                    model.LocationName = entity.LocationName;
                    model.PinCode = entity.PinCode;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
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

        public IEnumerable<LocationExportViewModel> GetLocationesForExport()
        {
            try
            {
                return db.MasterLocations.Select(c => new LocationExportViewModel { RowID = c.LocationRowID, CountryName = c.MasterCountry.CountryName, StateName = c.MasterState.StateName, DistrictName = c.MasterDistrict.DistrictName,LocationName=c.LocationName,PinCode=c.PinCode }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LocationViewModel> GetLocations()
        {
            try
            {
                return db.MasterLocations.Select(c => new LocationViewModel { LocationRowID = c.LocationRowID, LocationName = c.LocationName, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsLocationExist(string LocationName)
        {
            try
            {
                var Location = db.MasterLocations.Where(c => c.LocationName.Trim().ToLower() == LocationName.Trim().ToLower()).FirstOrDefault();
                if (Location != null && Location.LocationName.Length > 0)
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

        public void UpdateLocation(UpdateLocationViewModel model)
        {
            try
            {
                if (model != null && model.LocationRowID > 0)
                {
                    db.MasterLocations.Single(c => c.LocationRowID == model.LocationRowID).LocationName = model.LocationName;
                    db.MasterLocations.Single(c => c.LocationRowID == model.LocationRowID).DistrictRowID = model.DistrictRowID;
                    db.MasterLocations.Single(c => c.LocationRowID == model.LocationRowID).StateRowID = model.StateRowID;
                    db.MasterLocations.Single(c => c.LocationRowID == model.LocationRowID).CountryRowID = model.CountryRowID;
                    db.MasterLocations.Single(c => c.LocationRowID == model.LocationRowID).PinCode = model.PinCode;
                }
                else
                {
                    throw new Exception("Location could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveLocation(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterLocations.Single(b => b.LocationRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Location could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
