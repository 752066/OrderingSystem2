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
    }
}
