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
    public partial class MemberInfoDal
    {
        //查询所有会员
        public List<MemberInfo> GetList(Dictionary<string,string> dict)
        {
            string sql = "select mi.*,mti.MTitle as mTypeTitle from memberinfo mi" +
                " inner join membertypeinfo mti where mi.MTypeId=mti.MId and mi.MIsDelete=0";

            if (dict.Count>0)
            {
                foreach (KeyValuePair<string,string> pari in dict)
                {
                    sql += " and " + pari.Key + " like '%" + pari.Value + "%'";
                }
                
            }

            List<MemberInfo> list = new List<MemberInfo>();
            DataTable dt = SqliteHelper.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                MemberInfo mi = new MemberInfo() {
                    MId = Convert.ToInt32(row["mid"]),
                    MMoney = Convert.ToDecimal(row["mmoney"]),
                    MName = row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MTypeTitle=row["mTypeTitle"].ToString()
                };
                list.Add(mi);
            }
            return list;
        }

        public int Insert(MemberInfo mi)
        {
            string sql = "insert into MemberInfo (mTypeId,mname,mphone,mmoney,misdelete)"
                +" values(@typeid,@name,@phone,@money,0)";
            SQLiteParameter[] ps = {
                new SQLiteParameter("@typeid",mi.MTypeId),
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(MemberInfo mi)
        {
            string sql = "update memberinfo set mname=@name,mTypeId=@typeId,mphone=@phone,"
                + " mmoney=@money where mid=@id";

            SQLiteParameter[] ps = {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@typeId",mi.MTypeId),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money", mi.MMoney),
                new SQLiteParameter("@id", mi.MId)
            };

            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "update memberinfo set misdelete=1 where mid=@id";
            SQLiteParameter sp = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
    }
}
