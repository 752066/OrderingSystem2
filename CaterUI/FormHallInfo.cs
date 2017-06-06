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
    public partial class FormHallInfo : Form
    {
        public FormHallInfo()
        {
            InitializeComponent();
            hiBll = new HallInfoBll();
        }

        private HallInfoBll hiBll;
        public event Action UpdateTableInfo;
        private void FormHallInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = hiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo()
            {
                HTitle = txtTitle.Text,
            };

            if (btnSave.Text=="添加")
            {
                if (hiBll.Insert(hi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            else
            {
                hi.HId =int.Parse( txtId.Text);
                if (hiBll.Update(hi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            UpdateTableInfo();
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("确定删除吗？", "", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (hiBll.Delete(id))
            {
                LoadList();
            }
            UpdateTableInfo();
        }
    }
}
