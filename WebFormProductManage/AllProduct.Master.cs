using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;
using static WebFormProductManage.ProductInfor1;

namespace WebFormProductManage
{
    public partial class AllProduct : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                List<Producer> producers = ProducerService.GetAllProducer();
                rptProducer.DataSource = producers;
                rptProducer.DataBind();
                if (SharedData.searchproduct.Count>0)
                {
                    rptAllProduct.DataSource = SharedData.searchproduct;
                    rptAllProduct.DataBind();
                }
                else
                {
                    
                    var queryID = Convert.ToInt32(Page.Request.QueryString["producerid"]);
                    var products = ProductService.GetAllProductByProducer(queryID);

                    if (products.Count > 0)
                    { 
                        rptAllProduct.DataSource = products;
                        rptAllProduct.DataBind();
                    }
                    else
                    {
                        products = ProductService.GetAll();
                        rptAllProduct.DataSource = products;
                        rptAllProduct.DataBind();
                    }
                }
                             
            }
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);

            rptAllProduct.DataSource = products;
            rptAllProduct.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);

            rptAllProduct.DataSource = products;
            rptAllProduct.DataBind();
        }
    }
}