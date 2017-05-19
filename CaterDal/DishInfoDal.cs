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
    public  partial class DishInfoDal
    {
        public List<DishInfo> GetList(Dictionary<string,string> dict)
        {
            string sql = "select di.*,dti.Dtitle as DTypeTitle from DishInfo di inner join DishTypeInfo dti on di.DTypeId=dti.DId " +
                "  where di.DIsDelete=0 and dti.DIsDelete=0";
            if (dict.Count>0)
            {
                foreach (var parm in dict)
                {
                    if (parm.Key== "di.Dtitle")
                    {
                        sql += " and " + parm.Key + " like '%" + parm.Value + "%' ";
                    }
                    if (parm.Key== "di.DTypeId")
                    {
                        sql += " and " + parm.Key + "=" + parm.Value;
                    }
                }
            }
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<DishInfo> list = new List<DishInfo>();
            foreach (DataRow  row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DChar = row["dchar"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"]),
                    DTypeTitle = row["DTypeTitle"].ToString(),
                    DTitle=row["DTitle"].ToString()
                });
            }
            return list;
        }

        public int Insert(DishInfo di)
        {
            string sql = "insert into DishInfo(DTitle,DTypeId,DPrice,DChar,DIsDelete) values (@title,@typeId,@price,@char,0)";
            SQLiteParameter[] sp = {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@typeId",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar),

            };

            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public int Update(DishInfo di)
        {
            string sql = "update DishInfo set dtitle=@title,dtypeid=@typeid,dprice=@price,dchar=@char where did=@id";
            SQLiteParameter[] sp =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@typeid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar),
                new SQLiteParameter("@id",di.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }      
    }
}
