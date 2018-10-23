using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebAppBGV.CommonMethods
{
    public class clsValidationMethods
    {
        public static bool IsValidEmail(string email)
        {
            var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return !string.IsNullOrEmpty(email) && r.IsMatch(email);
        }

        public static bool IsValidFileByExt(string Extension)
        {
            string[] AllowedFileExtensions = new string[] { ".doc", ".docx", ".txt", ".pdf", ".xls", ".xlsx" };

            if (!AllowedFileExtensions.Contains(Extension))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidNewsFileByExt(string Extension)
        {
            string[] AllowedFileExtensions = new string[] { ".doc", ".docx", ".txt", ".pdf", ".xls", ".xlsx", ".jpeg", ".png", ".jpg" };

            if (!AllowedFileExtensions.Contains(Extension))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidImagesByExt(string Extension)
        {
            string[] AllowedFileExtensions = new string[] { ".gif", ".jpeg", ".png", ".jpg" };

            if (!AllowedFileExtensions.Contains(Extension))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       
    }
}