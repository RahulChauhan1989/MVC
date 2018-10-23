using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQClientBulkUploadMap : EntityTypeConfiguration<PQClientBulkUpload>
    {
        public PQClientBulkUploadMap()
        {
            this.HasKey  (c => c.ClientBulkUploadRowID);
            this.Property(c => c.ClientBulkUploadRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.ExcelFileName).HasMaxLength(300);
            this.Property(c => c.AttachDocName).HasMaxLength(300);
            this.Property(c => c.UploadedBy).HasMaxLength(100);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
        }
    }
}
