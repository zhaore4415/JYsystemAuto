using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NH.Web.adm.Company
{
    public partial class CompanyTag : WebBase.Edit
    {
        protected int _TagId1 = 0;
        protected int _TagId2 = 0;
        protected int _TagId3 = 0;
        protected string _TagImg1 = null;
        protected string _TagImg2 = null;
        protected string _TagImg3 = null;
        protected int _status1 = 0;
        protected int _status2 = 0;
        protected int _status3 = 0;
        protected string _startdate1;
        protected string _enddate1;
        protected string _startdate2;
        protected string _enddate2;
        protected string _startdate3;
        protected string _enddate3;

        protected string _Folder = "/Upload/TagImg/";

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "JinJi":
                    Modify(1);
                    break;
                case "VIP":
                    Modify(2);
                    break;
                case "PinPai":
                    Modify(3);
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            Model.CompanyTag model1 = new Model.CompanyTag() { CompanyId = Id, TypeId = 1 };
            model1 = BLL.CompanyTag.GetModel(model1);
            if (model1 != null)
            {
                _TagId1 = model1.Id;
                _TagImg1 = _Folder + model1.Logo;
                _status1 = model1.Status;
                _startdate1 = model1.StartDate.HasValue ? model1.StartDate.Value.ToString("yyyy-MM-dd") : "";
                _enddate1 = model1.EndDate.HasValue ? model1.EndDate.Value.ToString("yyyy-MM-dd") : "";
            }


            Model.CompanyTag model2 = new Model.CompanyTag() { CompanyId = Id, TypeId = 2 };
            model2 = BLL.CompanyTag.GetModel(model2);
            if (model2 != null)
            {
                _TagId2 = model2.Id;
                _TagImg2 = _Folder + model2.Logo;
                _status2 = model2.Status;
                _startdate2 = model2.StartDate.HasValue ? model2.StartDate.Value.ToString("yyyy-MM-dd") : "";
                _enddate2 = model2.EndDate.HasValue ? model2.EndDate.Value.ToString("yyyy-MM-dd") : "";
            }


            Model.CompanyTag model3 = new Model.CompanyTag() { CompanyId = Id, TypeId = 3 };
            model3 = BLL.CompanyTag.GetModel(model3);
            if (model3 != null)
            {
                _TagId3 = model3.Id;
                _TagImg3 = _Folder + model3.Logo;
                _status3 = model3.Status;
                _startdate3 = model3.StartDate.HasValue ? model3.StartDate.Value.ToString("yyyy-MM-dd") : "";
                _enddate3 = model3.EndDate.HasValue ? model3.EndDate.Value.ToString("yyyy-MM-dd") : "";
            }
        }

        private void Modify(int typeId)
        {
            int tagId = int.Parse(Request.Form["TagId"]);
            //int typeId = 1;
            HttpPostedFile hpf = Request.Files[0];
            string filename = null;
            DateTime? startdate = null;
            DateTime? enddate = null;

            Model.CompanyTag temp = BLL.CompanyTag.GetModel(new Model.CompanyTag() { CompanyId = Id, TypeId = typeId });

            if (tagId == 0)
            {
                //添加
                if (temp != null)
                {
                    Maticsoft.Common.Ajax.WriteError("此推荐已经存在");
                }
            }
            else
            {
                //修改
                if (temp == null)
                {
                    Maticsoft.Common.Ajax.WriteError("操作失败");
                }
            }
            if (!Directory.Exists(Server.MapPath(_Folder)))
            {
                Directory.CreateDirectory(Server.MapPath(_Folder));
            }

            try
            {
                startdate = DateTime.Parse(Request.Form["txtStartDate" + typeId]); 
            }
            catch
            {
                startdate = DateTime.MinValue;
            }
            try
            {
                enddate = DateTime.Parse(Request.Form["txtEndDate" + typeId]);
            }
            catch
            {
                enddate = DateTime.MinValue;
            }

            if (tagId == 0)
            {
                //添加
                if (hpf.ContentLength == 0)
                {
                    Maticsoft.Common.Ajax.WriteError("请选择LOGO图片");
                }
                if (!Maticsoft.Common.ImageHelper.IsWebImage(hpf.ContentType))
                {
                    Maticsoft.Common.Ajax.WriteError("图片格式不正确");
                }
                filename = typeId + "_" + DateTime.Now.ToString("yyMMddhhmmss") + "_" + Id.ToString() + Path.GetExtension(hpf.FileName);

                Model.CompanyTag model = new Model.CompanyTag();
                model.CompanyId = Id;
                model.Logo = filename;
                model.TypeId = typeId;
                model.StartDate = startdate;
                model.EndDate = enddate;
                model.Status = 1;
                model.AddTime = DateTime.Now;

                if (BLL.CompanyTag.Add(model) > 0)
                {
                    hpf.SaveAs(Server.MapPath(_Folder + filename));
                    Maticsoft.Common.Ajax.WriteOk("操作成功");
                }
                else
                {
                    Maticsoft.Common.Ajax.WriteError("操作失败");
                }
            }
            else
            {
                //修改
                if (hpf.ContentLength > 0)
                {
                    if (!Maticsoft.Common.ImageHelper.IsWebImage(hpf.ContentType))
                    {
                        Maticsoft.Common.Ajax.WriteError("图片格式不正确");
                    }
                    else
                    {
                        filename = typeId + "_" + DateTime.Now.ToString("yyMMddhhmmss") + "_" + Id.ToString() + Path.GetExtension(hpf.FileName);
                    }
                }

                Model.CompanyTag model = new Model.CompanyTag();
                model.Id = tagId;
                model.Logo = filename;
                model.Status = Request.Form["cbTag" + typeId] == "1" ? 1 : 0;
                model.StartDate = startdate;
                model.EndDate = enddate;

                if (BLL.CompanyTag.Update(model))
                {
                    if (filename != null)
                    {
                        File.Delete(Server.MapPath(_Folder + temp.Logo));//删除旧图片
                        hpf.SaveAs(Server.MapPath(_Folder + filename));//保存新图片
                    }
                    Maticsoft.Common.Ajax.WriteOk("修改成功");
                }
                else
                {
                    Maticsoft.Common.Ajax.WriteError("修改失败");
                }
            }
        }

    }
}