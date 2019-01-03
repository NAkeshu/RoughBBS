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
    public partial class userdetail : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();
        string userid;
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayNameandID();
            displayUserPosts();
            displayUserComments();
            displayoldUserInfo();
        }

        protected void displayNameandID()
        {
            this.userid = Request.Cookies["userid"].Value;
            this.username = Request.Cookies["username"].Value;

            name.Text = this.username + "的个人空间";
            id.Text = "账号：" + this.userid;
        }

        protected void displayUserPosts()
        {
            string str = "select count(*) from post where authorid='" + this.userid + "'";
            string postsnum = this.ConnSQL.getSQLData(str);
            posts.Text = postsnum + "篇";
            DataSet ds = new DataSet();
            ds = this.ConnSQL.getUserPostsList(this.userid);
            postslist.DataSource = ds.Tables["userposts"].DefaultView;
            postslist.DataBind();
        }

        protected void displayUserComments()
        {
            string str = "select count(*) from comment where authorid='" + this.userid + "'";
            string commentsnum = this.ConnSQL.getSQLData(str);
            comments.Text = commentsnum + "条";
            DataSet ds = new DataSet();
            ds = this.ConnSQL.getUserCommentsList(this.userid);
            commentslist.DataSource = ds.Tables["usercomments"].DefaultView;
            commentslist.DataBind();
        }

        protected void displayoldUserInfo()
        {
            useridinfo.Text = this.userid;
            oldname.Text = this.username;
            string sqlstr = "select email from users where userid='" + this.userid + "'";
            oldmail.Text = this.ConnSQL.getSQLData(sqlstr);
        }

        protected void changeusername(object sender, EventArgs e)
        {
            string newnametext = newname.Text.ToString();
            if (newnametext != "")
            {
                int flag = this.ConnSQL.updateUsername(this.userid, newnametext);
                if (flag == 1)
                {
                    newname.Text = "";
                    HttpCookie cookie = Request.Cookies["username"];
                    cookie.Value = newnametext;
                    Response.AppendCookie(cookie);
                    Page_Load(sender, e);
                    Response.Write("修改昵称成功");
                }
                else if (flag == 0)
                {
                    Response.Write("修改昵称失败");
                }
                else
                {
                    Response.Write("未知错误");
                }
            }
            else
            {
                Response.Write("昵称不可为空");
            }
            
        }

        protected void changeemail(object sender, EventArgs e)
        {
            string newemailtext = newmail.Text;
            int flag = this.ConnSQL.updateEmail(this.userid, newemailtext);
            if (flag == 1)
            {
                newmail.Text = "";
                displayoldUserInfo();
                Response.Write("修改邮箱成功");
            }
            else if (flag == 0)
            {
                Response.Write("修改邮箱失败");
            }
            else
            {
                Response.Write("未知错误");
            }
        }

        protected void changepassword(object sender, EventArgs e)
        {
            string sqlstr = "select password from users where userid='" + this.userid + "'";
            string oldpwdtext = oldpassword.Text;
            string newpwdtext = newpassword.Text;
            string trueoldpwdtext = this.ConnSQL.getSQLData(sqlstr);
            if (oldpwdtext == trueoldpwdtext)
            {
                if (newpwdtext != "")
                {
                    int flag = this.ConnSQL.updateUserPassword(this.userid, newpwdtext);
                    if (flag == 1)
                    {
                        oldpassword.Text = "";
                        newpassword.Text = "";
                        Response.Write("修改密码成功");
                    }
                    else if (flag == 0)
                    {
                        Response.Write("修改密码失败");
                    }
                    else
                    {
                        Response.Write("未知错误");
                    }
                }
                else
                {
                    Response.Write("新密码不可为空");
                }
            }
            else
            {
                Response.Write("密码错误");
            }
        }
    }
}