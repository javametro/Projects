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

namespace PDFSplit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
                //MailMessage mm = new MailMessage("dharmeshbhalodia33@gmail.com", "dharmeshbhalodia33@gmail.com");
                //mm.Subject = "Your certificate";
                //mm.Body = "Hello <br /> " + " and Enroll" + 1;
                ////    mm.IsBodyHtml = true;
                //mm.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.EnableSsl = true;
                //NetworkCredential NetworkCred = new NetworkCredential("dharmeshbhalodia33@gmail.com", "Priyancee33$");
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 465;
                //smtp.Send(mm);












               // smtp.Timeout = 2000000;
                //Attachment at = new Attachment(Path.GetDirectoryName(ofd.FileName)+"\\"+sr+".pdf", MediaTypeNames.Application.Pdf);
                //// Add time stamp information for the file.
                //ContentDisposition disposition = at.ContentDisposition;
                //disposition.CreationDate = System.IO.File.GetCreationTime(ofd.FileName);
                //disposition.ModificationDate = System.IO.File.GetLastWriteTime(ofd.FileName);
                //disposition.ReadDate = System.IO.File.GetLastAccessTime(ofd.FileName);
                //// Add the file attachment to this e-mail message.
                //mm.Attachments.Add(at);
              //  smtp.Send(mm);
           
        }
    }
}
