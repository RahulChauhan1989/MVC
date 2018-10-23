using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQAddressVarPartenerMap : EntityTypeConfiguration<PQAddressVarPartener>
    {
        public PQAddressVarPartenerMap()
        {
            this.HasKey(d => d.PQAddressVarPtrRowId);
            this.Property(d => d.PQAddressVarPtrRowId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(d => d.SubCheckName).HasMaxLength(100);
            this.Property(d => d.AV_Cand_Name).HasMaxLength(100);
            this.Property(d => d.AV_Add).HasMaxLength(100);
            this.Property(d => d.AV_AddLine1).HasMaxLength(100);
            this.Property(d => d.AV_AddLine2).HasMaxLength(100);
            this.Property(d => d.AV_Buldng_Street_Name).HasMaxLength(100);
            this.Property(d => d.AV_State).HasMaxLength(100);
            this.Property(d => d.AV_District).HasMaxLength(100);
            this.Property(d => d.AV_City).HasMaxLength(100);
            this.Property(d => d.AV_Landmark).HasMaxLength(100);
            this.Property(d => d.CheckStatus).HasMaxLength(20);
            this.Property(d => d.IsAddressChanged).HasMaxLength(5);
            this.Property(d => d.Address).HasMaxLength(300);
            this.Property(d => d.Landmark).HasMaxLength(100);
            this.Property(d => d.DurationOfStay).HasMaxLength(20);
            this.Property(d => d.AccomodationType).HasMaxLength(100);
            this.Property(d => d.RespName).HasMaxLength(100);
            this.Property(d => d.RespIdDetails).HasMaxLength(100);
            this.Property(d => d.RespRelation).HasMaxLength(100);
            this.Property(d => d.RespContactDetails).HasMaxLength(100);
            this.Property(d => d.NeighbourNameAndNos).HasMaxLength(100);
            this.Property(d => d.AnyOtherComments).HasMaxLength(200);
            this.Property(d => d.PtrStatus).HasMaxLength(20);
            this.Property(d => d.Longitude).HasMaxLength(30);
            this.Property(d => d.Latitude).HasMaxLength(30);

            this.HasRequired(d => d.PQAddress).WithMany().HasForeignKey(d => d.AddressRowID).WillCascadeOnDelete(false);
            this.HasRequired(d => d.MasterVendorLogin).WithMany().HasForeignKey(d => d.VendorLoginRowID).WillCascadeOnDelete(false);

        }
    }
}
