using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web
{
    public partial class 事务 : System.Web.UI.Page
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        SqlConnection conn = new SqlConnection(ConnectionString);//VR2ZV92W0C15Y1X\SQLEXPRESS;database=ebase56;uid=sa;pwd=cssao888
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 普通事务：单数据库之间 //cmd.Transaction = conn.BeginTransaction();    //cmd.Transaction.Commit();    cmd.Transaction.Rollback();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                try
                {
                    cmd.Transaction = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into test([Class]
                           ,[Teacher] ) values
                            ('三年级','小毛老师')";

                  
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into test2 values('大毛')";
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    Response.Write("成功");
                }
                catch (Exception err)
                {
                    Response.Write(err);
                    cmd.Transaction.Rollback();
                }
            }
        }
        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"insert into test([Class]
                           ,[Teacher] ) values
                            ('三年级','小毛老师2')
                ", conn);
            try
            {

                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into test2([Student],[Address]) values('10a','深圳')";
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                Response.Write("成功");
            }
            catch (Exception err)
            {
                Response.Write(err);
                cmd.Transaction.Rollback();
            }


            //conn.Open();
            //SqlCommand command = new SqlCommand(@"insert into test([Class]
            //               ,[Teacher] ) values
            //                ('三年级','小毛老师2')", conn);
            //try
            //{
            //    command.Transaction = conn.BeginTransaction();
            //    command.ExecuteNonQuery();
            //    command.CommandText = "insert into test values(222)";
            //    command.ExecuteNonQuery();
            //    command.Transaction.Commit();
            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine(err);
            //    command.Transaction.Rollback();
            //}

        }
        /// <summary>
        /// DTC(Distributed Transaction Coordinator) 分布式事务处理 ：多数据库之间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"insert into test([Class]
                           ,[Teacher] ) values
                            ('三年级','小毛老师2')

                ", conn);
                try
                {
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "insert into test3 values('大毛2')";
                    cmd.ExecuteNonQuery();

                    test2();
                    ts.Complete();
                }
                catch (Exception err)
                {
                    Response.Write(err);

                }
            }
        }

        //嵌套事务
        private void test2()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //departmentdal deptdal = new departmentdal();
                //deptdal.insert("嵌套事务");
                ts.Complete();
            }
        }


    }
}