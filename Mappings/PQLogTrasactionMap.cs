using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class PQLogTrasactionMap : EntityTypeConfiguration<PQLogTrasaction>
    {
        public PQLogTrasactionMap()
        {
            this.HasKey(l => l.TransactionRowID);
            this.Property(l => l.TransactionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(l => l.UserType).HasMaxLength(50);
            this.Property(l => l.UniqueComponentID).HasMaxLength(50);
            this.Property(l => l.PageName).HasMaxLength(50);
            this.Property(l => l.CaseStatus).HasMaxLength(50);
            this.Property(l => l.TransactionAction).HasMaxLength(50);
        }
    }
}
