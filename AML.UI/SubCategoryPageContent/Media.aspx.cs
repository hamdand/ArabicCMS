using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.SubCategoryPageContent
{
    public partial class Media : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subCategory = SubCategoryService.GetById(selectedId, selectedLanguage);
                litTitle.Text = subCategory.Name;
                litDes.Text = subCategory.Description;



                if (selectedLanguage.ToLower().Contains("ar"))
                {
                    rpDocuments.DataSource = subCategory.PageMedia.Where(x => x.IsEnglishFile == false && x.IsDeleted == false);
                    rpDocuments.DataBind();
                }
                else
                {
                    rpDocuments.DataSource = subCategory.PageMedia.Where(x => x.IsEnglishFile == true && x.IsDeleted == false);
                    rpDocuments.DataBind();
                }

            }
        }
    }
}