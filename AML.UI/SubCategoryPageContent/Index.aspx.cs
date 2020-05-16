using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.SubCategoryPageContent
{
    public partial class Index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subCategory = SubCategoryService.GetById(selectedId, selectedLanguage);
                litTitle.Text = subCategory.Name;
                litDes.Text = subCategory.Description;
                if (subCategory.PageText != null)
                    if (selectedLanguage.ToLower().Contains("ar"))
                    {
                        litContent.Text = subCategory.PageText.TextArabic;
                    }
                    else
                    {
                        litContent.Text = subCategory.PageText.TextEnglish;
                    }

            }
        }
    }
}