using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.adm.WebBase
{
    public class ModelEnum
    {
        #region  功能码操作类型描述 FunType
        /// <summary>
        /// 使用操作类型
        /// </summary>
        public enum FunType
        {
            /// <summary>
            /// 查询
            /// </summary>
            Query = 1,
            /// <summary>
            /// 编辑
            /// </summary>
            Edit = 2,
            /// <summary>
            /// 删除
            /// </summary>
            Delete = 3,
            /// <summary>
            /// 方法控制
            /// </summary>
            Control = 4

        }

        /// <summary>
        /// 获取操作类型的中文描述
        /// </summary>
        /// <param name="UseStateType"></param>
        /// <returns></returns>
        public static string FunTypeDesc(FunType _enFunType)
        {
            string _strR = string.Empty;
            switch (_enFunType)
            {
                case FunType.Query:
                    _strR = "查询";
                    break;
                case FunType.Edit:
                    _strR = "添加/编辑";
                    break;
                case FunType.Delete:
                    _strR = "删除";
                    break;
                case FunType.Control:
                    _strR = "方法控制";
                    break;
            }
            return _strR;
        }
        #endregion

        #region 管理员状态枚举
        /// <summary>
        /// 管理员状态枚举
        /// </summary>
        public enum AUserStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            On=1,

            /// <summary>
            /// 禁用
            /// </summary>
            Off=0,

            /// <summary>
            /// 已删除
            /// </summary>
            Delete=-1
        }
        /// <summary>
        /// 获取管理员状态描述
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        public static string AUserStatusDesc(AUserStatus _status)
        {
            string result = null;
            switch (_status)
            { 
                case AUserStatus.On:
                    result = "正常";
                    break;
                case AUserStatus.Off:
                    result = "禁用";
                    break;
                case AUserStatus.Delete:
                    result = "已删除";
                    break;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 审核状态
        /// </summary>
        public enum VerifyStatus
        {
            /// <summary>
            /// 审核通过
            /// </summary>
            True=1,

            /// <summary>
            /// 审核不通过
            /// </summary>
            False=-1,

            /// <summary>
            /// 未审核
            /// </summary>
            NoVerify=0
        }

        /// <summary>
        /// 获取审核状态文字描述
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        public static string VerifyStatusDesc(VerifyStatus _status)
        {
            string result = null;
            switch (_status)
            {
                case VerifyStatus.True:
                    result = "审核通过";
                    break;
                case VerifyStatus.False:
                    result = "审核不通过";
                    break;
                case VerifyStatus.NoVerify:
                    result = "未审核";
                    break;
            }
            return result;
        }
    }
}