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
    public class ClientSeverityRepository : IClientSeverityRepository
    {
        DataContext db;
        public ClientSeverityRepository()
        {
            db = new DataContext();
        }

        public UpdateClientSeverityViewModel GetClientSeverityForUpdateById(int ClientSeverityRowID)
        {
            try
            {
                UpdateClientSeverityViewModel model = new UpdateClientSeverityViewModel();
                var entity = db.PQClientSeverities.Find(ClientSeverityRowID);
                if (entity != null)
                {
                    model.ClientSeverityRowId = entity.ClientSeverityRowId;
                    model.ClientColorName = entity.ClientColorName;
                    model.ClientColorCode = entity.ClientColorCode;
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

        public void UpdateClientSeverity(UpdateClientSeverityViewModel model)
        {

            try
            {
                if (model != null && model.ClientSeverityRowId > 0)
                {
                    db.PQClientSeverities.Single(b => b.ClientSeverityRowId == model.ClientSeverityRowId).ClientColorName = model.ClientColorName;
                    db.PQClientSeverities.Single(b => b.ClientSeverityRowId == model.ClientSeverityRowId).ClientColorCode = model.ClientColorCode;
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

        public IEnumerable<MasertSeverityViewModel> GetMasterSeveritys()
        {
            try
            {
                return db.MasterSeverityGrids.Select(item => new MasertSeverityViewModel
                {
                    SeverityGridRowId = item.SeverityGridRowId,
                    ColorName = item.ColorName,
                    SeverityGrid = item.SeverityGrid,
                    ColorCode = item.ColorCode,
                }).ToList();
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

        public ClientSeverityListPagedModel GetClientSeverities(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short ClientRowID=0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientSeverity> data = db.PQClientSeverities.Include("PQClientMaster").Where(p => p.ClientRowID == ClientRowID);

                //if (!string.IsNullOrEmpty(Search))
                //{
                //    data = data.Where(b => b.ClientColorCode.ToString().Contains(Search));
                //}

                switch (sort)
                {
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientSeverityRowId) : data.OrderByDescending(d => d.ClientSeverityRowId);
                        break;
                }

                ClientSeverityListPagedModel model = new ClientSeverityListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientSeverities = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientSeverityViewModel
                {
                    ClientSeverityRowId = item.ClientSeverityRowId,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    ClientColorName = item.ClientColorName,
                    ClientColorCode = item.ClientColorCode,
                    ColorCode = item.MasterSeverityGrid.ColorCode,
                    SeverityGrid = item.MasterSeverityGrid.SeverityGrid,

                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        //string GetClientNameById(short  = 0)
        //{
        //    string ClientName = db.MasterAbbreviations.Where(c => c.ClientAbbRowID == ClientAbbRowID).FirstOrDefault().ClientAbbreviation;
        //    return ClientName;
        //}
    }
}
