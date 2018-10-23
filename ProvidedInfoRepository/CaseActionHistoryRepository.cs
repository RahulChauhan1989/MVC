using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ProvidedInfoViewModel;

namespace BAL.ProvidedInfoRepository
{
   public class CaseActionHistoryRepository : ICaseActionHistoryRepository
    {
        DataContext db;
        public CaseActionHistoryRepository()
        {
            db = new DataContext();
        }

        public void AddCaseActionHistory(AddCaseActionHistoryViewModel model)
        {
            try
            {
                if (model != null)
                {
                    CaseActionHistory entity = new CaseActionHistory();
                    entity.PersonalRowID = model.PersonalRowID;
                    entity.CaseStatus = model.CaseStatus;
                    entity.UpdatedBy = model.UpdatedBy;
                    entity.UpdatedByNameDesig = model.UpdatedByNameDesig;
                    entity.UpdatedDate = model.UpdatedDate;
                    entity.Remarks = model.Remarks;
                    entity.Status = model.Status;                
                    db.CaseActionHistories.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CaseActionHistoryListPagedModel GetCaseActionHistories(int PersonalRowID = 0)
        {
            try
            {
                IQueryable<CaseActionHistory> data = db.CaseActionHistories.Where(p => p.PersonalRowID == PersonalRowID);

                CaseActionHistoryListPagedModel model = new CaseActionHistoryListPagedModel();
                model.CaseActionHistories = data.Select(item => new CaseActionHistoryViewModel
                {
                    CaseAHRowID = item.CaseAHRowID,
                    PersonalRowID = item.PersonalRowID,
                    CaseStatus = item.CaseStatus,
                    UpdatedByNameDesig = item.UpdatedByNameDesig,
                    Remarks = item.Remarks,
                    UpdatedDate = item.UpdatedDate
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
    }
}
