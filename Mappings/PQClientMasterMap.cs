using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientMasterMap : EntityTypeConfiguration<PQClientMaster>
    {
        public PQClientMasterMap()
        {
            this.HasKey(p => p.ClientRowID);
            this.Property(p => p.ClientRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ClientCode).HasMaxLength(50).IsRequired();
            this.Property(p => p.ClientCode1).HasMaxLength(20);

            this.Property(p => p.Address).HasMaxLength(300);
            this.Property(p => p.RegisteredAddress).HasMaxLength(300);
            this.Property(p => p.CorporateOfficeAddress).HasMaxLength(300);

            this.Property(p => p.SpecialInstructions).HasMaxLength(200);

            this.Property(p => p.IncentiveInstruction).HasMaxLength(100);
            this.Property(p => p.PenaltyDetails).HasMaxLength(100);
            this.Property(p => p.LiabilityDetails).HasMaxLength(100);
            this.Property(p => p.BillingAprvlDetails).HasMaxLength(100);

            this.Property(p => p.SpocName).HasMaxLength(3000).IsRequired();
            this.Property(p => p.SpocEmailID).HasMaxLength(5000).IsRequired();

            this.Property(p => p.CSpocName).HasMaxLength(100).IsRequired();
            this.Property(p => p.CSpocDesignation).HasMaxLength(100);
            this.Property(p => p.CSpocContactNo).HasMaxLength(20);
            this.Property(p => p.CSpocMobileNo).HasMaxLength(15);
            this.Property(p => p.CSpocEmailID).HasMaxLength(200).IsRequired();

            this.Property(p => p.CBillingSpocName).HasMaxLength(100);
            this.Property(p => p.CBillingSpocDesignation).HasMaxLength(100);
            this.Property(p => p.CBillingSpocMobileNo).HasMaxLength(15);
            this.Property(p => p.CBillingSpocEmailID).HasMaxLength(200);
            this.Property(p => p.CBillingInstructions).HasMaxLength(200);
            this.Property(p => p.CBillingAddress).HasMaxLength(300);

            this.Property(p => p.CEsclationSpocName).HasMaxLength(100);
            this.Property(p => p.CEsclationSpocDesignation).HasMaxLength(100);
            this.Property(p => p.CEsclationSpocMobileNo).HasMaxLength(15);
            this.Property(p => p.CEsclationSpocEmailID).HasMaxLength(200);

            this.Property(p => p.CSendInsuffDisplay).HasMaxLength(100);
            this.Property(p => p.CSendInsuffEmail).HasMaxLength(100);
            this.Property(p => p.CSendReportDisplay).HasMaxLength(100);
            this.Property(p => p.CSendReportEmail).HasMaxLength(100);
            this.Property(p => p.CSendRedReportDisplay).HasMaxLength(100);
            this.Property(p => p.CSendRedReportEmail).HasMaxLength(100);
            this.Property(p => p.CSendBillingAprvlDisplay).HasMaxLength(100);
            this.Property(p => p.CSendBillingAprvlEmail).HasMaxLength(100);

            this.Property(p => p.Remark).HasMaxLength(500);

            this.Property(p => p.SMTPServer).HasMaxLength(100);
            this.Property(p => p.SMTPPort).HasMaxLength(5);
            this.Property(p => p.SMTPUserName).HasMaxLength(100);
            this.Property(p => p.SMTPPassword).HasMaxLength(100);

            this.Property(p => p.ClientCategory).HasMaxLength(50);
            this.Property(p => p.CSalesSPOCName).HasMaxLength(100);

            this.Property(p => p.Other1).HasMaxLength(100);
            this.Property(p => p.Other2).HasMaxLength(100);
            this.Property(p => p.Other3).HasMaxLength(100);
            this.Property(p => p.Other4).HasMaxLength(100);
            this.Property(p => p.Other5).HasMaxLength(100);
            this.Property(p => p.RamcoId).HasMaxLength(100);
            this.Property(p => p.SpocId).HasMaxLength(100);

            this.HasRequired(p => p.MasterAbbreviation).WithMany().HasForeignKey(p => p.ClientAbbRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterClientSubGroup).WithMany().HasForeignKey(p => p.ClientSubgroupID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterCountry).WithMany().HasForeignKey(p => p.CountryRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterState).WithMany().HasForeignKey(p => p.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterDistrict).WithMany().HasForeignKey(p => p.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterLocation).WithMany().HasForeignKey(p => p.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterCompanyBranch).WithMany().HasForeignKey(p => p.BORowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterBillingCycle).WithMany().HasForeignKey(p => p.BillingRowID).WillCascadeOnDelete(false);
        }
    }
}
