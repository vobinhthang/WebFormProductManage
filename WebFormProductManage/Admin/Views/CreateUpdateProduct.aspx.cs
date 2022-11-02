using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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


                    tbPrice.Text = Convert.ToString(product.Price);
                    tbDescription.Text = product.Description;
                    tbColor.Text = product.Color;
                    if (product.Hot==1)
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
            if (fileImage.HasFile)
            {
                imageFileName = fileImage.FileName;
                string imageServerPath = Server.MapPath(imageFolderPath + imageFileName);
                fileImage.SaveAs(imageServerPath);
                
            }

            Product product = new Product();
            product.Id = queryID;
            product.Name = tbName.Text;
            product.Thumbnail = imageFolderPath + imageFileName;
            product.Price = Convert.ToInt32(tbPrice.Text);
            product.Color = tbColor.Text;
            product.Description = tbDescription.Text;
            if (cbHot.Checked)
                product.Hot = 1;
            else
                product.Hot = 0;
            product.ProducerID = Convert.ToInt32(ddlProducerName.SelectedItem.Value);
            if (ProductService.CreateOrUpdate(product))
            {
                tbID.Text = string.Empty;
                tbName.Text = string.Empty;
                tbPrice.Text = string.Empty;
                tbDescription.Text = string.Empty;
                tbColor.Text = string.Empty;
                cbHot.Checked = false;

                if (queryID!=0)
                {
                    Response.Write("<script>alert('Cập nhập sản phẩm thành công !')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Thêm sản phẩm thành công !')</script>");
                }
            }
        }

    }
}