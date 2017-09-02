using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// FunCode
    /// </summary>
    public partial class FunCode
    {

        public static DataTable GetListWithRoleId(int roleId)
        {
            return DAL.FunCode.GetListWithRoleId(roleId);
        }
    }
}