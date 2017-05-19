using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
   public partial class MemberTypeInfoBll
    {
        MemberTypeInfoDal mtiDal = new MemberTypeInfoDal();
        public List<MemberTypeInfo> getMTIList()
        {
            return mtiDal.getMemberTypeInfoList();
        }

        //添加
        public bool AddMTI(MemberTypeInfo mi)
        {
            return mtiDal.insertMTI(mi) > 0;
        }
        //修改
        public bool UpdateMTI(MemberTypeInfo mi)
        {
            return mtiDal.updateMTI(mi) > 0;
        }
        //删除
        public bool RemoveMTI(string mid)
        {
            return mtiDal.DeleteMTI(mid) > 0;
        }
    }
}
