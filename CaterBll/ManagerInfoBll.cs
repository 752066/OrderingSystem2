using CaterCommon;
using CaterDal;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterBll
{
   public partial class ManagerInfoBll
    {
        ManagerInfoDal miDal = new ManagerInfoDal();
        public List<ManagerInfo> getManagerInfoList()
        {
            return miDal.selectAllManagerInfo();
        }
        //添加一个用户
        public bool AddManagerInfo(ManagerInfo mi) {

            return miDal.insertManager(mi)>0;
        }
        //修改用户
        public bool UpdateManagerInfo(ManagerInfo mi)
        {
            return miDal.updateManager(mi) > 0;
        }
        //删除用户
        public bool RemoveManagerInfo(int mid)
        {
            return miDal.deleteManager(mid)>0;
        }

        //登录
        public LoginState LoginSys(string name, string pwd,out int userType)
        {
            userType = -1;
            ManagerInfo mi = miDal.selectByName(name);
            if (mi == null)
            {
                return LoginState.nameerror;
            }
            else {
                if (!mi.MPwd.Equals(Md5Helper.MD5HashCode(pwd)))
                {
                    return LoginState.pwderror;
                }
                userType = mi.MType;
                return LoginState.ok;
            }
        }
            
    }
}
