using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class InboxAddressMap : EntityTypeConfiguration<InboxAddress>
    {
        public InboxAddressMap()
        {
            this.HasKey(i => i.InboxAddressRowID);
            this.Property(i => i.InboxAddressRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(i => i.To).HasMaxLength(500);
            this.Property(i => i.CC).HasMaxLength(500);
            this.Property(i => i.From).HasMaxLength(200);
            this.Property(i => i.Subject).HasMaxLength(500);
            this.Property(i => i.Date).HasMaxLength(200);
            this.Property(i => i.MessageID).HasMaxLength(200);
            this.Property(i => i.Body).HasMaxLength(8000);
            this.Property(i => i.Body1).HasMaxLength(8000);
            this.Property(i => i.Body2).HasMaxLength(8000);
            this.Property(i => i.Body3).HasMaxLength(8000);
            this.Property(i => i.Attachments).HasMaxLength(5000);
            this.Property(i => i.MailSaveAsPDF).HasMaxLength(1000);
            this.Property(i => i.SecuritasRefNo).HasMaxLength(50);
            this.Property(i => i.AllocatedStatus).HasMaxLength(20);
            this.Property(i => i.Remarks).HasMaxLength(2000);
            this.Property(i => i.Header).HasMaxLength(8000);
            this.Property(i => i.Header1).HasMaxLength(8000);
            this.Property(i => i.Header2).HasMaxLength(8000);
            this.Property(i => i.Header3).HasMaxLength(8000);
            this.Property(i => i.OtherDetails).HasMaxLength(200);
            this.Property(i => i.OtherDetails1).HasMaxLength(200);
            this.Property(i => i.OtherDetails2).HasMaxLength(200);
        }
    }
}
