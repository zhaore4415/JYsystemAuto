using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NH.Model
{
    public class OnlineMemberModel
    {
        public string loginName;
        public DateTime refreshTime;
        public string sessionId;
        /// <summary>
        /// 状态：1:正常；2:资料有更新，需要重新获取资料
        /// </summary>
        public int status;
    }
}
