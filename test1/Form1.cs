using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            #region 手写sqlite数据库连接代码

            //List<ManagerInfo> list = new List<ManagerInfo>();
            //string connStr = @"data source=D:\Gamedownloader\07 .NET就业班-三层项目+SVN五天\2015-05-13.NET就业班-三层项目+SVN\资料\ItcastCater.db;version=3;";
            //using (SQLiteConnection conn = new SQLiteConnection(connStr))
            //{
            //    SQLiteCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = @"select * from managerInfo";
            //    conn.Open();
            //    SQLiteDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        ManagerInfo managerInfo = new ManagerInfo
            //        {
            //            Mid = Convert.ToInt32(reader["Mid"]),
            //            Mname = reader["Mname"].ToString(),
            //            Mpwd = reader["mpwd"].ToString(),
            //            Mtype = Convert.ToInt32(reader["mtype"])
            //        };
            //        list.Add(managerInfo);
            //    }
            //    dataGridView1.DataSource = list;
            //} 
            #endregion

            dataGridView1.DataSource = SqliteHelper.getDataTable("select * from managerinfo");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
