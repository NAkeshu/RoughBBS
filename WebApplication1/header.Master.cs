using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isLogin();
            Session["UrlRefferer"] = Request.Url.ToString();
        }

        protected int isLogin()
        {
            if (Request.Cookies["username"] != null) // 验证是否登录，更改网页登录按钮
            {
                signPanel.Controls.Clear();
                HyperLink UserDetail = new HyperLink();
                UserDetail.Text = Request.Cookies["username"].Value;
                UserDetail.NavigateUrl = "userdetail.aspx";
                Button signoutBTN = new Button();
                signoutBTN.Text = "退出";
                signoutBTN.Command += new CommandEventHandler(signoutBTN_Click);
                signPanel.Controls.Add(UserDetail);
                if (Request.Cookies["isAdmin"] != null && Request.Cookies["isAdmin"].Value.Equals("1"))
                {
                    Button SectionAdminBTN = new Button();
                    Button UserAdminBTN = new Button();
                    SectionAdminBTN.Text = "版区管理";
                    UserAdminBTN.Text = "用户管理";
                    SectionAdminBTN.Command += new CommandEventHandler(SectionsAdminBTN_Click);
                    UserAdminBTN.Command += new CommandEventHandler(UsersAdminBTN_Click);
                    signPanel.Controls.Add(SectionAdminBTN);
                    signPanel.Controls.Add(UserAdminBTN);
                }
                signPanel.Controls.Add(signoutBTN);
                return 1;
            }
            else
                return 0;
        }

        protected void signinBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("signin.aspx");
        }

        protected void signupBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void signoutBTN_Click(object sender, EventArgs e)
        {
            string urlstr = Request.Url.ToString();
            string[] sArray = urlstr.Split('/');
            
            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            if (sArray[3] == "userdetail.aspx")
            {
                Response.Redirect("./Sections.aspx");
            }
            else
            {
                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void SectionsAdminBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("SectionsAdmin.aspx");
        }

        protected void UsersAdminBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersAdmin.aspx");
        }
    }
}