using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterAntecedentTypeMap : EntityTypeConfiguration<MasterAntecedentType>
    {
        public MasterAntecedentTypeMap()
        {
            this.HasKey(a => a.AntecedentTypeRowId);
            this.Property(a => a.AntecedentTypeRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.AntecedentTypeName).HasMaxLength(50).IsRequired();
        }
    }
}
