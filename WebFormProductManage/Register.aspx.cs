using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Services;

namespace WebFormProductManage
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
                if (!UserService.Register(txt_userName.Text.Trim(), txt_userPassWord.Text.Trim()))
                {
                    
                    Response.Write("<script>alert('Tài khoản đăng ký đã tồn tại !')</script>");

                }
                else
                {
                   
                    Response.Write("<script>alert('Đăng ký tài khoản thành công !')</script>");

                }
            

        }
    }
}