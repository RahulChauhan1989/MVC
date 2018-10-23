using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICountryRepository
    {
        bool IsCountryExist(string CountryCode, string CountryName);

        bool IsCountryExist(string CountryName, string CountryCode, short CountryID);

        void AddCountry(AddCountryViewModel model);

        IEnumerable<CountryViewModel> GetCountry();

        IEnumerable<CountryExportViewModel> GetCountriesForExport();

        UpdateCountryViewModel GetCountryForUpdateById(short CountryID);

        void UpdateCountry(UpdateCountryViewModel model);

        void DeleteCountry(short CoRowID);

        void ActiveCountry(short id = 0, string checkeds = "");

        int SaveChanges();

        CountryListPagedModel GetCountries(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
