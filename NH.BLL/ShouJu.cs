﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    public partial class ShouJu
    {
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteShouJu(int Fid)
        {
            return DAL.ShouJu.DeleteShouJu(Fid);
        }
        #endregion
    }
}
