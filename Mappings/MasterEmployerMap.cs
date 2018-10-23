using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterEmployerMap : EntityTypeConfiguration<MasterEmployer>
    {
        public MasterEmployerMap()
        {
            this.HasKey(e => e.EmployerRowID);
            this.Property(e => e.EmployerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.CompanyName).HasMaxLength(200).IsRequired();
            this.Property(e => e.CompanyStatus).HasMaxLength(50);
            this.Property(e => e.COtherStatus).HasMaxLength(200);
            this.Property(e => e.CompanyLegalStatus).HasMaxLength(50);
            this.Property(e => e.COtherLegalStatus).HasMaxLength(200);
            this.Property(e => e.CompanyAddress).HasMaxLength(200);
            this.Property(e => e.Website).HasMaxLength(100);
            this.Property(e => e.CompanySnapshot).HasMaxLength(250);
            this.Property(e => e.CINNumber).HasMaxLength(30);
            this.Property(e => e.ModeOfInitiation).HasMaxLength(50);
            this.Property(e => e.OtherInitiation).HasMaxLength(200);
            this.Property(e => e.MandatoryDocument).HasMaxLength(500);
            this.Property(e => e.OtherDocumentDetail).HasMaxLength(200);
            this.Property(e => e.SpecialInstruction).HasMaxLength(500);
            this.Property(e => e.AdditionalCosting).HasMaxLength(3);
            this.Property(e => e.ModeOfPayment).HasMaxLength(20);
            this.Property(e => e.PayableAT).HasMaxLength(50);
            this.Property(e => e.FavourOf).HasMaxLength(200);
            this.Property(e => e.AccountNumber).HasMaxLength(20);
            this.Property(e => e.IFSCCode).HasMaxLength(20);
            this.Property(e => e.ConcernPersonName).HasMaxLength(100);
            this.Property(e => e.DesigConcernPerson).HasMaxLength(100);
            this.Property(e => e.OfficialEmailId).HasMaxLength(250);
            this.Property(e => e.OfficialLandlineNo).HasMaxLength(100);
            this.Property(e => e.MobileNo).HasMaxLength(100);
            this.Property(e => e.PVInitiated).HasMaxLength(3);
            this.Property(e => e.PVInitAtAddress).HasMaxLength(220);
            this.Property(e => e.PVInitAtAddressProof).HasMaxLength(250);
            this.Property(e => e.RegisteredOnMCA).HasMaxLength(3);
            this.Property(e => e.MCARegProof).HasMaxLength(250);
            this.Property(e => e.OtherDocumentAdded).HasMaxLength(3);
            this.Property(e => e.OtherDocumentNo).HasMaxLength(100);
            this.Property(e => e.OtherDocProof).HasMaxLength(250);
            this.Property(e => e.AdditionalComments).HasMaxLength(500);
            this.Property(e => e.Other1).HasMaxLength(200);
            this.Property(e => e.Other2).HasMaxLength(200);
            this.Property(e => e.Other3).HasMaxLength(200);
            this.Property(e => e.Other4).HasMaxLength(200);
            this.Property(e => e.Other5).HasMaxLength(200);

            this.HasRequired(e => e.MasterLocation).WithMany().HasForeignKey(e => e.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.MasterDistrict).WithMany().HasForeignKey(e => e.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.MasterState).WithMany().HasForeignKey(e => e.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(e => e.MasterCountry).WithMany().HasForeignKey(e => e.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
