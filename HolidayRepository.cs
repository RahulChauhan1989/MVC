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
    public class HolidayRepository : IHolidayRepository
    {
        DataContext db;
        public HolidayRepository()
        {
            db = new DataContext();
        }

        public void AddHoliday(AddHolidayViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterHoliday entity = new MasterHoliday();
                    entity.HoliTitle = model.HoliTitle;
                    entity.HoliDate = model.HoliDate;
                    entity.HoliDay = model.HoliDay;
                    entity.HoliMonth = model.HoliMonth;
                    entity.HoliYear = model.HoliYear;
                    entity.Remarks = model.Remarks;
                    entity.AddInfo = model.AddInfo;
                    entity.IsDefault = Convert.ToByte(model.IsDefault);

                    db.MasterHolidays.Add(entity);
                }
                else
                {
                    throw new Exception("Holiday could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateHolidayViewModel GetHolidayForUpdateById(short HolidayRowID)
        {
            try
            {
                UpdateHolidayViewModel model = new UpdateHolidayViewModel();
                var entity = db.MasterHolidays.Find(HolidayRowID);

                if (entity != null)
                {
                    model.HoliRowID = entity.HoliRowID;
                    model.HoliTitle = entity.HoliTitle;
                    model.HoliDate = entity.HoliDate;
                    model.HoliDay = entity.HoliDay;
                    model.HoliMonth = entity.HoliMonth;
                    model.HoliYear = entity.HoliYear;
                    model.Remarks = entity.Remarks;
                    model.AddInfo = entity.AddInfo;
                    model.IsDefault = Convert.ToBoolean(entity.IsDefault);
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

        public IEnumerable<HolidayViewModel> GetHolidays(DateTime currDate, DateTime dDate)
        {
            try
            {
                currDate = DateTime.Now;
                dDate = DateTime.Now;
                return db.MasterHolidays.Where(h=>h.HoliDate >= currDate && h.HoliDate<= dDate)
                    .Select(item => new HolidayViewModel
                {
                    HoliRowID = item.HoliRowID,
                    HoliTitle = item.HoliTitle,
                    HoliDate = item.HoliDate,
                    HoliDay = item.HoliDay,
                    HoliMonth = item.HoliMonth,
                    HoliYear = item.HoliYear,
                    Remarks = item.Remarks,
                    AddInfo = item.AddInfo,
                    IsDefault = item.IsDefault,
                    Status = item.Status,
                }).ToList();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HolidayListPagedModel GetHolidays(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterHoliday> data = db.MasterHolidays;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(s => s.HoliTitle.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "holidate":
                        data = sortDir == "asc" ? data.OrderBy(s => s.HoliDate) : data.OrderByDescending(s => s.HoliDate);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(s => s.HoliDate) : data.OrderByDescending(s => s.HoliDate);
                        break;
                }

                HolidayListPagedModel model = new HolidayListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Holidays = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new HolidayViewModel
                {
                    HoliRowID = item.HoliRowID,
                    HoliTitle = item.HoliTitle,
                    HoliDate = item.HoliDate,
                    HoliDay = item.HoliDay,
                    HoliMonth = item.HoliMonth,
                    HoliYear = item.HoliYear,
                    Remarks = item.Remarks,
                    AddInfo = item.AddInfo,
                    IsDefault =item.IsDefault,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<HolidayExportViewModel> GetHolidayesForExport()
        {
            try
            {
                return db.MasterHolidays.Select(c => new HolidayExportViewModel
                {
                    RowID = c.HoliRowID,
                    HolidayTitle = c.HoliTitle,
                    HoliDate = c.HoliDate,
                    HoliDay = c.HoliDay,
                    Remarks=c.Remarks,
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsHolidayExist(string HolidayName,DateTime HoliDate)
        {
            try
            {
                var Holiday = db.MasterHolidays.Where(c => c.HoliTitle.Trim().ToLower() == HolidayName.Trim().ToLower() && c.HoliDate==HoliDate).FirstOrDefault();
                if (Holiday != null && Holiday.HoliTitle.Length > 0)
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

        public bool IsHolidayExist(string HolidayName, DateTime HoliDate, short HoliRowID = 0)
        {
            try
            {
                var Holiday = db.MasterHolidays.Where(c => c.HoliTitle.Trim().ToLower() == HolidayName.Trim().ToLower() && c.HoliRowID != HoliRowID
                || c.HoliDate == HoliDate && c.HoliRowID != HoliRowID).FirstOrDefault();
                if (Holiday != null && Holiday.HoliTitle.Length > 0)
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

        public void UpdateHoliday(UpdateHolidayViewModel model)
        {
            try
            {
                if (model != null && model.HoliRowID > 0)
                {
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).HoliTitle = model.HoliTitle;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).HoliDate = model.HoliDate;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).HoliDay = model.HoliDay;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).HoliMonth = model.HoliMonth;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).HoliYear = model.HoliYear;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).Remarks = model.Remarks;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).AddInfo = model.AddInfo;
                    db.MasterHolidays.Single(b => b.HoliRowID == model.HoliRowID).IsDefault = Convert.ToByte(model.IsDefault);

                }
                else
                {
                    throw new Exception("Holiday could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HolidayActiveInActive(short Id=0,string Status="")
        {
            try
            {
                if (Id > 0 && Status != null)
                {
                    db.MasterHolidays.Single(b => b.HoliRowID == Id).Status = Convert.ToByte(Status);
                }
                else
                {
                    throw new Exception("Holiday could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HolidayIsDefault(short Id = 0, string IsDefault = "")
        {
            try
            {
                if (Id > 0 && IsDefault != null)
                {
                    db.MasterHolidays.Single(b => b.HoliRowID == Id).IsDefault = Convert.ToByte(IsDefault);
                }
                else
                {
                    throw new Exception("Holiday could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
