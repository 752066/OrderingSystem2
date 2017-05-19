using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class DishInfoBll
    {
        private DishInfoDal did = new DishInfoDal();
        public List<DishInfo> GetList(Dictionary<string,string> dict)
        {
            return did.GetList(dict);
        }

        public bool Insert(DishInfo di)
        {
            return did.Insert(di) > 0;
        }

        public bool Update(DishInfo di)
        {
            return did.Update(di) > 0;
        }
    }
}
