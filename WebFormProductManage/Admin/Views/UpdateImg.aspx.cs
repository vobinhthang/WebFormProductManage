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
    public partial class UpdateImg : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);
            if (!IsPostBack)
            {
                Product product = ProductService.GetProductById(queryID);

                tbID.Text = Convert.ToString(product.Id);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string imageFolderPath = "~/Assets/img/";
            string imageFileName = string.Empty;
            if (fileImage.HasFile)
            {
                imageFileName = fileImage.FileName;
                string imageServerPath = Server.MapPath(imageFolderPath + imageFileName);
                fileImage.SaveAs(imageServerPath);

            }

            Product product = new Product();
            product.Id = queryID;
           
            product.Thumbnail = imageFolderPath + imageFileName;
            
            
            if (ProductService.UpdateImage(product))
            {
                Response.Write("<script>alert('Cập nhập ảnh sản phẩm thành công !')</script>");

            }
        }
    }
}