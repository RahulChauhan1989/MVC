using BAL;
using BAL.ProvidedInfoRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using ViewModels;
using ViewModels.ProvidedInfoViewModel;

namespace WebAppBGV.CommonMethods
{
    public class clsCommonMethods
    {
        #region Encryption and Decryption Implementation

        public static string PasswordEncrypt(string strText)
        {
            string strEncrKey;
            strEncrKey = "&%#@?,:*";

            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(strEncrKey);
                byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write);
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string PasswordDecrypt(string strText)
        {
            string sDecrKey;
            sDecrKey = "&%#@?,:*";

            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[strText.Length];
            try
            {
                byte[] byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        #endregion

        #region "* Data Security Implementation *"

        /// <summary> 
        /// This function will Clean the Input data and replace Single Quotes and "SCRIPT" tag and make it WEB Save and prevent Hacking 
        /// </summary> 
        /// <param name="SourceData">Variable to be replaced</param> 
        /// <returns>Cleaned Data</returns> 
        /// <remarks></remarks> 
        public string Clean(string SourceData)
        {
            string CleanedData = Clean(SourceData, true, false);
            return CleanedData;
        }

        public string Clean(string SourceData, bool HTMLAllowed, bool scriptTagAllowed)
        {
            string SRC;
            SRC = "";
            if (SourceData != "" & SourceData != null)
            {

                SRC = SourceData;
                // SRC = SourceData.Trim();
                // Replace single quote 
                SRC = SRC.Replace("'", "''");
                SRC = SRC.Replace("<", "&lt;");
                SRC = SRC.Replace(">", "&gt;");

                if (HTMLAllowed == false)
                {
                    SRC = HttpContext.Current.Server.UrlEncode(SRC);
                }
                else
                {
                    if (scriptTagAllowed == false)
                    {
                        // Replace SCRIPT Tag 

                        SRC = SRC.Replace("<script", "&lt;script");
                        SRC = SRC.Replace("</script", "&lt;/script");

                        SRC = SRC.Replace("<input", "&lt;input");
                        SRC = SRC.Replace("</input", "&lt;/input");

                        SRC = SRC.Replace("<form", "&lt;form");
                        SRC = SRC.Replace("</form", "&lt;/form");

                        SRC = SRC.Replace("<embed", "&lt;embed");
                        SRC = SRC.Replace("</embed", "&lt;/embed");


                        SRC = SRC.Replace("<textarea", "&lt;textarea");
                        SRC = SRC.Replace("</textarea", "&lt;/textarea");

                        SRC = SRC.Replace("<select", "&lt;select");
                        SRC = SRC.Replace("</select", "&lt;/select");

                        SRC = SRC.Replace("<img", "&lt;img");
                        SRC = SRC.Replace("</img", "&lt;/img");
                    }
                }
            }

            return SRC;
        }

        #endregion

        #region Error Log Implementation
        
        static string sLogFormat = string.Empty;
        static string sErrorTime = string.Empty;

        public static void ErrorLog(string sPathName, string sErrMsg, string sStackTrace)
        {
            CreateLogFiles();
            StreamWriter streamWriter = new StreamWriter(string.Concat(sPathName, "(", sErrorTime, ").txt"), true);
            streamWriter.WriteLine(string.Concat(sLogFormat, sErrMsg));
            streamWriter.WriteLine(sStackTrace);
            streamWriter.WriteLine("__________________________________________________________________");
            streamWriter.Flush();
            streamWriter.Close();
        }
        
        public static void UserLog(string sPathName, string sErrMsg, string sStackTrace, string sUType)
        {
            CreateLogFiles();
            StreamWriter streamWriter = new StreamWriter(string.Concat(sPathName, "(", sErrorTime, ").txt"), true);
            streamWriter.WriteLine(sLogFormat);
            streamWriter.WriteLine("Unauthorized Attempted User Details");
            streamWriter.WriteLine(string.Concat("User Type  : ", sUType));
            streamWriter.WriteLine(string.Concat("User Name : ", sErrMsg));
            streamWriter.WriteLine(string.Concat("Password   : ", sStackTrace));
            streamWriter.WriteLine("__________________________________________________________________");
            streamWriter.Flush();
            streamWriter.Close();
        }

        protected static void CreateLogFiles()
        {
            string str = DateTime.Now.ToShortDateString().ToString();
            DateTime now = DateTime.Now;
            sLogFormat = string.Concat(str, " ", now.ToLongTimeString().ToString(), " ==> ");
            int year = DateTime.Now.Year;
            string str1 = year.ToString();
            year = DateTime.Now.Month;
            string str2 = year.ToString();
            year = DateTime.Now.Day;
            string str3 = year.ToString();
            string[] strArrays = new string[] { str3, "-", str2, "-", str1 };
            sErrorTime = string.Concat(strArrays);
        }

        public static void AddPQLogTrasaction(int PersonalRowID, string PageName, string CaseStatus, string UniqueComponentID, string TransactionAction)
        {
            try
            {
                AddPQLogTrasactionViewModel logModel = new AddPQLogTrasactionViewModel();
                logModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                logModel.TeamMemberRowID = Convert.ToInt16(HttpContext.Current.Session["TeamMemberRowID"]);
                logModel.UserType = HttpContext.Current.Session["Designation"].ToString();
                logModel.PageName = PageName;   // "Add Candidate";
                logModel.CaseStatus = CaseStatus;   // "Candidate Reference Generated";
                logModel.UniqueComponentID = UniqueComponentID; // "Input";
                logModel.TransactionDate = DateTime.Now;
                logModel.TransactionAction = TransactionAction; // "Insert";
                logModel.Status = 1;

                IPQLogTrasactionRepository repoPQLogTrasaction = new PQLogTrasactionRepository();
                repoPQLogTrasaction.AddPQLogTrasaction(logModel);
                repoPQLogTrasaction.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddPQLogTrasactionByClient(int PersonalRowID, string PageName, string CaseStatus, string UniqueComponentID, string TransactionAction)
        {
            try
            {
                AddPQLogTrasactionViewModel logModel = new AddPQLogTrasactionViewModel();
                logModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                logModel.TeamMemberRowID = Convert.ToInt16(HttpContext.Current.Session["ClientRowID"]);
                logModel.UserType = HttpContext.Current.Session["ClientName"].ToString();
                logModel.PageName = PageName;   // "Add Candidate";
                logModel.CaseStatus = CaseStatus;   // "Candidate Reference Generated";
                logModel.UniqueComponentID = UniqueComponentID; // "Input";
                logModel.TransactionDate = DateTime.Now;
                logModel.TransactionAction = TransactionAction; // "Insert";
                logModel.Status = 1;

                IPQLogTrasactionRepository repoPQLogTrasaction = new PQLogTrasactionRepository();
                repoPQLogTrasaction.AddPQLogTrasaction(logModel);
                repoPQLogTrasaction.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddPQLogTrasactionByCandidate(int PersonalRowID, string PageName, string CaseStatus, string UniqueComponentID, string TransactionAction)
        {
            try
            {
                AddPQLogTrasactionViewModel logModel = new AddPQLogTrasactionViewModel();
                logModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                logModel.TeamMemberRowID = Convert.ToInt16(HttpContext.Current.Session["TempPersonalRowID"]);
                logModel.UserType = "Candidate";
                logModel.PageName = PageName;   // "Add Candidate";
                logModel.CaseStatus = CaseStatus;   // "Candidate Reference Generated";
                logModel.UniqueComponentID = UniqueComponentID; // "Input";
                logModel.TransactionDate = DateTime.Now;
                logModel.TransactionAction = TransactionAction; // "Insert";
                logModel.Status = 1;

                IPQLogTrasactionRepository repoPQLogTrasaction = new PQLogTrasactionRepository();
                repoPQLogTrasaction.AddPQLogTrasaction(logModel);
                repoPQLogTrasaction.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddPQLogTrasactionByPartner(int PersonalRowID, string PageName, string CaseStatus, string UniqueComponentID, string TransactionAction)
        {
            try
            {
                AddPQLogTrasactionViewModel logModel = new AddPQLogTrasactionViewModel();
                logModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                logModel.TeamMemberRowID = Convert.ToInt16(HttpContext.Current.Session["VendorRowID"]);
                logModel.UserType ="Partner";
                logModel.PageName = PageName;   // "Add Candidate";
                logModel.CaseStatus = CaseStatus;   // "Candidate Reference Generated";
                logModel.UniqueComponentID = UniqueComponentID; // "Input";
                logModel.TransactionDate = DateTime.Now;
                logModel.TransactionAction = TransactionAction; // "Insert";
                logModel.Status = 1;

                IPQLogTrasactionRepository repoPQLogTrasaction = new PQLogTrasactionRepository();
                repoPQLogTrasaction.AddPQLogTrasaction(logModel);
                repoPQLogTrasaction.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Case/Check Action History Save 

        public static void AddCaseActionHistory(int PersonalRowID, string CaseStatus, string Remarks)
        {
            try
            {
                AddCaseActionHistoryViewModel caseModel = new AddCaseActionHistoryViewModel();
                caseModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                caseModel.Remarks = Remarks;      // "Description of the case status";
                caseModel.CaseStatus = CaseStatus;   // "Case Status Of Case";
                caseModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["TeamMemberRowID"]); ;    // "UpdatedBy";
                caseModel.UpdatedByNameDesig = HttpContext.Current.Session["TeamMemberName"].ToString() + " (" + HttpContext.Current.Session["Designation"].ToString() + ")";
                caseModel.UpdatedDate = DateTime.Now;
                caseModel.Status = 1;

                ICaseActionHistoryRepository repoCaseActionHistory = new CaseActionHistoryRepository();
                repoCaseActionHistory.AddCaseActionHistory(caseModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCaseActionHistoryByClient(int PersonalRowID, string CaseStatus, string Remarks)
        {
            try
            {
                AddCaseActionHistoryViewModel caseModel = new AddCaseActionHistoryViewModel();
                caseModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                caseModel.Remarks = Remarks;      // "Description of the case status";
                caseModel.CaseStatus = CaseStatus;   // "Case Status Of Case";
                caseModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["ClientRowID"]);  // "UpdatedBy";
                caseModel.UpdatedByNameDesig = HttpContext.Current.Session["ClientName"].ToString();
                caseModel.UpdatedDate = DateTime.Now;
                caseModel.Status = 1;

                ICaseActionHistoryRepository repoCaseActionHistory = new CaseActionHistoryRepository();
                repoCaseActionHistory.AddCaseActionHistory(caseModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCaseActionHistoryByCandidate(int PersonalRowID, string CaseStatus, string Remarks)
        {
            try
            {
                AddCaseActionHistoryViewModel caseModel = new AddCaseActionHistoryViewModel();
                caseModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                caseModel.Remarks = Remarks;      // "Description of the case status";
                caseModel.CaseStatus = CaseStatus;   // "Case Status Of Case";
                caseModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["TempPersonalRowID"]);  // "UpdatedBy";
                caseModel.UpdatedByNameDesig = HttpContext.Current.Session["LoginCandidateName"].ToString();
                caseModel.UpdatedDate = DateTime.Now;
                caseModel.Status = 1;

                ICaseActionHistoryRepository repoCaseActionHistory = new CaseActionHistoryRepository();
                repoCaseActionHistory.AddCaseActionHistory(caseModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCheckActionHistory(int PersonalRowID, short SubCheckRowID, string CheckStatus, string Remarks)
        {
            try
            {
                AddCheckActionHistoryViewModel checkModel = new AddCheckActionHistoryViewModel();
                checkModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                checkModel.SubCheckRowID = SubCheckRowID;  // SubCheckRo
                checkModel.Remarks = Remarks;   // "Description of the check status";
                checkModel.CheckStatus = CheckStatus;   // "Candidate check status";
                checkModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["TeamMemberRowID"]);
                checkModel.UpdatedByNameDesig = HttpContext.Current.Session["TeamMemberName"].ToString() + " (" + HttpContext.Current.Session["Designation"].ToString() + ")";
                checkModel.UpdatedDate = DateTime.Now;
                checkModel.Status = 1;

                ICheckActionHistoryRepository repoCaseActionHistory = new CheckActionHistoryRepository();
                repoCaseActionHistory.AddCheckActionHistory(checkModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCheckActionHistoryByClient(int PersonalRowID, short SubCheckRowID, string CheckStatus, string Remarks)
        {
            try
            {
                AddCheckActionHistoryViewModel checkModel = new AddCheckActionHistoryViewModel();
                checkModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                checkModel.SubCheckRowID = SubCheckRowID;  // SubCheckRo
                checkModel.Remarks = Remarks;   // "Description of the check status";
                checkModel.CheckStatus = CheckStatus;   // "Candidate check status";
                checkModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["ClientRowID"]);
                checkModel.UpdatedByNameDesig = HttpContext.Current.Session["ClientName"].ToString();
                checkModel.UpdatedDate = DateTime.Now;
                checkModel.Status = 1;

                ICheckActionHistoryRepository repoCaseActionHistory = new CheckActionHistoryRepository();
                repoCaseActionHistory.AddCheckActionHistory(checkModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCheckActionHistoryByCandidate(int PersonalRowID, short SubCheckRowID, string CheckStatus, string Remarks)
        {
            try
            {
                AddCheckActionHistoryViewModel checkModel = new AddCheckActionHistoryViewModel();
                checkModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                checkModel.SubCheckRowID = SubCheckRowID;  // SubCheckRo
                checkModel.Remarks = Remarks;   // "Description of the check status";
                checkModel.CheckStatus = CheckStatus;   // "Candidate check status";
                checkModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["TempPersonalRowID"]);
                checkModel.UpdatedByNameDesig = HttpContext.Current.Session["LoginCandidateName"].ToString();
                checkModel.UpdatedDate = DateTime.Now;
                checkModel.Status = 1;

                ICheckActionHistoryRepository repoCaseActionHistory = new CheckActionHistoryRepository();
                repoCaseActionHistory.AddCheckActionHistory(checkModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddCheckActionHistoryByPartner(int PersonalRowID, short SubCheckRowID, string CheckStatus, string Remarks)
        {
            try
            {
                AddCheckActionHistoryViewModel checkModel = new AddCheckActionHistoryViewModel();
                checkModel.PersonalRowID = PersonalRowID; // model.PersonalRowID;
                checkModel.SubCheckRowID = SubCheckRowID;  // SubCheckRo
                checkModel.Remarks = Remarks;   // "Description of the check status";
                checkModel.CheckStatus = CheckStatus;   // "Candidate check status";
                checkModel.UpdatedBy = Convert.ToInt16(HttpContext.Current.Session["VendorRowID"]);
                checkModel.UpdatedByNameDesig = HttpContext.Current.Session["VendorName"].ToString();
                checkModel.UpdatedDate = DateTime.Now;
                checkModel.Status = 1;

                ICheckActionHistoryRepository repoCaseActionHistory = new CheckActionHistoryRepository();
                repoCaseActionHistory.AddCheckActionHistory(checkModel);
                repoCaseActionHistory.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

    }
}