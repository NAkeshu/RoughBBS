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
    public partial class Sections : System.Web.UI.Page
    {
        BBSSQL ConnSQL = new BBSSQL();
        protected void Page_Load(object sender, EventArgs e)
        {
            displaySections();
        }

        protected void displaySections()
        {
            DataSet ds = new DataSet();
            ds = this.ConnSQL.getSectionsList();
            SectionsList.DataSource = ds.Tables["sectionslist"].DefaultView;
            SectionsList.DataBind();
        }
    }
}