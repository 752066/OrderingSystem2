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
    public partial class FormMemberTypeInfo : Form
    {
        public static FormMemberTypeInfo formmti;
        private static DialogResult result = DialogResult.Cancel;
        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
        public static FormMemberTypeInfo create()
        {
            if (formmti==null)
            {
                formmti = new FormMemberTypeInfo();
            }
            return formmti;
        }
        public FormMemberTypeInfo()
        {
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = mtiBll.getMTIList();
        }

        private void FormMemberTypeInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            formmti = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mti = new MemberTypeInfo();
            mti.MTitle = txtTitle.Text;
            mti.MDiscount = Convert.ToDecimal(txtDiscount.Text);
            if (!btnSave.Text.Equals("保存"))
            {
                mti.MId =Convert.ToInt32( txtId.Text);
                if (mtiBll.UpdateMTI(mti))
                {
                    LoadList();
                    txtId.Text = "添加时无编号";
                    txtDiscount.Text = "";
                    txtTitle.Text = "";
                    btnSave.Text = "保存";
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                result = DialogResult.OK;
                return;
            }
            if (mtiBll.AddMTI(mti))
            {
                LoadList();
            }
            else {
                MessageBox.Show("添加失败");
            }
            result = DialogResult.OK;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDiscount.Text = "";
            txtTitle.Text = "";
            btnSave.Text = "保存";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text= row.Cells[1].Value.ToString();
            txtDiscount.Text= row.Cells[2].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count>0)
            {
                string mid = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                if (mtiBll.RemoveMTI(mid))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            result = DialogResult.OK;
        }

        private void FormMemberTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
