using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPKaoQinSetting
    /// </summary>
    public partial class ERPKaoQinSetting
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _guidingtime1;

        /// <summary>
        /// GuiDingTime1
        /// </summary>
        public string GuiDingTime1
        {
            get { return _guidingtime1; }
            set { _guidingtime1 = value; }
        }

        private string _guidingtime2;

        /// <summary>
        /// GuiDingTime2
        /// </summary>
        public string GuiDingTime2
        {
            get { return _guidingtime2; }
            set { _guidingtime2 = value; }
        }

    }
}

