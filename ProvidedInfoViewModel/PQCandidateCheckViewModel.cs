using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQCandidateCheckViewModel
    {
        public Int64 CandCheckRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public byte Status { get; set; }
    }

    public class AddPQCandidateCheckViewModel
    {
        public Int64 CandCheckRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public byte Status { get; set; }
    }

    public class PQCandidateCheckListPagedModel
    {
        public IEnumerable<PQCandidateCheckViewModel> PQCandidateChecks { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CandidateCheckMenuViewModel
    {
        public short CheckID { get; set; }
        public string CheckName{ get; set; }
    }

    public class ClientCheckPackageTAT
    {
        public byte TAT { get; set; }
        
        public byte InternalTAT { get; set; }
    }
}
