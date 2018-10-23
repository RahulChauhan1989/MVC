using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterDesignationMap : EntityTypeConfiguration<MasterDesignation>
    {
        public MasterDesignationMap()
        {
            this.HasKey(d => d.DesignationRowID);
            this.Property(d => d.DesignationRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            this.Property(d => d.DesignationName).HasMaxLength(100).IsRequired(); 
                       
            this.HasRequired(d => d.MasterDepartment).WithMany().HasForeignKey(d => d.DepartmentRowID).WillCascadeOnDelete(false);
        }
    }
}
