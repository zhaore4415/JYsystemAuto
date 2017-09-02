using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// area
    /// </summary>
    public partial class area
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _code;

        /// <summary>
        /// code
        /// </summary>
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;

        /// <summary>
        /// name
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _cityid;

        /// <summary>
        /// cityId
        /// </summary>
        public string cityId
        {
            get { return _cityid; }
            set { _cityid = value; }
        }

    }
}

