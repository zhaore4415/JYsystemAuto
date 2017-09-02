using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPFormType
    /// </summary>
    public partial class ERPFormType
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

        private string _formtypelist;

        /// <summary>
        /// FormTypeList
        /// </summary>
        public string FormTypeList
        {
            get { return _formtypelist; }
            set { _formtypelist = value; }
        }

    }
}

