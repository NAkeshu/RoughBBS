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
    public partial class SectionAdmin : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createnewsection(object sender, EventArgs e)
        {
            string sectionname = newsectionname.Text;
            string sectiondetail = newsectiondetail.Text;
            string ownerid = newownerid.Text;

            if (sectionname != "")
            {
                string sqlstr = "select count(*) from section where sectionname='" + sectionname + "'";
                string sectionnamenum = this.ConnSQL.getSQLData(sqlstr);
                if (sectionnamenum == "0")
                {
                    sqlstr = "select count(*) from users where userid='" + ownerid + "'";
                    string ownernum = this.ConnSQL.getSQLData(sqlstr);
                    if (ownernum != "0")
                    {
                        int flag = this.ConnSQL.insertNewSection(sectionname, sectiondetail, ownerid);
                        if (flag == 1)
                        {
                            Response.Write("新建版区成功");
                            Response.Redirect(Request.Url.ToString());
                        }
                        else
                        {
                            Response.Write("创建失败");
                        }
                    }
                    else
                    {
                        Response.Write("版主用户不存在");
                    }
                }
                else
                {
                    Response.Write("该版区已存在");
                }
            }
            else
            {
                Response.Write("版区名不能为空");
            }
        }

        protected void deletesection(object sender, EventArgs e)
        {
            string section = deletesectionname.Text;
            if (section != "")
            {
                string sqlstr = "select count(*) from section where sectionname='" + section + "'";
                string sectionnum = this.ConnSQL.getSQLData(sqlstr);
                if (sectionnum != "0")
                {
                    int flag = this.ConnSQL.deletesectionfromDB(section);
                    if (flag == 1)
                    {
                        Response.Write("删除成功");
                        Response.Redirect(Request.Url.ToString());
                    }
                    else
                    {
                        Response.Write("删除失败" + flag);
                    }
                }
                else
                {
                    Response.Write("不存在该版区");
                }
            }
            else
            {
                Response.Write("必须填写版区名");
            }
        }

        protected void changesectionname(object sender, EventArgs e)
        {
            string section = updatesectionname.Text;
            string newname = newnametext.Text;
            if (section != "")
            {
                string sqlstr = "select count(*) from section where sectionname='" + section + "'";
                string sectionnum = this.ConnSQL.getSQLData(sqlstr);
                if (sectionnum != "0")
                {
                    if (newname != "")
                    {
                        sqlstr = "select count(*) from section where sectionname='" + newname + "'";
                        sectionnum = this.ConnSQL.getSQLData(sqlstr);
                        if (sectionnum != "1")
                        {
                            int flag = this.ConnSQL.updatesectionname(section, newname);
                            if (flag == 1)
                            {
                                Response.Write("更新成功");
                                Response.Redirect(Request.Url.ToString());
                            }
                            else
                            {
                                Response.Write("更新失败");
                            }
                        }
                        else
                        {
                            Response.Write("版区名冲突");
                        }
                    }
                    else
                    {
                        Response.Write("版取名不能为空");
                    }
                }
                else
                {
                    Response.Write("版区不存在");
                }
            }
            else
            {
                Response.Write("请先选择版区");
            }
        }

        protected void changesectiondetail(object sender, EventArgs e)
        {
            string section = updatesectionname.Text;
            string detail = newdetail.Text;

            if (section != "")
            {
                string sqlstr = "select count(*) from section where sectionname='" + section + "'";
                string sectionnum = this.ConnSQL.getSQLData(sqlstr);
                if (sectionnum != "0")
                {
                    int flag = this.ConnSQL.updatesectiondetail(section, detail);
                    if (flag == 1)
                    {
                        Response.Write("修改成功");
                        Response.Redirect(Request.Url.ToString());
                    }
                    else
                    {
                        Response.Write("更新失败");
                    }
                }
                else
                {
                    Response.Write("版区不存在");
                }
            }
            else
            {
                Response.Write("请先选择版区");
            }
        }

        protected void changesectionowner(object sender, EventArgs e)
        {
            string section = updatesectionname.Text;
            string ownerid = newowner.Text;

            if (section != "")
            {
                string sqlstr = "select count(*) from section where sectionname='" + section + "'";
                string sectionnum = this.ConnSQL.getSQLData(sqlstr);
                if (sectionnum != "0")
                {
                    sqlstr = "select count(*) from users where userid = '" + ownerid + "'";
                    string usernum = this.ConnSQL.getSQLData(sqlstr);
                    if (usernum != "0")
                    {
                        int flag = this.ConnSQL.updatesectionowner(section, ownerid);
                        if (flag == 1)
                        {
                            Response.Write("修改成功");
                            Response.Redirect(Request.Url.ToString());
                        }
                        else
                        {
                            Response.Write("更新失败");
                        }
                    }
                    else
                    {
                        Response.Write("版主不存在");
                    }
                }
                else
                {
                    Response.Write("版区不存在");
                }
            }
            else
            {
                Response.Write("请先选择版区");
            }
        }
    }
}