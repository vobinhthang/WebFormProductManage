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
    public partial class GetAllRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Role> roles = RoleService.GetAll();
                gvRole.DataSource = roles;
                gvRole.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/views/createupdaterole");
        }

        protected void gvRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Role role = new Role();
            role.Id = Convert.ToInt32(gvRole.DataKeys[e.RowIndex].Value);
            if (RoleService.Delete(role))
                Response.Redirect("/admin/views/getallrole");
            else
                Response.Write("Lỗi!!! Xóa thông tin không thành công !");

        }

        protected void gvRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");

                foreach (Button bt in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (bt.CommandName.Equals("Delete"))
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa thông tin vai trò có ID là: " + lbID.Text + "?')){ return false; };";
                    }
                }
            }
        }

        protected void gvRole_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvRole.DataKeys[e.NewEditIndex].Value);
            Role role = RoleService.GetUserById(_id);
            string strid = role.Id.ToString();
            Response.Redirect("/admin/views/createupdaterole?id=" + strid);
        }
    }
}