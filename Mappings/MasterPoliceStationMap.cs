using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterPoliceStationMap : EntityTypeConfiguration<MasterPoliceStation>
    {
        public MasterPoliceStationMap()
        {
            this.HasKey(p => p.PoliceStationRowID);
            this.Property(p => p.PoliceStationRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.PoliceStationName).HasMaxLength(200).IsRequired();
            this.Property(p => p.PoliceStationAddress).HasMaxLength(200);
            this.Property(p => p.Coverage).HasMaxLength(200);
            this.Property(p => p.Website).HasMaxLength(100);
            this.Property(p => p.ModeOfInitiation).HasMaxLength(50);
            this.Property(p => p.OtherInitiation).HasMaxLength(200);
            this.Property(p => p.SpecialInstruction).HasMaxLength(500);
            this.Property(p => p.MandatoryDocument).HasMaxLength(500);
            this.Property(p => p.OtherDocumentDetail).HasMaxLength(200);
            this.Property(p => p.AdditionalCosting).HasMaxLength(3);
            this.Property(p => p.ModeOfPayment).HasMaxLength(20);
            this.Property(p => p.PayableAT).HasMaxLength(50);
            this.Property(p => p.FavourOf).HasMaxLength(200);
            this.Property(p => p.AccountNumber).HasMaxLength(20);
            this.Property(p => p.IFSCCode).HasMaxLength(20);
            this.Property(p => p.ConcernPersonName).HasMaxLength(100);
            this.Property(p => p.DesigConcernPerson).HasMaxLength(100);
            this.Property(p => p.OfficialEmailId).HasMaxLength(250);
            this.Property(p => p.OfficialLandlineNo).HasMaxLength(100);
            this.Property(p => p.MobileNo).HasMaxLength(100);
            this.Property(p => p.AdditionalComments).HasMaxLength(500);
            this.Property(p => p.Other1).HasMaxLength(200);
            this.Property(p => p.Other2).HasMaxLength(200);
            this.Property(p => p.Other3).HasMaxLength(200);
            this.Property(p => p.Other4).HasMaxLength(200);
            this.Property(p => p.Other5).HasMaxLength(200);

            this.HasRequired(p => p.MasterLocation).WithMany().HasForeignKey(p => p.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterDistrict).WithMany().HasForeignKey(p => p.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterState).WithMany().HasForeignKey(p => p.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(p => p.MasterCountry).WithMany().HasForeignKey(p => p.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
