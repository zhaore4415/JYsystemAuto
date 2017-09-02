using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Ad
    /// </summary>
    public partial class Ad
    {
        /// <summary>
        /// 获取最大排序值
        /// </summary>
        /// <returns></returns>
        public static int GetMaxSort(int typeId)
        {
            return DAL.Ad.GetMaxSort(typeId);
        }
    }
}