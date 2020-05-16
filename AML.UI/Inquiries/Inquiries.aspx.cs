using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Inquiries
{
    public partial class Inquiries : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rpInquiries.DataSource= InquireyService.GetAllPublic(IsArabic);
                rpInquiries.DataBind();
            }
        }
    }
}