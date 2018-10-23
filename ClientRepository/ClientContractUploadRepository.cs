using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class ClientContractUploadRepository : IClientContractUploadRepository
    {
        DataContext db;

        public ClientContractUploadRepository()
        {
            db = new DataContext();
        }

        public void AddFileUpload(AddCContractAgreementViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientContract entity = new PQClientContract();
                    entity.ClientRowID = model.ClientRowID;
                    entity.DocumentType = model.DocumentType;
                    entity.FileName = model.FileName;
                    entity.UploadDate = model.Uploaddate;
                    entity.Remarks = model.Remarks;
                    entity.DocumentUploadFrom = model.DocumentUploadFrom;
                    db.PQClientContracts.Add(entity);
                }
                else
                {
                    throw new Exception("File Upload could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteFileUpload(short AgreementId)
        {
            try
            {
                var entity = db.PQClientContracts.Find(AgreementId);
                if (entity != null)
                {
                    db.PQClientContracts.Remove(entity);
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

        public AddCContractAgreementViewModel GetCContractAgreementFileNameById(short CCARowID)
        {
            try
            {
                AddCContractAgreementViewModel model = new AddCContractAgreementViewModel();
                var entity = db.PQClientContracts.Find(CCARowID);
                if (entity != null)
                {
                    //model.AgreementRowID = entity.AgreementRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.FileName = entity.FileName;
                    //model.DocumentType = entity.DocumentType;
                    //model.DocumentUploadFrom = entity.DocumentUploadFrom;
                    //model.Remarks = entity.Remarks;
                    //model.Uploaddate = entity.Uploaddate;
                    //model.Status = entity.Status;
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

        public CContractAgreementListPageModel GetFileUpload(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientContract> data = db.PQClientContracts.Where(c => c.ClientRowID == CId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(c => c.FileName.ToString().Contains(Search) || c.DocumentType.ToString().Contains(Search) || c.Remarks.ToString().Contains(Search) || c.UploadDate.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "DocumentType":
                        data = sortDir == "asc" ? data.OrderBy(c => c.DocumentType) : data.OrderByDescending(d => d.DocumentType);
                        break;
                    case "DocumentUploadFrom":
                        data = sortDir == "asc" ? data.OrderBy(c => c.DocumentUploadFrom) : data.OrderByDescending(d => d.DocumentType);
                        break;
                    case "Uploaddate":
                        data = sortDir == "asc" ? data.OrderBy(c => c.UploadDate) : data.OrderByDescending(d => d.UploadDate);
                        break;
                    case "Remarks":
                        data = sortDir == "asc" ? data.OrderBy(c => c.Remarks) : data.OrderByDescending(d => d.Remarks);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.DocumentType) : data.OrderByDescending(d => d.DocumentType);
                        break;
                }

                CContractAgreementListPageModel model = new CContractAgreementListPageModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.CContractAgreements = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CContractAgreementViewModel
                {

                    ClientRowID = item.ClientRowID,
                    ClientContractRowID = item.ClientContractRowID,
                    FileName = item.FileName,
                    DocumentType = item.DocumentType,
                    DocumentUploadFrom = item.DocumentUploadFrom,
                    Remarks = item.Remarks,
                    Uploaddate = item.UploadDate,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CContractAgreementViewModel> GetFileUploads()
        {

            try
            {
                return db.PQClientContracts.Select(c => new CContractAgreementViewModel { ClientRowID = c.ClientRowID, DocumentType = c.DocumentType, DocumentUploadFrom = c.DocumentUploadFrom, FileName = c.FileName, Remarks = c.Remarks, Uploaddate = c.UploadDate, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsFileUploadExist(string FileUploadName, short ClientRowId)
        {
            try
            {
                var FileUplod = db.PQClientContracts.Where(c => c.FileName.Trim().ToLower() == FileUploadName.Trim().ToLower() && c.ClientRowID == ClientRowId).FirstOrDefault();
                if (FileUplod != null && FileUplod.FileName.Length > 0)
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

        public void UpdateSLAUpload(short ClientRowID = 0, byte SLAUpload = 0)
        {
            try
            {
                db.PQClientMasters.Single(p => p.ClientRowID == ClientRowID).SLAUploaded = SLAUpload;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveContractUpload(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.PQClientContracts.Single(b => b.ClientContractRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Client Contract Upload could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExportCContractAgreementViewModel> GetClientContractForExport(short CId = 0)
        {
            try
            {
                return db.PQClientContracts.Where(a => a.ClientRowID == CId).Select(c => new ExportCContractAgreementViewModel { ClientContractRowID = c.ClientContractRowID, DocumentType = c.DocumentType, DocumentUploadFrom = c.DocumentUploadFrom, FileName = c.FileName, Remarks = c.Remarks, Uploaddate = c.UploadDate }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
