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
    public partial class signup : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string ID = IDText.Text;
            string Name = UsernameText.Text;
            string Password = PasswordText.Text;
            string Ensure = ensurePassword.Text;
            string Email = EmailText.Text;

            if (ID != "")
            {
                if (Name != "")
                {
                    if (Password != "")
                    {
                        if (Ensure == Password)
                        {
                            if (Email != "")
                            {
                                if (this.ConnSQL.isRegistered(ID) == false)
                                {
                                    if (this.ConnSQL.signupUsertoSQL(ID, Name, Password, Email) == 1)
                                        Label5.Text = "注册成功！";
                                    HttpCookie MyCookie = new HttpCookie("userid");
                                    MyCookie.Value = ID;
                                    MyCookie.Expires = DateTime.Now.AddDays(20);
                                    HttpCookie NameCookie = new HttpCookie("username");
                                    NameCookie.Value = Name;
                                    NameCookie.Expires = DateTime.Now.AddDays(20);
                                    HttpCookie AdminCookie = new HttpCookie("isAdmin");
                                    AdminCookie.Value = '0'.ToString();
                                    MyCookie.Expires = DateTime.Now.AddDays(20);
                                    Response.Cookies.Add(MyCookie);
                                    Response.Cookies.Add(NameCookie);
                                    Response.Cookies.Add(AdminCookie);
                                    Response.Redirect(Session["UrlRefferer"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            Label5.Text = "注册失败";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./signin.aspx");
        }
    }
}