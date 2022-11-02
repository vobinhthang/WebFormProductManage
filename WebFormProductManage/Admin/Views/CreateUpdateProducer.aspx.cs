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
    public partial class CreateUpdateProducer : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            if (!IsPostBack)
            {
               

                if (queryID > 0)
                {
                    lbTitle.Text = "Cập nhập nhà sản xuất";
                    btnSave.Text = "Lưu";
                    Producer producer = ProducerService.GetProducerById(queryID);

                    tbID.Text = Convert.ToString(producer.Id);
                    tbFullname.Text = producer.Fullname;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            

            Producer producer = new Producer();
            producer.Id = queryID;
            producer.Fullname = tbFullname.Text;

            if (ProducerService.CreateOrUpdate(producer))
            {
                tbFullname.Text = string.Empty;
                if (queryID != 0)
                {
                    Response.Write("<script>alert('Cập nhập nhà sản xuất thành công !')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Thêm nhà sản xuất thành công !')</script>");
                }
            }
        }

    }
}