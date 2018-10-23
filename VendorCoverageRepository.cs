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
    public class VendorCoverageRepository : IVendorCoverageRepository
    {
        DataContext db;
        public VendorCoverageRepository()
        {
            db = new DataContext();
        }

        public void ActiveVendorCoverage(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterVendorCoverages.Single(b => b.VendorCoverageRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Vendor Coverage could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddVendorCoverage(AddVendorCoverageViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterVendorCoverage entity = new MasterVendorCoverage();
                    entity.VendorRowID = model.VendorRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.VendorCost = model.VendorCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.Level1TAT = model.Level1TAT;
                    entity.Level2TAT = model.Level2TAT;
                    entity.Remarks = model.Remarks;
                    db.MasterVendorCoverages.Add(entity);
                }
                else
                {
                    throw new Exception("All fields are mandatory");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UpdateVendorCoverageViewModel GetVendorCoverageForUpdateById(int VendorCoverageRowID)
        {
            try
            {
                UpdateVendorCoverageViewModel model = new UpdateVendorCoverageViewModel();
                var entity = db.MasterVendorCoverages.Find(VendorCoverageRowID);
                if (entity != null)
                {
                    model.VendorCoverageRowID = entity.VendorCoverageRowID;
                    model.VendorRowID = entity.VendorRowID;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.VendorCost = entity.VendorCost;
                    model.AdditionalCosting = entity.AdditionalCosting;
                    model.AdditionalCost = entity.AdditionalCost;
                    model.Level1TAT = entity.Level1TAT;
                    model.Level2TAT = entity.Level2TAT;
                    model.Remarks = entity.Remarks;
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

        public IEnumerable<VendorCoverageViewModel> GetVendorCoverages()
        {
            throw new NotImplementedException();
        }

        public VendorCoverageListPagedModel GetVendorCoverages(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short VID=0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterVendorCoverage> data = db.MasterVendorCoverages.Include("MasterCheckFamilies")
                    .Include("MasterStates").Include("MasterDistricts").Where(c => c.VendorRowID == VID);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(c => c.MasterCheckFamily.CheckFamilyName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CheckFamily":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CheckFamilyRowID) : data.OrderByDescending(d => d.CheckFamilyRowID);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.VendorCoverageRowID) : data.OrderByDescending(d => d.VendorCoverageRowID);
                        break;
                }

                VendorCoverageListPagedModel model = new VendorCoverageListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.VendorCoverages = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new VendorCoverageViewModel
                {
                    VendorCoverageRowID=item.VendorCoverageRowID,
                    VendorRowID = item.VendorRowID,
                    CheckFamilyRowID = item.CheckFamilyRowID,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    CountryRowID = item.CountryRowID,
                    CountryName = item.MasterCountry.CountryName,
                    StateRowID = item.StateRowID,
                    StateName=item.MasterState.StateName,
                    VendorCost = item.VendorCost,
                    AdditionalCosting = item.AdditionalCosting,
                    AdditionalCost = item.AdditionalCost,
                    Level1TAT = item.Level1TAT,
                    Level2TAT = item.Level2TAT,
                    Remarks = item.Remarks,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsCoverageChecksExist(short VendorRowID, short CheckFamilyRowID,short StateRowID=0)
        {
            try
            {
                var CoverageChecks = db.MasterVendorCoverages.Where(s => s.VendorRowID == VendorRowID && s.CheckFamilyRowID==CheckFamilyRowID && s.StateRowID==StateRowID).FirstOrDefault();

                if (CoverageChecks != null)
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

        public void UpdateVendorCoverage(UpdateVendorCoverageViewModel model)
        {
            try
            {
                if (model != null && model.VendorRowID > 0)
                {
                    MasterVendorCoverage entity = new MasterVendorCoverage();
                    entity.VendorCoverageRowID = model.VendorCoverageRowID;
                    entity.VendorRowID = model.VendorRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.VendorCost = model.VendorCost;
                    entity.AdditionalCosting = model.AdditionalCosting;
                    entity.AdditionalCost = model.AdditionalCost;
                    entity.Level1TAT = model.Level1TAT;
                    entity.Level2TAT = model.Level2TAT;
                    entity.Remarks = model.Remarks;
                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Vendor coverage details could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
