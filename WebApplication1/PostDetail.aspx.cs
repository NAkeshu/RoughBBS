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
    public partial class PostDetail : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                displayPostDetail();
                displayComments();
            }
        }

        protected void displayPostDetail()
        {
            DataSet ds = this.ConnSQL.getPostDetail(Request.QueryString["id"].ToString());
            PostDetailGV.DataSource = ds.Tables["postdetail"].DefaultView;
            PostDetailGV.DataBind();
        }

        protected void commentthePost(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] != null)
            {
                Session["tofloor"] = "0";
                Session["postid"] = Request.QueryString["id"].ToString();
                Session["postname"] = Request.QueryString["topic"].ToString();
                Response.Redirect("./Comment.aspx");
            }
            else
            {
                Session["errormessage"] = "评论前请先登录！";
                Response.Redirect("./signin.aspx");
            }
        }

        protected int countCommentNum()
        {
            int num;
            num = this.ConnSQL.getCommentNum(Request.QueryString["id"].ToString());
            return num;
        }

        protected void displayComments()
        {
            DataSet ds = this.ConnSQL.getComemnts(Request.QueryString["id"].ToString());
            CommentsList.DataSource = ds.Tables["comments"].DefaultView;
            CommentsList.DataBind();
        }

        protected void CommentsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "commenttoComment")
            {
                int floor = Convert.ToInt32(e.CommandArgument) + 1;
                if (Request.Cookies["userid"] != null)
                {
                    Session["tofloor"] = floor;
                    Session["postid"] = Request.QueryString["id"].ToString();
                    Session["postname"] = Request.QueryString["topic"].ToString();
                    Response.Redirect("./Comment.aspx");
                }
                else
                {
                    Session["errormessage"] = "评论前请先登录！";
                    Response.Redirect("./signin.aspx");
                }
            }
        }

        protected void backtoRefferer(object sender, EventArgs e)
        {
            string sqlstr = "select sectionname from post where postid='" + Request.QueryString["id"].ToString() + "'";
            string sectionname = this.ConnSQL.getSQLData(sqlstr);
            string urlstr = "./PostsList.aspx?section=" + sectionname;
            Response.Redirect(urlstr);
        }
    }
}