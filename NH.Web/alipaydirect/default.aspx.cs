using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Alipay;

namespace NH.Web.alipaydirect.create_direct_pay_by_user_CSHARP_UTF_8
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnAlipay_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = "http://fx.buccker.net/alipaydirect/notify_url.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = "http://fx.buccker.net/alipaydirect/return_url.aspx";//buyer_email=zhaore4415%40163.com&buyer_id=2088712290144873&exterface=create_direct_pay_by_user&is_success=T&notify_id=RqPnCoPT3K9%252Fvwbh3InUEzU%252BKEbm2hrSaGTN1KEaDZlJdQOB4toTNOj4HkSNKmxq1EOe&notify_time=2016-02-19+13%3A45%3A27&notify_type=trade_status_sync&out_trade_no=1002&payment_type=1&seller_email=finance%40phonetou.com&seller_id=2088511830821124&subject=a&total_fee=0.01&trade_no=2016021921001004870203589342&trade_status=TRADE_SUCCESS&sign=af351bcb250ea4aa77b405eaa4ab840a&sign_type=MD5
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //商户订单号
            string out_trade_no = WIDout_trade_no.Text.Trim();
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = WIDsubject.Text.Trim();
            //必填

            //付款金额
            string total_fee = WIDtotal_fee.Text.Trim();
            //必填

            //订单描述

            string body = WIDbody.Text.Trim();
            //商品展示地址
            string show_url = WIDshow_url.Text.Trim();
            //需以http://开头的完整路径，例如：http://www.商户网址.com/myorder.html

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = "";
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner",Config.Partner);
            sParaTemp.Add("seller_email", Config.Seller_email);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);

        }
    }
}