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
    public class PQLogTrasactionRepository : IPQLogTrasactionRepository
    {
        DataContext db;

        public PQLogTrasactionRepository()
        {
            db = new DataContext();
        }

        public void AddPQLogTrasaction(AddPQLogTrasactionViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQLogTrasaction entity = new PQLogTrasaction();
                    entity.TeamMemberRowID = model.TeamMemberRowID;
                    entity.UserType = model.UserType;
                    entity.PersonalRowID = model.PersonalRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.UniqueComponentID = model.UniqueComponentID;
                    entity.PageName = model.PageName;
                    entity.CaseStatus = model.CaseStatus;
                    entity.TransactionDate = model.TransactionDate;
                    entity.TransactionAction = model.TransactionAction;

                    db.PQLogTrasactions.Add(entity);
                }
                else
                {
                    throw new Exception("College could not be blank!");
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
    }
}
