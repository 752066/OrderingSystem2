using CaterCommon;
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
   public partial class ManagerInfoDal
    {
        //获取用户信息
        public List<ManagerInfo> selectAllManagerInfo()
        {
            string sql = "select * from ManagerInfo";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo {
                    MId = Convert.ToInt32(row["mid"]),
                    MName=row["mname"].ToString(),
                    MPwd=row["mpwd"].ToString(),
                    MType=Convert.ToInt32(row["mtype"])
                });
            }
            return list;
        }

        //添加用户
        public int insertManager(ManagerInfo mi)
        {
            string sql= "insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            SQLiteParameter[] ps = {new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",Md5Helper.MD5HashCode(mi.MPwd)),
                new SQLiteParameter("@type",mi.MType)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        //修改用户
        public int updateManager(ManagerInfo mi)
        {
            string sql = "update managerinfo set mname=@name,mpwd=@pwd,mtype=@type where mid=@id";
            string sql2= "update managerinfo set mname=@name,mtype=@type where mid=@id";
            string sql3 = string.Empty;
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            if (mi.MPwd.Equals("确定修改密码？"))
            {
                sql3 = sql2;
            }
            else
            {
                sql3 = sql;
                list.Add(new SQLiteParameter("@pwd", Md5Helper.MD5HashCode(mi.MPwd)));
            }
            list.Add(new SQLiteParameter("@name", mi.MName));
            list.Add(new SQLiteParameter("@type", mi.MType));
            list.Add(new SQLiteParameter("@id", mi.MId));
            return SqliteHelper.ExecuteNonQuery(sql3, list.ToArray());
           


        }

        //删除用户
        public int deleteManager(int mid)
        {
            string sql = "delete from managerinfo where mid=@id";
            SQLiteParameter sp = new SQLiteParameter("@id",Convert.ToInt32(mid));
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        //查找用户
        public ManagerInfo selectByName(string name)
        {
            ManagerInfo mi = null;
            string sql = "select * from managerinfo where mname=@name";
            SQLiteParameter sp = new SQLiteParameter("@name", name);
            DataTable dt = SqliteHelper.GetDataTable(sql, sp);
            if (dt.Rows.Count>0)
            {
                mi = new ManagerInfo();
                DataRow row = dt.Rows[0];
                mi.MId = Convert.ToInt32(row[0]);
                mi.MName = dt.Rows[0]["mname"].ToString();
                mi.MPwd = dt.Rows[0]["mpwd"].ToString();
                mi.MType = Convert.ToInt32(dt.Rows[0]["mtype"]);
                return mi;
            }
            return mi;
            
        }
    }
}
