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
    public partial class GetAllOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Order> orders = OrderService.GetAll();
                gvOrder.DataSource = orders;
                gvOrder.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/views/createupdateorder");

        }

      

        protected void gvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Order order = new Order();
            order.Id = Convert.ToInt32(gvOrder.DataKeys[e.RowIndex].Value);
            if (OrderDetailService.DeleteAllOrder(order.Id))
            {
                if (OrderService.Delete(order))
                    Response.Redirect("/admin/views/getallorder");
                else
                    Response.Write("Lỗi!!! Xóa thông tin không thành công !");
            }

        }

        protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");

                foreach (Button bt in e.Row.Cells[7].Controls.OfType<Button>())
                {
                    if (bt.CommandName.Equals("Delete"))
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa thông tin hóa đơn có ID là: " + lbID.Text + "?')){ return false; };";
                    }
                }
            }
        }

        protected void gvOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvOrder.DataKeys[e.NewEditIndex].Value);
            Order order = OrderService.GetOrderById(_id);
            string strid = order.Id.ToString();
            Response.Redirect("/admin/views/createupdateorder?id=" + strid);
        }
    }
}