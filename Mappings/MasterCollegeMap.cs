using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCollegeMap : EntityTypeConfiguration<MasterCollege>
    {
        public MasterCollegeMap()
        {
            this.HasKey(c => c.CollegeRowID);
            this.Property(c => c.CollegeRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CollegeName).HasMaxLength(200).IsRequired();
            this.Property(c => c.CollegeStatus).HasMaxLength(50);
            this.Property(u => u.OtherStatus).HasMaxLength(200);
            this.Property(c => c.AffiliatedFrom).HasMaxLength(50);
            this.Property(u => u.OtherAffiliated).HasMaxLength(200);
            this.Property(c => c.CollegeAddress).HasMaxLength(200);
            this.Property(c => c.Website).HasMaxLength(100);
            this.Property(u => u.Snapshot).HasMaxLength(250);
            this.Property(u => u.ResultLink).HasMaxLength(100);
            this.Property(c => c.ModeOfInitiation).HasMaxLength(50);
            this.Property(u => u.OtherInitiation).HasMaxLength(200);
            this.Property(c => c.SpecialInstruction).HasMaxLength(500);
            this.Property(u => u.OtherDocumentDetail).HasMaxLength(200);
            this.Property(c => c.AdditionalCosting).HasMaxLength(3);
            this.Property(c => c.ModeOfPayment).HasMaxLength(20);
            this.Property(u => u.PayableAT).HasMaxLength(50);
            this.Property(c => c.FavourOf).HasMaxLength(150);
            this.Property(u => u.AccountNumber).HasMaxLength(20);
            this.Property(u => u.IFSCCode).HasMaxLength(20);
            this.Property(c => c.ConcernPersonName).HasMaxLength(100);
            this.Property(c => c.DesigConcernPerson).HasMaxLength(100);
            this.Property(c => c.OfficialEmailId).HasMaxLength(250);
            this.Property(c => c.OfficialLandlineNo).HasMaxLength(100);
            this.Property(c => c.MobileNo).HasMaxLength(100);
            this.Property(c => c.AdditionalComments).HasMaxLength(500);
            this.Property(c => c.Other1).HasMaxLength(200);
            this.Property(c => c.Other2).HasMaxLength(200);
            this.Property(c => c.Other3).HasMaxLength(200);
            this.Property(c => c.Other4).HasMaxLength(200);
            this.Property(c => c.Other5).HasMaxLength(200);

            this.HasRequired(c => c.MasterUniversity).WithMany().HasForeignKey(c => c.UniversityRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterLocation).WithMany().HasForeignKey(c => c.LocationRowID).WillCascadeOnDelete(false);            
            this.HasRequired(c => c.MasterDistrict).WithMany().HasForeignKey(c => c.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterState).WithMany().HasForeignKey(c => c.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCountry).WithMany().HasForeignKey(c => c.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
