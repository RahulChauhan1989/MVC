using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InboxAddress
    {
        public InboxAddress()
        {
            InboxAddressRowID = 0;
            MessageNum = 0;
            To = string.Empty;
            CC = string.Empty;
            From = string.Empty;
            Subject = string.Empty;
            Date = string.Empty;
            MessageID = string.Empty;
            Body = string.Empty;
            Body1 = string.Empty;
            Body2 = string.Empty;
            Body3 = string.Empty;
            Attachments = string.Empty;
            MailSaveAsPDF = string.Empty;
            IsNew = 0;
            SecuritasRefNo = string.Empty;
            AllocatedStatus = string.Empty;
            AllocatedToVerifier = 0;
            Status = 1;
            Remarks = string.Empty;
            MailReadBy = 0;
            Header = string.Empty;
            Header1 = string.Empty;
            Header2 = string.Empty;
            Header3 = string.Empty;
            OtherDetails = string.Empty;
            OtherDetails1 = string.Empty;
            OtherDetails2 = string.Empty;
        }

        public int InboxAddressRowID { get; set; }
        public int MessageNum { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string MessageID { get; set; }
        public string Body { get; set; }
        public string Body1 { get; set; }
        public string Body2 { get; set; }
        public string Body3 { get; set; }
        public string Attachments { get; set; }
        public string MailSaveAsPDF { get; set; }
        public byte IsNew { get; set; }
        public string SecuritasRefNo { get; set; }
        public string AllocatedStatus { get; set; }
        public short AllocatedToVerifier { get; set; }
        public DateTime? AllocatedToVerifierDate { get; set; }
        public byte Status { get; set; }
        public DateTime? MailImportDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? MailReadDate { get; set; }
        public byte MailReadBy { get; set; }
        public string Header { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string OtherDetails { get; set; }
        public string OtherDetails1 { get; set; }
        public string OtherDetails2 { get; set; }
    }
}
