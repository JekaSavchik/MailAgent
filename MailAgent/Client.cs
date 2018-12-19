using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailAgent
{
    class Client
    {
        string UserName;
        string Password;
        public string Postal_service { get; }
        public MailAddress mailAddress { get;}
        public SmtpClient Smtp { get; }

        public Client(string userName, string postal_service, string password)
        {
            UserName = userName;
            Postal_service = postal_service;
            Password = password;
            string mail_address = UserName + Postal_service;
            mailAddress = new MailAddress(mail_address, UserName);
            Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.Credentials = new NetworkCredential(mail_address, Password);
        }


    }
}
