using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Shi
    /// </summary>
    public partial class Shi
    {

        private int _sk_id = Int32.MinValue;

        /// <summary>
        /// sk_id
        /// </summary>
        public int sk_id
        {
            get { return _sk_id; }
            set { _sk_id = value; }
        }

        private int _fk_id = Int32.MinValue;

        /// <summary>
        /// fk_id
        /// </summary>
        public int fk_id
        {
            get { return _fk_id; }
            set { _fk_id = value; }
        }

        private string _second_kind_id;

        /// <summary>
        /// second_kind_id
        /// </summary>
        public string second_kind_id
        {
            get { return _second_kind_id; }
            set { _second_kind_id = value; }
        }

        private string _second_kind_name;

        /// <summary>
        /// second_kind_name
        /// </summary>
        public string second_kind_name
        {
            get { return _second_kind_name; }
            set { _second_kind_name = value; }
        }

        private string _second_kind_salary_id;

        /// <summary>
        /// second_kind_salary_id
        /// </summary>
        public string second_kind_salary_id
        {
            get { return _second_kind_salary_id; }
            set { _second_kind_salary_id = value; }
        }

        private string _second_kind_sale_id;

        /// <summary>
        /// second_kind_sale_id
        /// </summary>
        public string second_kind_sale_id
        {
            get { return _second_kind_sale_id; }
            set { _second_kind_sale_id = value; }
        }

    }
}

