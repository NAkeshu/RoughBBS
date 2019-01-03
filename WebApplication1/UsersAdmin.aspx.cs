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
    public partial class UsersAdmin : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            displayUsers();
        }

        protected void displayUsers()
        {
            DataSet ds = new DataSet();
            ds = this.ConnSQL.getUsersList();
            UsersList.DataSource = ds.Tables["userslist"].DefaultView;
            UsersList.DataBind();
        }

        protected void UsersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "setAdmin")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                int col = 0;
                string userid = UsersList.Rows[row].Cells[col].Text;
                int flag = this.ConnSQL.updateAdmin(userid);
                if (flag == 1)
                {
                    Response.Write("设置/取消管理员成功");
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    Response.Write("设置/取消管理员失败");
                }
            }
            else if (e.CommandName == "dl")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                int col = 0;
                string userid = UsersList.Rows[row].Cells[col].Text;
                int flag = this.ConnSQL.deleteUser(userid);
                if (flag == 1)
                {
                    Response.Write("删除成功");
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