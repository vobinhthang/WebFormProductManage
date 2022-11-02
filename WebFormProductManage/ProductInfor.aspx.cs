using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage
{
    public partial class ProductInfor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int queryProductId = Convert.ToInt32(Page.Request.QueryString["productid"]);
                List<Product> products = ProductService.ListProductById(queryProductId);

                rptProdcutInfor.DataSource = products;
                rptProdcutInfor.DataBind();
            }
        }
    }
}