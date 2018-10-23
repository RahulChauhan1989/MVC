using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterClientAbbreviationMap : EntityTypeConfiguration<MasterClientAbbreviation>
    {
        public MasterClientAbbreviationMap()
        {
            this.HasKey(a => a.ClientAbbRowID);
            this.Property(a => a.ClientAbbRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.ClientName).HasMaxLength(150).IsRequired();
            this.Property(a => a.ClientAbbreviation).HasMaxLength(20).IsRequired();
        }
    }
}
