using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuQuite_Click(object sender, EventArgs e)
        {
            //退出程序
            Application.Exit();
        }
        
        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            ManagerInfoForm form = ManagerInfoForm.create();
            form.Show();
            form.Focus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Tag)==0)
            {
                menuManagerInfo.Visible = false;
            }
        }

        private void menuMeber_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo form = FormMemberTypeInfo.create();
            form.Show();
            form.Focus();
        }
    }
}
