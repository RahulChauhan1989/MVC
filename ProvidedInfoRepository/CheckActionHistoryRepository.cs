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
    public class CheckActionHistoryRepository : ICheckActionHistoryRepository
    {
        DataContext db;
        public CheckActionHistoryRepository()
        {
            db = new DataContext();
        }

        public void AddCheckActionHistory(AddCheckActionHistoryViewModel model)
        {
            try
            {
                if (model != null)
                {
                    CheckActionHistory entity = new CheckActionHistory();
                    entity.PersonalRowID = model.PersonalRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.CheckStatus = model.CheckStatus;
                    entity.Remarks = model.Remarks;
                    entity.UpdatedBy = model.UpdatedBy;
                    entity.UpdatedByNameDesig = model.UpdatedByNameDesig;
                    entity.UpdatedDate = model.UpdatedDate;
                    entity.Status = model.Status;
                    db.CheckActionHistories.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CheckActionHistoryViewModel> GetCheckActionHistories(int PersonalRowID = 0, short SubCheckRowID = 0)
        {
            try
            {
                return db.CheckActionHistories.Where(p => p.PersonalRowID == PersonalRowID && p.SubCheckRowID == SubCheckRowID)
                     .Select(item => new CheckActionHistoryViewModel
                     {
                         CheckAHRowID = item.CheckAHRowID,
                         PersonalRowID = item.PersonalRowID,
                         SubCheckRowID = item.SubCheckRowID,
                         SubCheckName = item.MasterSubCheckFamily.SubCheckName,
                         CheckStatus = item.CheckStatus,
                         UpdatedByNameDesig = item.UpdatedByNameDesig,
                         Remarks = item.Remarks,
                         UpdatedDate = item.UpdatedDate
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
    }
}
