using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Xian
    /// </summary>
    public partial class Xian
    {

        private int _tk_id = Int32.MinValue;

        /// <summary>
        /// tk_id
        /// </summary>
        public int tk_id
        {
            get { return _tk_id; }
            set { _tk_id = value; }
        }

        private int _sk_id = Int32.MinValue;

        /// <summary>
        /// sk_id
        /// </summary>
        public int sk_id
        {
            get { return _sk_id; }
            set { _sk_id = value; }
        }

        private string _third_kind_id;

        /// <summary>
        /// third_kind_id
        /// </summary>
        public string third_kind_id
        {
            get { return _third_kind_id; }
            set { _third_kind_id = value; }
        }

        private string _third_kind_name;

        /// <summary>
        /// third_kind_name
        /// </summary>
        public string third_kind_name
        {
            get { return _third_kind_name; }
            set { _third_kind_name = value; }
        }

        private string _third_kind_salary_id;

        /// <summary>
        /// third_kind_salary_id
        /// </summary>
        public string third_kind_salary_id
        {
            get { return _third_kind_salary_id; }
            set { _third_kind_salary_id = value; }
        }

        private string _third_kind_is_retail;

        /// <summary>
        /// third_kind_is_retail
        /// </summary>
        public string third_kind_is_retail
        {
            get { return _third_kind_is_retail; }
            set { _third_kind_is_retail = value; }
        }

    }
}

