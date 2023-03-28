using System;
using System.Collections.Generic;
using System.Globalization;
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
       

        protected void btnAddCart_Click(object sender, EventArgs e)
        {

            
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"

            int queryProductId = Convert.ToInt32(Page.Request.QueryString["productid"]);
            var products = ProductService.GetProductById(queryProductId);

            SharedData.AmountProduct = Convert.ToInt32(tbAmount.Text);
            products.Amount = SharedData.AmountProduct;

            var price = products.Price.Replace(".", string.Empty);
            SharedData.Price = price;
            var amount = products.Amount;
            var total = Convert.ToInt32(price) * amount;
            SharedData.TotalPrice = total.ToString("###,###", cul.NumberFormat);
            products.TotalPrice = SharedData.TotalPrice;

            products.TotalPrice = SharedData.TotalPrice;

            if (SharedData.cart.Count == 0)
            {
                
                SharedData.cart.Add(products);
            }
            else
            {
                var rs= SharedData.cart.SingleOrDefault(p => p.Id.Equals(products.Id));

                if (rs != null)
                {
                    
                }
                else
                {
                    
                    SharedData.cart.Add(products);
                } 
                    

            }
            
            

            Session["cart"] = SharedData.cart;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"

            int queryProductId = Convert.ToInt32(Page.Request.QueryString["productid"]);
            var products = ProductService.GetProductById(queryProductId);

            SharedData.AmountProduct = Convert.ToInt32(tbAmount.Text);
            products.Amount = SharedData.AmountProduct;

            var price = products.Price.Replace(".", string.Empty);
            SharedData.Price = price;
            var amount = products.Amount;
            var total = Convert.ToInt32(price) * amount;
            SharedData.TotalPrice = total.ToString("###,###", cul.NumberFormat);
            products.TotalPrice = SharedData.TotalPrice;

            products.TotalPrice = SharedData.TotalPrice;

            if (SharedData.cart.Count == 0)
            {

                SharedData.cart.Add(products);
            }
            else
            {
                var rs = SharedData.cart.SingleOrDefault(p => p.Id.Equals(products.Id));

                if (rs != null)
                {

                }
                else
                {

                    SharedData.cart.Add(products);
                }


            }



            Session["cart"] = SharedData.cart;
        }

        protected void btnNavi_Click(object sender, EventArgs e)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"

            int queryProductId = Convert.ToInt32(Page.Request.QueryString["productid"]);
            var products = ProductService.GetProductById(queryProductId);

            SharedData.AmountProduct = Convert.ToInt32(tbAmount.Text);
            products.Amount = SharedData.AmountProduct;

            var price = products.Price.Replace(".", string.Empty);
            SharedData.Price = price;
            var amount = products.Amount;
            var total = Convert.ToInt32(price) * amount;
            SharedData.TotalPrice = total.ToString("###,###", cul.NumberFormat);
            products.TotalPrice = SharedData.TotalPrice;

            products.TotalPrice = SharedData.TotalPrice;

            if (SharedData.cart.Count == 0)
            {

                SharedData.cart.Add(products);
            }
            else
            {
                var rs = SharedData.cart.SingleOrDefault(p => p.Id.Equals(products.Id));

                if (rs != null)
                {

                }
                else
                {

                    SharedData.cart.Add(products);
                }


            }



            Session["cart"] = SharedData.cart;

            Response.Redirect("/cart");
        }
    }
}