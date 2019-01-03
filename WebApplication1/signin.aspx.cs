using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using connectSQL;

namespace WebApplication1
{
    public partial class signin : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["errormessage"]);
            Session["errormessage"] = "";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string UserID = UserIDText.Text;
            string Password = PasswordText.Text;
            string SqlCommand = "SELECT password FROM users WHERE (userid = '" + UserID + "');";
            string UserPassword = this.ConnSQL.getSQLData(SqlCommand);
            if (Password == UserPassword)
            {
                Label3.Text = "登陆成功";
                HttpCookie MyCookie = new HttpCookie("userid");
                MyCookie.Value = UserID;
                MyCookie.Expires = DateTime.Now.AddDays(20);
                HttpCookie NameCookie = new HttpCookie("username");
                string sqlstr = "select username from users where userid='" + UserID + "'";
                NameCookie.Value = this.ConnSQL.getSQLData(sqlstr);
                NameCookie.Expires = DateTime.Now.AddDays(20);
                HttpCookie AdminCookie = new HttpCookie("isAdmin");
                AdminCookie.Value = isAdmin(UserID);
                MyCookie.Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(MyCookie);
                Response.Cookies.Add(NameCookie);
                Response.Cookies.Add(AdminCookie);
                Response.Redirect(Session["UrlRefferer"].ToString());
            }
            else
            {
                Label3.Text = "密码或账号错误";
            }
        }

        protected string isAdmin(string UserID)
        {
            string SqlCommand = "SELECT isAdmin FROM users WHERE (userid = '" + UserID + "');";
            string result = this.ConnSQL.getSQLData(SqlCommand);
            return result;
        }

        protected void signupBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("./signup.aspx");
        }
    }
}