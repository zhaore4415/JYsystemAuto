using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class Company2Service : WebBase.Free
    {
        protected string selectedId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"])
            {
                case "Add":
                    Add();
                    break;
                default:
                    break;
            }

            DataTable dtSelected = BLL.Service2Company.GetList("CompanyId=" + Id).Tables[0];

            List<string> serviceIds = new List<string>();
            foreach (DataRow row in dtSelected.Rows)
            {
                serviceIds.Add(row["ServiceId"].ToString());
            }
            if (serviceIds.Count > 0)
            {
                selectedId = "['" + string.Join("','", serviceIds.ToArray()) + "']";
            }
            else
            {
                selectedId = "[]";
            }
        }

        private void Add()
        {
            int companyid = int.Parse(Request.Form["companyid"]);
            string sids = Request.Form["service"];
            if (string.IsNullOrEmpty(sids))
            {
                Maticsoft.Common.Ajax.WriteError("请选择负责人");
            }

            //删除已取消的
            BLL.Service2Company.DeleteByWhere("CompanyId = " + companyid + " and ServiceId not in (" + sids + ")");

            string[] arryIds = sids.Split(',');
            foreach (string id in arryIds)
            {
                Model.Service2Company model = new Model.Service2Company();
                model.CompanyId = companyid;
                model.ServiceId = int.Parse(id);

                //如果不存在则添加
                if (!BLL.Service2Company.Exists(model))
                {
                    BLL.Service2Company.Add(model);
                }
            }

            Maticsoft.Common.Ajax.WriteOk("操作成功");

            Response.End();
        }

    }
}