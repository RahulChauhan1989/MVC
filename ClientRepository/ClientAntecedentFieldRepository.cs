using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{


    public class ClientAntecedentsFieldRepository : IClientAntecedentFieldRepository
    {
        DataContext db;

        public ClientAntecedentsFieldRepository()
        {
            db = new DataContext();
        }

        public void AddPQClientAntecedentsField(AddClientFieldViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientField entity = new PQClientField();
                    entity.ClientFieldRowID = model.ClientFieldRowID;
                    entity.ClientRowID = model.ClientRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.AntecedentRowId = model.AntecedentRowId;
                    entity.CADisplayName = model.CADisplayName;
                    db.PQClientFields.Add(entity);
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

        public void AddPQClientAntecedentsDefaultSelected(AddClientFieldViewModel model)
        {
            try
            {
                if (model != null)
                {
                    List<PQClientField> entities = new List<PQClientField>();
                    PQClientField entity;

                    var antecedent = db.MasterAntecedents.Where(a => (a.CheckFamilyRowID == model.CheckFamilyRowID || a.CheckFamilyRowID == 39)
                    && a.IsSetDefault == 1 && a.Status == 1).ToList();

                    foreach (var item in antecedent)
                    {
                        if (!IsPQClientAntecedentsExist(model.ClientRowID, item.CheckFamilyRowID, model.SubCheckRowID, item.AntecedentRowId))
                        {
                            entity = new PQClientField();
                            entity.ClientRowID = model.ClientRowID;
                            entity.CheckFamilyRowID = item.CheckFamilyRowID;
                            entity.SubCheckRowID = model.SubCheckRowID;
                            entity.AntecedentRowId = item.AntecedentRowId;
                            entity.CADisplayName = item.DisplayName;
                            entities.Add(entity);
                        }
                    }
                    db.PQClientFields.AddRange(entities);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Client Id Mapped First!");
                }
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
                if (CheckMasterId == 40)    //For Special Check Only
                {
                    return db.MasterAntecedents.Where(a => (a.CheckFamilyRowID == CheckMasterId) && a.Status == 1)
                        .Select(a => new AntecedentViewModel
                        {
                            AntecedentRowId = a.AntecedentRowId,
                            FieldName = a.FieldName,
                            DisplayName = a.DisplayName,
                            AntecedentTypeName = a.MasterAntecedentType.AntecedentTypeName,
                            CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                            IsSetDefault = a.IsSetDefault,
                            BGVPublished = a.BGVPublished,
                            EmailAdded = a.EmailAdded,
                            ReportPublished = a.ReportPublished,
                            DisplayOrder = a.DisplayOrder,
                            Status = a.Status
                        }
                    ).ToList();
                }
                else
                {
                    return db.MasterAntecedents.Where(a => (a.CheckFamilyRowID == CheckMasterId || a.CheckFamilyRowID == 39) && a.Status == 1)
                        .Select(a => new AntecedentViewModel
                        {
                            AntecedentRowId = a.AntecedentRowId,
                            FieldName = a.FieldName,
                            DisplayName = a.DisplayName,
                            AntecedentTypeName = a.MasterAntecedentType.AntecedentTypeName,
                            CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                            IsSetDefault = a.IsSetDefault,
                            BGVPublished = a.BGVPublished,
                            EmailAdded = a.EmailAdded,
                            ReportPublished = a.ReportPublished,
                            DisplayOrder = a.DisplayOrder,
                            Status = a.Status
                        }
                    ).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AntecedentViewModel> GetClientAntecedents(short ClientRowId = 0, short CheckFamilyId = 0, short SubCheckRowId = 0)
        {
            try
            {
                var data = db.PQClientFields.Where(a => a.ClientRowID == ClientRowId && (a.CheckFamilyRowID == CheckFamilyId || a.CheckFamilyRowID == 39));
                return data.Where(a => a.SubCheckRowID == SubCheckRowId)
                    .Select(a => new AntecedentViewModel
                    {
                        AntecedentRowId = a.AntecedentRowId,
                        CheckFamilyName = a.MasterCheckFamily.CheckFamilyName,
                        Status = a.Status
                    }
                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsPQClientAntecedentsExist(short CId = 0, short ChkId = 0, short SChKId = 0, short AntId = 0)
        {
            try
            {
                var ClientAntecedents = db.PQClientFields.Where(c => c.ClientRowID == CId && c.CheckFamilyRowID == ChkId && c.SubCheckRowID == SChKId && c.AntecedentRowId == AntId).FirstOrDefault();
                if (ClientAntecedents != null && ClientAntecedents.ClientFieldRowID > 0)
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

        public void UpdatePQClientAntecedentsField(AddClientFieldViewModel model)
        {
            try
            {
                if (model != null && model.ClientRowID > 0)
                {
                    db.PQClientFields.Single(c => c.ClientRowID == model.ClientRowID && c.CheckFamilyRowID == model.CheckFamilyRowID
                    && c.SubCheckRowID == model.SubCheckRowID && c.AntecedentRowId == model.AntecedentRowId).CADisplayName = model.CADisplayName;
                }
                else
                {
                    throw new Exception("Invalid Client Details!");
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
