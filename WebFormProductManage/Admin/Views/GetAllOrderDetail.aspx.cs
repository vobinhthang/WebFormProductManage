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
    public partial class GetAllOrderDetail : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);
            lbMa.Text = Convert.ToString(queryID);
            SharedData.OrderId = queryID;
            if (!IsPostBack)
            {
               
                List<OrderDetail> orderDetails = OrderDetailService.GetAll(queryID);
                gvOrderDetail.DataSource = orderDetails;
                gvOrderDetail.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/admin/views/createupdateorderdetail");

        }

        protected void gvOrderDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            OrderDetail orderDetails = new OrderDetail();
            orderDetails.Id = Convert.ToInt32(gvOrderDetail.DataKeys[e.RowIndex].Value);
            if (OrderDetailService.Delete(orderDetails))
            {
                queryID = Convert.ToInt32(Page.Request.QueryString["id"]);
                string _id = Convert.ToString(queryID);
                Response.Redirect("/admin/views/getallorderdetail?id=" + _id);
            }
            else
            {
                Response.Write("Lỗi!!! Xóa thông tin không thành công !");
            }
          
        }

        protected void gvOrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");

                foreach (Button bt in e.Row.Cells[8].Controls.OfType<Button>())
                {
                    if (bt.CommandName.Equals("Delete"))
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa thông tin hóa đơn có ID là: " + lbID.Text + "?')){ return false; };";
                    }
                }
            }
        }

        protected void gvOrderDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvOrderDetail.DataKeys[e.NewEditIndex].Value);
            OrderDetail orderDetails = OrderDetailService.GetOrderDetailById(_id);
            string strid = orderDetails.Id.ToString();
            Response.Redirect("/admin/views/createupdateorderdetail?id=" + strid);
        }
    }
}