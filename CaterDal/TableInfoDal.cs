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
   public partial class TableInfoDal
    {
        public List<TableInfo> GetList(Dictionary<string,string> dic)
        {
            string sql = "select ti.*,hi.HTitle HTitle from TableInfo as ti inner join HallInfo as hi where ti.THallId=hi.HId and ti.TIsDelete=0 and hi.HIsDelete=0";

            List<TableInfo> list = new List<TableInfo>();
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (dic.Count>0)
            {
                foreach (var pari in dic)
                {
                    sql += " and " + pari.Key + "=@" + pari.Key;
                    listP.Add(new SQLiteParameter("@" + pari.Key, pari.Value));
                }
            }
            DataTable dt = SqliteHelper.GetDataTable(sql,listP.ToArray());
            foreach (DataRow  row in dt.Rows)
            {
                list.Add(new TableInfo
                {
                    THallId = Convert.ToInt32(row["THallId"]),
                    TId = Convert.ToInt32(row["tid"]),
                    TIsFree = Convert.ToBoolean(row["tisfree"]),
                    TTitle = row["ttitle"].ToString(),
                    HTitle=row["htitle"].ToString()
                });
            }

            return list;
        }

        public int Insert(TableInfo ti)
        {
            string sql = "insert into TableInfo (ttitle,thallid,tisfree,tisdelete) values (@title,@hallid,@isfree,0)";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@title",ti.HTitle),
                new SQLiteParameter("@hallid",ti.THallId),
                new SQLiteParameter("@isfree",ti.TIsFree)
            };

            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
        
        public int Update(TableInfo ti)
        {
            string sql = "update TableInfo set ttitle=@title,thallid=@hallid,tisfree=@isfree where tid=@id";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@title",ti.HTitle),
                new SQLiteParameter("@hallid",ti.THallId),
                new SQLiteParameter("@isfree",ti.TIsFree),
                new SQLiteParameter("@id",ti.TId),

            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Delete(int id)
        {
            string sql = "update TableInfo set tisdelete=1 where tid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
