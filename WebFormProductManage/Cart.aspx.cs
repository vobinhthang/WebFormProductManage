using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage
{
    public partial class Cart : System.Web.UI.Page
    {int rs = 0;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!IsPostBack)
            {
                
                rptCartItems.DataSource = Session["cart"];
                rptCartItems.DataBind();

                List<Product> products = (List<Product>)Session["cart"];

                for (int i = 0; i < rptCartItems.Items.Count; i++)
                {
                    Label pr =(Label) rptCartItems.Items[i].FindControl("lbTotalPrice");
                    
                    rs += Convert.ToInt32(pr.Text.Replace(".", string.Empty));
                }
                lbAllPrice.Text = rs.ToString("###,###", cul.NumberFormat); ;
            }
        }

        protected void rptCartItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                List<Product> products = (List<Product>)Session["cart"];
                

                int index =Convert.ToInt32(e.CommandArgument);
                
                products.RemoveAt(index);



                Session["cart"] = products;

                rptCartItems.DataSource = Session["cart"];
                rptCartItems.DataBind();

                for (int i = 0; i < rptCartItems.Items.Count; i++)
                {
                    Label pr = (Label)rptCartItems.Items[i].FindControl("lbTotalPrice");

                    rs += Convert.ToInt32(pr.Text.Replace(".", string.Empty));
                }
                lbAllPrice.Text = rs.ToString("###,###", cul.NumberFormat);

            }
           
        }
 
        protected  void tbAmount_TextChanged(object sender, EventArgs e)
        {
           
            List<Product> products = (List<Product>)Session["cart"];
            
            for (int i=0; i < products.Count;i++) 
            {
                Label lbTotalPrice = (Label)rptCartItems.Items[i].FindControl("lbTotalPrice");
                Label lbPrice = (Label)rptCartItems.Items[i].FindControl("lbPrice");
                TextBox tb = (TextBox)rptCartItems.Items[i].FindControl("tbAmount");



              


                SharedData.AmountProduct = Convert.ToInt32(tb.Text);
                SharedData.Price = lbPrice.Text.Replace(".",string.Empty);

                var amount = SharedData.AmountProduct;
                var price = Convert.ToInt32(SharedData.Price);
                var total = amount * price;


                SharedData.TotalPrice = total.ToString("###,###", cul.NumberFormat);

                lbTotalPrice.Text = SharedData.TotalPrice;
      
            }

            for (int i = 0; i < rptCartItems.Items.Count; i++)
            {
                Label pr = (Label)rptCartItems.Items[i].FindControl("lbTotalPrice");

                rs += Convert.ToInt32(pr.Text.Replace(".", string.Empty));
            }
            lbAllPrice.Text = rs.ToString("###,###", cul.NumberFormat);

        }

        protected void rptCartItems_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
           
        }

        protected void rptCartItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Label indexItem = (Label)e.Item.FindControl("lbID");
            //var ind = indexItem.Text;
            //SharedData.IndexItem = Convert.ToInt32(ind);
        }
    }
}