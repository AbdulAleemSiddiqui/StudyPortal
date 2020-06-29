using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace FYP1.Models
{
    class Mail
    {
        //Company_User and Company_Code and Company_Address and Company_Link
        //
        public string ConfimationLink { get; set; }
        public string ConfirmationMessage { get; set; }

        public string UserName { set; get; }
        public string UserMail { set; get; }
        public string Subject { set; get; }

        private string email = "fatimaakbar538@gmail.com", password = "fatima8852";

        private string Company_Name { get; set; } = "Pakistan Study Panel";
        private string Company_Address { get; set; } = "Abc, Karachi";

        private string SenderMail { set { value = email; } get { return email; } }
        private string SenderPassword { set { value = password; } get { return password; } }
        public void Sent()
        {
            SetMessage();
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(SenderMail);
                mail.To.Add(UserMail);
                mail.Subject = "Email Confirmation";
                mail.Body = ConfirmationMessage;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        private void SetMessage()
        {
            ConfirmationMessage = "";
            var path = AppDomain.CurrentDomain.BaseDirectory + "verify-email.html";
            foreach (var item in File.ReadAllLines(@path))
            {
                ConfirmationMessage += item.Replace("Company_Code", Company_Name)
                    .Replace("Company_Address", Company_Address)
                    .Replace("Company_Link", ConfimationLink)
                    .Replace("Company_User", UserName)+ " \n";

            }
        }
        public void SetCredientials(string a, string b)
        {
            email = a; password = b;
        }
        public bool isEmailExist(string email)
        {
            TcpClient tClient = new TcpClient("gmail-smtp-in.l.google.com", 25);
            string CRLF = "\r\n";
            byte[] dataBuffer;
            string ResponseString;
            NetworkStream netStream = tClient.GetStream();
            StreamReader reader = new StreamReader(netStream);
            ResponseString = reader.ReadLine();
            /* Perform HELO to SMTP Server and get Response */
            dataBuffer = BytesFromString("HELO KirtanHere" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            dataBuffer = BytesFromString("MAIL FROM:<abdulaleem.yousuf97@gmail.com>" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            /* Read Response of the RCPT TO Message to know from google if it exist or not */
            dataBuffer = BytesFromString("RCPT TO:<" + email.Trim() + ">" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            if (GetResponseCode(ResponseString) == 550)
            {
                dataBuffer = BytesFromString("QUITE" + CRLF);
                netStream.Write(dataBuffer, 0, dataBuffer.Length);
                tClient.Close();
                return false;
            }
            /* QUITE CONNECTION */
            dataBuffer = BytesFromString("QUITE" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            tClient.Close();
            return true;
        }
        private byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
        private int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }
    }
}