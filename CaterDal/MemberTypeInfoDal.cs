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
    public partial class MemberTypeInfoDal
    {
        //获取所有会员类型
        public List<MemberTypeInfo> getMemberTypeInfoList()
        {
            string sql = "select * from membertypeinfo where mIsDelete=0";
            DataTable dt = SqliteHelper.GetDataTable(sql);
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MDiscount = Convert.ToDecimal(row["mdiscount"]),
                    // MIsDelete=Convert.ToInt32(row["misdelete"]),
                    MTitle = row["mtitle"].ToString()
                });
            }
            return list;
        }
        //添加
        public int insertMTI(MemberTypeInfo mti)
        {
            string sql = "insert into membertypeinfo(mtitle,MDiscount,MIsDelete)" 
                + "values(@title,@discount,@MIsDelete)";
            SQLiteParameter[] sp = { new SQLiteParameter("@title",mti.MTitle)
            ,new SQLiteParameter("@discount",mti.MDiscount)
            ,new SQLiteParameter("@MIsDelete",false)};
           return SqliteHelper.ExecuteNonQuery(sql, sp);
        }
        //修改
        public int updateMTI(MemberTypeInfo mti)
        {
            string sql = "update membertypeinfo set mtitle=@title,MDiscount=@discount where mid=@id";
            SQLiteParameter[] sp = { new SQLiteParameter("@title",mti.MTitle)
            ,new SQLiteParameter("@discount",mti.MDiscount)
            ,new SQLiteParameter("@id",mti.MId)};
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        //删除
        public int DeleteMTI(string mid)
        {
            string sql = "delete from MemberTypeInfo where mid=@id";
            SQLiteParameter ps = new SQLiteParameter("@id", mid);
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
