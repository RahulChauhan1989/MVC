using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientFieldMap : EntityTypeConfiguration<PQClientField>
    {
        public PQClientFieldMap()
        {
            this.HasKey  (f => f.ClientFieldRowID);
            this.Property(f => f.ClientFieldRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(f => f.CADisplayName).HasMaxLength(200);

            this.HasRequired(f => f.PQClientMaster).WithMany().HasForeignKey(f => f.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(f => f.MasterCheckFamily).WithMany().HasForeignKey(f => f.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(f => f.MasterSubCheckFamily).WithMany().HasForeignKey(f => f.SubCheckRowID).WillCascadeOnDelete(false);
            this.HasRequired(f => f.MasterAntecedent).WithMany().HasForeignKey(f => f.AntecedentRowId).WillCascadeOnDelete(false);
        }
    }
}
