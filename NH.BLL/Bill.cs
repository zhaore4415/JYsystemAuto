using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NH.BLL
{
    public partial class Bill
    {
        public static long GetMaxSort()
        {
            return DAL.Bill.GetMaxSort();
        }
        #region 更新一条数据
        /// <summary>
        /// 
        /// 更新一条数据
        /// </summary>
        public static bool UpdateOrder(NH.Model.Bill model)
        {
            return DAL.Bill.UpdateOrder(model);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool ExistsOrder(long OrderNumber)
        {
            return DAL.Bill.ExistsOrder(OrderNumber);
        }
        #endregion
    }
}
