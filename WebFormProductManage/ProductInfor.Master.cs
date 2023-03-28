using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage
{
    public partial class ProductInfor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int queryProductId = Convert.ToInt32(Page.Request.QueryString["productid"]);
                var product = ProductService.GetProductById(queryProductId);
                if(product != null)
                {
                    var _id = product.ProducerID;
                    List<Product> products = ProductService.Get5ProductByProducer(_id);
                    rptProduct.DataSource = products;
                    rptProduct.DataBind();
                }

                
            }
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);
            if (products.Count > 0)
            {

                SharedData.searchproduct = products;
                Response.Redirect("/allproduct");
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);
            if (products.Count > 0)
            {

                SharedData.searchproduct = products;
                Response.Redirect("/allproduct");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}