using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQDrugTestVerMap:EntityTypeConfiguration<PQDrugTestVer>
    {
        public PQDrugTestVerMap()
        {
            this.HasKey(d => d.DrugTestVerRouID);
            this.Property(d => d.DrugTestVerRouID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d=>d.DT_Cand_Name                         ).HasMaxLength(100);
            this.Property(d=>d.DT_Amphetamine                       ).HasMaxLength(50);
            this.Property(d=>d.DT_Barbiturate                       ).HasMaxLength(50);
            this.Property(d=>d.DT_Benzodiazepine                    ).HasMaxLength(50);
            this.Property(d=>d.DT_Cannabinoids                      ).HasMaxLength(50);
            this.Property(d=>d.DT_Cocaine                           ).HasMaxLength(50);
            this.Property(d=>d.DT_Date_Verf                         ).HasMaxLength(50);
            this.Property(d=>d.DT_Marijuana                         ).HasMaxLength(50);
            this.Property(d=>d.DT_Marijuana_Cannabinoids            ).HasMaxLength(50);
            this.Property(d=>d.DT_Methadone                         ).HasMaxLength(50);
            this.Property(d=>d.DT_Methamphetamine                   ).HasMaxLength(50);
            this.Property(d=>d.DT_Methaqualone                      ).HasMaxLength(50);
            this.Property(d=>d.DT_Morphine_Opiate                   ).HasMaxLength(50);
            this.Property(d=>d.DT_Opiates                           ).HasMaxLength(50);
            this.Property(d=>d.DT_Oxycodone                         ).HasMaxLength(50);
            this.Property(d=>d.DT_Phencyclidine                     ).HasMaxLength(50);
            this.Property(d=>d.DT_Propoxyphene                      ).HasMaxLength(50);
            this.Property(d=>d.DT_Tricyclic_Antidepressant          ).HasMaxLength(50);
            this.Property(d=>d.DT_Illicit_Drugs                     ).HasMaxLength(50);
            this.Property(d=>d.DT_Alcohol                           ).HasMaxLength(50);
            this.Property(d=>d.DT_Amphetamines                      ).HasMaxLength(50);
            this.Property(d=>d.DT_Barbiturates                      ).HasMaxLength(50);
            this.Property(d=>d.DT_Benzodiazepines                   ).HasMaxLength(50);
            this.Property(d=>d.DT_Cocaine1                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Heroin                            ).HasMaxLength(50);
            this.Property(d=>d.DT_Ketamine                          ).HasMaxLength(50);
            this.Property(d=>d.DT_LSD                               ).HasMaxLength(50);
            this.Property(d=>d.DT_Marijuana1                        ).HasMaxLength(50);
            this.Property(d=>d.DT_MDMA                              ).HasMaxLength(50);
            this.Property(d=>d.DT_Opiates1                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Rohypnol                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Steroids                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Synthetic_Drugs                   ).HasMaxLength(50);
            this.Property(d=>d.DT_benzoes                           ).HasMaxLength(50);
            this.Property(d=>d.DT_BP_Test                           ).HasMaxLength(50);
            this.Property(d=>d.DT_Dehydroepiandrosterone            ).HasMaxLength(50);
            this.Property(d=>d.DT_Ecstacy                           ).HasMaxLength(50);
            this.Property(d=>d.DT_Epitestosterone                   ).HasMaxLength(50);
            this.Property(d=>d.DT_Hydroxyandrosterone               ).HasMaxLength(50);
            this.Property(d=>d.DT_Hydroxyetiocholanolone            ).HasMaxLength(50);
            this.Property(d=>d.DT_Marijuna                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Methamphetamines                  ).HasMaxLength(50);
            this.Property(d=>d.DT_Methandienone                     ).HasMaxLength(50);
            this.Property(d=>d.DT_Nortestosterone                   ).HasMaxLength(50);
            this.Property(d=>d.DT_oxycodon                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Oxymetholone                      ).HasMaxLength(50);
            this.Property(d=>d.DT_pencilin                          ).HasMaxLength(50);
            this.Property(d=>d.DT_Phencyclidine1                    ).HasMaxLength(50);
            this.Property(d=>d.DT_Any_Other_Cmmnts                  ).HasMaxLength(50);
            this.Property(d=>d.DT_Others                            ).HasMaxLength(200);
            this.Property(d=>d.DT_Others2                           ).HasMaxLength(200);
            this.Property(d=>d.DT_Others3                           ).HasMaxLength(200);
            this.Property(d=>d.DT_Others4                           ).HasMaxLength(200);
            this.Property(d=>d.DT_Others5                           ).HasMaxLength(200);
            this.Property(d=>d.DT_Others6                           ).HasMaxLength(200);
            this.Property(d=>d.DT_Others7                           ).HasMaxLength(200);
            this.Property(d=>d.ATA_Reverse_Directory                ).HasMaxLength(200);
            this.Property(d=>d.ATA_Residcl_Commrcl                  ).HasMaxLength(200);
            this.Property(d=>d.ATA_Stock_Exchnge                    ).HasMaxLength(200);
            this.Property(d=>d.ATA_Telphne_Directry_Srch            ).HasMaxLength(200);
            this.Property(d=>d.ATA_Yellow_Pages                     ).HasMaxLength(200);
            this.Property(d=>d.ATA_Who_Domain                       ).HasMaxLength(200);
            this.Property(d=>d.ATA_GoogleSearch                     ).HasMaxLength(200);
            this.Property(d=>d.ATA_InfrastructureOfCmp              ).HasMaxLength(200);
            this.Property(d=>d.ATA_Just_Dial                        ).HasMaxLength(200);
            this.Property(d=>d.ATA_Neighbor_Check1                  ).HasMaxLength(200);
            this.Property(d=>d.ATA_NASCOM_Empanelment               ).HasMaxLength(200);
            this.Property(d=>d.ATA_Photograph                       ).HasMaxLength(200);
            this.Property(d=>d.ATA_Physical_Site                    ).HasMaxLength(200);
            this.Property(d=>d.ATA_Reg_Company                      ).HasMaxLength(200);
            this.Property(d=>d.ATA_PO_Courier_Check                 ).HasMaxLength(200);
            this.Property(d=>d.ATA_Network_Sol                      ).HasMaxLength(200);
            this.Property(d=>d.ATA_ApprxEmpWorking                  ).HasMaxLength(200);
            this.Property(d=>d.ATA_CID_No                           ).HasMaxLength(100);
            this.Property(d=>d.ATA_Cmpny_Addr                       ).HasMaxLength(100);
            this.Property(d=>d.ATA_Decoy_Call                       ).HasMaxLength(200);
            this.Property(d=>d.ATA_Cmpny_Website                    ).HasMaxLength(200);
            this.Property(d => d.DT_OtherProof).HasMaxLength(50);

            this.Property(a => a.TypeRevert).HasMaxLength(20);
            this.Property(a => a.CheckStatus).HasMaxLength(20);
            this.Property(a => a.CaseStatus).HasMaxLength(20);
            this.Property(a => a.ColorName).HasMaxLength(20);
            this.Property(a => a.Remarks).HasMaxLength(200);

            this.Property(a => a.VerifierDesignation).HasMaxLength(100);
            this.Property(a => a.VerifierContactNo).HasMaxLength(20);
            this.Property(a => a.VerifierMobileNo).HasMaxLength(20);
            this.Property(a => a.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(c => c.PQDrugTest).WithMany().HasForeignKey(c => c.DrugTestRowID).WillCascadeOnDelete(false);
        }

    }
}
