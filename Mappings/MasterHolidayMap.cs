using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class MasterHolidayMap : EntityTypeConfiguration<MasterHoliday>
    {
        public MasterHolidayMap()
        {
            this.HasKey(d => d.HoliRowID);
            this.Property(d => d.HoliRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.HoliTitle).HasMaxLength(200).IsRequired();
            this.Property(d => d.HoliDay  ).HasMaxLength(15).IsRequired();
            this.Property(d => d.HoliMonth).HasMaxLength(20).IsRequired();
            this.Property(d => d.HoliYear ).HasMaxLength(10).IsRequired();
            this.Property(d => d.Remarks  ).HasMaxLength(200);
            this.Property(d => d.AddInfo).HasMaxLength(100);
        }
    }
}
