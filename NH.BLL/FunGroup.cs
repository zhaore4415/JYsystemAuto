using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// FunGroup
    /// </summary>
    public partial class FunGroup
    {
        public static List<Model.FunGroup> GetSortedList()
        {
            List<Model.FunGroup> SortList = new List<Model.FunGroup>();
            List<Model.FunGroup> list = GetModelList("");
            return list;



 
        }
    }
}