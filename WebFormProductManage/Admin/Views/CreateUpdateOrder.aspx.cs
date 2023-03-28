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
    public partial class CreateUpdateOrder : System.Web.UI.Page
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
                    Order order = OrderService.GetOrderById(queryID);

                   
                    tbFullName.Text = order.FullName;
                    tbPhoneNumber.Text = order.PhoneNumber;
                    tbAddress.Text = order.Address;
                    tbOrderDate.Text =Convert.ToString(order.OrderDate);
                    tbTotalMoney.Text = Convert.ToString(order.TotalMoney);
                    
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Id = queryID;
            order.FullName = tbFullName.Text;
            order.PhoneNumber = tbPhoneNumber.Text;
            order.Address = tbAddress.Text;
            order.TotalMoney =tbTotalMoney.Text;
            order.OrderDate = DateTime.Now;
            if (OrderService.CreateOrUpdate(order))
            {

                Response.Redirect("/admin/views/getallorder");
            }
        }
    }
}