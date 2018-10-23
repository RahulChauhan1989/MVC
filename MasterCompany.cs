using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCompany
    {
        public MasterCompany()
        {
            CompanyRowID = 0;
            CompanyName = string.Empty;
            CompanyAddress = string.Empty;
            CountryRowID = 0;
            StateRowID = 0;
            DistrictRowID = 0;
            LocationRowID = 0;
            GeneralEmail = string.Empty;
            PhoneNo = string.Empty;
            MobileNo = string.Empty;
            FaxNo = string.Empty;
            CompanyLogo = string.Empty;
            SpecialInstruction = string.Empty;
            SMTPServer = string.Empty;
            SMTPPort = string.Empty;
            SMTPUserName = string.Empty;
            SMTPPassword = string.Empty;
            EnableSsl = 0;
            InitiationDName = string.Empty;
            InitiationEmail = string.Empty;
            MISDName = string.Empty;
            MISEmail = string.Empty;
            InsuffDName = string.Empty;
            InsuffEmail = string.Empty;
            ReportDName = string.Empty;
            ReportEmail = string.Empty;
            BillingDName = string.Empty;
            BillingEmail = string.Empty;
            OtherDName = string.Empty;
            OtherEmail = string.Empty;
            Status = 1;
            Other1 = string.Empty;
            Other2 = string.Empty;
            Other3 = string.Empty;

        }
        public short CompanyRowID { get; set; }
        public string CompanyName { get; set; } 
        public string CompanyAddress { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }

        public int LocationRowID { get; set; }
        public virtual MasterLocation MasterLocation { get; set; }

        public string GeneralEmail { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string CompanyLogo { get; set; }
        public string SpecialInstruction { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public byte EnableSsl { get; set; }
        public string InitiationDName{ get; set; }
        public string InitiationEmail { get; set; }
        public string InsuffDName { get; set; }
        public string InsuffEmail { get; set; }
        public string ReportDName { get; set; }
        public string ReportEmail { get; set; }
        public string MISDName { get; set; }
        public string MISEmail { get; set; }
        public string BillingDName { get; set; }
        public string BillingEmail { get; set; }
        public string OtherDName{ get; set; }
        public string OtherEmail { get; set; }
        public byte Status { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
    }
}
