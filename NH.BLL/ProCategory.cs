using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProCategory
    {
        public static int GetMaxSort()
        {
            return DAL.ProCategory.GetMaxSort();
        }

        public static int DeleteSubCategory(int id)
        {
            return DAL.ProCategory.DeleteSubCategory(id);
        }

        #region
        /*
        /// <summary>
        /// 递归更新上级Child
        /// </summary>
        /// <param name="path"></param>
        public static void UpdateParentsChildCount(string path)
        {
            string[] ids = path.Split(',');
            foreach (string id in ids)
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    DAL.ProCategory.UpdateParentChildCount(id);
                }
            }
        }
         */
        #endregion

        public static void UpdateParentChildCount(string parentId)
        {
            DAL.ProCategory.UpdateParentChildCount(parentId);
        }

      
    }
}