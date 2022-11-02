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
    public partial class AllProduct : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                List<Producer> producers = ProducerService.GetAllProducer();
                rptProducer.DataSource = producers;
                rptProducer.DataBind();
            }
        }

        
    }
}