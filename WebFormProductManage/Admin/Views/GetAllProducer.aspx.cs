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
    public partial class GetAllProducer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Producer> producers = ProducerService.GetAllProducer();
                gvProducer.DataSource = producers;
                gvProducer.DataBind();
            }
        }

        protected void gvProducer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Producer producer = new Producer();
            producer.Id = Convert.ToInt32(gvProducer.DataKeys[e.RowIndex].Value);
            if (ProducerService.Delete(producer))
                Response.Redirect("/admin/views/getallproducer");
            else
                Response.Write("Lỗi!!! Xóa thông tin không thành công !");
        }

        protected void gvProducer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");

                foreach (Button bt in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (bt.CommandName.Equals("Delete"))
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa nhà sản xuất có ID là: " + lbID.Text + "?')){ return false; };";
                    }
                }
            }
        }

        protected void gvProducer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvProducer.DataKeys[e.NewEditIndex].Value);
            Producer producer = ProducerService.GetProducerById(_id);
            string strid = producer.Id.ToString();
            Response.Redirect("/admin/views/createupdateproducer?id=" + strid);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/views/createupdateproducer");
        }
    }
}