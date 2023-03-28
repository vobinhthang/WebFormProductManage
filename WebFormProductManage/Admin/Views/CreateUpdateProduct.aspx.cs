using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormProductManage.Models;
using WebFormProductManage.Services;

namespace WebFormProductManage.Admin.Views
{
    public partial class CreateUpdateProduct : System.Web.UI.Page
    {
        int queryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            if (!IsPostBack)
            {
                List<Producer> producers = ProducerService.GetAllProducer();
                ddlProducerName.DataSource = producers;
                ddlProducerName.DataTextField = "Fullname";
                ddlProducerName.DataValueField = "ID";
                ddlProducerName.DataBind();
                
                if (queryID > 0)
                {

                    fileImage.Visible = false;
                    lbimage.Visible=false;

                    lbTitle.Text = "Cập nhập sản phẩm";
                    btnSave.Text = "Lưu";
                    Product product = ProductService.GetProductById(queryID);

                    tbID.Text = Convert.ToString(product.Id);
                    tbName.Text = product.Name;

                    tbPrice.Text = product.Price.Replace(".", string.Empty); 
                    
                    tbDescription.Text = product.Description;
                    tbColor.Text = product.Color;
                    if (product.Hot.Equals("Có"))
                    {
                        cbHot.Checked = true;
                    }

                    ListItem listItem = ddlProducerName.Items.FindByText(product.ProducerName);
                    if (listItem != null)
                    {
                        ddlProducerName.ClearSelection();
                        listItem.Selected = true;
                    }
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            queryID = Convert.ToInt32(Page.Request.QueryString["id"]);

            string imageFolderPath = "~/Assets/img/";
            string imageFileName = string.Empty;
            
            
            Product product = new Product();
            product.Id = queryID;
            product.Name = tbName.Text;
            if (fileImage.HasFile)
            {
                imageFileName = fileImage.FileName;
                string imageServerPath = Server.MapPath(imageFolderPath + imageFileName);
                fileImage.SaveAs(imageServerPath);
                product.Thumbnail = imageFolderPath + imageFileName;
                
            }
            product.Price = tbPrice.Text;
            product.Color = tbColor.Text;
            product.Description = tbDescription.Text;
            if (cbHot.Checked)
                product.Hot = "True";
            else
                product.Hot = "False";
            product.ProducerID = Convert.ToInt32(ddlProducerName.SelectedItem.Value);
            if (ProductService.CreateOrUpdate(product))
            {
              

                if (queryID!=0)
                {
                    Response.Write("<script>alert('Cập nhập sản phẩm thành công !')</script>");
                }
                else
                {
                    tbID.Text = string.Empty;
                    tbName.Text = string.Empty;
                    tbPrice.Text = string.Empty;
                    tbDescription.Text = string.Empty;
                    tbColor.Text = string.Empty;
                    cbHot.Checked = false;
                    Response.Write("<script>alert('Thêm sản phẩm thành công !')</script>");
                }
            }
        }

    }
}