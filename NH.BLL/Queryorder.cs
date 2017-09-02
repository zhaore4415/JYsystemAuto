using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NH.BLL
{
    public partial class Queryorder
    {
        /// <summary>
        /// OrderNumber 自增
        /// </summary>
        /// <returns></returns>
        public static long GetMaxSort()
        {
            return DAL.Queryorder.GetMaxSort();
        }
        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateOrder(NH.Model.Queryorder model)
        {
            return DAL.Queryorder.UpdateOrder(model);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsOrder(long OrderNumber)
        {
            return DAL.Queryorder.ExistsOrder(OrderNumber);
        }
        #endregion
    }
}
