using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NH.Web.adm.Person
{
    public partial class PersonIdentityVerify : WebBase.Edit
    {
        protected int _status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "verify":
                    Verify();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            Model.IdentityVerify model = new Model.IdentityVerify() { MemberID = Id };
            model = BLL.IdentityVerify.GetModel(model);
            if (model != null)
            {
                lbStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)model.Status);
                lbIdentityNo.Text = model.IdentityNo;
                lbExpireDate.Text = model.ExpireDate.ToString("yyyy-MM-dd");
                lbSex.Text = model.Sex.Value ? "男" : "女";
                lbTel.Text = model.Tel;
                lbQQ.Text = model.QQ;
                string filepath = "/Upload/IdentityFile/" + model.IdentityImg;
                if (File.Exists(Server.MapPath(filepath)))
                {
                    imgIdentity.ImageUrl = filepath;
                    imgIdentity.Visible = true;
                }
                _status = model.Status;

                phContent.Visible = true;
                phEmpty.Visible = false;
            }
            else
            {
                phContent.Visible = false;
                phEmpty.Visible = true;
            } 
        }

        private void Verify()
        {
            Model.IdentityVerify model = BLL.IdentityVerify.GetModel(Id);
            if (model == null) Maticsoft.Common.Ajax.WriteError("不存在此记录");

            model.Id = Id;
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.IdentityVerify.Update(model))
            {
                Model.Member member = new Model.Member();
                member.Id = model.MemberID;
                member.IdentityVerified = model.Status == 1;
                BLL.Member.Update(member);
                BLL.Member.UpdateComplete(Id);
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }
    }
}