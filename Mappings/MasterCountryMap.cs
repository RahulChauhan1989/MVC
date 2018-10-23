using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterCountryMap : EntityTypeConfiguration<MasterCountry>
    {
        public MasterCountryMap()
        {
            this.HasKey(c => c.CountryRowID);
            this.Property(c => c.CountryRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.CountryName).HasMaxLength(100).IsRequired();
            this.Property(c => c.CountryCode).HasMaxLength(10);
            this.Property(c => c.CountryCallingCode).HasMaxLength(10);
            this.Property(c => c.InternationalDialingPrefix).HasMaxLength(10);
        }
    }
}
