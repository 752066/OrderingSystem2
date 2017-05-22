using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
   public static class SqliteHelper
    {
        static string connStr = ConfigurationManager.
            ConnectionStrings["itcastCater"].ConnectionString;

        //执行命令方法insert update delete
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        //查询第一行第一列数据
        public static object ExecuteScalar(string sql,params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
        }
        //查询整张表数据
        public static DataTable getDataTable(string sql, params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, conn);
                DataTable table = new DataTable();
                sda.Fill(table);
                return table;
            }
        }
    }
}
