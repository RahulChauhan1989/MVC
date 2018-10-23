using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;
using ViewModels;
using System.Data.Entity.Validation;

namespace BAL.ClientRepository
{

    public class PQClientHolidayRepository : IPQClientHolidayRepository
    {
        DataContext db;
        public PQClientHolidayRepository()
        {
            db = new DataContext();
        }

        public void AddIPQClientHoliday(AddPQClientHolidayViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientHoliday entity = new PQClientHoliday();
                    entity.ClientRowID = model.ClientRowID;
                    entity.HoliRowID = model.HoliRowID;
                     db.PQClientHolidays.Add(entity);
                }
                else
                {
                    throw new Exception("Client Holiday could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePQClientHoliday(short ClientHoliRowID)
        {
            try
            {
                var entity = db.PQClientHolidays.Find(ClientHoliRowID);

                if (entity != null)
                {
                    db.PQClientHolidays.Remove(entity);
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

        public IEnumerable<PQClientHolidayViewModel> GetClientHolidays(short CId = 0)
        {
            try
            {
                return db.PQClientHolidays.Where(a => a.ClientRowID == CId)
                    .Select(a => new PQClientHolidayViewModel
                    {
                        ClientHoliRowID = a.ClientHoliRowID,
                        ClientRowID = a.ClientRowID,
                        HoliRowID = a.HoliRowID,
                        HolidayDate = a.MasterHoliday.HoliDate,
                        Status = a.Status
                    }
                ).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<HolidayViewModel> GetHolidayList()
        {
            try
            {
                return db.MasterHolidays.Where(h=>h.Status==1).Select(h => new HolidayViewModel
                {
                    HoliTitle = h.HoliTitle,
                    HoliDate = h.HoliDate,
                    HoliRowID = h.HoliRowID,
                    Remarks=h.Remarks,
                    IsDefault =h.IsDefault
                }).ToList().OrderBy(h=>h.HoliDate);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
       
        public PQClientHolidayListPagedModel GetPQClientHoliday(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short CId=0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientHoliday> data = db.PQClientHolidays.Where(h=>h.ClientRowID==CId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(s => s.PQClientMaster.ClientRowID.ToString().Contains(Search) || s.MasterHoliday.HoliRowID.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "holiday":
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterHoliday.HoliTitle) : data.OrderByDescending(s => s.MasterHoliday.HoliTitle);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(s => s.MasterHoliday.HoliDate) : data.OrderByDescending(s => s.MasterHoliday.HoliDate);
                        break;
                }

                PQClientHolidayListPagedModel model = new PQClientHolidayListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.PQClientHolidays = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQClientHolidayViewModel
                {
                    ClientHoliRowID=item.ClientHoliRowID,
                    ClientRowID =item.ClientRowID,   
                    HoliName=item.MasterHoliday.HoliTitle,
                    Remarks=item.MasterHoliday.Remarks,
                    HolidayDate = item.MasterHoliday.HoliDate, 
                    Status = item.Status
                }).ToList();

                return model;

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public UpdatePQClientHolidayViewModel GetPQClientHolidayForUpdateById(short ClientHoliRowID)
        {
            try
            {
                UpdatePQClientHolidayViewModel model = new UpdatePQClientHolidayViewModel();
                var entity = db.PQClientHolidays.Find(ClientHoliRowID);

                if (entity != null)
                {
                    model.ClientHoliRowID = entity.ClientHoliRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.HoliRowID = entity.HoliRowID;
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

        public bool IsClientHolidayExist(short ClientRowID, short HoliRowID)
        {
            try
            {
                var branch = db.PQClientHolidays.Where(b => b.ClientRowID == ClientRowID &&  b.HoliRowID == HoliRowID ).FirstOrDefault();
                if (branch != null )
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

        public void UpdatePQClientHoliday(UpdatePQClientHolidayViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
