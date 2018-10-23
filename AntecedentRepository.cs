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
    public class AntecedentRepository : IAntecedentRepository
    {
        DataContext db;
        public AntecedentRepository()
        {
            db = new DataContext();
        }

        public UpdateAntecedentViewModel GetAntecedentForUpdateById(short AntecedentRowID)
        {
            try
            {
                UpdateAntecedentViewModel model = new UpdateAntecedentViewModel();
                var entity = db.MasterAntecedents.Find(AntecedentRowID);
                if (entity != null)
                {
                    model.AntecedentRowId = entity.AntecedentRowId;
                    model.FieldName = entity.FieldName;
                    model.DisplayName = entity.DisplayName;
                    model.AntecedentTypeRowId = entity.AntecedentTypeRowId;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.BGVPublished = entity.BGVPublished;
                    model.ReportPublished = entity.ReportPublished;
                    model.EmailAdded = entity.EmailAdded;
                    model.Status = entity.Status;
                    model.DisplayOrder = entity.DisplayOrder;
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

        public IEnumerable<AntecedentViewModel> GetAntecedents()
        {
            try
            {
                return db.MasterAntecedents.Select(a => new AntecedentViewModel
                {
                    AntecedentRowId = a.AntecedentRowId,
                    FieldName = a.FieldName,
                    DisplayName = a.DisplayName,
                    //AntecedentTypeName = a.AntecedentType.AntecedentTypeName,
                    CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                    BGVPublished = a.BGVPublished,
                    EmailAdded = a.EmailAdded,
                    ReportPublished = a.ReportPublished,
                    DisplayOrder = a.DisplayOrder,
                    Status = a.Status
                }
                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AntecedentExportViewModel> GetAntecedentesForExport()
        {
            try
            {
                return db.MasterAntecedents.Select(a => new AntecedentExportViewModel
                {
                    AntecedentRowId = a.AntecedentRowId,
                    FieldName = a.FieldName,
                    DisplayName = a.DisplayName,
                    //AntecedentTypeName = a.AntecedentType.AntecedentTypeName,
                    CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                    BGVPublished = a.BGVPublished,
                    EmailAdded = a.EmailAdded,
                    ReportPublished = a.ReportPublished,

                }
                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AntecedentViewModel> GetAntecedents(short CheckMasterId)
        {
            try
            {
                return db.MasterAntecedents.Where(a => a.CheckFamilyRowID == CheckMasterId)
                    .Select(a => new AntecedentViewModel
                    {
                        AntecedentRowId = a.AntecedentRowId,
                        FieldName = a.FieldName,
                        DisplayName = a.DisplayName,
                        AntecedentTypeName = a.MasterAntecedentType.AntecedentTypeName,
                        CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                        BGVPublished = a.BGVPublished,
                        EmailAdded = a.EmailAdded,
                        ReportPublished = a.ReportPublished,
                        DisplayOrder = a.DisplayOrder,
                        Status = a.Status
                    }
                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AntecedentViewModel> GetAntecedentAutoComplete(string Antecedent, short CheckFamilyRowID)
        {
            var Antecedents = db.MasterAntecedents.Select(d => new AntecedentViewModel
            {
                CheckFamilyRowID = d.MasterCheckFamily.CheckFamilyRowID,
                DisplayName = d.DisplayName
            }).Where(c => c.DisplayName.StartsWith(Antecedent) && c.CheckFamilyRowID == CheckFamilyRowID)
                .ToList();
            return Antecedents;
        }

        public AntecedentListPageModel GetAntecedents(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CheckFamilyRowID = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterAntecedent> data = db.MasterAntecedents;
                if (!string.IsNullOrEmpty(Search) || CheckFamilyRowID > 0)
                {
                    if (CheckFamilyRowID > 0)
                    {
                        data = data.Where(d => d.CheckFamilyRowID == CheckFamilyRowID);
                    }
                    if (!string.IsNullOrEmpty(Search))
                    {
                        data = data.Where(d => d.DisplayName.Contains(Search)); 
                    }
                }
                //if (!string.IsNullOrEmpty(Search))
                //{
                //    data = data.Where(b => b.FieldName.ToString().Contains(Search));
                //}

                switch (sort)
                {
                    case "checkfamilyname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterCheckFamily.CheckFamilyName) : data.OrderByDescending(d => d.MasterCheckFamily.CheckFamilyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.AntecedentRowId) : data.OrderByDescending(d => d.AntecedentRowId);
                        break;
                }

                AntecedentListPageModel model = new AntecedentListPageModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Antecedents = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new AntecedentViewModel
                {
                    AntecedentRowId = item.AntecedentRowId,
                    FieldName = item.FieldName,
                    DisplayName = item.DisplayName,
                    AntecedentTypeName = item.MasterAntecedentType.AntecedentTypeName,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    BGVPublished = item.BGVPublished,
                    ReportPublished = item.ReportPublished,
                    EmailAdded = item.EmailAdded,
                    DisplayOrder = item.DisplayOrder,
                    IsSetDefault=item.IsSetDefault,
                    Status = item.Status
                }).ToList();

                foreach (var item in model.Antecedents)
                {
                    if (item.BGVPublished == 1)
                        item.BGVPublish = "Yes";
                    else
                        item.BGVPublish = "No";

                    if (item.ReportPublished == 1)
                        item.ReportPublish = "Yes";
                    else
                        item.ReportPublish = "No";

                    if (item.EmailAdded == 1)
                        item.EmailAdd = "Yes";
                    else
                        item.EmailAdd = "No";
                }

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

        public void UpdateAntecedent(UpdateAntecedentViewModel model)
        {
            try
            {
                if (model != null && model.AntecedentRowId > 0)
                {
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).FieldName = model.FieldName;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).DisplayName = model.DisplayName;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).AntecedentTypeRowId = model.AntecedentTypeRowId;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).CheckFamilyRowID = model.CheckFamilyRowID;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).BGVPublished = model.BGVPublished;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).ReportPublished = model.ReportPublished;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).EmailAdded = model.EmailAdded;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).Status = model.Status;
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == model.AntecedentRowId).DisplayOrder = Convert.ToByte(model.DisplayOrder);
                }
                else
                {
                    throw new Exception("Antecedent could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActiveAntecedent(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Antecedent could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetDefaultAntecedent(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterAntecedents.Single(b => b.AntecedentRowId == id).IsSetDefault = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Antecedent could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
