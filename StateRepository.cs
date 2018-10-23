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
    public class StateRepository : IStateRepository
    {
        DataContext db;

        public StateRepository()
        {
            db = new DataContext();
        }

        public bool IsStateExist(string StateName)
        {
            try
            {
                var state = db.MasterStates.Where(s => s.StateName.Trim().ToLower() == StateName.Trim().ToLower()).FirstOrDefault();

                if (state != null && state.StateName != null && state.StateName.Length > 0)
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

        public void AddState(AddStateViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterState entity = new MasterState();
                    entity.StateName = model.StateName;
                    entity.CountryRowID = model.CountryRowID;

                    db.MasterStates.Add(entity);
                }
                else
                {
                    throw new Exception("State could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateStateViewModel GetStateForUpdateById(short StateRowID)
        {
            try
            {
                UpdateStateViewModel model = new UpdateStateViewModel();

                var entity = db.MasterStates.Find(StateRowID);
                if (entity != null)
                {
                    model.StateRowID = entity.StateRowID;
                    model.StateName = entity.StateName;
                    model.CountryRowID = entity.CountryRowID;
                    model.Status = entity.Status;
                }
                else
                {
                    throw new Exception("Invalid Id");
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateState(UpdateStateViewModel model)
        {
            try
            {
                if (model != null && model.StateRowID > 0)
                {
                    db.MasterStates.Single(c => c.StateRowID == model.StateRowID).StateName = model.StateName;
                    db.MasterStates.Single(c => c.StateRowID == model.StateRowID).CountryRowID = model.CountryRowID;
                }
                else
                {
                    throw new Exception("Country could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteState(short StateRowID)
        {
            try
            {
                var entity = db.MasterStates.Find(StateRowID);
                if (entity != null)
                {
                    db.MasterStates.Remove(entity);
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

        public StateListPagedModel GetStates(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterState> data = db.MasterStates;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(s => s.StateName.ToString().Contains(Search) || s.MasterCountry.CountryName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "statename":
                        data = sortDir == "asc" ? data.OrderBy(s => s.StateName) : data.OrderByDescending(s => s.StateName);
                        break;
                    case "countryname":
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterCountry.CountryName) : data.OrderByDescending(s => s.MasterCountry.CountryName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(s => s.StateName) : data.OrderByDescending(s => s.StateName);
                        break;
                }

                StateListPagedModel model = new StateListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.States = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new StateViewModel
                {
                    StateRowID = item.StateRowID,
                    StateName = item.StateName,
                    CountryRowID = item.MasterCountry.CountryRowID,
                    CountryName = item.MasterCountry.CountryName,       
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

        public StateCheckBoxList GetStatesForCheckbox(short countryRowID)
        {
            IQueryable<MasterState> data = db.MasterStates;

            StateCheckBoxList model = new StateCheckBoxList();
            model.checkBoxList = data.Where(s => s.CountryRowID == countryRowID).Select(item => new StateForCheckBoxViewModel
            {
                StateRowID = item.StateRowID,
                StateName = item.StateName, 
                StateIsChecked=false,              
            }).ToList();

            return model;
        }

        public IEnumerable<StateExportViewModel> GetStatesForExport()
        {
            try
            {
                return db.MasterStates.Select(c => new StateExportViewModel { RowID = c.StateRowID, CountryName = c.MasterCountry.CountryName, StateName = c.StateName}).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<StateViewModel> GetStates()
        {
            try
            {
                return db.MasterStates.Select(item => new StateViewModel
                {
                    StateRowID = item.StateRowID,
                    StateName = item.StateName,
                    CountryRowID = item.MasterCountry.CountryRowID,
                    CountryName = item.MasterCountry.CountryName,
                    Status = item.Status
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveStates(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterStates.Single(b => b.StateRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("States could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
