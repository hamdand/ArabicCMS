using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class AddFAQs : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                rpSubCatItems.DataSource = FAQService.GetAll("ar");
                rpSubCatItems.DataBind();
                if (selectedId > 0)
                {
                    var category = FAQService.GetById(selectedId, "ar");
                    txtArDes.Text = category.DescriptionArabic;
                    txtArName.Text = category.NameArabic;
                    txtEnDes.Text = category.DescriptionEnglish;
                    txtEnName.Text = category.NameEnglish;

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                litSendMsg.Visible = false;
                litErrorMsg.Visible = false;
                if (Page.IsValid)
                {
                    if (selectedId == -1)
                    {



                        FAQService.Create(new FAQ()
                        {
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            NameArabic = txtArName.Text,
                            NameEnglish = txtEnName.Text,
                            SortId = 0,
                            DescriptionArabic = txtArDes.Text,
                            DescriptionEnglish = txtEnDes.Text,
                            UserId = currentUserId
                        });
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        clearForm();
                        rpSubCatItems.DataSource = FAQService.GetAll("ar");
                        rpSubCatItems.DataBind();
                        //Response.Redirect(Request.RawUrl.Split('?')[0] + "?myParam=0", false);

                    }
                    else
                    {
                        var faq = FAQService.GetById(selectedId, "ar");

                        faq.Modified = DateTime.Now;
                        faq.NameArabic = txtArName.Text;
                        faq.NameEnglish = txtEnName.Text;

                        faq.UserId = currentUserId;

                        faq.DescriptionArabic = txtArDes.Text;
                        faq.DescriptionEnglish = txtEnDes.Text;

                        FAQService.UpdateFAQ(faq);
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        rpSubCatItems.DataSource = FAQService.GetAll("ar");
                        rpSubCatItems.DataBind();
                        //Response.Redirect(Request.RawUrl.Split('?')[0] + "?myParam=0", false);
                    }
                }
            }
            catch (Exception ex)
            {
                litErrorMsg.Text = "<div id=\"errormessage\" style=\"display:block\"> " + ex.Message + "</div>";
                litErrorMsg.Visible = true;
            }
        }

        private void clearForm()
        {
            txtArDes.Text = txtArName.Text = txtEnDes.Text = txtEnName.Text = string.Empty;
        }
    }
}