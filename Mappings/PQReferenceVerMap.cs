﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class PQReferenceVerMap:EntityTypeConfiguration<PQReferenceVer>
    {
        public PQReferenceVerMap()
        {
            this.HasKey(r => r.ReferenceCheckVerRowID);
            this.Property(r => r.ReferenceCheckVerRowID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(r=>r.RV_Cmplnts_Result_Dsplnry_Sub            ).HasMaxLength(200);
            this.Property(r=>r.RV_Reliable_Honest_Person                ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Fmly_Associat_Politics           ).HasMaxLength(200);
            this.Property(r=>r.RV_Duration                              ).HasMaxLength(200);
            this.Property(r=>r.RV_Relation_Sub                          ).HasMaxLength(200);
            this.Property(r=>r.RV_Response_Frm_Rfre                     ).HasMaxLength(200);
            this.Property(r=>r.RV_CandidateName                         ).HasMaxLength(100);
            this.Property(r=>r.RV_OrganisationName                      ).HasMaxLength(100);
            this.Property(r=>r.RV_RefereeName                           ).HasMaxLength(100);
            this.Property(r=>r.RV_RefereeDesignation                    ).HasMaxLength(100);
            this.Property(r=>r.RV_Refre_Prsnt_Emp                       ).HasMaxLength(100);
            this.Property(r=>r.RV_Refre_ConDet                          ).HasMaxLength(100);
            this.Property(r=>r.RV_Refere_Desig                          ).HasMaxLength(100);
            this.Property(r=>r.RV_Refere_Add                            ).HasMaxLength(100);
            this.Property(r=>r.RV_Refre_MobNo                           ).HasMaxLength(15);
            this.Property(r=>r.RV_Refre_Eid                             ).HasMaxLength(100);
            this.Property(r=>r.RV_Prof_Relationship_Cand_Dur            ).HasMaxLength(200);
            this.Property(r=>r.RV_Know_Long                             ).HasMaxLength(200);
            this.Property(r=>r.RV_Tenure_Emp                            ).HasMaxLength(100);
            this.Property(r=>r.RV_Know_Subject                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Was_Cand_Honest                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Rate_Prof_Ability                     ).HasMaxLength(20);
            this.Property(r=>r.RV_Commun_Jr_Sr_Colleague                ).HasMaxLength(200);
            this.Property(r=>r.RV_Relationship_With_Sub                 ).HasMaxLength(100);
            this.Property(r=>r.RV_Overall_Jb_Perf                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Response_Wrtn_Verb                    ).HasMaxLength(20);
            this.Property(r=>r.RV_State_Specify_Medcl_Prblm             ).HasMaxLength(200);
            this.Property(r=>r.RV_Sate_Specify_Per_Prblm_Perf           ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Perf_Intgrty_Wrk                  ).HasMaxLength(200);
            this.Property(r=>r.RV_Particular_Gud_Least_Effect           ).HasMaxLength(200);
            this.Property(r=>r.RV_Comment_Per_Qualities                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Aware_Son_Daughtr_Appld_Jb            ).HasMaxLength(20);
            this.Property(r=>r.RV_Character                             ).HasMaxLength(20);
            this.Property(r=>r.RV_Anger_Mngmt                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Behaviour                             ).HasMaxLength(20);
            this.Property(r=>r.RV_Intgrty_Commitmnt                     ).HasMaxLength(20);
            this.Property(r=>r.RV_Nature                                ).HasMaxLength(20);
            this.Property(r=>r.RV_Perf_level                            ).HasMaxLength(20);
            this.Property(r=>r.RV_SoftSkill                             ).HasMaxLength(20);
            this.Property(r=>r.RV_Action_Orient                         ).HasMaxLength(20);
            this.Property(r=>r.RV_Algmnt_Skills                         ).HasMaxLength(20);
            this.Property(r=>r.RV_Anger_Mgmt_Skills                     ).HasMaxLength(20);
            this.Property(r=>r.RV_Reliability                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Aptitutde                             ).HasMaxLength(20);
            this.Property(r=>r.RV_Influence_Style                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Initiative                            ).HasMaxLength(20);
            this.Property(r=>r.RV_Interper_Skills                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Comm_Skills                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Energy                                ).HasMaxLength(20);
            this.Property(r=>r.RV_Performance                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Team_Mgmt_Skills                      ).HasMaxLength(20);
            this.Property(r=>r.RV_Teamng_Skills                         ).HasMaxLength(20);
            this.Property(r=>r.RV_Tech_Competence                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Time_Mgmt_Org_Skills                  ).HasMaxLength(20);
            this.Property(r=>r.RV_Value_System                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Voice_Accent                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Plan_Fr_Higher_Studies                ).HasMaxLength(200);
            this.Property(r=>r.RV_What_kind_of_Jb                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Family_Background                     ).HasMaxLength(20);
            this.Property(r=>r.RV_His_Behaviour                         ).HasMaxLength(20);
            this.Property(r=>r.RV_His_Conduct                           ).HasMaxLength(20);
            this.Property(r=>r.RV_His_Perf                              ).HasMaxLength(20);
            this.Property(r=>r.RV_Recommd_Work_MNC                      ).HasMaxLength(20);
            this.Property(r=>r.RV_Manag_Analyz_MIS_Plng                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Mngng_Int_Ext_Cust_Expect             ).HasMaxLength(200);
            this.Property(r=>r.RV_Additional_Cmmnts_RC                  ).HasMaxLength(200);
            this.Property(r=>r.RV_Cmplnts_Rslt_Dsplnry_Sub              ).HasMaxLength(200);
            this.Property(r=>r.RV_Achivement_During_Tenure              ).HasMaxLength(200);
            this.Property(r=>r.RV_Other_cmmnts_RC                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Other_Qualitative_Input               ).HasMaxLength(200);
            this.Property(r=>r.RV_Qualitative_Input_Plng                ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Record_Misreprsnt_Facts          ).HasMaxLength(200);
            this.Property(r=>r.RV_Area_Development                      ).HasMaxLength(200);
            this.Property(r=>r.RV_Attendance_Punct_RC                   ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Attitude_Task_Hndld              ).HasMaxLength(200);
            this.Property(r=>r.RV_Comm_Skills_RC                        ).HasMaxLength(20);
            this.Property(r=>r.RV_Contribution_Intro_Concept            ).HasMaxLength(200);
            this.Property(r=>r.RV_Dsg_Refre                             ).HasMaxLength(200);
            this.Property(r=>r.RV_Dsg_RC                                ).HasMaxLength(200);
            this.Property(r=>r.RV_CTC                                   ).HasMaxLength(200);
            this.Property(r=>r.RV_Reason_Leav                           ).HasMaxLength(200);
            this.Property(r=>r.RV_Relationship_With_Sub_Dur             ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Elgblty_Rhre                      ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Meet_Pos_Perf_Req                 ).HasMaxLength(20);
            this.Property(r=>r.RV_Recall_Edu_Credential                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Recall_Emp_Back                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Do_you_trust                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Effect_Settng_Meetng_Goals            ).HasMaxLength(20);
            this.Property(r=>r.RV_Cand_Interpersonal_Skills             ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Mngmt_Skills                     ).HasMaxLength(200);
            this.Property(r=>r.RV_Acquainted_Cand_how_long              ).HasMaxLength(200);
            this.Property(r=>r.RV_Diligent_Twds_Work                    ).HasMaxLength(200);
            this.Property(r=>r.RV_How_Discipline                        ).HasMaxLength(200);
            this.Property(r=>r.RV_How_Ppl_Respond                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Rate_Perf_Ability                     ).HasMaxLength(20);
            this.Property(r=>r.RV_Respond_Work_Pressure                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Mtng_Target_Dline                ).HasMaxLength(200);
            this.Property(r=>r.RV_As_Team_Player                        ).HasMaxLength(200);
            this.Property(r=>r.RV_Atude_Twds_Work                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Was_Cand_Motivated                    ).HasMaxLength(200);
            this.Property(r=>r.RV_How_Was_Behaviour                     ).HasMaxLength(200);
            this.Property(r=>r.RV_Perform_Task_Time_Cost                ).HasMaxLength(200);
            this.Property(r=>r.RV_Rate_Drive_Fr_Result                  ).HasMaxLength(20);
            this.Property(r=>r.RV_Rate_Resilience_Perserve              ).HasMaxLength(20);
            this.Property(r=>r.RV_Term_Resource_Discipline              ).HasMaxLength(200);
            this.Property(r=>r.RV_Rhre_Cmpny_Again                      ).HasMaxLength(200);
            this.Property(r=>r.RV_Is_Reliable_Hon_Person                ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_High_Intgrty                     ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Sincere_Hon                      ).HasMaxLength(100);
            this.Property(r=>r.RV_Knowlge_Pos_Responsiblts              ).HasMaxLength(20);
            this.Property(r=>r.RV_Major_Carrer_Changes_Sub              ).HasMaxLength(200);
            this.Property(r=>r.RV_Mngng_Mtng_Int_Cust_Expect            ).HasMaxLength(200);
            this.Property(r=>r.RV_Mgng_Complexity                       ).HasMaxLength(100);
            this.Property(r=>r.RV_Meeting_Deadlines                     ).HasMaxLength(20);
            this.Property(r=>r.RV_Mode_Of_Exit                          ).HasMaxLength(200);
            this.Property(r=>r.RV_Moral_Values                          ).HasMaxLength(200);
            this.Property(r=>r.RV_Oral_Comm_Skills                      ).HasMaxLength(20);
            this.Property(r=>r.RV_Commnt_Ldrshp_Abilities               ).HasMaxLength(200);
            this.Property(r=>r.RV_Specify_Cand_Area_Improve             ).HasMaxLength(200);
            this.Property(r=>r.RV_Specify_Cand_Strength                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Prblm_Solving_Ablts                   ).HasMaxLength(20);
            this.Property(r=>r.RV_Prof_Conduct                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Prof_Strength                         ).HasMaxLength(200);
            this.Property(r=>r.RV_Prof_Values                           ).HasMaxLength(200);
            this.Property(r=>r.RV_Quality_Of_Work                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Rating_On_Scale                       ).HasMaxLength(20);
            this.Property(r=>r.RV_Rating_Que_1                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Rating_Que_2                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Rating_Que_3                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Rating_Que_4                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Recommd_Similar_Pos                   ).HasMaxLength(200);
            this.Property(r=>r.RV_Reslt_Orient                          ).HasMaxLength(200);
            this.Property(r=>r.RV_Role_Responsibilities_Cand            ).HasMaxLength(200);
            this.Property(r=>r.RV_Stress_Mgmt                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Sub_Perf_Intgrty_Wrk_RC               ).HasMaxLength(200);
            this.Property(r=>r.RV_Suff_Notice_Period_Prov               ).HasMaxLength(200);
            this.Property(r=>r.RV_Team_Conduct                          ).HasMaxLength(20);
            this.Property(r=>r.RV_Team_Ldrshp                           ).HasMaxLength(20);
            this.Property(r=>r.RV_Team_Mgmt                             ).HasMaxLength(20);
            this.Property(r=>r.RV_Was_Sub_Team_Player                   ).HasMaxLength(20);
            this.Property(r=>r.RV_Was_Cand_Involve_Union_Act            ).HasMaxLength(200);
            this.Property(r=>r.RV_Weakness                              ).HasMaxLength(200);
            this.Property(r=>r.RV_Strength_Area_Developmnt              ).HasMaxLength(200);
            this.Property(r=>r.RV_Cand_Edu_Prof_Qualification           ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Area_Develop_Weak                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Say_Abt_Enterpren_Skills              ).HasMaxLength(200);
            this.Property(r=>r.RV_Particiular_Gud_Least_Effect          ).HasMaxLength(200);
            this.Property(r=>r.RV_Pos_Cand_Working                      ).HasMaxLength(200);
            this.Property(r=>r.RV_TimePeriod_Cand_Work_Under            ).HasMaxLength(200);
            this.Property(r=>r.RV_Work_Ethnics_Moral_Intgrty            ).HasMaxLength(200);
            this.Property(r=>r.RV_Commnt_Per_Abilities                  ).HasMaxLength(200);
            this.Property(r=>r.RV_Wrtn_Comm_Skills_RC                   ).HasMaxLength(20);
            this.Property(r=>r.RV_AnyIssues                             ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Meet_Pos_Perf_Req_RC              ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Comm_Interper_Skills              ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Effect_Gettng_Rslt                ).HasMaxLength(200);
            this.Property(r=>r.RV_Intgrty_Commitmnt_RC                  ).HasMaxLength(200);
            this.Property(r=>r.RV_Is_Reliable_Hon_Person_RC             ).HasMaxLength(20);
            this.Property(r=>r.RV_Nature_Job                            ).HasMaxLength(200);
            this.Property(r=>r.RV_Overall_Jb_Perf_RC                    ).HasMaxLength(200);
            this.Property(r => r.RV_Social_Conduct                      ).HasMaxLength(20);
            this.Property(r=>r.RV_Social_Conduct_RC                     ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Per_Prof_Weak                     ).HasMaxLength(200);
            this.Property(r=>r.RV_Work_Ethics_Moral_Intgrty_Rc          ).HasMaxLength(20);
            this.Property(r=>r.RV_Recommnd_Sub_Emp_Top_MNC              ).HasMaxLength(20);
            this.Property(r=>r.RV_Cmmnts_Sub_Strngth_Weak               ).HasMaxLength(200);
            this.Property(r=>r.RV_Cmplnts_Rslt_Dsplnry_Sub_RC           ).HasMaxLength(200);
            this.Property(r=>r.RV_Contribution_Intro_Concept_RC         ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Pos_Perf_Req_RC                   ).HasMaxLength(200);
            this.Property(r=>r.RV_Confrontation_Tackled                 ).HasMaxLength(200);
            this.Property(r=>r.RV_Pressure_Sit_Hndld                    ).HasMaxLength(200);
            this.Property(r=>r.RV_React_To_Change                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Enforcing_Gud_Qualt_Work_Jrs          ).HasMaxLength(200);
            this.Property(r=>r.RV_Sub_Team_Leader                       ).HasMaxLength(200);
            this.Property(r=>r.RV_Any_Other_Cmmnts_Fdback               ).HasMaxLength(200);
            this.Property(r=>r.RV_Exp_During_Financ_Dealing             ).HasMaxLength(200);
            this.Property(r=>r.RV_Rel_Busines_Entity                    ).HasMaxLength(200);
            this.Property(r=>r.RV_Dur_Busines_Rel_Cmpny                 ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails6                         ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails7                         ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails8                         ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails9                         ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails10                        ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails11                        ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails12                        ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails13                        ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails14                        ).HasMaxLength(200);
            this.Property(r=>r.RV_OtherDetails15                        ).HasMaxLength(200);
            this.Property(r=>r.ATA_Reverse_Directory                    ).HasMaxLength(200);
            this.Property(r=>r.ATA_Residcl_Commrcl                      ).HasMaxLength(200);
            this.Property(r=>r.ATA_Stock_Exchnge                        ).HasMaxLength(200);
            this.Property(r=>r.ATA_Telphne_Directry_Srch                ).HasMaxLength(200);
            this.Property(r=>r.ATA_Yellow_Pages                         ).HasMaxLength(200);
            this.Property(r=>r.ATA_Who_Domain                           ).HasMaxLength(200);
            this.Property(r=>r.ATA_GoogleSearch                         ).HasMaxLength(200);
            this.Property(r=>r.ATA_InfrastructureOfCmp                  ).HasMaxLength(200);
            this.Property(r=>r.ATA_Just_Dial                            ).HasMaxLength(200);
            this.Property(r=>r.ATA_Neighbor_Check1                      ).HasMaxLength(200);
            this.Property(r=>r.ATA_NASCOM_Empanelment                   ).HasMaxLength(200);
            this.Property(r=>r.ATA_Photograph                           ).HasMaxLength(200);
            this.Property(r=>r.ATA_Physical_Site                        ).HasMaxLength(200);
            this.Property(r=>r.ATA_Reg_Company                          ).HasMaxLength(200);
            this.Property(r=>r.ATA_PO_Courier_Check                     ).HasMaxLength(200);
            this.Property(r=>r.ATA_Network_Sol                          ).HasMaxLength(200);
            this.Property(r=>r.ATA_ApprxEmpWorking                      ).HasMaxLength(200);
            this.Property(r=>r.ATA_CID_No                               ).HasMaxLength(100);
            this.Property(r=>r.ATA_Cmpny_Addr                           ).HasMaxLength(100);
            this.Property(r=>r.ATA_Decoy_Call                           ).HasMaxLength(200);
            this.Property(r => r.ATA_Cmpny_Website).HasMaxLength(200);

            this.Property(r => r.TypeRevert).HasMaxLength(50);
            this.Property(r => r.CheckStatus).HasMaxLength(50);
            this.Property(r => r.Severity).HasMaxLength(50);
            this.Property(r => r.ColorName).HasMaxLength(50);
            this.Property(r => r.ReportComments).HasMaxLength(3000);

            this.Property(r => r.VerifierDesignation).HasMaxLength(100);
            this.Property(r => r.VerifierContactNo).HasMaxLength(20);
            this.Property(r => r.VerifierMobileNo).HasMaxLength(20);
            this.Property(r => r.VerifierEmailId).HasMaxLength(100);

            this.HasRequired(r => r.PQReferenceCheck).WithMany().HasForeignKey(r => r.ReferenceCheckRowID).WillCascadeOnDelete(false);
        }
    }
}