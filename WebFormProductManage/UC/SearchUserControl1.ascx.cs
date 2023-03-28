using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage.UC
{
    public partial class SearchUserControl1 : System.Web.UI.UserControl
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);
                     
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);
            
        }
    }
}