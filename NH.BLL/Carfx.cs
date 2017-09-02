using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NH.BLL
{
    public partial class Carfx
    {
        public static int GetNums(string uid, long OrderSN)
        {
            return DAL.Carfx.GetNums(uid, OrderSN);
        }
        public static int GetSums(string uid, long OrderSN)
        {
            return DAL.Carfx.GetSums(uid,OrderSN);
        }

        #region 删除一条数据
        /// <summary>
        /// 根据订单号删除数据
        /// </summary>
        public static bool DeleteUId(int order)
        {
            return DAL.Carfx.DeleteUId(order);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateNum(NH.Model.Carfx model)
        {
            return DAL.Carfx.UpdateNum(model);
        }
        #endregion
        #region 更新一条数据
        /// <summary>
        /// 更新订单状态
        /// </summary>
        public static bool UpdateOrder(NH.Model.Carfx model)
        {
            return DAL.Carfx.UpdateOrder(model);
        }
        #endregion
    }
}
