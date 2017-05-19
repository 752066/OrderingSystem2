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
    public partial class FormDishTypeInfo : Form
    {
        public FormDishTypeInfo()
        {
            InitializeComponent();
        }
        private DishTypeInfoBll dtiBll = new DishTypeInfoBll();
        private int index = -1;
        private DialogResult result = DialogResult.Cancel;
        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dtiBll.GetList();
            if (index>=0)
            {
                dgvList.Rows[index].Selected = true;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dti = new DishTypeInfo()
            {
                DTitle = txtTitle.Text.Trim(),
            };
            if (btnSave.Text == "保存")
            {
                if (dtiBll.Add(dti))
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
                dti.DId =Convert.ToInt32( txtId.Text.ToString());
                if (dtiBll.Edit(dti))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }


            txtTitle.Text = "";
            txtId.Text = "添加时无编号";
            btnSave.Text = "添加";
            result = DialogResult.OK;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtId.Text = "添加时无编号";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            index = e.RowIndex;
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var row = dgvList.SelectedRows[0];
           DialogResult result= MessageBox.Show("确认删除吗？", "窗口",MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (dtiBll.Delete(Convert.ToInt32( row.Cells[0].Value)))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            this.result = DialogResult.OK;
        }

        private void FormDishTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult =this.result;
        }
    }
}
