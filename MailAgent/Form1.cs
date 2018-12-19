using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailAgent
{
    public partial class Form1 : Form
    {
        Client client;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string mail = comboBoxAddress.Text;
            string password = textBoxPassword.Text;
            client = new Client(userName, mail, password);
        }



        private static async Task SendEmailAsync(Client _from, string _to, string _Subject, string _Body)
        {
            //MailAddress from = new MailAddress(_from.UserName + _from.Postal_service , _from.UserName);
            //MailAddress to = new MailAddress(_to);
            //MailMessage m = new MailMessage(from, to);
            //m.Subject = "Тест";
            //m.Body = "Письмо-тест 2 работы smtp-клиента";
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            //smtp.EnableSsl = true;
            //await smtp.SendMailAsync(m);
            //MessageBox.Show("Письмо отправлено");
            try
            {
                MailAddress to = new MailAddress(_to);
                MailMessage m = new MailMessage(_from.mailAddress, to);
                m.Subject = _Subject;
                m.Body = _Body;
                SmtpClient smtp = _from.Smtp;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                MessageBox.Show("Письмо отправлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string To = textBoxTo.Text;
            string Subjekt = textBoxSubject.Text;
            string Body = textBoxBody.Text;
            SendEmailAsync(client, To, Subjekt, Body).GetAwaiter();
        }
    }
}
