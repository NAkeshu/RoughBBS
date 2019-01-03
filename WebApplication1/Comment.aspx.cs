using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connectSQL;

namespace WebApplication1
{
    public partial class Comment : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();
        string username;
        string userid;
        int tofloor;
        string postid;
        string postname;
        int floor;
        string Ctext;
        string NowTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayCommentInfo();
        }

        protected void displayCommentInfo()
        {
            this.username = Request.Cookies["username"].Value;
            this.userid = Request.Cookies["userid"].Value;
            this.tofloor = Convert.ToInt32(Session["tofloor"]);
            this.postid = Session["postid"].ToString();
            this.postname = Session["postname"].ToString();
            this.floor = this.ConnSQL.getCommentNum(postid) + 1;
            this.NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            user.Text = this.username + "（" + this.userid + "）";
            if (tofloor == 0)
            {
                commenttowho.Text = this.postname + "（主题帖）";
            }
            else
            {
                commenttowho.Text = this.postname + "【对" + tofloor + "楼的评论】";
            }
            commenttime.Text = this.NowTime;
        }

        protected void submitComment(object sender, EventArgs e)
        {
            this.Ctext = CommentText.Text.ToString();
            if (this.tofloor != 0)
            {
                this.Ctext = "【回复" + this.tofloor + "楼】" + this.Ctext;
            }

            int flag = this.ConnSQL.insertComment(floor, postid, userid, Ctext, NowTime, tofloor);
            if (flag == 0)
            {
                Response.Write("评论失败，errorcode: flag=0");
            }
            else if (flag == 1)
            {
                int fflag = this.ConnSQL.updatePostforComment(NowTime, floor, postid);
                if (fflag == 1)
                {
                    Response.Write("评论成功！将返回主题页");
                    Response.Redirect(Session["UrlRefferer"].ToString());
                }
                else if (fflag == 0)
                {
                    Response.Write("评论失败，errorcode: fflag=0");
                }
                else
                {
                    Response.Write("未知错误");
                }
            }
            else
            {
                Response.Write("未知错误");
            }

        }

        protected void backtoPostDetail(object sender, EventArgs e)
        {
            Response.Redirect(Session["UrlRefferer"].ToString());
        }
    }
}