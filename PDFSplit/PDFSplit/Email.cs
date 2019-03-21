using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace PDFSplit
{
    public partial class Email : Form
    {
        private string currpath;
        private OpenFileDialog ofd;
        private DataTable data;

        public Email()
        {
            InitializeComponent();
            currpath = null;
            button1.Enabled =false;
            
        }

        private void browser_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Title = "Select Excel file for spliting";
            ofd.DefaultExt = ".excel";
            ofd.Filter = "Excel files(*.xlsx) | *.xlsx|excel(*.xls) | *.xls";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();
            currpath = ofd.FileName;

            string constr=null;

            if (Path.GetExtension(ofd.FileName).Equals(".xls"))
            {
                 constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        currpath +
                        ";Extended Properties='Excel 8.0;HDR=YES;';";

            }
            if(Path.GetExtension(ofd.FileName).Equals(".xlsx"))
            {
                constr="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                       currpath +
                       ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            }
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select SR,NAME,ENROLLMENT,EMAIL From [Sheet1$] where SR IS NOT NULL", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            data = new DataTable();
            sda.Fill(data);
            
            if(data.Rows.Count>0)
            {
                dataGridView1.DataSource = data.DefaultView;
                button1.Enabled = true;
            }

            
            con.Close();
            con.Dispose();
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ofd.FileName);

            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            //int rowCount = xlRange.Rows.Count;
            //int colCount = xlRange.Columns.Count;

            //DataTable dt = new DataTable();


            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            ////rule of thumb for releasing com objects:
            ////  never use two dots, all COM objects must be referenced and released individually
            ////  ex: [somthing].[something].[something] is bad

            ////release com objects to fully kill excel process from running in the background
            //Marshal.ReleaseComObject(xlRange);
            //Marshal.ReleaseComObject(xlWorksheet);

            ////close and release
            //xlWorkbook.Close();
            //Marshal.ReleaseComObject(xlWorkbook);

            ////quit and release
            //xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parallel.ForEach(data.AsEnumerable(), row =>
            {
                SendEmail(row["EMAIL"].ToString(), row["NAME"].ToString(), row["ENROLLMENT"].ToString(), row["SR"].ToString());
            });
        }
        private bool SendEmail(string recipient, string Name, string Enrollment,string sr)
        {

            MailMessage mm = new MailMessage(Properties.Settings.Default.Email_ID, recipient);
            mm.Subject = "Your certificate";
            mm.Body = "Dear <br />" + Name+" and Enroll"+Enrollment;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = false;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = Properties.Settings.Default.Email_ID;
            NetworkCred.Password = Properties.Settings.Default.Pass;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 465;
            smtp.Timeout = 2000000;
            //Attachment at = new Attachment(Path.GetDirectoryName(ofd.FileName)+"\\"+sr+".pdf", MediaTypeNames.Application.Pdf);
            //// Add time stamp information for the file.
            //ContentDisposition disposition = at.ContentDisposition;
            //disposition.CreationDate = System.IO.File.GetCreationTime(ofd.FileName);
            //disposition.ModificationDate = System.IO.File.GetLastWriteTime(ofd.FileName);
            //disposition.ReadDate = System.IO.File.GetLastAccessTime(ofd.FileName);
            //// Add the file attachment to this e-mail message.
            //mm.Attachments.Add(at);
            smtp.Send(mm);
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSetting us = new UserSetting();
            us.ShowDialog();
        }
    }
}
