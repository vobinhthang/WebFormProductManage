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
    public partial class CreateUpdate : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            if (!IsPostBack)
            {
                List<Role> roles = UserService.GetAllRole();
                ddlRoleName.DataSource = roles;
                ddlRoleName.DataTextField = "Name";
                ddlRoleName.DataValueField = "ID";
                ddlRoleName.DataBind();

                if (queryID > 0)
                {
                    lbTitle.Text = "Cập nhập người dùng";
                    btnSave.Text = "Lưu";
                    User user = UserService.GetUserById(queryID);

                    tbID.Text = Convert.ToString(user.Id);
                    tbUsername.Text = user.Username;
                    tbPassword.Text = user.Password;
                    tbFullname.Text = user.Fullname;
                    ListItem listItem = ddlRoleName.Items.FindByText(user.RoleName);
                    if (listItem != null)
                    {
                        ddlRoleName.ClearSelection();
                        listItem.Selected = true;
                    }
                }
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Id = queryID;
            user.Username = tbUsername.Text;
            user.Password = tbPassword.Text;
            user.Fullname = tbFullname.Text;
            user.RoleID = Convert.ToInt32(ddlRoleName.SelectedItem.Value);
            if (UserService.CreateOrUpdate(user))
            {
                Response.Redirect("/admin/views/getalluser");
            }
        }
    }
}