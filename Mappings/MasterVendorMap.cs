using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterVendorMap : EntityTypeConfiguration<MasterVendor>
    {
        public MasterVendorMap()
        {
            this.HasKey(v => v.VendorRowID);
            this.Property(v => v.VendorRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(v => v.VendorName).HasMaxLength(200).IsRequired();
            this.Property(v => v.Address).HasMaxLength(200);
            this.Property(v => v.AuditStatus).HasMaxLength(20);
            this.Property(v => v.ModeOfInitiation).HasMaxLength(50);
            this.Property(v => v.OtherInitiation).HasMaxLength(200);
            this.Property(v => v.VendorContactPerson).HasMaxLength(100);
            this.Property(v => v.VendorEmaiID).HasMaxLength(250);
            this.Property(v => v.VendorMobileNo).HasMaxLength(100);
            this.Property(v => v.VendorContactNo).HasMaxLength(100);
            this.Property(v => v.SPOCToName).HasMaxLength(100);
            this.Property(v => v.SPOCToEmailId).HasMaxLength(100);
            this.Property(v => v.SPOCToMobileNo).HasMaxLength(20);
            this.Property(v => v.SPOCToContactNo).HasMaxLength(20);
            this.Property(v => v.SpecialInstruction).HasMaxLength(500);
            this.Property(v => v.ModeOfPayment).HasMaxLength(20);
            this.Property(v => v.PayableAT).HasMaxLength(50);
            this.Property(v => v.FavourOf).HasMaxLength(200);
            this.Property(v => v.AccountNumber).HasMaxLength(20);
            this.Property(v => v.IFSCCode).HasMaxLength(20);
            this.Property(v => v.PanNo).HasMaxLength(20);
            this.Property(v => v.PanDoc).HasMaxLength(300);
            this.Property(v => v.IDProofNo).HasMaxLength(50);
            this.Property(v => v.IDProofDoc).HasMaxLength(300);
            this.Property(v => v.ServiceTaxCertificateNo).HasMaxLength(50);
            this.Property(v => v.ServiceTaxCertificateDoc).HasMaxLength(300);
            this.Property(v => v.RegistrationCertificateNo).HasMaxLength(50);
            this.Property(v => v.RegistrationCertificateDoc).HasMaxLength(300);
            this.Property(v => v.AgreementDocs).HasMaxLength(250);
            this.Property(v => v.OtherDocumentDetail).HasMaxLength(200);
            this.Property(v => v.Other1).HasMaxLength(200);
            this.Property(v => v.Other2).HasMaxLength(200);
            this.Property(v => v.Other3).HasMaxLength(200);
            this.Property(v => v.Other4).HasMaxLength(200);
            this.Property(v => v.Other5).HasMaxLength(200);

            this.HasRequired(v => v.MasterLocation).WithMany().HasForeignKey(v => v.LocationRowID).WillCascadeOnDelete(false);
            this.HasRequired(v => v.MasterDistrict).WithMany().HasForeignKey(v => v.DistrictRowID).WillCascadeOnDelete(false);
            this.HasRequired(v => v.MasterState).WithMany().HasForeignKey(v => v.StateRowID).WillCascadeOnDelete(false);
            this.HasRequired(v => v.MasterCountry).WithMany().HasForeignKey(v => v.CountryRowID).WillCascadeOnDelete(false);
        }
    }
}
