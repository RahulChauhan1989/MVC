using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterDepartmentMap : EntityTypeConfiguration<MasterDepartment>
    {
        public MasterDepartmentMap()
        {
            this.HasKey(d => d.DepartmentRowID);
            this.Property(d => d.DepartmentRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.DepartmentName).HasMaxLength(100).IsRequired();
        }
    }
}
