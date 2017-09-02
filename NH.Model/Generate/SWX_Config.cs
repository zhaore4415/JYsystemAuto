using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    //SWX_Config
    public partial class SWX_Config
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id = Int32.MinValue;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// access_token
        /// </summary>		
        private string _access_token;
        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }
        /// <summary>
        /// CorpId
        /// </summary>		
        private string _corpid;
        public string CorpId
        {
            get { return _corpid; }
            set { _corpid = value; }
        }
        /// <summary>
        /// Secret
        /// </summary>		
        private string _secret;
        public string Secret
        {
            get { return _secret; }
            set { _secret = value; }
        }

    }
}

