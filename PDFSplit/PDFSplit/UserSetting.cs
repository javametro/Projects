using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace PDFSplit
{
    public partial class UserSetting : Form
    {
        public UserSetting()
        {
            InitializeComponent();
            this.AcceptButton = button1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Email_ID = textBox1.Text;
            Properties.Settings.Default.Pass = textBox2.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void UserSetting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Email_ID;
            textBox2.Text = Properties.Settings.Default.Pass;
        }
    }
}
