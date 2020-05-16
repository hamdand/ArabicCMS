using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI
{
    public partial class FAQs : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpFAQs.DataSource = FAQService.GetAll(selectedLanguage);
                rpFAQs.DataBind();
            }

        }
    }
}