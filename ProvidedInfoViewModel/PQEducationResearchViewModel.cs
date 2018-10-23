using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQEducationResearchViewModel
    {
        public int EduResearchRowID { get; set; }

        public int EducationRowId { get; set; }
        public string OtherInstitute { get; set; }

        public string ClientName { get; set; }
        public string Name { get; set; }
        public string SubCheckName { get; set; }
        public string CompanyRefNo { get; set; }

        public short AddedBy { get; set; }
        public string AddedNameDesig { get; set; }
        public DateTime? AddedOn { get; set; }

        public short UpdatedBy { get; set; }
        public string UpdatedNameDesig { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public byte Status { get; set; }
    }

    public class AddPQEducationResearchViewModel
    {
        public int EduResearchRowID { get; set; }

        public int EducationRowId { get; set; }
        public string OtherInstitute { get; set; }

        public short AddedBy { get; set; }
        public string AddedNameDesig { get; set; }
        public DateTime? AddedOn { get; set; }

        public short UpdatedBy { get; set; }
        public string UpdatedNameDesig { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public byte Status { get; set; }
    }

    public class UpdatePQEducationResearchViewModel
    {
        public int EduResearchRowID { get; set; }

        public short UpdatedBy { get; set; }
        public string UpdatedNameDesig { get; set; }
        public DateTime? UpdatedOn { get; set; }
        
    }
    public class PQEducationResearchListPagedModel
    {
        public IEnumerable<PQEducationResearchViewModel> PQEducationResearchs { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
