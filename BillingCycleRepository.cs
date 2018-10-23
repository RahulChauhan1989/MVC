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
    public class BillingCycleRepository : IBillingCycleRepository
    {
        DataContext db;

        public BillingCycleRepository()
        {
            db = new DataContext();
        }

        public bool IsBillingCycleExist(string BillingCycleName)
        {
            try
            {
                var billing = db.MasterBillingCycles.Where(m => m.BillingCycle.Trim().ToLower() == BillingCycleName.Trim().ToLower()).FirstOrDefault();
                if (billing != null && billing.BillingCycle.Trim().Length > 0)
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

        public void AddBillingCycle(AddBillingCycleViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterBillingCycle entity = new MasterBillingCycle();
                    entity.BillingCycle = model.BillingCycle;

                    db.MasterBillingCycles.Add(entity);
                }
                else
                {
                    throw new Exception("Billing Cycle could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBillingCycle(byte BCRowID)
        {
            try
            {
                var entity = db.MasterBillingCycles.Find(BCRowID);
                if (entity != null)
                {
                    db.MasterBillingCycles.Remove(entity);
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

        public UpdateBillingCycleViewModel GetBillingCycleForUpdateById(byte BCRowID)
        {
            try
            {
                UpdateBillingCycleViewModel model = new UpdateBillingCycleViewModel();

                var entity = db.MasterBillingCycles.Find(BCRowID);
                if (entity != null)
                {
                    model.BillingRowID = entity.BillingRowID;
                    model.BillingCycle = entity.BillingCycle;
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

        public void UpdateBillingCycle(UpdateBillingCycleViewModel model)
        {
            try
            {
                if (model != null && model.BillingCycle.Length > 0)
                {
                    db.MasterBillingCycles.Single(b => b.BillingRowID == model.BillingRowID).BillingCycle = model.BillingCycle;
                }
                else
                {
                    throw new Exception("Billing cycle could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BillingCycleViewModel> GetBillingCycles()
        {
            try
            {
                return db.MasterBillingCycles.Select(m => new BillingCycleViewModel { BillingRowID = m.BillingRowID, BillingCycle = m.BillingCycle, Status = m.Status }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BillingCycleExportViewModel> GetBillingCyclesForExport()
        {
            try
            {
                return db.MasterBillingCycles.Select(m => new BillingCycleExportViewModel { BillingRowID = m.BillingRowID, BillingCycle = m.BillingCycle }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BillingCycleListPagedModel GetBillingCycles(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageSize < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterBillingCycle> data = db.MasterBillingCycles;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.BillingCycle.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "BillingCycle":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BillingCycle) : data.OrderByDescending(d => d.BillingCycle);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.BillingCycle) : data.OrderByDescending(d => d.BillingCycle);
                        break;
                }

                BillingCycleListPagedModel model = new BillingCycleListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.BillingCycles = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new BillingCycleViewModel
                {
                    BillingRowID = item.BillingRowID,
                    BillingCycle = item.BillingCycle,
                    Status = item.Status
                }).ToList();

                return model;
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

        public void ActiveBillingCycle(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterBillingCycles.Single(b => b.BillingRowID == id).Status = Convert.ToByte(checkeds);
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
