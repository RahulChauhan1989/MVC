using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQGlobalDatabaseMap:EntityTypeConfiguration<PQGlobalDatabase>
    {
        public PQGlobalDatabaseMap()
        {

            this.HasKey(g => g.GlobalDatabaseRowID);
            this.Property(g => g.GlobalDatabaseRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           this.Property(g=>g.GDC_Cand_Name         ).HasMaxLength(100);
           this.Property(g=>g.GDC_Sec_Ref_No        ).HasMaxLength(100);
           this.Property(g=>g.GDC_Father_Name       ).HasMaxLength(100);
           this.Property(g=>g.GDC_DOB               ).HasMaxLength(100);
           this.Property(g=>g.GDC_Address           ).HasMaxLength(100);
           this.Property(g=>g.GDC_OtherDetails      ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails2     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails3     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails4     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails5     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails6     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails7     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails8     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails9     ).HasMaxLength(200);
           this.Property(g=>g.GDC_OtherDetails10    ).HasMaxLength(200);
           this.Property(g=>g.ATA_CID_No            ).HasMaxLength(100);
           this.Property(g=>g.ATA_Cmpny_Addr        ).HasMaxLength(100);
            this.Property(g => g.GDC_OtherProof     ).HasMaxLength(100);

            this.Property(a => a.Mailto).HasMaxLength(200);
            this.Property(a => a.MailtoClient).HasMaxLength(200);
            this.Property(a => a.MailedBy).HasMaxLength(100);
            this.Property(a => a.ClientComment).HasMaxLength(100);
            this.Property(a => a.INFRemarks).HasMaxLength(200);

            this.HasRequired(c => c.PQClientMaster).WithMany().HasForeignKey(c => c.ClientRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.PQPersonal).WithMany().HasForeignKey(c => c.PersonalRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterCheckFamily).WithMany().HasForeignKey(c => c.CheckFamilyRowID).WillCascadeOnDelete(false);
            this.HasRequired(c => c.MasterSubCheckFamily).WithMany().HasForeignKey(c => c.SubCheckRowID).WillCascadeOnDelete(false);
        }

    }
}
