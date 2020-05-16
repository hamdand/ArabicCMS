using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class PendingInquiries : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpSubCatItems.DataSource = InquiryService.GetAll(true);
                rpSubCatItems.DataBind();
            }
        }

        protected void rpSubCatItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                InquiryService.Delete(int.Parse(e.CommandArgument.ToString()));
                Response.Redirect("PendingInquiries");
            }
        }
    }
}