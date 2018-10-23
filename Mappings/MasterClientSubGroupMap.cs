using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterClientSubGroupMap : EntityTypeConfiguration<MasterClientSubGroup>
    {
        public MasterClientSubGroupMap()
        {
            this.HasKey(s => s.ClientSubGroupID);
            this.Property(s => s.ClientSubGroupID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ClientSubGroupName).HasMaxLength(100).IsRequired();
            this.HasRequired(s => s.MasterClientAbbreviation).WithMany().HasForeignKey(s => s.ClientAbbRowID).WillCascadeOnDelete(false);
        }
    }
}
