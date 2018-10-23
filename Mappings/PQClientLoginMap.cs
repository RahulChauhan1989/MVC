using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientLoginMap : EntityTypeConfiguration<PQClientLogin>
    {
        public PQClientLoginMap()
        {
            this.HasKey(d => d.ClientUserRowID);
            this.Property(d => d.ClientUserRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.ClientBranch).HasMaxLength(100);
            this.Property(d => d.UserID).HasMaxLength(100).IsRequired();
            this.Property(d => d.UPass).HasMaxLength(100).IsRequired();
            this.Property(d => d.CreatedBy).HasMaxLength(100);
            this.Property(d => d.UType).HasMaxLength(100);
            this.Property(d => d.Remarks).HasMaxLength(300);
          
            this.HasRequired(d => d.PQClientMaster).WithMany().HasForeignKey(d => d.ClientRowID).WillCascadeOnDelete(false);
            
        }
    }
}
