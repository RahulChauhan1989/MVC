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
    public class AbbreviationRepository : IAbbreviationRepository
    {
        DataContext db;
        public AbbreviationRepository()
        {
            db = new DataContext();
        }

        public void AddAbbreviation(AddAbbreviationViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterClientAbbreviation entity = new MasterClientAbbreviation();
                    entity.ClientAbbreviation = model.ClientAbbreviation;
                    entity.ClientName = model.ClientName;
                    db.MasterClientAbbreviations.Add(entity);
                }
                else
                {
                    throw new Exception("Client Abbreviation could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAbbreviation(byte AbbreID)
        {
            try
            {
                var entity = db.MasterClientAbbreviations.Find(AbbreID);
                if (entity != null)
                {
                    db.MasterClientAbbreviations.Remove(entity);
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

        public IEnumerable<AbbreviationViewModel> GetAbbreviationCycles()
        {
            try
            {
                return db.MasterClientAbbreviations.Select(A => new AbbreviationViewModel { ClientAbbRowID = A.ClientAbbRowID, ClientAbbreviation = A.ClientAbbreviation, ClientName = A.ClientName }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UpdateAbbreviationViewModel GetAbbreviationForUpdateById(short BCRowID)
        {
            try
            {
                UpdateAbbreviationViewModel model = new UpdateAbbreviationViewModel();
                var entity = db.MasterClientAbbreviations.Find(BCRowID);
                if (entity != null)
                {
                    model.ClientAbbRowID = entity.ClientAbbRowID;
                    model.ClientName = entity.ClientName;
                    model.ClientAbbreviation = entity.ClientAbbreviation;
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

        public AbbreviationListPagedModel GetAbbreviations(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterClientAbbreviation> data = db.MasterClientAbbreviations;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.ClientAbbreviation.ToString().Contains(Search) || b.ClientName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "ClientAbbreviation":
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientAbbreviation) : data.OrderByDescending(d => d.ClientAbbreviation);
                        break;
                    case "clientname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientName) : data.OrderByDescending(d => d.ClientName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientName) : data.OrderByDescending(d => d.ClientName);
                        break;
                }

                AbbreviationListPagedModel model = new AbbreviationListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientAbbreviations = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new AbbreviationViewModel
                {
                    ClientAbbRowID = item.ClientAbbRowID,
                    ClientAbbreviation = item.ClientAbbreviation,
                    ClientName = item.ClientName
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsAbbreviationExist(string ClientName)
        {
            try
            {
                var abbrev = db.MasterClientAbbreviations.Where(a =>a.ClientName.Trim().ToLower() == ClientName.Trim().ToLower()).FirstOrDefault();
                if (abbrev != null && abbrev.ClientName.Length > 0)
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

        public bool IsAbbreviationExist(string ClientName, string CAbbreviation, short ClientAbbRowID)
        {
            try
            {
                var abbrev = db.MasterClientAbbreviations
                    .Where(a => (a.ClientName.Trim().ToLower() == ClientName.Trim().ToLower() || a.ClientAbbreviation == CAbbreviation) && a.ClientAbbRowID !=  ClientAbbRowID)
                    .FirstOrDefault();

                if (abbrev != null)
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

        public void UpdateAbbreviation(UpdateAbbreviationViewModel model)
        {
            try
            {
                if (model != null && model.ClientAbbRowID > 0)
                {
                    db.MasterClientAbbreviations.Single(A => A.ClientAbbRowID == model.ClientAbbRowID).ClientAbbreviation = model.ClientAbbreviation;
                    db.MasterClientAbbreviations.Single(A => A.ClientAbbRowID == model.ClientAbbRowID).ClientName = model.ClientName;

                }
                else
                {
                    throw new Exception("Client Abbreviation could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AbbreviationViewModel> GetAbbreviationForExports()
        {
            try
            {
                return db.MasterClientAbbreviations.Select(a => new AbbreviationViewModel { ClientAbbRowID = a.ClientAbbRowID, ClientAbbreviation = a.ClientAbbreviation, ClientName = a.ClientName, Status=a.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
