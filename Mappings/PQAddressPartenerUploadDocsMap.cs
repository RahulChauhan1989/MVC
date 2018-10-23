using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQAddressPartenerUploadDocsMap:EntityTypeConfiguration<PQAddressPartenerUploadDocs>
    {
        public PQAddressPartenerUploadDocsMap()
        {
            this.HasKey(v => v.PartenerUploadRowID);
            this.Property(v => v.PartenerUploadRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(v => v.DocumentUploadFrom).HasMaxLength(200);
            this.Property(v => v.DocumentType).HasMaxLength(50);
            this.Property(v => v.FileName).HasMaxLength(100);
            this.Property(v => v.FilePath).HasMaxLength(300);

            this.HasRequired(v => v.PQAddressVarPartener).WithMany().HasForeignKey(v => v.PQAddressVarPtrRowId).WillCascadeOnDelete(false);

        }
    }
}
