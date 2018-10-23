using BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ViewModels;

namespace WebAppBGV.CommonMethods
{
    public class clsSendMail
    {
        //private string Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();
        //private string Port = ConfigurationManager.AppSettings["SMTPPort"].ToString();
        //private string UserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
        //private string Pass = ConfigurationManager.AppSettings["SMTPPwd"].ToString();
        //private string EnableSsl = ConfigurationManager.AppSettings["EnableSsl"].ToString();

        ICompanyRepository repoCompany = new CompanyRepository();
        private string Host = string.Empty;
        private string Port = string.Empty;
        private string UserID = string.Empty;
        private string Pass = string.Empty;
        private bool EnableSsl = false;

        public clsSendMail()
        {
            try
            {
                CompanyMailAuthenticationViewModel model = repoCompany.GetMailAuthenticationById(1);

                if (model != null)
                {
                    this.Host = model.SMTPServer;
                    this.Port = model.Port;
                    this.UserID = model.SMTPUserName;
                    this.Pass = clsCommonMethods.PasswordDecrypt(model.SMTPPassword);
                    this.EnableSsl = model.EnableSsl;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public clsSendMail(string SMTPServer, string SMTPPort, string SMTPUserID, string SMTPPwd, bool EnableSsl)
        {
            this.Host = SMTPServer;
            this.Port = SMTPPort;
            this.UserID = SMTPUserID;
            this.Pass = SMTPPwd;
            this.EnableSsl = EnableSsl;
        }

        public bool SendMail(string display, string from, string to, string subj, string msg)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                //+++++++++++ Multiple To
                if (to.Length > 0 && from.Length > 0)
                {
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from, display);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);

                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To & From are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public bool SendMail(string display, string from, string to, string subj, string msg, Attachment attach)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                //+++++++++++ Multiple To
                if (to.Length > 0 && from.Length > 0 && attach != null)
                {
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from, display);
                    Message.Attachments.Add(attach);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);

                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To, From & Attachment are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public bool SendMail(string display, string from, string to, string cc, string subj, string msg)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                if (to.Length > 0 && cc.Length > 0 && from.Length > 0)
                {
                    //+++++++++++ Multiple To
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    //+++++++++++ Multiple CC
                    if (cc.Contains(','))
                    {
                        string[] arrCC = cc.Split(',');
                        if (cc.Length > 0)
                        {
                            foreach (string val in arrCC)
                            {
                                Message.CC.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.CC.Add(new MailAddress(cc));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from, display);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);

                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To, Bcc & From are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public bool SendMail(string display, string from, string to, string cc, string subj, string msg, Attachment attach)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                if (to.Length > 0 && cc.Length > 0 && from.Length > 0 && attach != null)
                {
                    //+++++++++++ Multiple To
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    //+++++++++++ Multiple CC
                    if (cc.Contains(','))
                    {
                        string[] arrCC = cc.Split(',');
                        if (cc.Length > 0)
                        {
                            foreach (string val in arrCC)
                            {
                                Message.CC.Add(new MailAddress(val.Trim()));
                            }
                        }
                    }
                    else
                    {
                        Message.CC.Add(new MailAddress(cc));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from, display);
                    Message.Attachments.Add(attach);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);
                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To, Cc, From & Attachment are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public bool SendMail(string display, string from, string to, string cc, string bcc, string subj, string msg)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                //+++++++++++ Multiple To
                if (to.Length > 0 && cc.Length > 0 && bcc.Length > 0 && from.Length > 0)
                {
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    //+++++++++++ Multiple CC
                    if (cc.Contains(','))
                    {
                        string[] arrCC = cc.Split(',');
                        if (cc.Length > 0)
                        {
                            foreach (string val in arrCC)
                            {
                                Message.CC.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.CC.Add(new MailAddress(cc));
                    }

                    //+++++++++++ Multiple BCC
                    if (bcc.Contains(','))
                    {
                        string[] arrBCC = bcc.Split(',');
                        if (bcc.Length > 0)
                        {
                            foreach (string val in arrBCC)
                            {
                                Message.Bcc.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.Bcc.Add(new MailAddress(bcc));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from, display);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);

                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To, Cc, Bcc & From are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public bool SendMail(string display, string from, string to, string cc, string bcc, string subj, string msg, Attachment attach)
        {
            bool Result = false;
            SmtpClient SMTP = new SmtpClient();
            MailMessage Message = new MailMessage();
            try
            {
                //+++++++++++ Multiple To
                if (to.Length > 0 && cc.Length > 0 && bcc.Length > 0 && from.Length > 0 && attach != null)
                {
                    if (to.Contains(','))
                    {
                        string[] arrTO = to.Split(',');
                        if (to.Length > 0)
                        {
                            foreach (string val in arrTO)
                            {
                                Message.To.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.To.Add(new MailAddress(to));
                    }

                    //+++++++++++ Multiple CC
                    if (cc.Contains(','))
                    {
                        string[] arrCC = cc.Split(',');
                        if (cc.Length > 0)
                        {
                            foreach (string val in arrCC)
                            {
                                Message.CC.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.CC.Add(new MailAddress(cc));
                    }

                    //+++++++++++ Multiple BCC
                    if (bcc.Contains(','))
                    {
                        string[] arrBCC = bcc.Split(',');
                        if (bcc.Length > 0)
                        {
                            foreach (string val in arrBCC)
                            {
                                Message.Bcc.Add(new MailAddress(val));
                            }
                        }
                    }
                    else
                    {
                        Message.Bcc.Add(new MailAddress(bcc));
                    }

                    Message.Subject = subj;
                    Message.Body = msg;
                    Message.From = new MailAddress(from);
                    Message.Attachments.Add(attach);
                    Message.IsBodyHtml = true;
                    Message.Priority = MailPriority.High;

                    NetworkCredential myCredential = new NetworkCredential(UserID, Pass);
                    SMTP.Host = Host;
                    SMTP.Port = Convert.ToInt32(Port);
                    SMTP.Credentials = myCredential;
                    SMTP.EnableSsl = EnableSsl;
                    SMTP.Send(Message);

                    Result = true;
                }
                else
                {
                    throw new Exception("Custom Error: Email To, Cc, Bcc, From & Attachment are invalid!");
                }
            }
            catch (SmtpException SmtpEx)
            {
                Result = false;
                throw SmtpEx;
            }

            return Result;
        }

        public CompanyMailSignatureViewModel GetCompanyMailSignature()
        {
            try
            {
                return repoCompany.GetDefaultSignatureDetails(1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}