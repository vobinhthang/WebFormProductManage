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
    public partial class GetAllProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Product> products = ProductService.GetAll();
                gvProduct.DataSource = products;
                gvProduct.DataBind();
            }
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/views/createupdateproduct");
        }

        protected void linkImage_Click(object sender, EventArgs e)
        {

        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Product product = new Product();
            product.Id = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
            if (ProductService.Delete(product))
                Response.Redirect("/admin/views/getallproduct");
            else
                Response.Write("Lỗi!!! Xóa thông tin không thành công !");
        }

        protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbID = (Label)e.Row.FindControl("lbID");
                foreach (Button bt in e.Row.Cells[6].Controls.OfType<Button>())
                {
                    if (bt.CommandName == "Delete")
                    {
                        bt.Attributes["onclick"] = "if(!confirm('Bạn có muốn xóa sản phẩm có ID là: " + lbID.Text + "?')){ return false; };";

                    }
                }
            }
        }

        protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(gvProduct.DataKeys[e.NewEditIndex].Value);
            Product product = ProductService.GetProductById(_id);
            string strid = product.Id.ToString();
            Response.Redirect("/admin/views/createupdateproduct?id=" + strid);
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);

            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string _search = tbSearch.Text.ToString();
            List<Product> products = ProductService.Search(_search);

            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduct.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.ToString());
            List<Product> products = ProductService.GetAll();
            gvProduct.PageIndex = e.NewPageIndex;
            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        public List<int> ItemsInt()
        {
            List<int> list = new List<int>();

            for (int i = 5; i <= 20; i += 5)
            {
                list.Add(i);

            }

            return list;
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text.ToString()))
            {
                List<Product> products = ProductService.GetAll();
                gvProduct.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.ToString());

                gvProduct.PageIndex = 0;
                gvProduct.DataSource = products;
                gvProduct.DataBind();
            }
            else
            {
                string _search = tbSearch.Text.ToString();
                List<Product> products = ProductService.Search(_search);
                gvProduct.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.ToString());

                gvProduct.PageIndex = 0;
                gvProduct.DataSource = products;
                gvProduct.DataBind();
            }
        }
    }
}