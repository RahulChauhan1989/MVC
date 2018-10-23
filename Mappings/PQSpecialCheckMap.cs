using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQSpecialCheckMap : EntityTypeConfiguration<PQSpecialCheck>
    {
        public PQSpecialCheckMap()
        {
            this.HasKey(c => c.SpecialCheckRowId);
            this.Property(c => c.SpecialCheckRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.UniqueComponentID).HasMaxLength(20);

            this.Property(c => c.SC_Cand_Name).HasMaxLength(100).IsRequired();
            this.Property(c => c.SC_Father_Name).HasMaxLength(100);
            this.Property(c => c.SC_SecuritasID).HasMaxLength(50);

            this.Property(c => c.SC_Others1).HasMaxLength(200);
            this.Property(c => c.SC_Others2).HasMaxLength(200);
            this.Property(c => c.SC_Others3).HasMaxLength(200);
            this.Property(c => c.SC_Others4).HasMaxLength(200);
            this.Property(c => c.SC_Others5).HasMaxLength(200);

            this.Property(c => c.CheckStatus).HasMaxLength(20);
            this.Property(c => c.ReWorkCheckStatus).HasMaxLength(20);
            this.Property(c => c.Remarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }
    }
}
