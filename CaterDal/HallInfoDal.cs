using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
   public partial class HallInfoDal
    {
        public List<HallInfo> GetList()
        {
            string sql = "select * from HallInfo where hisdelete=0";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<HallInfo> list = new List<HallInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HallInfo {
                    HId=Convert.ToInt32(row["hid"]),
                    HTitle=row["htitle"].ToString(),
                });
            }

            return list;
        }

        public int Insert(HallInfo hi)
        {
            string sql = "insert into HallInfo(htitle,hisdelete) values(@title,0)";
            SQLiteParameter p = new SQLiteParameter("@title", hi.HTitle);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(HallInfo hi)
        {
            string sql = "update HallInfo set htitle=@title where hid=@id";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@title",hi.HTitle),
                new SQLiteParameter("@id",hi.HId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Delete(int id)
        {
            string sql = "update HallInfo set hisdelete=1 where hid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
       
    }
}
