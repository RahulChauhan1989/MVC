using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQAddressVerDispositionMap : EntityTypeConfiguration<PQAddressVerDisposition>
    {
        public PQAddressVerDispositionMap()
        {
            this.HasKey(d => d.AddressVerDispositionRowID);
            this.Property(d => d.AddressVerDispositionRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(d => d.PQAddressVer).WithMany().HasForeignKey(d => d.AddressVerRowID).WillCascadeOnDelete(true);
            this.HasRequired(d => d.PQClientDisposition).WithMany().HasForeignKey(d => d.ClientDispositionRowId).WillCascadeOnDelete(false);
        }
    }
}
