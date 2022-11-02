using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormProductManage.Admin.Views
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (HttpContext.Current.Session["username"]==null)
            {
                Response.Redirect("/admin/views/login");
            }
            else
            {
                lbWellcome.Text = Page.Session["username"].ToString();
            }
                    
            
        }

        
    }
}