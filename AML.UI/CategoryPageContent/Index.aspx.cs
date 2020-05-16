using System;

namespace AML.UI.CategoryPageContent
{
    public partial class Index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var category = CategoryService.GetById(selectedId, selectedLanguage);
                litTitle.Text = category.Name;
                litDes.Text = category.Description;
                if (category.PageText != null)
                    if (selectedLanguage.ToLower().Contains("ar"))
                    {
                        litContent.Text = category.PageText.TextArabic;
                    }
                    else
                    {
                        litContent.Text = category.PageText.TextEnglish;
                    }

            }
        }
    }
}