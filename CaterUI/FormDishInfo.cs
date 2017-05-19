using CaterBll;
using CaterCommon;
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
    public partial class FormDishInfo : Form
    {
        public FormDishInfo()
        {
            InitializeComponent();
        }
        private DishInfoBll dib = new DishInfoBll();
        private int selectIndex = -1;
        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            #region 查询下拉列表绑定
            List<DishTypeInfo> list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = -1,
                DTitle = "全部"
            });
            ddlTypeSearch.DataSource = list;
            ddlTypeSearch.ValueMember = "DId";
            ddlTypeSearch.DisplayMember = "DTitle";
            #endregion

            #region 添加下拉列表绑定
            ddlTypeAdd.DataSource = dtiBll.GetList();
            ddlTypeAdd.DisplayMember = "DTitle";
            ddlTypeAdd.ValueMember = "Did";
            #endregion
        }

        private void LoadList()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (txtTitleSearch.Text!="")
            {
                dict.Add("di.Dtitle", txtTitleSearch.Text.Trim());
            }

            if (ddlTypeSearch.SelectedIndex!=0)
            {
                dict.Add("di.DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dib.GetList(dict);
            if (selectIndex>=0)
            {
                dgvList.Rows[selectIndex].Selected = true;
            }
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
        }



        private void txtTitleSave_Leave(object sender, EventArgs e)
        {
            txtChar.Text = PinYinHelper.GetPinYin(txtTitleSave.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtChar.Text = "";
            txtPrice.Text = "";
            txtTitleSave.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo()
            {
                DChar = txtChar.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTitle = txtTitleSave.Text,
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue.ToString())
            };

            if (btnSave.Text == "添加")
            {
                #region 添加菜单
                if (dib.Insert(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("....error");
                }
                #endregion
            }
            else
            {
                #region 修改菜单
                di.DId = Convert.ToInt32(txtId.Text);
                if (dib.Update(di))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("error");
                }
                #endregion
            }

            txtChar.Text = "";
            txtPrice.Text = "";
            txtTitleSave.Text = "";
            ddlTypeAdd.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitleSave.Text = row.Cells[1].Value.ToString();
            ddlTypeAdd.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtChar.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "修改";
            selectIndex = e.RowIndex;
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FormDishTypeInfo Formdti = new FormDishTypeInfo();
            DialogResult result=Formdti.ShowDialog();
            if (result==DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }
    }
}
