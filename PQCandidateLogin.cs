using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQCandidateLogin
    {
        public PQCandidateLogin()
        {

            CandidateUserRowID = 0;
            ClientRowID = 0;
            TempPersonalRowID = 0;
            PersonalRowID = 0;
            CandidateName = string.Empty;
            CandidateEmail = string.Empty;
            CandidateEmailCC = string.Empty;
            UserID = string.Empty;          
            UPass = string.Empty;
            CreatedBy = string.Empty;
            UnBlockedBy = 0;        
            UserType = 0;          
            Status = 1;
             EmployeeID = string.Empty;          
            SentMailStatus = 0;
            Remarks = string.Empty;
            CantactNo = string.Empty;
            AlternatvieNo = string.Empty;            
            CreatedUserId = 0;
            Department= string.Empty;
            YTRApplicable = 0;
        }

        public int CandidateUserRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int TempPersonalRowID { get; set; }
        public virtual TempPQPersonal TempPQPersonal { get; set; }

        public int PersonalRowID { get; set; }

        public string    CandidateName           { get; set; }
        public string    CandidateEmail          { get; set; }
        public string    CandidateEmailCC        { get; set; }
        public string    UserID                  { get; set; }
        public string    UPass                   { get; set; }
        public string    CreatedBy               { get; set; }
        public DateTime? CreatedTime             { get; set; }
        public DateTime? ModifiedTime            { get; set; }
        public DateTime? BlockedDate             { get; set; }
        public short     UnBlockedBy             { get; set; }
        public DateTime? UnBlockedDate           { get; set; }
        public byte      UserType                   { get; set; }
        public byte      Status                  { get; set; }
        public string    EmployeeID             { get; set; }
        public byte      SentMailStatus          { get; set; }
        public DateTime? SentMailDate            { get; set; }
        public string    Remarks                 { get; set; }
        public string    CantactNo               { get; set; }
        public string    AlternatvieNo           { get; set; }
        public short     CreatedUserId           { get; set; }
        public string     Department         { get; set; }
        public byte      YTRApplicable           { get; set; }
    }
}
