using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICompanyRepository
    {
        bool IsCompanyExist(string CompanyName);
        bool IsCompanyExist(string CompanyName, short CmpId);

        void AddCompany(AddCompanyViewModel model);

        UpdateCompanyViewModel GetCompanyForUpdateById(short CompanyRowID);

        CompanyViewModel GetCompanyForDetailsById(short CompanyRowID);

        void UpdateCompany(UpdateCompanyViewModel model);

        void DeleteCompany(short CompanyRowID);

        int SaveChanges();
        void ActiveCompany(short id = 0, string checkeds = "");
        IEnumerable<CompanyViewModel> GetCompany();

        IEnumerable<CompanyExportViewModel> GetCompaniesForExport();

        CompanyListPagedModel GetCompanies(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
        CompanyMailAuthenticationViewModel GetMailAuthenticationById(short CompanyRowID);
        CompanyMailSignatureViewModel GetDefaultSignatureDetails(short CompanyRowID);
    }
}
