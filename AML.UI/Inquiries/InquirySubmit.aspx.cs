using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Inquiries
{
    public partial class InquirySubmit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                InquireyService.Create(new Inquiry
                {
                    Name= txtArName.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    UserId = currentUserId,
                    IsArabic=IsArabic
                });
                clearform();
                litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";

            }
        }

        private void clearform()
        {
            txtArName.Text = txtDesc.Text = string.Empty;
        }
    }
}