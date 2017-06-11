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
    public partial class FormOrderDish : Form
    {
        public FormOrderDish()
        {
            InitializeComponent();
        }

        private DishInfoBll diBll = new DishInfoBll();
        private DishTypeInfoBll dtiBll = new DishTypeInfoBll();
        private OrderInfoBll oiBll = new OrderInfoBll();
        private void FormOrderDish_Load(object sender, EventArgs e)
        {
            LoadDishTypeInfo();
            LoadDishInfo();
            LoadOrderDishInfo();
        }

        private void LoadDishTypeInfo()
        {
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo { DId=-1,DTitle="全部"});
            ddlType.DataSource = list;
            ddlType.DisplayMember = "dtitle";
            ddlType.ValueMember = "did";
        }

        private void LoadDishInfo()
        {
            List<DishInfo> list = new List<DishInfo>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtTitle.Text != "")
            {
                dic.Add("di.dchar", txtTitle.Text);
            }
            if (ddlType.SelectedIndex != 0)
            {
                dic.Add("di.DTypeId", ddlType.SelectedValue.ToString());
            }
            list = diBll.GetList(dic);
            dgvAllDish.AutoGenerateColumns = false;
            dgvAllDish.DataSource = list;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void dgvAllDish_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvAllDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //点菜
            int orderId = Convert.ToInt32(this.Tag);
            int dishId = Convert.ToInt32(dgvAllDish.Rows[e.RowIndex].Cells[0].Value);
            if (oiBll.OrderDish(orderId, dishId))
            {
                //刷新点菜界面
                LoadOrderDishInfo();
            }
        }

        private void LoadOrderDishInfo()
        {
            int orderId = Convert.ToInt32(this.Tag);
            dgvOrderDetail.AutoGenerateColumns = false;
            dgvOrderDetail.DataSource = oiBll.GetOrderDishInfo(orderId);
        }
    }
}
