using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class SubCategoryEditContentText : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var category = SubCategoryService.GetById(selectedId, isArabic ? AML.Domain.Helper.Lang.Arabic.ToString() : AML.Domain.Helper.Lang.English.ToString());

                litTitle.Text = category.Name;
                litDes.Text = category.Description;

                if (category.PageText != null)
                {
                    FreeTextBox1.Text = isArabic ? category.PageText.TextArabic : category.PageText.TextEnglish;

                }

            }
        }

        protected void FreeTextBox1_SaveClick(object sender, EventArgs e)
        {
            try
            {
                litSendMsg.Visible = false;
                litErrorMsg.Visible = false;
                if (Page.IsValid)
                {
                    var subCategory = SubCategoryService.GetById(selectedId, "Ar");
                    if (subCategory.PageText == null)
                        subCategory.PageText = new PageTextContent();

                    if (isArabic)
                        subCategory.PageText.TextArabic = FreeTextBox1.Text.Replace("background: white;", "").Replace("background:white", "");
                    else
                        subCategory.PageText.TextEnglish = FreeTextBox1.Text.Replace("background: white;", "").Replace("background:white", "");

                    SubCategoryService.Update(subCategory);
                    litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                    litSendMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {

                litErrorMsg.Text = "<div id=\"errormessage\" style=\"display:block\"> " + ex.Message + "</div>";
                litErrorMsg.Visible = true;
            }
        }
    }
}