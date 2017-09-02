using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// RecommendCode
    /// </summary>
    public partial class RecommendCode
    {
        

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateCode(NH.Model.RecommendCode model)
        {
            return DAL.RecommendCode.UpdateCode(model);
        }
        #endregion

    
    }
}