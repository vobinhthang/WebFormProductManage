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
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["user_name"] != null)
                {
                    lbUserName.Text = Page.Session["user_name"].ToString();
                }


                List<Product> products = ProductService.Get6Product();
                rptProduct.DataSource = products;
                rptProduct.DataBind();

                List<Producer> producers = ProducerService.GetAllProducer();
                rptProducer.DataSource = producers;
                rptProducer.DataBind();
            }
        }
    }
}