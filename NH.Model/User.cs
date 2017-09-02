using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        private OnlineMemberModel _onlineModel;

        public OnlineMemberModel OnlineModel
        {
            get { return _onlineModel; }
            set { _onlineModel = value;}
        }
    }
}

