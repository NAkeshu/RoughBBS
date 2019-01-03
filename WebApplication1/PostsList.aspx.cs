using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connectSQL;

namespace WebApplication1
{
    public partial class PostsList : System.Web.UI.Page
    {
        string SectionName;
        BBSSQL ConnSQL = new BBSSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SectionName = getSectionName();
            displaySectionInfo();
            displayPostsList();
        }

        protected string getSectionName()
        {
            string str;
            str = Request.QueryString["section"];
            return str;
        }

        protected void displaySectionInfo()
        {
            SectionNameInfo.Text = this.SectionName;
            SectionDetailInfo.Text = this.ConnSQL.getSectionDetail(this.SectionName);
        }

        protected void displayPostsList()
        {
            DataSet PostsListsds = new DataSet();
            PostsListsds = this.ConnSQL.getPostsList(SectionName);
            PostsListGV.DataSource = PostsListsds.Tables["postslist"].DefaultView;
            PostsListGV.DataBind();
        }

        protected void backtoRefferer(object sender, EventArgs e)
        {
            string urlstr = "./Sections.aspx";
            Response.Redirect(urlstr);
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] != null)
            {
                Session["section"] = Request.QueryString["section"];
                Response.Redirect("./Post.aspx");
            }
            else
            {
                Session["errormessage"] = "评论前请先登录！";
                Response.Redirect("./signin.aspx");
            }
            
        }
    }
}