using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class ClientCompletedContractRepository : IClientCompletedContractRepository
    {
        DataContext db;
        public ClientCompletedContractRepository()
        {
            db = new DataContext();
        }

        public ClientCompletedContractViewModel ClientComletedContract(short ClientRowId = 0)
        {
            ClientCompletedContractViewModel model = new ClientCompletedContractViewModel();

            model.UploadClientContracts = db.PQClientContracts.Where(c => c.ClientRowID == ClientRowId).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            model.ClientCheck = db.PQClientChecks.Where(c => c.ClientRowID == ClientRowId && c.AntecedentSelected == 1).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            model.ClientPackage = db.PQClientPackages.Where(c => c.ClientRowID == ClientRowId && c.AntecedentSelected == 1).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            model.clientDisposition = db.PQClientDispositions.Where(c => c.ClientRowID == ClientRowId).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            model.ClientSeveritie = db.PQClientSeverities.Where(c => c.ClientRowID == ClientRowId).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            model.ClientHoliday = db.PQClientHolidays.Where(c => c.ClientRowID == ClientRowId).FirstOrDefault() == null ? Convert.ToByte(0) : Convert.ToByte(1);

            var ClientInfo = db.PQClientMasters.Where(c => c.ClientRowID == ClientRowId).FirstOrDefault();
            if (ClientInfo != null && !string.IsNullOrEmpty(ClientInfo.SMTPServer) && !string.IsNullOrEmpty(ClientInfo.SMTPPort) && !string.IsNullOrEmpty(ClientInfo.SMTPUserName) && !string.IsNullOrEmpty(ClientInfo.SMTPPassword))
            {
                model.ClientMail = 1;
            }
            else
            {
                model.ClientMail = 0;
            }
            
            return model;
        }
    }
}
