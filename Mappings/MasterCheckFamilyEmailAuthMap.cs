using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCheckFamilyEmailAuthMap : EntityTypeConfiguration<MasterCheckFamilyEmailAuth>
    {
        public MasterCheckFamilyEmailAuthMap()
        {
            this.HasKey(e => e.CheckFamilyEmailAuthRowID);
            this.Property(e => e.CheckFamilyEmailAuthRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.Property(e => e.SMTPServer).HasMaxLength(100).IsRequired();
            this.Property(e => e.SMTPUserName).HasMaxLength(100).IsRequired();
            this.Property(e => e.SMTPPassword).HasMaxLength(100).IsRequired();

            this.HasRequired(e => e.MasterCheckFamily).WithMany().HasForeignKey(e => e.CheckFamilyRowID).WillCascadeOnDelete(false);
        }
    }
}
