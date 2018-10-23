using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCompanyBranchMap : EntityTypeConfiguration<MasterCompanyBranch>
    {
        public MasterCompanyBranchMap()
        {
            this.HasKey(b => b.BORowID);
            this.Property(b => b.BORowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(b => b.BOName).HasMaxLength(100).IsRequired();
            this.Property(b => b.BOAddress).HasMaxLength(300);
            this.Property(b => b.BOConcernPersonName).HasMaxLength(100);
            this.Property(b => b.BOContactNumber).HasMaxLength(20);
            this.Property(b => b.BOEmailId).HasMaxLength(100);
            
            this.HasRequired(c => c.MasterCompany).WithMany().HasForeignKey(c => c.CompanyRowID).WillCascadeOnDelete(false);
        }
    }
}
