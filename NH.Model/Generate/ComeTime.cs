using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ComeTime
    /// </summary>
    public partial class ComeTime
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _sort = Int32.MinValue;

        /// <summary>
        /// Sort
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

    }
}

