using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace WinfromChat
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;//使最大化窗口失效
        }

        public object Connection { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string str = "server=.;uid=sa;pwd=123456;database=WeChat;Connect Timeout=18000;";
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                string strSql = string.Format("select * from Users where UserName='{0}'", txtLogin.Text);
                using (SqlCommand sqlcmd = new SqlCommand(strSql, sqlcon))
                {
                    SqlDataReader sqlDR= sqlcmd.ExecuteReader();
                    if (sqlDR.Read())
                    {
                        string name = sqlDR["UserName"].ToString();
                        string password = sqlDR["UserPassword"].ToString();
                        if (txtPwd.Text==password)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("密码错啦，请重新输入");
                            txtLogin.Clear();
                            txtPwd.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在");
                        txtLogin.Clear();
                        txtPwd.Clear();
                    }
                }
            }
            

             
            ////1.得到账号密码
            //if (txtLogin.Text!="admin"&&txtPwd.Text!="88888")
            //{
            //    MessageBox.Show("账户名和密码错啦");
            //}
            //else
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            ////2.验证输入
        }
    }
}
