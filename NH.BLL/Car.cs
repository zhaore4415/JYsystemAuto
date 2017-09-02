using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NH.BLL
{
    public partial class Car
    {
        public static int GetNums(string uid, long OrderSN)
        {
            return DAL.Car.GetNums(uid, OrderSN);
        }
        public static decimal GetSums(string uid, long OrderSN)
        {
            return DAL.Car.GetSums(uid,OrderSN);
        }
        public static int GetJiFen(string uid, long OrderSN)
        {
            return DAL.Car.GetJiFen(uid, OrderSN);
        }
        #region 删除一条数据
        /// <summary>
        /// 根据订单号删除数据
        /// </summary>
        public static bool DeleteUId(int order)
        {
            return DAL.Car.DeleteUId(order);
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateNum(NH.Model.Car model)
        {
            return DAL.Car.UpdateNum(model);
        }
        #endregion
        #region 更新一条数据
        /// <summary>
        /// 更新订单状态
        /// </summary>
        public static bool UpdateOrder(NH.Model.Car model)
        {
            return DAL.Car.UpdateOrder(model);
        }
        #endregion
    }
}
