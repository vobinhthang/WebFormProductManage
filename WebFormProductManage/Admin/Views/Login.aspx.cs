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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Session["username"] = null;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string _username = tbTaiKhoan.Text.Trim();
            string _password = tbMatKhau.Text.Trim();
            User user = UserService.GetOne(_username, _password);
            if(user != null)
            {
                Page.Session["username"] = _username;
                Response.Redirect("/admin/views/");
            }
            else
            {   
                lbMesageErros.Visible = true;
                lbMesageErros.Text = "Tài khoản hoặc mật khẩu không đúng!";            
            }
            
        }

      
    }
}