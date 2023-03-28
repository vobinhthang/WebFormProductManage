using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage.Admin.Views
{
    public partial class CreateUpdateOrderDetail : System.Web.UI.Page
    {

        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            if (!IsPostBack)
            {

                List<Product> products = ProductService.GetAll();
                ddlProduct.DataSource = products;
                ddlProduct.DataTextField = "Name";
                ddlProduct.DataValueField = "Id";
                ddlProduct.DataBind();

                if (queryID > 0)
                {
                    lbTitle.Text = "Cập nhập chi tiết hóa đơn";
                    btnSave.Text = "Lưu";
                    OrderDetail orderDetail = OrderDetailService.GetOrderDetailById(queryID);
                    ListItem listItem = ddlProduct.Items.FindByText(orderDetail.Name);
                    if (listItem != null)
                    {
                        ddlProduct.ClearSelection();
                        listItem.Selected = true;
                    }
                    tbAmount.Text = Convert.ToString(orderDetail.Amount);
                    tbPrice.Text = orderDetail.Price;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            OrderDetail orderDetails = new OrderDetail();
            orderDetails.Id = queryID;
            orderDetails.Amount = Convert.ToInt32(tbAmount.Text);
            orderDetails.Price = tbPrice.Text;
            orderDetails.OrderId = SharedData.OrderId;
            orderDetails.ProductId = Convert.ToInt32(ddlProduct.SelectedItem.Value);
            if (OrderDetailService.CreateOrUpdate(orderDetails))
            {
                
                Response.Redirect("/admin/views/getallorderdetail?id="+ SharedData.OrderId);
            }
        }
    }
}