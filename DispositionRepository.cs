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
    public class DispositionRepository : IDispositionRepository
    {
        DataContext db;

        public DispositionRepository()
        {
            db = new DataContext();
        }

        public void AddDisposition(AddDispositionViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterDisposition entity = new MasterDisposition();
                    entity.Disposition = model.Disposition;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.SeverityGridRowId = model.SeverityGridRowId;
                    db.MasterDispositions.Add(entity);
                }
                else
                {
                    throw new Exception("Disposition could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDisposition(short DispositionID)
        {
            var entity = db.MasterDispositions.Find(DispositionID);
            if (entity != null)
            {
                db.MasterDispositions.Remove(entity);
            }
            else
            {
                throw new Exception("Invalid Id!");
            }
        }

        public IEnumerable<DispositionViewModel> GetDisposition()
        {
            try
            {
                return db.MasterDispositions.Select(d => new DispositionViewModel { Disposition = d.Disposition, CheckFamilyName = d.MasterCheckFamily.CheckFamilyName, SeverityGridName = d.MasterSeverityGrid.SeverityGrid, Status = d.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DispositionExportViewModel> GetDispositionsForExport()
        {
            try
            {
                return db.MasterDispositions.Select(d => new DispositionExportViewModel { RowID = d.DispositionRowId, Disposition = d.Disposition, CheckFamilyName = d.MasterCheckFamily.CheckFamilyName, SeverityGridName = d.MasterSeverityGrid.SeverityGrid }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DispositionViewModel> GetDispositionAutoComplete(string Disposition, short CheckFamilyRowID)
        {
            //var data= (from N in db.MasterDispositions
            //           where N.Disposition.StartsWith(Disposition) && N.CheckFamilyRowID== CheckFamilyRowID
            //           select new { N.Name });


            var Dispositions = db.MasterDispositions.Select(d => new DispositionViewModel
            {
                DispositionRowId = d.DispositionRowId,
                CheckFamilyRowID = d.MasterCheckFamily.CheckFamilyRowID,
                Disposition = d.Disposition,
                IsSetDefalut=d.IsSetDefault,
                SeverityGridRowId=d.SeverityGridRowId,
                Status=d.Status,
            }).Where(c => c.Disposition.StartsWith(Disposition) && c.CheckFamilyRowID == CheckFamilyRowID)
                .ToList();
            return Dispositions;
           
        }

        public DispositionListPagedModel GetDisposition(int pageNo, int pageSize, string sort, string sortDir, short CheckFamilyRowID, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<MasterDisposition> data = db.MasterDispositions;
                if (!string.IsNullOrEmpty(Search) || CheckFamilyRowID > 0)
                {
                    if (CheckFamilyRowID > 0)
                    {
                        data = data.Where(d => d.MasterCheckFamily.CheckFamilyRowID.ToString() == CheckFamilyRowID.ToString());
                    }
                    data = data.Where(d => d.Disposition.ToString().Contains(Search) || d.MasterCheckFamily.CheckFamilyName.Contains(Search) || d.MasterSeverityGrid.SeverityGrid.Contains(Search));
                }
                switch (sort)
                {
                    case "FamilyName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterCheckFamily.CheckFamilyName) : data.OrderByDescending(d => d.MasterCheckFamily.CheckFamilyName);
                        break;
                    case "SeverityGrid":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterSeverityGrid.SeverityGrid) : data.OrderByDescending(d => d.MasterSeverityGrid.SeverityGrid);
                        break;
                    case "Disposition":
                        data = sortDir == "asc" ? data.OrderBy(d => d.Disposition) : data.OrderByDescending(d => d.Disposition);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterCheckFamily.CheckFamilyName) : data.OrderByDescending(d => d.MasterCheckFamily.CheckFamilyName);
                        break;
                }
                DispositionListPagedModel model = new DispositionListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Dispositions = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new DispositionViewModel
                {
                    DispositionRowId = item.DispositionRowId,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    SeverityGridName = item.MasterSeverityGrid.SeverityGrid,
                    Disposition = item.Disposition,
                    IsSetDefalut=item.IsSetDefault,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UpdateDispositionViewModel GetDispositionForUpdateById(short DispositionID)
        {
            UpdateDispositionViewModel model = new UpdateDispositionViewModel();
            var entity = db.MasterDispositions.Find(DispositionID);
            if (entity != null)
            {
                model.DispositionRowId = entity.DispositionRowId;
                model.CheckFamilyRowID = entity.CheckFamilyRowID;
                model.SeverityGridRowId = entity.SeverityGridRowId;
                model.Disposition = entity.Disposition;
                model.Status = entity.Status;
            }
            else
            {
                throw new Exception("Invalid Id!");
            }

            return model;
        }

        public bool IsDispositionExist(string DispositionName)
        {
            try
            {
                var disposition = db.MasterDispositions.Where(d => d.Disposition.Trim().ToLower() == DispositionName.Trim().ToLower()).FirstOrDefault();
                if (disposition != null && disposition.Disposition.Length > 0)
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

        public void UpdateDisposition(UpdateDispositionViewModel model)
        {
            try
            {
                if (model != null && model.DispositionRowId > 0)
                {
                    db.MasterDispositions.Single(b => b.DispositionRowId == model.DispositionRowId).CheckFamilyRowID = model.CheckFamilyRowID;
                    db.MasterDispositions.Single(b => b.DispositionRowId == model.DispositionRowId).SeverityGridRowId = model.SeverityGridRowId;
                    db.MasterDispositions.Single(b => b.DispositionRowId == model.DispositionRowId).Disposition = model.Disposition;
                }
                else
                {
                    throw new Exception("Disposition could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveDisposition(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterDispositions.Single(b => b.DispositionRowId == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Disposition could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetDefaultDisposition(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterDispositions.Single(b => b.DispositionRowId == id).IsSetDefault = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Disposition could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
