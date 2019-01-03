using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connectSQL;

namespace WebApplication1
{
    public partial class Post : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();
        string username;
        string userid;
        string section;
        string topic;
        string text;
        string NowTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayPostInfo();
        }

        protected void displayPostInfo()
        {
            this.username = Request.Cookies["username"].Value;
            this.userid = Request.Cookies["userid"].Value;
            this.section = Session["section"].ToString();
            this.NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            authorni.Text = this.username + "（" + this.userid + "）";
            SectionName.Text = this.section;
            posttime.Text = this.NowTime;
        }

        protected void submitPost(object sender, EventArgs e)
        {
            this.topic = posttopic.Text;
            this.text = posttext.Text;

            int flag = this.ConnSQL.insertPost(this.section, this.userid, this.topic, this.text, this.NowTime);
            if (flag == 1)
            {
                int fflag = this.ConnSQL.updateSectionforPost(this.section, this.NowTime);
                if (fflag == 1)
                {
                    Response.Write("发表成功！即将返回");
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
            else if (flag == 0)
            {
                Response.Write("评论失败，errorcode: flag=0");
            }
            else
            {
                Response.Write("未知错误");
            }
        }

        protected void backtoPostsList(object sender, EventArgs e)
        {
            Response.Redirect(Session["UrlRefferer"].ToString());
        }

    }
}