using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.adm.WebBase
{
    /// <summary>
    /// Ajax Json返回统一实体
    /// </summary>
    public class AjaxJsonModel
    {
        public AjaxJsonModel() { }

        public AjaxJsonModel(ResSataus _status)
        {
            this.EnumStatus = _status; 
        }
        public AjaxJsonModel(ResSataus _status, string _resultNumber) 
        {
            this.EnumStatus = _status;
            this.ResultNumber = _resultNumber;
        }

        public AjaxJsonModel(ResSataus _status, string _resultNumber, string _successId)
        {
            this.EnumStatus = _status;
            this.ResultNumber = _resultNumber;
            this.SuccessId = _successId;
        }

        public AjaxJsonModel(ResSataus _status, string _resultNumber, string _successId, string _messages)
        {
            this.EnumStatus = _status;
            this.ResultNumber = _resultNumber;
            this.SuccessId = _successId;
            this.Messages = _messages;
        }

        /// <summary>
        /// 返回结果状态
        /// </summary>
        private ResSataus EnumStatus { get; set; }

        public string Status {
            get { return this.EnumStatus.ToString(); }
        }

        /// <summary>
        /// 返回编码  一般用于保存消息编码
        /// </summary>
        public string ResultNumber { get; set; }

        /// <summary>
        /// 保存成功数据ID   用于新增保存成功后返回的ID
        /// </summary>
        public string SuccessId { get; set; }

        /// <summary>
        /// 返回字符串消息
        /// </summary>
        public string Messages { get; set; }


        /// <summary>
        /// 附加返回属性1
        /// </summary>
        public string Attribute1 { get; set; }
        /// <summary>
        /// 附加返回属性2
        /// </summary>
        public string Attribute2 { get; set; }
        /// <summary>
        /// 附加返回属性3
        /// </summary>
        public string Attribute3 { get; set; }

        /// <summary>
        /// 附加返回属性4
        /// </summary>
        public string Attribute4 { get; set; }
    }

    public enum ResSataus
    {
        Success,
        Error,
        Warn,
        LoginLose
    }
}