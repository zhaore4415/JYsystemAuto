using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WeiPay
{
    /**
    * 
    * 作用：微信支付相关支付信息实体类，支付信息通过该类封装，微信支付版本V3.3.7
    * 作者：邹学典
    * 编写日期：2014-12-25
    * 
    * 
    * */
    public class PayModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 手机号
        /// </summary>
        private string _tel;

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        /// <summary>
        /// 联系地址
        /// </summary>
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 购买数量
        /// </summary>
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 产品图片
        /// </summary>
        private string _pic;

        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        private string _pname;

        public string Pname
        {
            get { return _pname; }
            set { _pname = value; }
        }

        /// <summary>
        /// 备注型号
        /// </summary>
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        /// <summary>
        /// 订单及详情共有ID
        /// </summary>
        private string _qdid;

        public string Qdid
        {
            get { return _qdid; }
            set { _qdid = value; }
        }
        /// <summary>
        /// 商户自己的订单号（必填）
        /// </summary>

        private string ordersn;
        public string OrderSN
        {
            get
            {
                //if (string.IsNullOrEmpty(ordersn))
                //    return DateTime.Now.ToString("yyMMddHHmmssff");
                return ordersn;
            }
            set
            {
                ordersn = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal ChuShou { get; set; }
        /// <summary>
        /// 订单支付金额单位为分（必填）
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 商品信息（必填，长度不能大于127字符）
        /// </summary>
        private string body;
        public string Body
        {
            get
            {
                if (string.IsNullOrEmpty(body))
                    return "微信支付";
                if (body.Length > 127)
                    return body.Substring(0, 120) + "...";
                return body;
            }
            set
            {
                body = value;
            }
        }
        /// <summary>
        /// 授权码code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 支付用户微信OpenId（必填）
        /// </summary>
        public string OpenId { get; set; }


        /// <summary>
        /// 用户自定义参数原样返回，不能有中文不然调用Notify页面会有错误。（长度不能大于127字符）
        /// </summary>
        /// 
        public string Attach { get; set; }

        /// <summary>
        /// 是否付了定金
        /// </summary>
        /// 
        public int IsPayment { get; set; }

        /// <summary>
        /// 重写ToString函数，获取跳转到支付页面的url其中附带参数
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("PayDetail.aspx?");
            sb.AppendFormat("ispayment={0}", IsPayment);
            sb.AppendFormat("&OrderSN={0}", OrderSN);
            //sb.AppendFormat("&Code={0}", Code); 
            //sb.AppendFormat("&Body={0}", Body);
            //sb.AppendFormat("&UserOpenId={0}", OpenId);
            //sb.AppendFormat("&Attach={0}", Attach);
         
            return sb.ToString();
        }

    }
}
