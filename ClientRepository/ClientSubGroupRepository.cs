using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;

namespace BAL
{
    public class ClientSubGroupRepository : IClientSubGroupRepository
    {
        DataContext db;

        public ClientSubGroupRepository()
        {
            db = new DataContext();
        }

        public void AddClientSubGroup(AddClientSubGroupViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterClientSubGroup entity = new MasterClientSubGroup();
                    entity.ClientAbbRowID = model.ClientAbbRowID;
                    entity.ClientSubGroupName = model.SubGroupName;
                    db.MasterClientSubGroups.Add(entity);
                }
                else
                {
                    throw new Exception("Client Sub-Group could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteClientSubGroup(short ClientSubGroupID)
        {
            var entity = db.MasterClientSubGroups.Find(ClientSubGroupID);
            if (entity != null)
            {
                db.MasterClientSubGroups.Remove(entity);
            }
            else
            {
                throw new Exception("Invalid Id!");
            }
        }

        public UpdateClientSubGroupViewModel GetClientSubGroupForUpdateById(short ClientSubGroupID)
        {
            try
            {
                UpdateClientSubGroupViewModel model = new UpdateClientSubGroupViewModel();
                var entity = db.MasterClientSubGroups.Find(ClientSubGroupID);
                if (entity != null)
                {
                    model.ClientSubGroupID = entity.ClientSubGroupID;
                    model.SubGroupName = entity.ClientSubGroupName;
                    model.ClientAbbRowID = entity.ClientAbbRowID;
                    model.Status = entity.Status;
                }
                else
                {
                    throw new Exception("Invalid Id ");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientSubGroupListPagedModel GetClientSubGroups(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<MasterClientSubGroup> data = db.MasterClientSubGroups;
                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(s => s.ClientSubGroupName.ToString().Contains(Search) || s.MasterClientAbbreviation.ClientAbbreviation.ToString().Contains(Search));
                }
                switch (sort)
                {
                    case "subgroupname":
                        data = sortDir == "asc" ? data.OrderBy(s => s.ClientSubGroupName) : data.OrderByDescending(s => s.ClientSubGroupName);
                        break;
                    case "ClientAbbreviation":
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterClientAbbreviation.ClientName) : data.OrderByDescending(s => s.MasterClientAbbreviation.ClientName);
                        break;

                    default:
                        data = sortDir == "asc" ? data.OrderBy(s => s.ClientSubGroupName) : data.OrderByDescending(s => s.ClientSubGroupName);
                        break;
                }
                ClientSubGroupListPagedModel model = new ClientSubGroupListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientSubGroups = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientSubGroupViewModel
                {
                    ClientSubGroupID = item.ClientSubGroupID,
                    SubGroupName = item.ClientSubGroupName,
                    ClientName = item.MasterClientAbbreviation.ClientName,
                    ClientAbbRowID = item.MasterClientAbbreviation.ClientAbbRowID
                }).ToList();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsClientSubGroupExist(string SubGroupName, short id)
        {
            try
            {
                var SubGrup = db.MasterClientSubGroups.Where(s => s.ClientSubGroupName.Trim().ToLower() == SubGroupName.Trim().ToLower()&& s.ClientAbbRowID==id).FirstOrDefault();
                if (SubGrup!=null&&SubGrup.ClientSubGroupName.Length>0)
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

        public void UpdateClientSubGroup(UpdateClientSubGroupViewModel model)
        {
            try
            {
                if (model!=null&&model.ClientSubGroupID>0)
                {
                    MasterClientSubGroup entity = new MasterClientSubGroup();
                    db.MasterClientSubGroups.Single(s => s.ClientSubGroupID == model.ClientSubGroupID).ClientSubGroupID = model.ClientSubGroupID;
                    db.MasterClientSubGroups.Single(s => s.ClientSubGroupID == model.ClientSubGroupID).ClientSubGroupName = model.SubGroupName;
                    db.MasterClientSubGroups.Single(s => s.ClientSubGroupID == model.ClientSubGroupID).ClientAbbRowID = model.ClientAbbRowID;
                    db.MasterClientSubGroups.Single(s => s.ClientSubGroupID == model.ClientSubGroupID).Status = model.Status;

                }
                else
                {
                    throw new Exception("Client Sub Group colud not be blank!");
                }
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ExportClientSubGroupViewModel> GetClientSubGroupForExport()
        {
            try
            {
                return db.MasterClientSubGroups.Select(b => new ExportClientSubGroupViewModel { ClientSubGroupID = b.ClientSubGroupID, ClientName = b.MasterClientAbbreviation.ClientName, SubGroupName = b.ClientSubGroupName }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
