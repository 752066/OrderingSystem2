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
    public partial class ManagerInfoForm : Form
    {
        private static ManagerInfoForm miForm;
        ManagerInfoBll miBll = new ManagerInfoBll();
        private ManagerInfoForm()
        {
            InitializeComponent();
            LoadList();
        }

        public static ManagerInfoForm create()
        {
            if (miForm==null)
            {
                miForm =new ManagerInfoForm();
            }
            return miForm;
        }
        //显示数据
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.getManagerInfoList().ToArray();
        }
        //格式化datagridview内容
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value)==1 ? "经理" : "店员";
            }
        }
        //双击单元格事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPwd.Text = "确定修改密码？";
            rb1.Checked=Convert.ToInt32(row.Cells[2].Value) == 1;
            btnSave.Text = "修改";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo();
            mi.MName = txtName.Text.Trim();
            mi.MPwd = txtPwd.Text.Trim();
            mi.MType = rb1.Checked ? 1 : 0;
            if (btnSave.Text.Equals("保存"))
            {
                if (miBll.AddManagerInfo(mi))
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
                mi.MId = Convert.ToInt32(txtId.Text.Trim());
                if (miBll.UpdateManagerInfo(mi))
                {
                    LoadList();
                    txtId.Text = "添加时无编号";
                    txtName.Text = "";
                    txtPwd.Text = "";
                    rb1.Checked = false;
                    btnSave.Text = "保存";
                }
                else
                {
                    MessageBox.Show("修改错误");
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtName.Text = "";
            txtPwd.Text = "";
            rb1.Checked = false;
            btnSave.Text = "保存";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //判断是否选中数据
            if (dgvList.SelectedRows.Count>0)
            {
               DialogResult result=MessageBox.Show("确定是否删除","提示",MessageBoxButtons.OKCancel);
                if (result==DialogResult.Cancel)
                {
                    return;
                }
                if (miBll.RemoveManagerInfo(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value)))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void ManagerInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            miForm = null;
        }
    }
}
