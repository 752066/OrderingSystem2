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
    public partial class FormMemberInfo : Form
    {
        private MemberInfoBll miBll = new MemberInfoBll();
        public FormMemberInfo()
        {
            InitializeComponent();
            
        }

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            ddlType.DataSource = mtiBll.getMTIList();
            ddlType.DisplayMember = "mTitle";
            ddlType.ValueMember = "mId";
        }

        private int index = 0;
        private void LoadList()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (txtNameSearch.Text!="")
            {
                dict.Add("mname",txtNameSearch.Text);
            }
            if (txtPhoneSearch.Text!="")
            {
                dict.Add("mphone", txtPhoneSearch.Text);
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList(dict);
            if (miBll.GetList(dict).Count>0)
            {
                dgvList.Rows[index].Selected = true;
            }
      
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtPhoneSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtPhoneSearch.Text = "";
            txtNameSearch.Text = "";
            LoadList();
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            
            var row = dgvList.SelectedRows[0];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text= row.Cells[1].Value.ToString();
            ddlType.Text= row.Cells[2].Value.ToString();
            txtPhoneAdd.Text= row.Cells[3].Value.ToString();
            txtMoney.Text= row.Cells[4].Value.ToString();
            index=row.Index;
            btnSave.Text = "修改";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo()
            {
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MName = txtNameAdd.Text,
                MPhone = txtPhoneAdd.Text,
                MTypeId =Convert.ToInt32( ddlType.SelectedValue)
            };

            if (btnSave.Text=="添加")
            {
                if (miBll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                mi.MId =Convert.ToInt32( txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }

            txtId.Text = "添加时无编号";
            txtPhoneAdd.Text = "";
            txtNameAdd.Text = "";
            btnSave.Text = "添加";
            txtMoney.Text = "";
            ddlType.SelectedValue = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            txtId.Text = "添加时无编号";
            txtPhoneAdd.Text = "";
            txtNameAdd.Text = "";
            btnSave.Text = "添加";
            txtMoney.Text = "";
            ddlType.SelectedValue = 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show("是否删除", "提示", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            int id =int.Parse( dgvList.SelectedRows[0].Cells[0].Value.ToString());
            if (miBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo mti = new FormMemberTypeInfo();

            DialogResult result=mti.ShowDialog();
            if (result==DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }

        }
    }
}
