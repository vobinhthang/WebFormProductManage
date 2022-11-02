using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Session["user_name"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            User user = UserService.GetOneClient(txt_userName.Text.Trim(), txt_userPassWord.Text.Trim());

            if (user!=null)
            {
                Page.Session["user_name"] = txt_userName.Text;
                Response.Redirect("/");

            }
            else
            {
                Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng !')</script>");
            }
        }
    }
}