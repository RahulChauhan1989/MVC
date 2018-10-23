using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientCandidateBulkUploadMap : EntityTypeConfiguration<PQClientCandidateBulkUpload>
    {
        public PQClientCandidateBulkUploadMap()
        {
            this.HasKey(c => c.CBulkUploadRowID);
            this.Property(c => c.CBulkUploadRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.ExcelFileName).HasMaxLength(300);
            this.Property(c => c.ImportBy).HasMaxLength(30);
            this.Property(c => c.Remarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
        }
    }
}
