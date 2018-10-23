using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.TempViewModel;

namespace BAL.ProvidedInfoRepository
{
    public class AddressInfoRepository : IAddressInfoRepository
    {
        DataContext db;
        public AddressInfoRepository()
        {
            db = new DataContext();
        }

        public void AddAddressInformation(PQAddressViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            PQAddress entity = new PQAddress();
                            entity.ClientRowID = model.ClientRowID;
                            entity.PersonalRowID = model.PersonalRowID;
                            entity.ClientPackageRowID = model.ClientPackageRowID;
                            entity.CheckFamilyRowID = model.CheckFamilyRowID;
                            entity.SubCheckRowID = model.SubCheckRowID;
                            entity.UniqueComponentID = model.UniqueComponentID;
                            entity.AV_Cand_Name = model.AV_Cand_Name;
                            entity.AV_Sec_Ref_No = model.AV_Sec_Ref_No;
                            entity.AV_Add = model.AV_Add;
                            entity.AV_Add_Line1 = model.AV_Add_Line1;
                            entity.AV_Add_Line2 = model.AV_Add_Line2;
                            entity.AV_Buldng_Street_name = model.AV_Buldng_Street_name;
                            entity.AV_State = model.AV_State;
                            entity.AV_District = model.AV_District;
                            entity.AV_City = model.AV_City;
                            entity.AV_Pincode = model.AV_Pincode;
                            entity.AV_Landmark = model.AV_Landmark;
                            entity.AV_Add_Type = model.AV_Add_Type;
                            entity.AV_Dur_of_Stay = model.AV_Dur_of_Stay;
                            entity.AV_Owner_Name = model.AV_Owner_Name;
                            entity.AV_Owner_ConNo = model.AV_Owner_ConNo;
                            entity.AV_NickName = model.AV_NickName;
                            entity.AV_Name_Chngd_Effect_Frm = model.AV_Name_Chngd_Effect_Frm;
                            entity.AV_Doc_Prov_Proof_Add = model.AV_Doc_Prov_Proof_Add;
                            entity.AddressProofFileName = model.AddressProofFileName;
                            entity.AV_Doc_Details = model.AV_Doc_Details;
                            entity.DocumentDetailsFileName = model.DocumentDetailsFileName;
                            entity.AV_OtherDetails = model.AV_OtherDetails;
                            entity.AV_OtherDetails2 = model.AV_OtherDetails2;
                            entity.AV_OtherDetails3 = model.AV_OtherDetails3;
                            entity.AV_OtherDetails4 = model.AV_OtherDetails4;
                            entity.AV_OtherDetails5 = model.AV_OtherDetails5;
                            entity.AV_OtherDetails6 = model.AV_OtherDetails6;
                            entity.AV_OtherDetails7 = model.AV_OtherDetails7;
                            entity.AV_OtherDetails8 = model.AV_OtherDetails8;
                            entity.AV_OtherDetails9 = model.AV_OtherDetails9;
                            entity.AV_OtherDetails10 = model.AV_OtherDetails10;
                            entity.ATA_CID_No = model.ATA_CID_No;
                            entity.ATA_Cmpny_Addr = model.ATA_Cmpny_Addr;
                            entity.CreatedBy = model.CreatedBy;
                            entity.CreatedDate = model.CreatedDate;
                            entity.OutDate = model.OutDate;
                            entity.InternalOutDate = model.InternalOutDate;

                            entity.CheckStatus = model.CheckStatus;
                            if (model.CheckStatus == "Completed")
                            {
                                entity.CheckStatus = "Completed-DE";
                            }

                            entity.ReWorkCheckStatus = model.ReWorkCheckStatus;
                            entity.Remarks = model.Remarks;
                            entity.Status = model.Status;

                            context.PQAddresss.Add(entity);
                            context.SaveChanges();

                            #region Save Check Status

                            PQAddressStatus chkEntity = new PQAddressStatus();
                            var addModel = context.PQAddresss.Include("PQPersonal").Where(p => p.AddressRowID == entity.AddressRowID).FirstOrDefault();
                            chkEntity.AddressRowID = addModel.AddressRowID;
                            chkEntity.DETLAllocatedTo = addModel.PQPersonal.AllocatedBy;
                            chkEntity.DETMCheckStatus = model.CheckStatus;
                            chkEntity.DETMAllocatedTo = addModel.PQPersonal.AllocatedToDE;
                            chkEntity.DETMAllocatedDate = addModel.PQPersonal.AllocatedToDEDate;
                            chkEntity.DETMQCAllocatedTo = addModel.PQPersonal.AllocatedToDEQC;
                            chkEntity.DETMQCAllocatedDate = addModel.PQPersonal.AllocatedToDEQCDate;

                            if (model.CheckStatus == "Completed")
                            {
                                chkEntity.DETMQCCheckStatus = model.CheckStatus;
                            }
                            if (model.CheckStatus == "Insufficent")
                            {
                                chkEntity.DETMQCCheckStatus = model.CheckStatus;
                                chkEntity.InfSuffRaiseBy = addModel.PQPersonal.AllocatedToDE;
                                chkEntity.InfSuffRaisedDate = addModel.CreatedDate;
                                chkEntity.InfSuffRaiseRemarks = model.INFRemarks;
                            }
                            if (model.CheckStatus == "Rejected" || model.CheckStatus == "Review Requested")
                            {
                                chkEntity.Remarks = model.INFRemarks;
                            }

                            context.PQAddressStatus.Add(chkEntity);
                            context.SaveChanges();

                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int GetAllAddressByClientId(short ClientRowID = 0)
        {
            try
            {
                var data = db.PQAddresss.Where(p => p.ClientRowID == ClientRowID).ToList();
                return data.Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public PQAddressViewModel GetAddressInfoForDataEntry(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                PQAddressViewModel model = new PQAddressViewModel();
                model = db.PQAddresss.Where(a => a.ClientRowID == ClientRowId && a.PersonalRowID == PersonalRowID
                && a.CheckFamilyRowID == ChFamilRowId && a.SubCheckRowID == subCheckId).Select(a => new PQAddressViewModel
                {
                    AddressRowID = a.AddressRowID,
                    ClientRowID = a.ClientRowID,
                    PersonalRowID = a.PersonalRowID,
                    ClientPackageRowID = a.ClientPackageRowID,
                    CheckFamilyRowID = a.CheckFamilyRowID,
                    SubCheckRowID = a.SubCheckRowID,
                    UniqueComponentID = a.UniqueComponentID,
                    AV_Add = a.AV_Add,
                    AV_Add_Line1 = a.AV_Add_Line1,
                    AV_Add_Line2 = a.AV_Add_Line2,
                    AV_Buldng_Street_name = a.AV_Buldng_Street_name,
                    AV_Cand_Name = a.AV_Cand_Name,
                    AV_City = a.AV_City,
                    AV_District = a.AV_District,
                    AV_State = a.AV_State,
                    AV_Pincode = a.AV_Pincode,
                    AV_Landmark = a.AV_Landmark,
                    AV_Add_Type = a.AV_Add_Type,
                    AV_Dur_of_Stay = a.AV_Dur_of_Stay,
                    AV_Owner_Name = a.AV_Owner_Name,
                    AV_Owner_ConNo = a.AV_Owner_ConNo,
                    AV_NickName = a.AV_NickName,
                    AV_Name_Chngd_Effect_Frm = a.AV_Name_Chngd_Effect_Frm,
                    AV_Doc_Prov_Proof_Add = a.AV_Doc_Prov_Proof_Add,
                    AddressProofFileName = a.AddressProofFileName,
                    AV_Doc_Details = a.AV_Doc_Details,
                    DocumentDetailsFileName = a.DocumentDetailsFileName,
                    AV_OtherDetails = a.AV_OtherDetails,
                    AV_OtherDetails2 = a.AV_OtherDetails2,
                    AV_OtherDetails3 = a.AV_OtherDetails3,
                    AV_OtherDetails4 = a.AV_OtherDetails4,
                    AV_OtherDetails5 = a.AV_OtherDetails5,
                    AV_OtherDetails6 = a.AV_OtherDetails6,
                    AV_OtherDetails7 = a.AV_OtherDetails7,
                    AV_OtherDetails8 = a.AV_OtherDetails8,
                    AV_OtherDetails9 = a.AV_OtherDetails9,
                    AV_OtherDetails10 = a.AV_OtherDetails10,
                    ATA_CID_No = a.ATA_CID_No,
                    ATA_Cmpny_Addr = a.ATA_Cmpny_Addr,
                    CheckStatus = a.CheckStatus,
                    ReWorkCheckStatus = a.ReWorkCheckStatus,
                    //RejectionReason = a.INFRemarks,
                }).FirstOrDefault();

                if (model != null)
                {
                    if (model.AV_State > 0)
                        model.AV_Country = db.MasterStates.Where(s => s.StateRowID == model.AV_State).FirstOrDefault().CountryRowID;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAddressInformation(PQAddressViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add = model.AV_Add;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line1 = model.AV_Add_Line1;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line2 = model.AV_Add_Line2;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Buldng_Street_name = model.AV_Buldng_Street_name;
                            //context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Cand_Name = model.AV_Cand_Name;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_State = model.AV_State;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_District = model.AV_District;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_City = model.AV_City;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Pincode = model.AV_Pincode;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Landmark = model.AV_Landmark;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Type = model.AV_Add_Type;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Dur_of_Stay = model.AV_Dur_of_Stay;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_Name = model.AV_Owner_Name;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_ConNo = model.AV_Owner_ConNo;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_NickName = model.AV_NickName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Name_Chngd_Effect_Frm = model.AV_Name_Chngd_Effect_Frm;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Prov_Proof_Add = model.AV_Doc_Prov_Proof_Add;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AddressProofFileName = model.AddressProofFileName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Details = model.AV_Doc_Details;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).DocumentDetailsFileName = model.DocumentDetailsFileName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails = model.AV_OtherDetails;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails2 = model.AV_OtherDetails2;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails3 = model.AV_OtherDetails3;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails4 = model.AV_OtherDetails4;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails5 = model.AV_OtherDetails5;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails6 = model.AV_OtherDetails6;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails7 = model.AV_OtherDetails7;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails8 = model.AV_OtherDetails8;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails9 = model.AV_OtherDetails9;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails10 = model.AV_OtherDetails10;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_CID_No = model.ATA_CID_No;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_Cmpny_Addr = model.ATA_Cmpny_Addr;

                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            if (model.CheckStatus == "Completed")
                            {
                                context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = "Completed-DE";
                            }

                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.CreatedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.CreatedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            var status = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault();

                            if (status.TMCheckStatus == "Insufficent" && status.TMQCCheckStatus == "Insufficent-QC" && model.CheckStatus == "Completed")
                            {
                                context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = "WIP-Pending";
                                context.SaveChanges();

                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMCheckStatus = model.CheckStatus;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMAllocatedDate = model.CreatedDate;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).TMCheckStatus = "WIP-Pending";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).TMAllocatedDate = model.CreatedDate;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).TMQCCheckStatus = "";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).TMQCAllocatedDate = model.CreatedDate;
                            }
                            else
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMCheckStatus = model.CheckStatus;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMAllocatedDate = model.CreatedDate;

                                if (model.CheckStatus == "Completed")
                                {
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMQCCheckStatus = model.CheckStatus;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMQCAllocatedDate = model.CreatedDate;
                                }
                                if (model.CheckStatus == "Insufficent")
                                {
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMQCCheckStatus = model.CheckStatus;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).DETMQCAllocatedDate = model.CreatedDate;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).InfSuffRaiseBy = model.CreatedBy;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).InfSuffRaisedDate = model.CreatedDate;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).InfSuffRaiseRemarks = model.INFRemarks;
                                }
                                if (model.CheckStatus == "Rejected" || model.CheckStatus == "Review Requested")
                                {
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == status.AddressStatusRowID).Remarks = model.INFRemarks;
                                }
                            }
                            context.SaveChanges();

                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public PQUpdateAddressViewModel GetAddressForUpdateById(int AddressRowID = 0)
        {
            try
            {
                PQUpdateAddressViewModel model = new PQUpdateAddressViewModel();
                var entity = db.PQAddresss.Find(AddressRowID);
                if (entity != null)
                {
                    model.ClientRowID = entity.ClientRowID;
                    model.PersonalRowID = entity.PersonalRowID;
                    model.ClientPackageRowID = entity.ClientPackageRowID;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.SubCheckRowID = entity.SubCheckRowID;
                    model.UniqueComponentID = entity.UniqueComponentID;
                    model.AV_Cand_Name = entity.AV_Cand_Name;
                    model.AV_Sec_Ref_No = entity.AV_Sec_Ref_No;
                    model.AV_Add = entity.AV_Add;
                    model.AV_Add_Line1 = entity.AV_Add_Line1;
                    model.AV_Add_Line2 = entity.AV_Add_Line2;
                    model.AV_Buldng_Street_name = entity.AV_Buldng_Street_name;
                    model.AV_State = entity.AV_State;
                    model.AV_District = entity.AV_District;
                    model.AV_City = entity.AV_City;
                    model.AV_Pincode = entity.AV_Pincode;
                    model.AV_Landmark = entity.AV_Landmark;
                    model.AV_Add_Type = entity.AV_Add_Type;
                    model.AV_Dur_of_Stay = entity.AV_Dur_of_Stay;
                    model.AV_Owner_Name = entity.AV_Owner_Name;
                    model.AV_Owner_ConNo = entity.AV_Owner_ConNo;
                    model.AV_NickName = entity.AV_NickName;
                    model.AV_Name_Chngd_Effect_Frm = entity.AV_Name_Chngd_Effect_Frm;
                    model.AV_Doc_Prov_Proof_Add = entity.AV_Doc_Prov_Proof_Add;
                    model.AddressProofFileName = entity.AddressProofFileName;
                    model.AV_Doc_Details = entity.AV_Doc_Details;
                    model.DocumentDetailsFileName = entity.DocumentDetailsFileName;
                    model.AV_OtherDetails = entity.AV_OtherDetails;
                    model.AV_OtherDetails2 = entity.AV_OtherDetails2;
                    model.AV_OtherDetails3 = entity.AV_OtherDetails3;
                    model.AV_OtherDetails4 = entity.AV_OtherDetails4;
                    model.AV_OtherDetails5 = entity.AV_OtherDetails5;
                    model.AV_OtherDetails6 = entity.AV_OtherDetails6;
                    model.AV_OtherDetails7 = entity.AV_OtherDetails7;
                    model.AV_OtherDetails8 = entity.AV_OtherDetails8;
                    model.AV_OtherDetails9 = entity.AV_OtherDetails9;
                    model.AV_OtherDetails10 = entity.AV_OtherDetails10;
                    model.ATA_CID_No = entity.ATA_CID_No;
                    model.ATA_Cmpny_Addr = entity.ATA_Cmpny_Addr;
                    model.CheckStatus = entity.CheckStatus;
                    model.CaseStatus = entity.ReWorkCheckStatus;
                    model.Remarks = entity.Remarks;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PQUpdateAddressViewModel GetAddressInfoForQualityCheck(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                PQUpdateAddressViewModel model = new PQUpdateAddressViewModel();
                var entity = db.PQAddresss.Where(b => b.ClientRowID == ClientRowId && b.PersonalRowID == PersonalRowID
                 && b.CheckFamilyRowID == ChFamilRowId && b.SubCheckRowID == subCheckId).FirstOrDefault();
                {
                    model.AddressRowID = entity.AddressRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.PersonalRowID = entity.PersonalRowID;
                    model.ClientPackageRowID = entity.ClientPackageRowID;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.SubCheckRowID = entity.SubCheckRowID;
                    model.UniqueComponentID = entity.UniqueComponentID;
                    model.AV_Add = entity.AV_Add;
                    model.AV_Add_Line1 = entity.AV_Add_Line1;
                    model.AV_Add_Line2 = entity.AV_Add_Line2;
                    model.AV_Buldng_Street_name = entity.AV_Buldng_Street_name;
                    model.AV_Cand_Name = entity.AV_Cand_Name;
                    model.AV_City = entity.AV_City;
                    model.AV_District = entity.AV_District;
                    model.AV_State = entity.AV_State;
                    model.AV_Pincode = entity.AV_Pincode;
                    model.AV_Landmark = entity.AV_Landmark;
                    model.AV_Add_Type = entity.AV_Add_Type;
                    model.AV_Dur_of_Stay = entity.AV_Dur_of_Stay;
                    model.AV_Owner_Name = entity.AV_Owner_Name;
                    model.AV_Owner_ConNo = entity.AV_Owner_ConNo;
                    model.AV_NickName = entity.AV_NickName;
                    model.AV_Name_Chngd_Effect_Frm = entity.AV_Name_Chngd_Effect_Frm;
                    model.AV_Doc_Prov_Proof_Add = entity.AV_Doc_Prov_Proof_Add;
                    model.AddressProofFileName = entity.AddressProofFileName;
                    model.AV_Doc_Details = entity.AV_Doc_Details;
                    model.DocumentDetailsFileName = entity.DocumentDetailsFileName;
                    model.AV_OtherDetails = entity.AV_OtherDetails;
                    model.AV_OtherDetails2 = entity.AV_OtherDetails2;
                    model.AV_OtherDetails3 = entity.AV_OtherDetails3;
                    model.AV_OtherDetails4 = entity.AV_OtherDetails4;
                    model.AV_OtherDetails5 = entity.AV_OtherDetails5;
                    model.AV_OtherDetails6 = entity.AV_OtherDetails6;
                    model.AV_OtherDetails7 = entity.AV_OtherDetails7;
                    model.AV_OtherDetails8 = entity.AV_OtherDetails8;
                    model.AV_OtherDetails9 = entity.AV_OtherDetails9;
                    model.AV_OtherDetails10 = entity.AV_OtherDetails10;
                    model.ATA_CID_No = entity.ATA_CID_No;
                    model.ATA_Cmpny_Addr = entity.ATA_Cmpny_Addr;
                    model.CheckStatus = entity.CheckStatus;
                    model.CaseStatus = entity.ReWorkCheckStatus;
                    model.CityName = db.MasterLocations.Where(a => a.LocationRowID == entity.AV_City).FirstOrDefault().LocationName;
                    model.StateName = db.MasterStates.Where(a => a.StateRowID == entity.AV_State).FirstOrDefault().StateName;
                    model.DistrictName = db.MasterDistricts.Where(a => a.DistrictRowID == entity.AV_District).FirstOrDefault().DistrictName;

                }


                if (model != null && model.AV_State > 0)
                    model.AV_Country = db.MasterStates.Where(s => s.StateRowID == model.AV_State).FirstOrDefault().CountryRowID;

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PQUpdateAddressViewModel GetAddressInfoForQualityCheck(int AddressRowID = 0)
        {
            try
            {
                PQUpdateAddressViewModel model = new PQUpdateAddressViewModel();
                var entity = db.PQAddresss.Where(b => b.AddressRowID == AddressRowID).FirstOrDefault();
                {
                    model.AddressRowID = entity.AddressRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.PersonalRowID = entity.PersonalRowID;
                    model.ClientPackageRowID = entity.ClientPackageRowID;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.SubCheckRowID = entity.SubCheckRowID;
                    model.UniqueComponentID = entity.UniqueComponentID;
                    model.AV_Add = entity.AV_Add;
                    model.AV_Add_Line1 = entity.AV_Add_Line1;
                    model.AV_Add_Line2 = entity.AV_Add_Line2;
                    model.AV_Buldng_Street_name = entity.AV_Buldng_Street_name;
                    model.AV_Cand_Name = entity.AV_Cand_Name;
                    model.AV_City = entity.AV_City;
                    model.AV_District = entity.AV_District;
                    model.AV_State = entity.AV_State;
                    model.AV_Pincode = entity.AV_Pincode;
                    model.AV_Landmark = entity.AV_Landmark;
                    model.AV_Add_Type = entity.AV_Add_Type;
                    model.AV_Dur_of_Stay = entity.AV_Dur_of_Stay;
                    model.AV_Owner_Name = entity.AV_Owner_Name;
                    model.AV_Owner_ConNo = entity.AV_Owner_ConNo;
                    model.AV_NickName = entity.AV_NickName;
                    model.AV_Name_Chngd_Effect_Frm = entity.AV_Name_Chngd_Effect_Frm;
                    model.AV_Doc_Prov_Proof_Add = entity.AV_Doc_Prov_Proof_Add;
                    model.AddressProofFileName = entity.AddressProofFileName;
                    model.AV_Doc_Details = entity.AV_Doc_Details;
                    model.DocumentDetailsFileName = entity.DocumentDetailsFileName;
                    model.AV_OtherDetails = entity.AV_OtherDetails;
                    model.AV_OtherDetails2 = entity.AV_OtherDetails2;
                    model.AV_OtherDetails3 = entity.AV_OtherDetails3;
                    model.AV_OtherDetails4 = entity.AV_OtherDetails4;
                    model.AV_OtherDetails5 = entity.AV_OtherDetails5;
                    model.AV_OtherDetails6 = entity.AV_OtherDetails6;
                    model.AV_OtherDetails7 = entity.AV_OtherDetails7;
                    model.AV_OtherDetails8 = entity.AV_OtherDetails8;
                    model.AV_OtherDetails9 = entity.AV_OtherDetails9;
                    model.AV_OtherDetails10 = entity.AV_OtherDetails10;
                    model.ATA_CID_No = entity.ATA_CID_No;
                    model.ATA_Cmpny_Addr = entity.ATA_Cmpny_Addr;
                    model.CheckStatus = entity.CheckStatus;
                    model.CaseStatus = entity.ReWorkCheckStatus;
                    model.CityName = db.MasterLocations.Where(a => a.LocationRowID == entity.AV_City).FirstOrDefault().LocationName;
                    model.StateName = db.MasterStates.Where(a => a.StateRowID == entity.AV_State).FirstOrDefault().StateName;
                    model.DistrictName = db.MasterDistricts.Where(a => a.DistrictRowID == entity.AV_District).FirstOrDefault().DistrictName;

                }

                if (model != null && model.AV_State > 0)
                    model.AV_Country = db.MasterStates.Where(s => s.StateRowID == model.AV_State).FirstOrDefault().CountryRowID;

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAddressInfoByQC(PQUpdateAddressViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add = model.AV_Add;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line1 = model.AV_Add_Line1;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line2 = model.AV_Add_Line2;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Buldng_Street_name = model.AV_Buldng_Street_name;
                            //context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Cand_Name = model.AV_Cand_Name;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_State = model.AV_State;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_District = model.AV_District;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_City = model.AV_City;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Pincode = model.AV_Pincode;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Landmark = model.AV_Landmark;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Type = model.AV_Add_Type;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Dur_of_Stay = model.AV_Dur_of_Stay;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_Name = model.AV_Owner_Name;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_ConNo = model.AV_Owner_ConNo;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_NickName = model.AV_NickName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Name_Chngd_Effect_Frm = model.AV_Name_Chngd_Effect_Frm;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Prov_Proof_Add = model.AV_Doc_Prov_Proof_Add;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AddressProofFileName = model.AddressProofFileName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Details = model.AV_Doc_Details;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).DocumentDetailsFileName = model.DocumentDetailsFileName;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails = model.AV_OtherDetails;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails2 = model.AV_OtherDetails2;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails3 = model.AV_OtherDetails3;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails4 = model.AV_OtherDetails4;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails5 = model.AV_OtherDetails5;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails6 = model.AV_OtherDetails6;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails7 = model.AV_OtherDetails7;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails8 = model.AV_OtherDetails8;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails9 = model.AV_OtherDetails9;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails10 = model.AV_OtherDetails10;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_CID_No = model.ATA_CID_No;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_Cmpny_Addr = model.ATA_Cmpny_Addr;

                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            if (model.CheckStatus == "Completed-DE")
                            {
                                context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = "Allocated-Mgr";
                            }

                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;

                            context.SaveChanges();

                            #region Save Check Status

                            // int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;
                            var CurrentStatus = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault();
                            if (model.CheckStatus == "Completed-DE")
                            {
                                if (CurrentStatus.TMCheckStatus == "Rejected")
                                {
                                    context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = "WIP-Pending";
                                    context.SaveChanges();

                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).DETMQCCheckStatus = "Completed-QC";
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).TMCheckStatus = "WIP-Pending";
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).TMAllocatedDate = model.ModifiedDate;
                                }
                                else
                                {
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).DETMQCCheckStatus = "Completed-QC";
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).MgrCheckStatus = "Allocated-Mgr";
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).MgrAllocatedTo = model.MgrAllocatedTo;
                                    context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).MgrAllocatedDate = model.ModifiedDate;
                                }

                            }

                            if (model.CheckStatus == "Insufficent")
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).DETMQCCheckStatus = "Insufficent-QC";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).InfSuffClearBy = 0;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).InfSuffClearComments = "";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == CurrentStatus.AddressStatusRowID).InfSuffClearDate = null;
                            }
                            context.SaveChanges();

                            if (model.CheckStatus == "Insufficent")
                            {
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).CaseStatus = "Insufficent";
                            }

                            context.SaveChanges();
                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressInfoByManager(PQUpdateAddressManagerViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TLCheckStatus = model.CheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TLAllocatedTo = model.TLAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TLAllocatedDate = model.ModifiedDate;
                            context.SaveChanges();
                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressInfoByTeamLeader(PQUpdateAddressTeamLeaderViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;


                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMCheckStatus = model.CheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMAllocatedTo = model.TMAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMAllocatedDate = model.ModifiedDate;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCCheckStatus = model.CheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCAllocatedTo = model.TMQCAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCAllocatedDate = model.ModifiedDate;


                            context.SaveChanges();
                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressByTeamMember(PQUpdateAddressTeamMemberViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMCheckStatus = model.CheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMAllocatedDate = model.ModifiedDate;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCCheckStatus = "";
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCAllocatedDate = model.ModifiedDate;

                            if (model.CheckStatus == "Re-Visit")
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRMgrCheckStatus = model.CheckStatus;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRMgrAllocatedDate = model.ModifiedDate;
                                context.SaveChanges();

                                //update Partner for Mobile APP
                                int AddressVarPtrRowId = context.PQAddressVarParteners.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().PQAddressVarPtrRowId;

                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).CheckStatus = model.CheckStatus;
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).CreatedDate = model.ModifiedDate;

                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).IsSynced = false;
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).SyncedBy = 0;
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).SyncedOn = null;

                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).AnyOtherComments = model.ActionRemark;
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).PtrStatus = "";
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).UpdatedBy = 0;
                                context.PQAddressVarParteners.Single(c => c.PQAddressVarPtrRowId == AddressVarPtrRowId).UpdatedDate = null;
                                context.SaveChanges();
                            }

                            if (model.CheckStatus == "Insufficent")
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCCheckStatus = model.CheckStatus;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).InfSuffRaiseRemarks = model.ActionRemark;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).InfSuffRaiseBy = model.ModifiedBy;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).InfSuffRaisedDate = model.ModifiedDate;
                                context.SaveChanges();
                            }
                            if (model.CheckStatus == "Rejected" || model.CheckStatus == "Funds Pending")
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).Remarks = model.ActionRemark;
                                context.SaveChanges();
                            }

                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressInfoByTeamLeaderReAllocated(PQUpdateAddressTeamLeaderViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            if (model.TMAllocatedTo > 0)
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMAllocatedTo = model.TMAllocatedTo;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMAllocatedDate = model.ModifiedDate;
                            }
                            if (model.TMQCAllocatedTo > 0)
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCAllocatedTo = model.TMQCAllocatedTo;
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMQCAllocatedDate = model.ModifiedDate;
                            }

                            context.SaveChanges();


                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #region Partner Concept

        public void UpdateAddressStatusByTeamMember(PQUpdateAddressStatusTeamMemberViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRMgrCheckStatus = model.CheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRMgrAllocatedTo = model.PTRMgrAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRMgrAllocatedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressStatusByPTRMgr(PQUpdateAddressStatusPTRMgrViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTLCheckStatus = "Team Leader-PRT";
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTLAllocatedTo = model.PTRTLAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTLAllocatedDate = model.ModifiedDate;
                            context.SaveChanges();
                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateAddressStatusByPTRTL(PQUpdateAddressStatusPTRTLViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Save Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTMCheckStatus = "Team Member-PRT";
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTMAllocatedTo = model.PTRTMAllocatedTo;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).PTRTMAllocatedDate = model.ModifiedDate;
                            context.SaveChanges();
                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool IsAddressCheckAllocatedToPartner(int AddressRowId)
        {
            try
            {
                var CheckPTRHas = db.PQAddressVarParteners.Where(p => p.AddressRowID == AddressRowId).FirstOrDefault();
                if (CheckPTRHas != null && CheckPTRHas.PQAddressVarPtrRowId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void RejectionUpdateAddressInfoByQC(UpdateAddressRejectionViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        string ActualCheckStatus = "WIP-Pending";
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = ActualCheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            #region Update Check Status

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMCheckStatus = ActualCheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMQCCheckStatus = "";
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).Remarks = model.INFRemarks;
                            context.SaveChanges();

                            #endregion

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool IfExistAddress(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0, string CheckStatus = "")
        {
            try
            {
                var listChecks = db.PQAddresss.Where(a => a.ClientRowID == ClientRowId && a.PersonalRowID == PersonalRowID
                     && a.CheckFamilyRowID == ChFamilRowId && a.SubCheckRowID == subCheckId && a.CheckStatus == CheckStatus).FirstOrDefault();
                if (listChecks != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IfExistAddressForDELeftMenu(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var listChecks = db.PQAddresss.Where(a => a.ClientRowID == ClientRowId && a.PersonalRowID == PersonalRowID
                     && a.CheckFamilyRowID == ChFamilRowId && a.SubCheckRowID == subCheckId).FirstOrDefault();
                if (listChecks != null)
                {
                    var ChkStatus = db.PQAddressStatus.Where(s => s.AddressRowID == listChecks.AddressRowID).FirstOrDefault();

                    if (ChkStatus.DETMCheckStatus == "WIP-Pending")
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IfExistAddressForQCLeftMenu(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var listChecks = db.PQAddresss.Where(a => a.ClientRowID == ClientRowId && a.PersonalRowID == PersonalRowID
                   && a.CheckFamilyRowID == ChFamilRowId && a.SubCheckRowID == subCheckId).FirstOrDefault();
                if (listChecks != null)
                {
                    var ChkStatus = db.PQAddressStatus.Where(s => s.AddressRowID == listChecks.AddressRowID).FirstOrDefault();

                    if (ChkStatus.DETMQCCheckStatus == "Completed" || ChkStatus.DETMQCCheckStatus == "Insufficent")
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ******* Temp Address *******

        public void AddTempAddressInformation(TempPQAddressViewModel model)
        {
            try
            {
                if (model != null)
                {
                    TempPQAddress entity = new TempPQAddress();
                    entity.ClientRowID = model.ClientRowID;
                    entity.PersonalRowID = model.PersonalRowID;
                    entity.ClientPackageRowID = model.ClientPackageRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.UniqueComponentID = model.UniqueComponentID;
                    entity.AV_Cand_Name = model.AV_Cand_Name;
                    entity.AV_Sec_Ref_No = model.AV_Sec_Ref_No;
                    entity.AV_Add = model.AV_Add;
                    entity.AV_Add_Line1 = model.AV_Add_Line1;
                    entity.AV_Add_Line2 = model.AV_Add_Line2;
                    entity.AV_Buldng_Street_name = model.AV_Buldng_Street_name;
                    entity.AV_State = model.AV_State;
                    entity.AV_District = model.AV_District;
                    entity.AV_City = model.AV_City;
                    entity.AV_Pincode = model.AV_Pincode;
                    entity.AV_Landmark = model.AV_Landmark;
                    entity.AV_Add_Type = model.AV_Add_Type;
                    entity.AV_Dur_of_Stay = model.AV_Dur_of_Stay;
                    entity.AV_Owner_Name = model.AV_Owner_Name;
                    entity.AV_Owner_ConNo = model.AV_Owner_ConNo;
                    entity.AV_NickName = model.AV_NickName;
                    entity.AV_Name_Chngd_Effect_Frm = model.AV_Name_Chngd_Effect_Frm;
                    entity.AV_Doc_Prov_Proof_Add = model.AV_Doc_Prov_Proof_Add;
                    entity.AddressProofFileName = model.AddressProofFileName;
                    entity.AV_Doc_Details = model.AV_Doc_Details;
                    entity.DocumentDetailsFileName = model.DocumentDetailsFileName;
                    //entity.AV_RationCard = model.AV_RationCard;
                    //entity.AV_TelephoneBill = model.AV_TelephoneBill;
                    //entity.AV_RentAgreement = model.AV_RentAgreement;
                    //entity.AV_Passport = model.AV_Passport;
                    //entity.AV_ElectricityBill = model.AV_ElectricityBill;
                    //entity.AV_GasSupplyBill = model.AV_GasSupplyBill;
                    //entity.AV_WaterBill = model.AV_WaterBill;
                    //entity.AV_OtherProof = model.AV_OtherProof;
                    //entity.AV_OtherDetails = model.AV_OtherDetails;
                    entity.AV_OtherDetails2 = model.AV_OtherDetails2;
                    entity.AV_OtherDetails3 = model.AV_OtherDetails3;
                    entity.AV_OtherDetails4 = model.AV_OtherDetails4;
                    entity.AV_OtherDetails5 = model.AV_OtherDetails5;
                    entity.AV_OtherDetails6 = model.AV_OtherDetails6;
                    entity.AV_OtherDetails7 = model.AV_OtherDetails7;
                    entity.AV_OtherDetails8 = model.AV_OtherDetails8;
                    entity.AV_OtherDetails9 = model.AV_OtherDetails9;
                    entity.AV_OtherDetails10 = model.AV_OtherDetails10;
                    entity.ATA_CID_No = model.ATA_CID_No;
                    entity.ATA_Cmpny_Addr = model.ATA_Cmpny_Addr;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreatedDate = model.CreatedDate;
                    //entity.OutDate = model.OutDate;
                    //entity.InternalOutDate = model.InternalOutDate;
                    entity.CheckStatus = model.CheckStatus;
                    entity.Remarks = model.Remarks;
                    entity.Status = model.Status;
                    db.TempPQAddresss.Add(entity);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetAllTempAddressByClientId(short ClientRowID = 0)
        {
            try
            {
                var data = db.TempPQAddresss.Where(p => p.ClientRowID == ClientRowID).ToList();
                return data.Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public TempPQUpdateAddressViewModel GetTempAddressForUpdateById(short AddressRowID)
        //{
        //    try
        //    {
        //        TempPQUpdateAddressViewModel model = new TempPQUpdateAddressViewModel();
        //        var entity = db.PQAddresss.Find(AddressRowID);
        //        if (entity != null)
        //        {
        //            model.ClientRowID = entity.ClientRowID;
        //            model.PersonalRowID = entity.PersonalRowID;
        //            model.ClientPackageRowID = entity.ClientPackageRowID;
        //            model.CheckFamilyRowID = entity.CheckFamilyRowID;
        //            model.SubCheckRowID = entity.SubCheckRowID;
        //            model.UniqueComponentID = entity.UniqueComponentID;
        //            model.AV_Cand_Name = entity.AV_Cand_Name;
        //            model.AV_Sec_Ref_No = entity.AV_Sec_Ref_No;
        //            model.AV_Add = entity.AV_Add;
        //            model.AV_Add_Line1 = entity.AV_Add_Line1;
        //            model.AV_Add_Line2 = entity.AV_Add_Line2;
        //            model.AV_Buldng_Street_name = entity.AV_Buldng_Street_name;
        //            model.AV_State = entity.AV_State;
        //            model.AV_District = entity.AV_District;
        //            model.AV_City = entity.AV_City;
        //            model.AV_Pincode = entity.AV_Pincode;
        //            model.AV_Landmark = entity.AV_Landmark;
        //            model.AV_Add_Type = entity.AV_Add_Type;
        //            model.AV_Dur_of_Stay = entity.AV_Dur_of_Stay;
        //            model.AV_Owner_Name = entity.AV_Owner_Name;
        //            model.AV_Owner_ConNo = entity.AV_Owner_ConNo;
        //            model.AV_NickName = entity.AV_NickName;
        //            model.AV_Name_Chngd_Effect_Frm = entity.AV_Name_Chngd_Effect_Frm;
        //            model.AV_Doc_Prov_Proof_Add = entity.AV_Doc_Prov_Proof_Add;
        //            model.AddressProofFileName = entity.AddressProofFileName;
        //            model.AV_Doc_Details = entity.AV_Doc_Details;
        //            model.DocumentDetailsFileName = entity.DocumentDetailsFileName;
        //            model.AV_RationCard = entity.AV_RationCard;
        //            model.AV_TelephoneBill = entity.AV_TelephoneBill;
        //            model.AV_RentAgreement = entity.AV_RentAgreement;
        //            model.AV_Passport = entity.AV_Passport;
        //            model.AV_ElectricityBill = entity.AV_ElectricityBill;
        //            model.AV_GasSupplyBill = entity.AV_GasSupplyBill;
        //            model.AV_WaterBill = entity.AV_WaterBill;
        //            model.AV_OtherProof = entity.AV_OtherProof;
        //            model.AV_OtherDetails = entity.AV_OtherDetails;
        //            model.AV_OtherDetails2 = entity.AV_OtherDetails2;
        //            model.AV_OtherDetails3 = entity.AV_OtherDetails3;
        //            model.AV_OtherDetails4 = entity.AV_OtherDetails4;
        //            model.AV_OtherDetails5 = entity.AV_OtherDetails5;
        //            model.AV_OtherDetails6 = entity.AV_OtherDetails6;
        //            model.AV_OtherDetails7 = entity.AV_OtherDetails7;
        //            model.AV_OtherDetails8 = entity.AV_OtherDetails8;
        //            model.AV_OtherDetails9 = entity.AV_OtherDetails9;
        //            model.AV_OtherDetails10 = entity.AV_OtherDetails10;
        //            model.ATA_CID_No = entity.ATA_CID_No;
        //            model.ATA_Cmpny_Addr = entity.ATA_Cmpny_Addr;
        //            model.CheckStatus = entity.CheckStatus;
        //            model.CaseStatus = entity.CaseStatus;
        //            model.Remarks = entity.Remarks;
        //        }
        //        else
        //        {
        //            throw new Exception("Invalid Id!");
        //        }
        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public void UpdateTempAddressInformation(TempPQAddressViewModel model)
        {
            try
            {
                if (model != null)
                {
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add = model.AV_Add;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line1 = model.AV_Add_Line1;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Line2 = model.AV_Add_Line2;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Buldng_Street_name = model.AV_Buldng_Street_name;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_State = model.AV_State;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_District = model.AV_District;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_City = model.AV_City;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Pincode = model.AV_Pincode;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Landmark = model.AV_Landmark;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Add_Type = model.AV_Add_Type;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Dur_of_Stay = model.AV_Dur_of_Stay;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_Name = model.AV_Owner_Name;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Owner_ConNo = model.AV_Owner_ConNo;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_NickName = model.AV_NickName;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Name_Chngd_Effect_Frm = model.AV_Name_Chngd_Effect_Frm;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Prov_Proof_Add = model.AV_Doc_Prov_Proof_Add;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AddressProofFileName = model.AddressProofFileName;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Doc_Details = model.AV_Doc_Details;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).DocumentDetailsFileName = model.DocumentDetailsFileName;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_RationCard = model.AV_RationCard;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_TelephoneBill = model.AV_TelephoneBill;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_RentAgreement = model.AV_RentAgreement;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Passport = model.AV_Passport;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_ElectricityBill = model.AV_ElectricityBill;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_GasSupplyBill = model.AV_GasSupplyBill;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_WaterBill = model.AV_WaterBill;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherProof = model.AV_OtherProof;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails = model.AV_OtherDetails;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails2 = model.AV_OtherDetails2;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails3 = model.AV_OtherDetails3;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails4 = model.AV_OtherDetails4;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails5 = model.AV_OtherDetails5;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails6 = model.AV_OtherDetails6;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails7 = model.AV_OtherDetails7;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails8 = model.AV_OtherDetails8;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails9 = model.AV_OtherDetails9;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_OtherDetails10 = model.AV_OtherDetails10;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_CID_No = model.ATA_CID_No;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ATA_Cmpny_Addr = model.ATA_Cmpny_Addr;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                    db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).AV_Cand_Name = model.AV_Cand_Name;
                    //db.TempPQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TempPQAddressViewModel GetAddressBySelf(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                TempPQAddressViewModel model = new TempPQAddressViewModel();
                model = db.TempPQAddresss.Where(a => a.ClientRowID == ClientRowId && a.PersonalRowID == PersonalRowID
                && a.CheckFamilyRowID == ChFamilRowId && a.SubCheckRowID == subCheckId).Select(a => new TempPQAddressViewModel
                {
                    AddressRowID = a.AddressRowID,
                    ClientRowID = a.ClientRowID,
                    PersonalRowID = a.PersonalRowID,
                    ClientPackageRowID = a.ClientPackageRowID,
                    CheckFamilyRowID = a.CheckFamilyRowID,
                    SubCheckRowID = a.SubCheckRowID,
                    UniqueComponentID = a.UniqueComponentID,
                    AV_Add = a.AV_Add,
                    AV_Add_Line1 = a.AV_Add_Line1,
                    AV_Add_Line2 = a.AV_Add_Line2,
                    AV_Buldng_Street_name = a.AV_Buldng_Street_name,
                    AV_City = a.AV_City,
                    AV_District = a.AV_District,
                    AV_State = a.AV_State,
                    AV_Pincode = a.AV_Pincode,
                    AV_Landmark = a.AV_Landmark,
                    AV_Add_Type = a.AV_Add_Type,
                    AV_Dur_of_Stay = a.AV_Dur_of_Stay,
                    AV_Owner_Name = a.AV_Owner_Name,
                    AV_Owner_ConNo = a.AV_Owner_ConNo,
                    AV_NickName = a.AV_NickName,
                    AV_Name_Chngd_Effect_Frm = a.AV_Name_Chngd_Effect_Frm,
                    AV_Doc_Prov_Proof_Add = a.AV_Doc_Prov_Proof_Add,
                    AddressProofFileName = a.AddressProofFileName,
                    AV_Doc_Details = a.AV_Doc_Details,
                    DocumentDetailsFileName = a.DocumentDetailsFileName,
                    //AV_RationCard = a.AV_RationCard,
                    //AV_TelephoneBill = a.AV_TelephoneBill,
                    //AV_RentAgreement = a.AV_RentAgreement,
                    //AV_Passport = a.AV_Passport,
                    //AV_ElectricityBill = a.AV_ElectricityBill,
                    //AV_GasSupplyBill = a.AV_GasSupplyBill,
                    //AV_WaterBill = a.AV_WaterBill,
                    //AV_OtherProof = a.AV_OtherProof,
                    AV_OtherDetails = a.AV_OtherDetails,
                    AV_OtherDetails2 = a.AV_OtherDetails2,
                    AV_OtherDetails3 = a.AV_OtherDetails3,
                    AV_OtherDetails4 = a.AV_OtherDetails4,
                    AV_OtherDetails5 = a.AV_OtherDetails5,
                    AV_OtherDetails6 = a.AV_OtherDetails6,
                    AV_OtherDetails7 = a.AV_OtherDetails7,
                    AV_OtherDetails8 = a.AV_OtherDetails8,
                    AV_OtherDetails9 = a.AV_OtherDetails9,
                    AV_OtherDetails10 = a.AV_OtherDetails10,
                    ATA_CID_No = a.ATA_CID_No,
                    ATA_Cmpny_Addr = a.ATA_Cmpny_Addr,
                    CheckStatus = a.CheckStatus,
                    AV_Cand_Name = a.AV_Cand_Name,
                    //CaseStatus = a.CaseStatus
                }).FirstOrDefault();

                if (model != null && model.AV_State > 0)
                    model.AV_Country = db.MasterStates.Where(s => s.StateRowID == model.AV_State).FirstOrDefault().CountryRowID;

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public PQAddressInsuffListPagedModel GetAllAddressInsuffListForDETL(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", int PersonalId = 0, string spocEmail = "", short TeamMemberRowid = 0, int ClientUserRowID = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQAddressStatus> data = db.PQAddressStatus.Include("PQAddress").Where(p => (p.DETMQCCheckStatus == "Insufficent-QC" || p.TMQCCheckStatus == "Insufficent-QC") && p.InfSuffClearBy == 0);

                if (TeamMemberRowid > 0)
                {
                    data = data.Where(b => b.DETLAllocatedTo == TeamMemberRowid && !string.IsNullOrEmpty(b.InfSuffClearComments));
                }
                else
                {
                    data = data.Where(b => string.IsNullOrEmpty(b.InfSuffClearComments));
                }

                if (ClientUserRowID > 0)
                {
                    data = data.Where(b => b.PQAddress.PQPersonal.ClientUserRowID == ClientUserRowID);
                }

                if (PersonalId == 0)
                {
                    if (ClientRowID > 0)
                    {
                        data = data.Where(b => b.PQAddress.ClientRowID == ClientRowID);
                    }

                    if (!string.IsNullOrEmpty(spocEmail))
                    {
                        var Clients = db.PQClientMasters.Where(s => s.SpocEmailID.Contains(spocEmail)).Select(s => s.ClientRowID).ToList();
                        data = data.Where(a => Clients.Contains(a.PQAddress.ClientRowID));
                    }

                    if (!string.IsNullOrEmpty(RecievingToDate) && !string.IsNullOrEmpty(RecievingFromDate))
                    {
                        DateTime startDate = Convert.ToDateTime(RecievingFromDate);
                        DateTime EndDate = Convert.ToDateTime(RecievingToDate);

                        data = data.Where(b => DbFunctions.TruncateTime(b.PQAddress.PQPersonal.OrderDate) >= startDate.Date && DbFunctions.TruncateTime(b.PQAddress.PQPersonal.OrderDate) <= EndDate.Date);
                    }

                    if (!string.IsNullOrEmpty(CompletedToDate) && !string.IsNullOrEmpty(CompletedFromDate))
                    {
                        DateTime startDate = Convert.ToDateTime(CompletedFromDate);
                        DateTime EndDate = Convert.ToDateTime(CompletedToDate);

                        data = data.Where(b => DbFunctions.TruncateTime(b.PQAddress.CreatedDate) >= startDate.Date && DbFunctions.TruncateTime(b.PQAddress.CreatedDate) <= EndDate.Date);
                    }

                    if (!string.IsNullOrEmpty(Search))
                    {
                        data = data.Where(b => (b.PQAddress.PQPersonal.Name + " " + b.PQAddress.PQPersonal.MiddleName + " " + b.PQAddress.PQPersonal.LastName).ToString().Replace(" ", "").Contains(Search.Replace(" ", "")) || b.PQAddress.PQPersonal.ClientRefID == Search);
                    }
                }
                else
                {
                    data = data.Where(b => b.PQAddress.PersonalRowID == PersonalId);
                }

                switch (sort)
                {
                    default:
                        data = sortDir == "asc" ? data.OrderByDescending(d => d.AddressStatusRowID) : data.OrderBy(d => d.AddressStatusRowID);
                        break;
                }

                PQAddressInsuffListPagedModel model = new PQAddressInsuffListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.PQAllInsuffAddresses = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQAddressInsuffViewModel
                {
                    AddressRowID = item.AddressRowID,
                    ClientRowID = item.PQAddress.ClientRowID,
                    ClientName = item.PQAddress.PQClientMaster.MasterAbbreviation.ClientName + " " + item.PQAddress.PQClientMaster.MasterClientSubGroup.ClientSubGroupName,
                    PersonalRowID = item.PQAddress.PersonalRowID,
                    CandidateName = item.PQAddress.PQPersonal.CandTitle + " " + item.PQAddress.PQPersonal.Name + " " + item.PQAddress.PQPersonal.MiddleName + " " + item.PQAddress.PQPersonal.LastName,
                    SubCheckRowID = item.PQAddress.SubCheckRowID,
                    CheckFamilyRowID = item.PQAddress.CheckFamilyRowID,
                    SubCheckName = item.PQAddress.MasterSubCheckFamily.SubCheckName,
                    CompanyRefNo = item.PQAddress.AV_Sec_Ref_No,
                    InfSuffRaiseBy = db.TeamMembers.Where(t => t.TeamMemberRowID == item.InfSuffRaiseBy).Select(t => t.TMFirstName + " " + t.TMLastName).FirstOrDefault(),
                    InfSuffRaisedDate = item.InfSuffRaisedDate,
                    INFRemarks = item.InfSuffRaiseRemarks,
                    CreatedDate = item.InfSuffRaisedDate,
                    CheckStatus = item.PQAddress.CheckStatus,
                    ReWorkCheckStatus = item.PQAddress.ReWorkCheckStatus,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdatePQAddressInsuffClearViewModel GetPQAddressDetailsById(int AddressRowID = 0)
        {
            try
            {
                UpdatePQAddressInsuffClearViewModel model = new UpdatePQAddressInsuffClearViewModel();
                //var entity = db.PQAddresss.Find(AddressRowID);

                var entity = db.PQAddressStatus.Where(a => a.AddressRowID == AddressRowID).FirstOrDefault();
                if (entity != null)
                {
                    model.AddressRowID = entity.AddressRowID;
                    model.ClientRowID = entity.PQAddress.ClientRowID;
                    model.PersonalRowID = entity.PQAddress.PersonalRowID;
                    model.SubCheckRowID = entity.PQAddress.SubCheckRowID;
                    model.UniqueComponentID = entity.PQAddress.UniqueComponentID;
                    model.INFRemarks = entity.InfSuffClearComments;
                    model.CheckStatus = entity.PQAddress.CheckStatus;
                    model.ReWorkCheckStatus = entity.PQAddress.ReWorkCheckStatus;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePQAddressInsuffClear(UpdatePQAddressInsuffClearViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            string ScnCheckStatus = "WIP-Pending";

                            var PQAddressStatusId = context.PQAddressStatus.Where(c => c.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;
                            
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == PQAddressStatusId).DETMCheckStatus = ScnCheckStatus;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == PQAddressStatusId).InfSuffClearBy = model.InfSuffClearBy;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == PQAddressStatusId).InfSuffClearDate = model.InfSuffClearDate;
                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == PQAddressStatusId).InfSuffClearComments = model.INFRemarks;
                            context.SaveChanges();

                            //Check Status Update
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = ScnCheckStatus;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedBy = model.ModifiedBy;
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).ModifiedDate = model.ModifiedDate;
                            context.SaveChanges();

                            context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).DECaseStatus = "WIP";
                            context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).AllocatedToDEDate = model.InfSuffClearDate;
                            context.SaveChanges();
                        }

                        transaction.Commit();

                        if (IsCheckhasInfsuff(model.ClientRowID, model.PersonalRowID))
                        {
                            db.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).CaseStatus = "WIP";
                            SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool IsCheckhasInfsuff(short ClientRowID = 0, int PersonalRowID = 0)
        {
            try
            {
                bool flag = true;

                var Address = db.PQAddresss.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (Address != null && Address.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var Employment = db.PQEmployments.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (Employment != null && Employment.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var Education = db.PQEducations.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (Education != null && Education.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var Reference = db.PQReferences.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (Reference != null && Reference.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var Criminal = db.PQCriminals.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (Criminal != null && Criminal.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var NationalIdentity = db.PQNationalIdentities.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (NationalIdentity != null && NationalIdentity.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                var SpecialCheck = db.PQSpecialChecks.Where(a => a.ClientRowID == ClientRowID && a.PersonalRowID == PersonalRowID).FirstOrDefault();
                if (SpecialCheck != null && SpecialCheck.CheckStatus == "Insufficent")
                {
                    flag = false;
                }

                return flag;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ViewAddressInfoDETL(ViewAddressViewModel model)
        {
            {
                using (DataContext context = new DataContext())
                {
                    using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (model != null)
                            {
                                context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                                context.SaveChanges();

                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).DECaseStatus = "WIP";
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).AllocatedToDEDate = DateTime.Now;
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).DEQCCaseStatus = "WIP";
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).AllocatedToDEQCDate = DateTime.Now;
                                context.SaveChanges();

                                int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMCheckStatus = model.CheckStatus;
                                context.SaveChanges();

                                transaction.Commit();
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public void UpdateAddressInfoRejectionByDEQC(ViewAddressViewModel model, bool flag = false)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.SaveChanges();

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;
                            if (flag)
                            {
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).DECaseStatus = "WIP";
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).AllocatedToDEDate = DateTime.Now;
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).DEQCCaseStatus = "WIP";
                                context.PQPersonals.Single(c => c.PersonalRowID == model.PersonalRowID).AllocatedToDEQCDate = DateTime.Now;
                                context.SaveChanges();

                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMQCCheckStatus = "";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMCheckStatus = model.CheckStatus;
                            }
                            else
                            {
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).DETMQCCheckStatus = "Completed-QC";
                                context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMCheckStatus = model.CheckStatus;
                            }

                            context.SaveChanges();

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ViewAddressInfoByVrifierTL(ViewAddressViewModel model)
        {
            using (DataContext context = new DataContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (model != null)
                        {
                            context.PQAddresss.Single(c => c.AddressRowID == model.AddressRowID).CheckStatus = model.CheckStatus;
                            context.SaveChanges();

                            int statusId = context.PQAddressStatus.Where(p => p.AddressRowID == model.AddressRowID).FirstOrDefault().AddressStatusRowID;

                            context.PQAddressStatus.Single(c => c.AddressStatusRowID == statusId).TMCheckStatus = model.CheckStatus;
                            context.SaveChanges();

                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
