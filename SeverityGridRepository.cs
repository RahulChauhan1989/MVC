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
    public class SeverityGridRepository : ISeverityGridRepository
    {
        DataContext db;
        public SeverityGridRepository()
        {
            db = new DataContext();
        }
        public void AddSeverityGrid(AddSeverityGridViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterSeverityGrid entity = new MasterSeverityGrid();
                    entity.SeverityGrid = model.SeverityGrid;
                    entity.ColorName = model.ColorName;
                    entity.ColorCode = model.ColorCode;
                    db.MasterSeverityGrids.Add(entity);
                }
                else
                {
                    throw new Exception("Severity Grid could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteSeverityGrid(short SeverityGridId)
        {
            try
            {
                var entity = db.MasterSeverityGrids.Find(SeverityGridId);
                if (entity != null)
                {
                    db.MasterSeverityGrids.Remove(entity);
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

        public IEnumerable<SeverityGridViewModel> GetSeverityGrid()
        {
            try
            {
                return db.MasterSeverityGrids.Select(s => new SeverityGridViewModel { SeverityGrid = s.SeverityGrid, ColorName = s.ColorName, ColorCode = s.ColorCode, Status = s.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SeverityGridExportViewModel> GetSeverityGridesForExport()
        {
            try
            {
                return db.MasterSeverityGrids.Select(s => new SeverityGridExportViewModel {RowID=s.SeverityGridRowId, SeverityGrid = s.SeverityGrid, ColorName = s.ColorName, ColorCode = s.ColorCode}).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SeverityGridListPagedModel GetSeverityGrid(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            if (pageNo > 1)
            {
                pageNo = 0;
            }
            IQueryable<MasterSeverityGrid> data = db.MasterSeverityGrids;
            if (!string.IsNullOrEmpty(Search))
            {
                data = data.Where(b => b.SeverityGrid.ToString().Contains(Search) || b.ColorName.ToString().Contains(Search) || b.ColorCode.ToString().Contains(Search));
            }
            switch (sort)
            {                
                default:
                    data = sortDir == "asc" ? data.OrderBy(d => d.SeverityGridRowId) : data.OrderByDescending(d => d.SeverityGridRowId);
                    break;
            }
            SeverityGridListPagedModel model = new SeverityGridListPagedModel();
            model.PageSize = pageSize;
            model.TotalRecords = data.Count();
            model.SeverityGrids = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new SeverityGridViewModel
            {
                SeverityGridRowId = item.SeverityGridRowId,
                SeverityGrid = item.SeverityGrid,
                ColorName = item.ColorName,
                ColorCode = item.ColorCode,
                Status=item.Status
            }).ToList();

            return model;
        }

        public UpdateSeverityGridViewModel GetSeverityGridForUpdateById(short SeverityGridId)
        {
            try
            {
                UpdateSeverityGridViewModel model = new UpdateSeverityGridViewModel();
                var entity = db.MasterSeverityGrids.Find(SeverityGridId);
                if (entity != null)
                {
                    model.SeverityGridRowId = entity.SeverityGridRowId;
                    model.SeverityGrid = entity.SeverityGrid;
                    model.ColorName = entity.ColorName;
                    model.ColorCode = entity.ColorCode;
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

        public bool IsSeverityGridExist(string SeverityGridName)
        {
            try
            {
                var Severity = db.MasterSeverityGrids.Where(s => s.SeverityGrid.Trim().ToLower() == SeverityGridName.Trim().ToLower()).FirstOrDefault();
                if (Severity != null && Severity.SeverityGrid.Length > 0)
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

        public bool IsSeverityGridExist(string SeverityGridName, short Id)
        {
            try
            {
                var Severity = db.MasterSeverityGrids.Where(s => s.SeverityGrid.Trim().ToLower() == SeverityGridName.Trim().ToLower()&&s.SeverityGridRowId!=Id).FirstOrDefault();
                if (Severity != null)
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

        public void UpdateSeverityGrid(UpdateSeverityGridViewModel model)
        {
            try
            {
                if (model != null & model.SeverityGridRowId > 0)
                {
                    db.MasterSeverityGrids.Single(s => s.SeverityGridRowId == model.SeverityGridRowId).SeverityGridRowId = model.SeverityGridRowId;
                    db.MasterSeverityGrids.Single(s => s.SeverityGridRowId == model.SeverityGridRowId).SeverityGrid = model.SeverityGrid;
                    db.MasterSeverityGrids.Single(s => s.SeverityGridRowId == model.SeverityGridRowId).ColorName = model.ColorName;
                    db.MasterSeverityGrids.Single(s => s.SeverityGridRowId == model.SeverityGridRowId).ColorCode = model.ColorCode;
                    db.MasterSeverityGrids.Single(s => s.SeverityGridRowId == model.SeverityGridRowId).Status = model.Status;

                }
                else
                {
                    throw new Exception("Severity Grid could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveSeverity(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterSeverityGrids.Single(b => b.SeverityGridRowId == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Severity could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
