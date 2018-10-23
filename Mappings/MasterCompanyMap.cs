using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    class MasterCompanyMap : EntityTypeConfiguration<MasterCompany>
    {
        public MasterCompanyMap()
        {
            this.HasKey(c => c.CompanyRowID);
            this.Property(c => c.CompanyRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CompanyName).HasMaxLength(150).IsRequired();
            this.Property(c => c.CompanyAddress).HasMaxLength(200);
            this.Property(c => c.GeneralEmail).HasMaxLength(100);
            this.Property(c => c.PhoneNo).HasMaxLength(20);
            this.Property(c => c.MobileNo).HasMaxLength(20);
            this.Property(c => c.FaxNo).HasMaxLength(20);
            this.Property(c => c.CompanyLogo).HasMaxLength(150);
            this.Property(c => c.SpecialInstruction).HasMaxLength(200);

            this.Property(c => c.SMTPServer).HasMaxLength(100);
            this.Property(c => c.SMTPPort).HasMaxLength(10);
            this.Property(c => c.SMTPUserName).HasMaxLength(100);
            this.Property(c => c.SMTPPassword).HasMaxLength(100);

            this.Property(c => c.InitiationDName).HasMaxLength(100);
            this.Property(c => c.InitiationEmail).HasMaxLength(100);

            this.Property(c => c.InsuffDName).HasMaxLength(100);
            this.Property(c => c.InsuffEmail).HasMaxLength(100);

            this.Property(c => c.ReportDName).HasMaxLength(100);
            this.Property(c => c.ReportEmail).HasMaxLength(100);

            this.Property(c => c.MISDName).HasMaxLength(100);
            this.Property(c => c.MISEmail).HasMaxLength(100);

            this.Property(c => c.BillingDName).HasMaxLength(100);
            this.Property(c => c.BillingEmail).HasMaxLength(100);

            this.Property(c => c.OtherDName).HasMaxLength(100);
            this.Property(c => c.OtherEmail).HasMaxLength(100);

            this.Property(c => c.Other1).HasMaxLength(100);
            this.Property(c => c.Other2).HasMaxLength(100);
            this.Property(c => c.Other3).HasMaxLength(100);

            this.HasRequired(c => c.MasterLocation).WithMany().HasForeignKey(c => c.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterDistrict).WithMany().HasForeignKey(c => c.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterState).WithMany().HasForeignKey(c => c.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCountry).WithMany().HasForeignKey(c => c.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
