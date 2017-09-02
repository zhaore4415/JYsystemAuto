using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Shen
    /// </summary>
    public partial class Shen
    {

        private int _fk_id = Int32.MinValue;

        /// <summary>
        /// fk_id
        /// </summary>
        public int fk_id
        {
            get { return _fk_id; }
            set { _fk_id = value; }
        }

        private string _first_kind_id;

        /// <summary>
        /// first_kind_id
        /// </summary>
        public string first_kind_id
        {
            get { return _first_kind_id; }
            set { _first_kind_id = value; }
        }

        private string _first_kind_name;

        /// <summary>
        /// first_kind_name
        /// </summary>
        public string first_kind_name
        {
            get { return _first_kind_name; }
            set { _first_kind_name = value; }
        }

        private string _first_kind_salary_id;

        /// <summary>
        /// first_kind_salary_id
        /// </summary>
        public string first_kind_salary_id
        {
            get { return _first_kind_salary_id; }
            set { _first_kind_salary_id = value; }
        }

        private string _first_kind_sale_id;

        /// <summary>
        /// first_kind_sale_id
        /// </summary>
        public string first_kind_sale_id
        {
            get { return _first_kind_sale_id; }
            set { _first_kind_sale_id = value; }
        }

    }
}

