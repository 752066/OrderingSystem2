using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
    public partial class TableInfoBll
    {
        private TableInfoDal tiDal = new TableInfoDal();
        public List<TableInfo> GetList(Dictionary<string,string> dic)
        {
            return tiDal.GetList(dic);
        }
    }
}
