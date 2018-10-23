using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQNationalIdentityStatusMap : EntityTypeConfiguration<PQNationalIdentityStatus>
    {
        public PQNationalIdentityStatusMap()
        {
            this.HasKey(a => a.NationalIdentityStatusRowID);
            this.Property(a => a.NationalIdentityStatusRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(a => a.DETMCheckStatus).HasMaxLength(20);
            this.Property(a => a.DETMQCCheckStatus).HasMaxLength(20);
            this.Property(a => a.MgrCheckStatus).HasMaxLength(20);
            this.Property(a => a.TLCheckStatus).HasMaxLength(20);
            this.Property(a => a.TMCheckStatus).HasMaxLength(20);
            this.Property(a => a.TMQCCheckStatus).HasMaxLength(20);
            this.Property(a => a.PVMgrCheckStatus).HasMaxLength(20);
            this.Property(a => a.PVTLCheckStatus).HasMaxLength(20);
            this.Property(a => a.PVTMCheckStatus).HasMaxLength(20);
            this.Property(a => a.PVTMQCCheckStatus).HasMaxLength(20);
            this.Property(a => a.PTRMgrCheckStatus).HasMaxLength(20);
            this.Property(a => a.PTRTLCheckStatus).HasMaxLength(20);
            this.Property(a => a.PTRTMCheckStatus).HasMaxLength(20);
            this.Property(a => a.InfSuffRaiseRemarks).HasMaxLength(200);
            this.Property(a => a.InfSuffClearComments).HasMaxLength(200);
            this.Property(a => a.ClientInfSuffClearComments).HasMaxLength(200);
            this.Property(a => a.StoppedCheckRemarks).HasMaxLength(200);
            this.Property(a => a.StoppedCheckClearComments).HasMaxLength(200);
            this.Property(a => a.RWCheckStatus).HasMaxLength(20);
            this.Property(a => a.RWQCMgrCheckStatus).HasMaxLength(20);
            this.Property(a => a.RWQCTLCheckStatus).HasMaxLength(20);
            this.Property(a => a.RWQCTMCheckStatus).HasMaxLength(20);
            this.Property(a => a.ReportSendStatus).HasMaxLength(20);
            this.Property(a => a.OTherCheckStatus).HasMaxLength(20);
            this.Property(a => a.OTher1CheckStatus).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.HasRequired(a => a.PQNationalIdentity).WithMany().HasForeignKey(a => a.NationalIdentityRowID).WillCascadeOnDelete(false);
        }
    }
}
