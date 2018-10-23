using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.TempViewModel
{
    public class TempPQCandidateCheckViewModel
    {
        public Int64 CandCheckRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public byte Status { get; set; }
    }

    public class AddTempPQCandidateCheckViewModel
    {
        public Int64 CandCheckRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public byte Status { get; set; }
    }

    public class TempPQCandidateCheckListPagedModel
    {
        public IEnumerable<TempPQCandidateCheckViewModel> TempPQCandidateChecks { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class TempCandidateCheckMenuViewModel
    {
        public short CheckID { get; set; }
        public string CheckName{ get; set; }
    }

    public class TempClientCheckPackageTAT
    {
        public byte TAT { get; set; }
        
        public byte InternalTAT { get; set; }
    }
}
