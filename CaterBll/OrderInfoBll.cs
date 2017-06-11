using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
   public partial  class OrderInfoBll
    {
        private OrderInfoDal oiDal = new OrderInfoDal();
        public int KanOrder(int tid)
        {
            return oiDal.KanOrder(tid);
        }

        public bool OrderDish(int orderId, int dishId)
        {
            return oiDal.OrderDish(orderId, dishId) > 0;
        }

        public List<OrderDetailInfo> GetOrderDishInfo(int orderId)
        {
            return oiDal.GetOrderDishInfo(orderId);
        }

        public int GetOrderIdByTableId(int tableId)
        {
            return oiDal.GetOrderIdByTableId(tableId);
        }
    }

}
