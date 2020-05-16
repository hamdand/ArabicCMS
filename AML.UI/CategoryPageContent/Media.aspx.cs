using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.CategoryPageContent
{
    public partial class Media : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var category = CategoryService.GetById(selectedId, selectedLanguage);
                litTitle.Text = category.Name;
                litDes.Text = category.Description;



                if (selectedLanguage.ToLower().Contains("ar"))
                {
                    rpDocuments.DataSource = category.PageMedia.Where(x => x.IsEnglishFile == false && x.IsDeleted == false);
                    rpDocuments.DataBind();
                }
                else
                {
                    rpDocuments.DataSource = category.PageMedia.Where(x => x.IsEnglishFile == true && x.IsDeleted == false);
                    rpDocuments.DataBind();
                }

            }
        }
    }
}