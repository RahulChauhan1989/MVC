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
    public class VCoverageDistrictRepository : IVCoverageDistrictRepository
    {
        DataContext db;
        public VCoverageDistrictRepository()
        {
            db = new DataContext();
        }

        public void ActiveVendorCoverageDistrict(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterVendorCoverageDistricts.Single(b => b.VCDistrictRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Coverage District could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddVendorCoverageDistrict(AddVCDistrictViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterVendorCoverageDistrict entity = new MasterVendorCoverageDistrict();
                    entity.VendorCoverageRowID = model.VendorCoverageRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    db.MasterVendorCoverageDistricts.Add(entity);
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

        public UpdateVCDistrictViewModel GetVendorCoverageDistrictForUpdateById(int VendorRowID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VCDistrictViewModel> GetVendorCoverageDistricts()
        {
            try
            {
                return db.MasterVendorCoverageDistricts.Select(item => new VCDistrictViewModel
                {
                    VCDistrictRowID = item.VCDistrictRowID,
                    VendorCoverageRowID = item.VendorCoverageRowID,
                    StateRowID = item.MasterDistrict.StateRowID,
                    StateName = item.MasterDistrict.MasterState.StateName,
                    DistrictRowID = item.DistrictRowID,
                    DistrictName = item.MasterDistrict.DistrictName,
                    Status = item.Status,
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VCDistrictListPagedModel GetVendorCoverageDistricts(int pageNo, int pageSize, string sort, string sortDir, string Search = "", int vcoverageid = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterVendorCoverageDistrict> data = db.MasterVendorCoverageDistricts.Include("MasterVendorCoverages")
                    .Include("MasterDistricts").Where(c => c.VendorCoverageRowID == vcoverageid).OrderBy(c => c.MasterDistrict.DistrictName);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(c => c.MasterDistrict.DistrictName.ToString().Contains(Search));
                }

                VCDistrictListPagedModel model = new VCDistrictListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.VCoverageDistricts = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new VCDistrictViewModel
                {
                    VCDistrictRowID = item.VCDistrictRowID,
                    VendorCoverageRowID = item.VendorCoverageRowID,
                    StateRowID = item.MasterDistrict.StateRowID,
                    StateName = item.MasterDistrict.MasterState.StateName,
                    DistrictRowID = item.DistrictRowID,
                    DistrictName = item.MasterDistrict.DistrictName,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsVCCoverageChecksExist(int VendorCoverageRowID=0, short DistrictRowID=0)
        {
            try
            {
                var CoverageDistricts = db.MasterVendorCoverageDistricts.Where(s => s.VendorCoverageRowID == VendorCoverageRowID && s.DistrictRowID == DistrictRowID).FirstOrDefault();

                if (CoverageDistricts != null)
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

        public void UpdateVendorCoverageDistrict(UpdateVCDistrictViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
