using CaterBll;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private OrderInfoBll oiBll = new OrderInfoBll();
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuQuite_Click(object sender, EventArgs e)
        {
            //退出程序
            Application.Exit();
        }
        
        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            ManagerInfoForm form = ManagerInfoForm.create();
            form.Show();
            form.Focus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Tag)==0)
            {
                menuManagerInfo.Visible = false;
            }
            LoadTableInfo();
        }

        private void LoadTableInfo()
        {
            HallInfoBll hiBll = new HallInfoBll();
            TableInfoBll tiBll = new TableInfoBll();
            var list = hiBll.GetList();
            tabControl1.TabPages.Clear();
            foreach (var item in list)
            {
                TabPage tp = new TabPage(item.HTitle);
                tabControl1.TabPages.Add(tp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("THallId", item.HId.ToString());
                var listTable = tiBll.GetList(dic);

                ListView lvTableInfo = new ListView();
                lvTableInfo.DoubleClick += LvTableInfo_DoubleClick;
                lvTableInfo.Dock = DockStyle.Fill;
                lvTableInfo.LargeImageList = imageList1;
                tp.Controls.Add(lvTableInfo);
                foreach (var ti in listTable)
                {
                    ListViewItem lvItem = new ListViewItem(ti.TTitle, ti.TIsFree ? 0 : 1);
                    lvTableInfo.Items.Add(lvItem);
                    lvItem.Tag = ti.TId;
                }
            }

        }
        int orderId;
        private void LvTableInfo_DoubleClick(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            var listItem = listView.SelectedItems[0];
            //餐桌空闲,开单
            int tid = Convert.ToInt32(listItem.Tag);
            if (listItem.ImageIndex == 0)
            {
                orderId= oiBll.KanOrder(tid);
                listItem.ImageIndex = 1;
            }
            else
            {
                orderId = oiBll.GetOrderIdByTableId(tid);
            }
            
            FormOrderDish formOD = new FormOrderDish();
            formOD.Tag = orderId;
            formOD.Show();
        }

        private void menuMeber_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo form = FormMemberTypeInfo.create();
            form.Show();
            form.Focus();
        }

        private void menuTable_Click(object sender, EventArgs e)
        {
            FormTableInfo form = FormTableInfo.create();
            form.refresh += LoadTableInfo;
            form.Show();
            form.Focus();
        }
    }
}
