﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
   public class PQIndianDatabaseMap:EntityTypeConfiguration<PQIndianDatabase>
    {
        public PQIndianDatabaseMap()
        {
            this.HasKey(i => i.IndianDatabaseRowID);
            this.Property(i => i.IndianDatabaseRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(i=>i.IDC_Cand_Name     ).HasMaxLength(200);   
            this.Property(i=>i.IDC_Sec_Ref_No    ).HasMaxLength(200);
            this.Property(i=>i.IDC_Father_Name   ).HasMaxLength(200);
            this.Property(i=>i.IDC_DOB           ).HasMaxLength(200);
            this.Property(i=>i.IDC_Address       ).HasMaxLength(200);
            this.Property(i=>i.ATA_CID_No        ).HasMaxLength(100);
            this.Property(i=>i.ATA_Cmpny_Addr    ).HasMaxLength(100);
            this.Property(i => i.IDC_OtherProof).HasMaxLength(200);

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
