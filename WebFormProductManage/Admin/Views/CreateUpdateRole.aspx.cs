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
    public partial class CreateUpdateRole : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            if (!IsPostBack)
            {

                if (queryID > 0)
                {
                    lbTitle.Text = "Cập nhập hóa đơn";
                    btnSave.Text = "Lưu";
                    Role role = RoleService.GetUserById(queryID);


                    tbName.Text = role.Name;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.Id = queryID;
            role.Name = tbName.Text;

            if (RoleService.CreateOrUpdate(role))
            {
                Response.Redirect("/admin/views/getallrole");
            }
        }
    }
}