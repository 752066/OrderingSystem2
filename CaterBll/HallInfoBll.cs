using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class HallInfoBll
    {
        public  HallInfoBll()
        {
            hiDal = new HallInfoDal();
        }

        private HallInfoDal hiDal;
        public List<HallInfo> GetList()
        {
            return hiDal.GetList();
        }

        public bool Insert(HallInfo hi)
        {
            return hiDal.Insert(hi)>0;
        }

        public bool Update(HallInfo hi)
        {
            return hiDal.Update(hi) > 0;
        }

        public bool Delete(int id)
        {
            return hiDal.Delete(id) > 0;
        }
    }
}
