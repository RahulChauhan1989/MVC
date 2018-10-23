using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCategoryMap : EntityTypeConfiguration<MasterCategory>
    {
        public MasterCategoryMap()
        {
            this.HasKey(c => c.CategoryRowID);
            this.Property(c => c.CategoryRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
        }
    }
}
