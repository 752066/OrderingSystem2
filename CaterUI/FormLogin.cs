using CaterBll;
using CaterModel;
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
    public partial class FormLogin : Form
    {
        ManagerInfoBll miBll = new ManagerInfoBll();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int type;
            LoginState state =miBll.LoginSys(txtName.Text, txtPwd.Text,out type);
            switch (state)
            {
                case LoginState.ok:
                    FormMain fm = new FormMain();
                    fm.Tag = type;
                    fm.Show();
                    this.Hide();
                    break;
                case LoginState.nameerror:
                    MessageBox.Show("用户名错误");
                    break;
                case LoginState.pwderror:
                    MessageBox.Show("密码错误");
                    break;
                default:
                    break;
            }
        }
    }
}
