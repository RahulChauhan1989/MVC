using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQClientHolidayMap : EntityTypeConfiguration<PQClientHoliday>
    {
        public PQClientHolidayMap()
        {
            this.HasKey(s => s.ClientHoliRowID);
            this.Property(s => s.ClientHoliRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);           
            this.HasRequired(s => s.MasterHoliday).WithMany().HasForeignKey(s => s.HoliRowID).WillCascadeOnDelete(false);
            this.HasRequired(s => s.PQClientMaster).WithMany().HasForeignKey(s => s.ClientRowID).WillCascadeOnDelete(false);
        }
    }
}
