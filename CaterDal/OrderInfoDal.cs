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
   public partial class OrderInfoDal
    {
        public int KanOrder(int tid)
        {
            string sql = "insert into orderinfo(ODate,IsPay,TableId) values(datetime('now', 'localtime'),0,@tid);"
                +" update TableInfo set tisfree=0 where tid=@tid;" + " select max(oid) from orderinfo";
            SQLiteParameter p = new SQLiteParameter("@tid", tid);
            return Convert.ToInt32( SqliteHelper.ExecuteScalar(sql, p));
        }

        public int OrderDish(int orderId, int dishId)
        {
            string sql = "insert into OrderDetailInfo(orderid,dishid,count) values(@oid,@did,1) ";
            SQLiteParameter[] sp = { new SQLiteParameter("@oid", orderId), new SQLiteParameter("@did", dishId) };
            return SqliteHelper.ExecuteNonQuery(sql, sp);
        }

        public List<OrderDetailInfo> GetOrderDishInfo(int orderId)
        {
            string sql= "select odi.oid,di.dTitle,di.dPrice,odi.count from dishinfo as di" +
                                " inner join orderDetailInfo as odi on di.did = odi.dishid where odi.orderId = @orderId";
            SQLiteParameter p = new SQLiteParameter("@orderId", orderId);
            DataTable dt= SqliteHelper.GetDataTable(sql, p);
            List<OrderDetailInfo> list = new List<OrderDetailInfo>();
            foreach (DataRow  row in dt.Rows)
            {
                list.Add(new OrderDetailInfo
                {
                    OId = Convert.ToInt32(row["oid"]),
                    Count = Convert.ToInt32(row["count"]),
                    DTitle = row["dtitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["dprice"])
                });
            }
            return list;
        }

        public int GetOrderIdByTableId(int tableId)
        {
            string sql = "select oid from OrderInfo where tableId=@tid and ispay=0";
            SQLiteParameter p = new SQLiteParameter("@tid", tableId);
            return Convert.ToInt32( SqliteHelper.ExecuteScalar(sql, p));
        }
    }


}
