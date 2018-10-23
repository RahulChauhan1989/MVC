using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class ClientDispositionRepository : IClientDispositionRepository
    {
        DataContext db;
        public ClientDispositionRepository()
        {
            db = new DataContext();
        }

        public void AddClientDisposition(AddClientDispositionViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientDisposition entity = new PQClientDisposition();
                    entity.ClientRowID = model.ClientRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.DispositionRowId = model.DispositionRowId;
                    entity.SeverityGridRowId = model.SeverityGridRowId;

                    db.PQClientDispositions.Add(entity);
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

        public void AddClientDispositionDefaultSelected(AddClientDispositionViewModel model)
        {
            try
            {
                if (model != null)
                {
                    List<PQClientDisposition> entities = new List<PQClientDisposition>();
                    PQClientDisposition entity;
                   
                    var disposition = db.MasterDispositions.Where(d => (d.CheckFamilyRowID == model.CheckFamilyRowID || d.CheckFamilyRowID == 39) && d.IsSetDefault == 1 && d.Status == 1).ToList();
                    foreach (var item in disposition)
                    {
                        if (!IsClientDispositionExist(model.ClientRowID, item.CheckFamilyRowID, item.DispositionRowId))
                        {
                            entity = new PQClientDisposition();
                            entity.ClientRowID = model.ClientRowID;
                            entity.CheckFamilyRowID = item.CheckFamilyRowID;
                            entity.DispositionRowId = item.DispositionRowId;
                            entity.SeverityGridRowId = item.SeverityGridRowId;
                            entities.Add(entity);
                        }             
                    }
                    db.PQClientDispositions.AddRange(entities);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Invalid Client Id!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDispositionViewModel> GetClientDispositionCycles()
        {
            throw new NotImplementedException();
        }

        public ClientDispositionListPagedModel GetClientDispositions(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0, short ChkId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientDisposition> data = db.PQClientDispositions.Include("MasterCheckFamily").Include("MasterDisposition")
                    .Include("MasterSeverityGrid").Where(p => p.ClientRowID == CId && p.CheckFamilyRowID== ChkId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.MasterDisposition.Disposition.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "Disposition":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterDisposition.Disposition) : data.OrderByDescending(d => d.MasterDisposition.Disposition);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientDispositionRowId) : data.OrderByDescending(d => d.ClientDispositionRowId);
                        break;
                }

                ClientDispositionListPagedModel model = new ClientDispositionListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientDispositions = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientDispositionViewModel
                {
                    ClientDispositionRowId = item.ClientDispositionRowId,
                    ClientRowID = item.ClientRowID,
                    CheckFamilyRowID = item.CheckFamilyRowID,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    DispositionRowId = item.DispositionRowId,
                    Disposition = item.MasterDisposition.Disposition,
                    SeverityGridRowId = item.SeverityGridRowId,
                    SeverityGrid = item.MasterSeverityGrid.SeverityGrid,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDispositionViewModel> GetClientDispositions(short CId = 0, short ChkId = 0)
        {
            try
            {
                return db.PQClientDispositions.Where(a => a.ClientRowID == CId && a.CheckFamilyRowID == ChkId)
                    .Select(a => new ClientDispositionViewModel
                    {
                        DispositionRowId = a.DispositionRowId,
                        CheckFamilyRowID=a.CheckFamilyRowID,
                        SeverityGridRowId=a.SeverityGridRowId,
                        CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                        Status = a.Status
                    }
                ).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientCheckFamilyListPagedModel GetClientCheckFamily(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                var data = (db.PQClientPackages.Include("MasterCheckFamily").Where(p => p.ClientRowID == CId).Select(p => new { p.CheckFamilyRowID, p.MasterCheckFamily.CheckFamilyName})
                            .Union(db.PQClientChecks.Include("MasterCheckFamily").Where(p => p.ClientRowID == CId).Select(p => new { p.CheckFamilyRowID, p.MasterCheckFamily.CheckFamilyName }))).Distinct();

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CheckFamilyName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CheckFamily":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CheckFamilyName) : data.OrderByDescending(d => d.CheckFamilyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CheckFamilyRowID) : data.OrderByDescending(d => d.CheckFamilyRowID);
                        break;
                }

                ClientCheckFamilyListPagedModel model = new ClientCheckFamilyListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientChekFamilies = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientCheckFamilyViewModel
                {
                    CheckFamilyRowID = item.CheckFamilyRowID,
                    CheckFamilyName = item.CheckFamilyName,
                    ClientRowID=CId,
                    DispositionMap = db.PQClientDispositions.Where(d=>d.CheckFamilyRowID==item.CheckFamilyRowID && d.ClientRowID==CId).Count() > 0 ? 1 : 0
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsClientDispositionExist(short CId = 0, short ChkId = 0, short DispositionRowId=0)
        {
            try
            {
                var ClientDispositions = db.PQClientDispositions.Where(c => c.ClientRowID == CId && c.CheckFamilyRowID == ChkId && c.DispositionRowId == DispositionRowId).FirstOrDefault();
                if (ClientDispositions != null && ClientDispositions.ClientDispositionRowId>0)
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

        public UpdateClientDispositionViewModel GetClientDispoSeverityForUpdateById(int ClientDispositionRowId)
        {
            try
            {
                UpdateClientDispositionViewModel model = new UpdateClientDispositionViewModel();
                var entity = db.PQClientDispositions.Find(ClientDispositionRowId);
                if (entity != null)
                {
                    model.ClientDispositionRowId = entity.ClientDispositionRowId;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.DispositionRowId = entity.DispositionRowId;
                    model.Disposition = entity.MasterDisposition.Disposition;
                    model.SeverityGridRowId = entity.SeverityGridRowId;
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

        public void UpdateDispoClientSeverity(UpdateClientDispositionViewModel model)
        {

            try
            {
                if (model != null && model.ClientDispositionRowId > 0)
                {
                    db.PQClientDispositions.Single(b => b.ClientDispositionRowId == model.ClientDispositionRowId).SeverityGridRowId = model.SeverityGridRowId;
                }
                else
                {
                    throw new Exception("Client Severity could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
