using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQSpecialCheckVerMap : EntityTypeConfiguration<PQSpecialCheckVer>
    {
        public PQSpecialCheckVerMap()
        {
            this.HasKey(t => t.SpecialCheckVerRowID);
            this.Property(t => t.SpecialCheckVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.SC_Cand_Name).HasMaxLength(100);
            this.Property(c => c.SC_Father_Name).HasMaxLength(100);
            this.Property(c => c.SC_Mode_Verify).HasMaxLength(50);
            this.Property(c => c.SC_Mode_VerOther).HasMaxLength(100);
            this.Property(c => c.SC_AnyOtherComments).HasMaxLength(500);

            this.Property(c => c.SC_Others1).HasMaxLength(200);
            this.Property(c => c.SC_Others2).HasMaxLength(200);
            this.Property(c => c.SC_Others3).HasMaxLength(200);
            this.Property(c => c.SC_Others4).HasMaxLength(200);
            this.Property(c => c.SC_Others5).HasMaxLength(200);

            this.Property(t => t.TypeRevert).HasMaxLength(50);
            this.Property(t => t.CheckStatus).HasMaxLength(50);
            this.Property(t => t.Severity).HasMaxLength(50);
            this.Property(t => t.ColorName).HasMaxLength(50);
            this.Property(t => t.ReportComments).HasMaxLength(3000);

            this.Property(t => t.VerifierDesignation).HasMaxLength(100);
            this.Property(t => t.VerifierContactNo).HasMaxLength(20);
            this.Property(t => t.VerifierMobileNo).HasMaxLength(20);
            this.Property(t => t.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQSpecialCheck).WithMany().HasForeignKey(c => c.SpecialCheckRowId).WillCascadeOnDelete(false);
        }
    }
}
