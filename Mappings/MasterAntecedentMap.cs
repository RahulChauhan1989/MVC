using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterAntecedentMap : EntityTypeConfiguration<MasterAntecedent>
    {
        public MasterAntecedentMap()
        {
            this.HasKey  (a => a.AntecedentRowId);
            this.Property(a => a.AntecedentRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.FieldName).HasMaxLength(100);
            this.Property(a => a.DisplayName).HasMaxLength(200);

            this.HasRequired(a => a.MasterAntecedentType).WithMany().HasForeignKey(a => a.AntecedentTypeRowId).WillCascadeOnDelete(false);
            this.HasRequired(a => a.MasterCheckFamily).WithMany().HasForeignKey(a => a.CheckFamilyRowID).WillCascadeOnDelete(false);
        }
    }
}
