using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ReceiveRecord
    /// </summary>
    public partial class ReceiveRecord
    {

        /// <summary>
        /// 接站剩余天数
        /// </summary>
        public int ReceiveLeftDays
        {
            get
            {
                return (int)Math.Ceiling((DateTime.Parse(EndDate.ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))).TotalDays);

            }
        }

    }
}

