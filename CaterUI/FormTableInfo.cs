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
    public partial class FormTableInfo : Form
    {
        public FormTableInfo()
        {
            InitializeComponent();
        }

        private TableInfoBll tiBll = new TableInfoBll();
        private int currentIndex;
        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            LoadSearchList();
            LoadList();
        }

        private void LoadSearchList()
        {
            HallInfoBll hiBll = new HallInfoBll();
            List<HallInfo> list = hiBll.GetList();
            list.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "全部"
            });
            ddlHallSearch.DataSource = list;
            ddlHallSearch.DisplayMember = "HTitle";
            ddlHallSearch.ValueMember = "HId";

            ddlHallAdd.DataSource = hiBll.GetList();
            ddlHallAdd.DisplayMember = "HTitle";
            ddlHallAdd.ValueMember = "HId";

            List<TModel> list2 = new List<TModel>()
           {
               new TModel() {id="-1",title="全部" },
               new TModel() {id="1",title= "空闲" },
              new TModel() {id="0",title="使用" }
           };

            ddlFreeSearch.DataSource = list2;
            ddlFreeSearch.DisplayMember = "title";
            ddlFreeSearch.ValueMember = "id";
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (ddlHallSearch.SelectedIndex>0)
            {
                dic.Add("THallId", ddlHallSearch.SelectedValue.ToString());
            }

            if (ddlFreeSearch.SelectedIndex>0)
            {
                dic.Add("TIsFree", ddlFreeSearch.SelectedValue.ToString());
            }
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = tiBll.GetList(dic);
            
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                e.Value = Convert.ToBoolean(e.Value) ? "空闲" : "使用";
            }
        }

        private void ddlHallSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlFreeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            ddlFreeSearch.SelectedIndex = 0;
            ddlHallSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableInfo ti = new TableInfo();
            ti.HTitle = txtTitle.Text;
            ti.THallId = Convert.ToInt32(ddlHallAdd.SelectedValue);
            ti.TIsFree = rbFree.Checked;

            if (txtId.Text== "添加时无编号")
            {
                if (tiBll.Insert(ti))
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
                ti.TId = Convert.ToInt32(txtId.Text);
                if (tiBll.Update(ti))
                {
                    LoadList();
                }
            }

            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            ddlHallAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = "";
            ddlHallAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIndex = e.RowIndex;
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            ddlHallAdd.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value))
            {
                rbFree.Checked = true;
            }
            else
            {
                rbUnFree.Checked = true;
            }
            btnSave.Text = "修改";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("确定删除", "提示", MessageBoxButtons.OKCancel);
            if (result==DialogResult.Cancel)
            {
                return;
            }
            if (tiBll.Delete(id))
            {
                LoadList();
            }
        }

        private void btnAddHall_Click(object sender, EventArgs e)
        {
            FormHallInfo formhi = new FormHallInfo();
            formhi.UpdateTableInfo += LoadList;
            formhi.UpdateTableInfo += LoadSearchList;
            formhi.ShowDialog();
        }
    }
}
