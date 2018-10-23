using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterUniversityMap : EntityTypeConfiguration<MasterUniversity>
    {
        public MasterUniversityMap()
        {
            this.HasKey(u => u.UniversityRowID);
            this.Property(u => u.UniversityRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(u => u.UniversityName).HasMaxLength(200).IsRequired();
            this.Property(u => u.UniversityStatus).HasMaxLength(50);
            this.Property(u => u.OtherStatus).HasMaxLength(200);
            this.Property(u => u.AffiliatedFrom).HasMaxLength(50);
            this.Property(u => u.OtherAffiliated).HasMaxLength(200);
            this.Property(u => u.UniversityAddress).HasMaxLength(200);
            this.Property(u => u.Website).HasMaxLength(100);
            this.Property(u => u.Snapshot).HasMaxLength(250);
            this.Property(u => u.ResultLink).HasMaxLength(100);
            this.Property(u => u.ModeOfInitiation).HasMaxLength(50);
            this.Property(u => u.OtherInitiation).HasMaxLength(200);
            this.Property(u => u.SpecialInstruction).HasMaxLength(500);
            this.Property(u => u.OtherDocumentDetail).HasMaxLength(200);
            this.Property(u => u.AdditionalCosting).HasMaxLength(3);
            this.Property(u => u.ModeOfPayment).HasMaxLength(20);
            this.Property(u => u.PayableAT).HasMaxLength(50);
            this.Property(u => u.FavourOf).HasMaxLength(200);
            this.Property(u => u.AccountNumber).HasMaxLength(20);
            this.Property(u => u.IFSCCode).HasMaxLength(20);
            this.Property(u => u.ConcernPersonName).HasMaxLength(100);
            this.Property(u => u.DesigConcernPerson).HasMaxLength(100);
            this.Property(u => u.OfficialEmailId).HasMaxLength(250);
            this.Property(u => u.OfficialLandlineNo).HasMaxLength(100);
            this.Property(u => u.MobileNo).HasMaxLength(100);
            this.Property(u => u.AdditionalComments).HasMaxLength(500);
            this.Property(u => u.Other1).HasMaxLength(200);
            this.Property(u => u.Other2).HasMaxLength(200);
            this.Property(u => u.Other3).HasMaxLength(200);
            this.Property(u => u.Other4).HasMaxLength(200);
            this.Property(u => u.Other5).HasMaxLength(200);

            this.HasRequired(u => u.MasterLocation).WithMany().HasForeignKey(u => u.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(u => u.MasterDistrict).WithMany().HasForeignKey(u => u.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(u => u.MasterState).WithMany().HasForeignKey(u => u.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(u => u.MasterCountry).WithMany().HasForeignKey(u => u.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
