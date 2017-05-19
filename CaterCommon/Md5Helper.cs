using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
   public partial class Md5Helper
    {

        public static string MD5HashCode(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] btOld = Encoding.UTF8.GetBytes(str);
            byte[] btNew = md5.ComputeHash(btOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in btNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        
           
    }
}
