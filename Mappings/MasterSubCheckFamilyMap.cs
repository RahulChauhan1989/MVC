using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class MasterSubCheckFamilyMap : EntityTypeConfiguration<MasterSubCheckFamily>
    {
        public MasterSubCheckFamilyMap()
        {
            this.HasKey(b => b.SubCheckRowID);
            this.Property(b => b.SubCheckRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(b => b.SubCheckName).HasMaxLength(100).IsRequired();
            this.HasRequired(b => b.MasterCheckFamily).WithMany().HasForeignKey(b => b.CheckFamilyRowID).WillCascadeOnDelete(false);
        }
    }
}
