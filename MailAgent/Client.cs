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
        public string UserName { get; }
        public string Password { get; }
        public string Postal_service { get; }
        public string mail_address { get; }
        public MailAddress mailAddress { get; }
        public SmtpClient Smtp { get; }

        public Client(string userName, string postal_service, string password)
        {
            UserName = userName;
            Postal_service = postal_service;
            Password = password;
            mail_address = UserName + Postal_service;
            mailAddress = new MailAddress(mail_address, UserName);
            Smtp = new SmtpClient(HostPort(), 587);
            Smtp.Credentials = new NetworkCredential(mail_address, Password);
        }

        string HostPort()
        {
            switch (Postal_service)
            {
                case "@gmail.com":
                    return "smtp.gmail.com";
                case "@mail.ru":
                    return "smtp.mail.ru";
                default:
                    return "smtp.yandex.ru";

            }
        }


    }
}
