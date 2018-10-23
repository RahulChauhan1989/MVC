using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientCheck
    {
        public PQClientCheck()
        {
            ClientCheckRowID = 0;
            ClientRowID = 0;
            CheckFamilyRowID = 0;
            SubCheckRowID = 0;
            TAT = 0;
            InternalTAT = 0;
            BillingPerCheck = 0;
            CostPerCheck = 0;
            ReportSequence = 0;
            AntecedentSelected = 0;
            SelectedTemplate = 0;
            Status = 1;
            AddedDate = DateTime.Now;
        }

        public int ClientCheckRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }
        
        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short SubCheckRowID { get; set; }
        public virtual MasterSubCheckFamily MasterSubCheckFamily { get; set; }
                
        public byte TAT { get; set; }
        public byte InternalTAT { get; set; }
        public double BillingPerCheck { get; set; }
        public double CostPerCheck { get; set; }
        public byte ReportSequence { get; set; }
        public byte AntecedentSelected { get; set; }    //Yes 1 and No 0 (By Default 0)
        public byte SelectedTemplate { get; set; }      //Yes 1 and No 0 (By Default 0)
        public byte Status { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
