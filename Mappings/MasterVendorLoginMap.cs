using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterVendorLoginMap : EntityTypeConfiguration<MasterVendorLogin>
    {
        public MasterVendorLoginMap()
        {
            this.HasKey(v => v.VendorLoginRowID);
            this.Property(v => v.VendorLoginRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(v => v.ContactPerson).HasMaxLength(100);
            this.Property(v => v.MobileNo).HasMaxLength(100);
            this.Property(d => d.UserID).HasMaxLength(50).IsRequired();
            this.Property(d => d.UPass).HasMaxLength(50).IsRequired();
            this.Property(d => d.CreatedBy).HasMaxLength(30);
            this.Property(d => d.Remarks).HasMaxLength(200);
            this.Property(d => d.Other1).HasMaxLength(100);
            this.Property(d => d.Other2).HasMaxLength(100);
            this.Property(d => d.Other3).HasMaxLength(100);

            this.HasRequired(d => d.MasterVendor).WithMany().HasForeignKey(d => d.VendorRowID).WillCascadeOnDelete(false);
        }
    }
}
