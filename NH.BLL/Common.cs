using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NH.BLL
{
    public partial class Common
    {
        public static DataSet GetAdminDefaultMsg()
        {
            return DAL.Common.GetAdminDefaultMsg();
        }
    }
}
