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
    public partial class PostsAdmin : System.Web.UI.Page
    {
        BBSSQL connSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            displayData();
        }

        protected void backtoRefferer(object sender, EventArgs e)
        {
            string urlstr = "./SectionsAdmin.aspx";
            Response.Redirect(urlstr);
        }

        protected void displayData()
        {
            DataSet ds = new DataSet();
            ds = this.connSQL.getPostsList(Request.QueryString["section"].ToString());
            PostsAdminGV.DataSource = ds.Tables["postslist"].DefaultView;
            PostsAdminGV.DataBind();
        }

        protected void PostsAdminGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "star")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                int col = 0;
                string postid = PostsAdminGV.Rows[row].Cells[col].Text;
                int flag = this.connSQL.starPost(postid);
                if (flag == 1)
                {
                    Response.Write("加精/取消成功");
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    Response.Write("加精/取消失败");
                }
            }
            else if (e.CommandName == "dl")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                int col = 0;
                string postid = PostsAdminGV.Rows[row].Cells[col].Text;
                int flag = this.connSQL.deletePost(postid);
                if (flag == 1)
                {
                    Response.Write("已删除");
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    Response.Write("删除失败，errorcode=" + flag);
                }
            }
        }
    }
}