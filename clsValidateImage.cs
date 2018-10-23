using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class clsValidateImage
    {
    }

    //Customized data annotation validator for uploading file
    public class ValidateImageFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024; //1 MB
                string[] AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png" };

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return false;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Image of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "Image is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

    public class ValidateImageFileWithNullCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024 * 3; //1 MB
                string[] AllowedFileExtensions = new string[] { ".pdf", ".doc", ".docx",".jpg", ".jpeg", ".png" };

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return true;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Image of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "Image is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class ValidateFileWithNullCheckAttributeInPartner : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024 * 3; //1 MB
                string[] AllowedFileExtensions = new string[] { ".pdf", ".jpg", ".jpeg", ".png" };

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return true;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload Image of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "Image is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    //Customized data annotation validator for uploading file
    public class ValidateLargeFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024 * 30; //30 MB
                //string[] AllowedFileExtensions = new string[] { ".pdf", ".doc", ".docx",".jpg", ".jpeg", ".gif", ".png" };
                string[] AllowedFileExtensions = new string[] { ".pdf", ".jpg", ".jpeg",".png" };
                var file = value as HttpPostedFileBase;

                if (file == null)
                    return false;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload File of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "File is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

    //Customized data annotation validator for uploading file
    public class ValidateLargeFileCandidateUploadDocs : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024 * 30; //30 MB
                string[] AllowedFileExtensions = new string[] {".doc", ".docx", ".xls", ".xlsx", ".pdf",".rtf", ".txt", ".jpeg",".jpg", ".png", ".eml", ".email",".msg",".zip",".rar" };

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return true;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload File of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "File is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

    //Customized data annotation validator for uploading file
    public class ValidateLargeFileCandidateUploadExcelDocs : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024 * 30; //30 MB
                string[] AllowedFileExtensions = new string[] {".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".gif", ".png", ".zip", ".rar" };

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return true;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload File of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "File is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }

    public class ValidateLargeFileClientCandidateUploadExcelDocs : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int MaxContentLength = 1024 * 1024; //1MB
                string[] AllowedFileExtensions = new string[] { ".xls", ".xlsx"};

                var file = value as HttpPostedFileBase;

                if (file == null)
                    return true;
                else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Please upload File of type: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
                else if (file.ContentLength > MaxContentLength)
                {
                    ErrorMessage = "File is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "KB";
                    return false;
                }
                else
                    return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}