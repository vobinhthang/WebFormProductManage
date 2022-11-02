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
    public partial class GetAllUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<User> users = UserService.GetAll();
                gvUser.DataSource = users;
                gvUser.DataBind();
            }
        }

        protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            User user = new User();
            user.Id = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Value);
            if (UserService.Delete(user))
                Response.Redirect("/admin/views/getalluser");
            else
                Response.Write("Lỗi!!! Xóa thông tin không thành công !");

        }

        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");
                
                foreach(Button bt in e.Row.Cells[5].Controls.OfType<Button>())
                {
                    if (bt.CommandName.Equals("Delete"))
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa thông tin người dùng có ID là: " + lbID.Text + "?')){ return false; };";
                    }
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/views/createupdate");
        }

        protected void gvUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvUser.DataKeys[e.NewEditIndex].Value);
            User user = UserService.GetUserById(_id);
            string strid = user.Id.ToString();
            Response.Redirect("/admin/views/createupdate?id=" + strid);
        }
    }
}