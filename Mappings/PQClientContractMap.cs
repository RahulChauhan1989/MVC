using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientContractMap : EntityTypeConfiguration<PQClientContract>
    {
        public PQClientContractMap()
        {
            this.HasKey(a => a.ClientContractRowID);
            this.Property(a => a.ClientContractRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.DocumentType).HasMaxLength(100);
            this.Property(a => a.FileName).HasMaxLength(200);
            this.Property(a => a.FilePath).HasMaxLength(300);
            this.Property(a => a.DocumentUploadFrom).HasMaxLength(100);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.HasRequired(a => a.PQClientMaster).WithMany().HasForeignKey(a => a.ClientRowID).WillCascadeOnDelete(false);
        }
    }
}
