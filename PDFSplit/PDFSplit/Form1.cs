using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplit
{
    public partial class Form1 : Form
    {
        private string currpath;
        private OpenFileDialog ofd;

        public Form1()
        {
            InitializeComponent();
            currpath = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SplitAndSave(currpath, Path.GetDirectoryName(ofd.FileName));
                //SplitAndSave(currpath + "\\certi.pdf", currpath);
            }
            catch(NullReferenceException ne)
            {
                MessageBox.Show(ne.Message.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputpath = currpath + "certi.pdf";
            PdfReader reader = new PdfReader(inputpath);
            int interval = 4;


            for (int pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber += interval)
            {
                SplitAndSaveInterval(currpath + "certi.pdf", currpath, pagenumber, interval);
            }
            MessageBox.Show("Process Completed");

        }
        public int SplitAndSave(string inputPath, string outputPath)
        {
            FileInfo file = new FileInfo(inputPath);
            string name = file.Name.Substring(0, file.Name.LastIndexOf("."));


            using (PdfReader reader = new PdfReader(inputPath))
            {


                for (int pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber++)
                {
                    string filename = pagenumber.ToString() + ".pdf";


                    Document document = new Document();
                    PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "\\" +filename, FileMode.Create));


                    document.Open();


                    copy.AddPage(copy.GetImportedPage(reader, pagenumber));


                    document.Close();
                    progressBar1.Visible = true;
                    progressBar1.Value = (pagenumber * 100) / reader.NumberOfPages;
                }
                return reader.NumberOfPages;
            }


        }

        private void SplitAndSaveFromTO(string inputPath, string outputPath, int From, int TO)
        {
            FileInfo file = new FileInfo(inputPath);
            string name = file.Name.Substring(0, file.Name.LastIndexOf("."));

            if (From <= TO && From<0)
            {

                using (PdfReader reader = new PdfReader(inputPath))
                {
                    Document document = new Document();
                    PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "\\" + From + ".pdf", FileMode.Create));
                    document.Open();


                    for (int pagenumber = From; pagenumber < (From + TO); pagenumber++)
                    {
                        if (reader.NumberOfPages >= pagenumber)
                        {
                            copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                        }
                        else
                        {
                            break;
                        }


                    }


                    document.Close();
                    //return reader.NumberOfPages;
                }
            }
            
        }
        private int SplitAndSaveInterval(string inputPath, string outputPath, int startpage, int interval)
        {
            FileInfo file = new FileInfo(inputPath);
            string name = file.Name.Substring(0, file.Name.LastIndexOf("."));


            using (PdfReader reader = new PdfReader(inputPath))
            {
                Document document = new Document();
                PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "" +startpage +".pdf", FileMode.Create));
                document.Open();


                for (int pagenumber = startpage; pagenumber < (startpage + interval); pagenumber++)
                {
                    if (reader.NumberOfPages >= pagenumber)
                    {
                        copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                    }
                    else
                    {
                        break;
                    }


                }


                document.Close();
                return reader.NumberOfPages;
            }
        }

        private void browser_Click(object sender, EventArgs e)
        {
           ofd= new OpenFileDialog();
            ofd.Title = "Select PDF file for spliting";
            ofd.DefaultExt = ".pdf";
            ofd.Filter = "txt files(*.pdf) | *.pdf";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();
            //FileName_lbl.Text = ofd.FileName;
            currpath = ofd.FileName;
            File_Name_lbl.Text = ofd.FileName;
            
            PdfReader reader = new PdfReader(ofd.FileName);
            Pages_lbl.Text = reader.NumberOfPages.ToString();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Email em = new Email();
            em.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SplitAndSaveFromTO(currpath, Path.GetDirectoryName(ofd.FileName));
                //SplitAndSave(currpath + "\\certi.pdf", currpath);
            }
            catch (NullReferenceException ne)
            {
                MessageBox.Show(ne.Message.ToString());
            }
        }
    }
}
 