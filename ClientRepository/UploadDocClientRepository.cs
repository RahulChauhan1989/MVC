using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.TempViewModel;

namespace BAL.ClientRepository
{
    public class UploadDocClientRepository: IUploadDocClientRepository
    {
        DataContext db;
        public UploadDocClientRepository()
        {
            db = new DataContext();
        }

        public TempPQVerifiedUploadDocsInfoListPagedModel GetCandidateUploadedDocList(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short SubCheckRowID = 0, int PersonalRowID = 0, int ClientUserRowID =0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IEnumerable<TempPQVerifiedUploadDocsViewModel> data = db.TempPQVerifiedUploadDocs.Include("PQPersonal").Where(p => p.PersonalRowID == PersonalRowID).Select(item => new TempPQVerifiedUploadDocsViewModel
                {
                    VerifiedUploadRowID = item.VerifiedUploadRowID,
                    PersonalRowID = item.PersonalRowID,
                    SubCheckRowID = item.SubCheckRowID,
                    SubCheckName = item.MasterSubCheckFamily.SubCheckName,
                    DocumentUploadFrom = item.DocumentUploadFrom,
                    DocumentType = item.DocumentType,
                    FileName = item.FileName,
                    Remarks = item.Remarks,
                    UploadDate = item.UploadDate,
                    Status = item.Status
                }).ToList().OrderBy(a => a.SubCheckRowID);
                
                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.DocumentType.ToString().Contains(Search));
                }

                if (SubCheckRowID > 0)
                {
                    data = data.Where(b => b.SubCheckRowID == SubCheckRowID);
                }

                switch (sort)
                {
                    case "subcname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.SubCheckName) : data.OrderByDescending(d => d.SubCheckName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderByDescending(d => d.VerifiedUploadRowID) : data.OrderBy(d => d.VerifiedUploadRowID);
                        break;
                }

                TempPQVerifiedUploadDocsInfoListPagedModel model = new TempPQVerifiedUploadDocsInfoListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientUploadDocInfo = data.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
               
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
