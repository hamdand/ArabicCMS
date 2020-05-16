using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class SubCategoryAdd : BaseAdminPage
    {
        public int categoryId { get { return Request["categoryId"] == null ? -1 : int.Parse(Request["categoryId"]); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMainCategory.DataSource = CategoryService.GetAll("ar").OrderBy(x => x.SortId).OrderByDescending(x => x.Id);
                ddlMainCategory.DataBind();

                ddlPageContentType.DataSource = PageContentService.GetAll("ar");
                ddlPageContentType.DataBind();

                if (selectedId > 0)
                {
                    var subCategory = SubCategoryService.GetById(selectedId, "ar");
                    txtArDes.Text = subCategory.DescriptionArabic;
                    txtArName.Text = subCategory.NameArabic;
                    txtEnDes.Text = subCategory.DescriptionEnglish;
                    txtEnName.Text = subCategory.NameEnglish;
                    txtURL.Text = subCategory.URL;
                    ddlPageContentType.SelectedValue = subCategory.ContentType.Id.ToString();
                    ddlPageContentType.Enabled = false;
                    ddlMainCategory.Enabled = false;
                }

                if (categoryId > 0)
                    ddlMainCategory.SelectedValue = categoryId.ToString();

                var subCategories = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "Ar").SubCategories.ToList();

                if (!isSorder(subCategories))
                {
                    int i = 1;
                    foreach (var item in subCategories)
                    {
                        item.SortId = i;
                        i++;
                    }
                    SubCategoryService.UpdateBulk(subCategories);
                }

                rpSubCatItems.DataSource = subCategories.OrderBy(x => x.SortId).ThenBy(x => x.Id).ToList();
                rpSubCatItems.DataBind();
            }
        }

        private bool isSorder(List<SubCategory> subCategories)
        {
            var subcategory = subCategories.Where(x => x.IsDeleted == false && x.SortId == 0);
            if (subcategory == null)
                return true;

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var category = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "ar");
                if (selectedId < 1)
                {
                    category.SubCategories.Add(new SubCategory()
                    {
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        NameArabic = txtArName.Text,
                        NameEnglish = txtEnName.Text,
                        ContentType = PageContentService.GetById(int.Parse(ddlPageContentType.SelectedValue)),
                        SortId = 0,
                        URL = txtURL.Text.Trim().ToUpper(),
                        DescriptionArabic = txtArDes.Text,
                        DescriptionEnglish = txtEnDes.Text,
                        UserId=currentUserId
                    });
                }
                else
                {
                    var subCategory = category.SubCategories.Where(x => x.Id == selectedId).First();//CategoryService.GetById(selectedId, "Ar");
                    subCategory.Modified = DateTime.Now;
                    subCategory.NameArabic = txtArName.Text;
                    subCategory.NameEnglish = txtEnName.Text;
                    subCategory.ContentType = PageContentService.GetById(int.Parse(ddlPageContentType.SelectedValue));
                    subCategory.UserId = currentUserId;
                    subCategory.URL = txtURL.Text.Trim().ToUpper();
                    subCategory.DescriptionArabic = txtArDes.Text;
                    subCategory.DescriptionEnglish = txtEnDes.Text;
                    if (subCategory.ContentType == null)
                        subCategory.ContentType = new PageContentType();
                    subCategory.ContentType = PageContentService.GetById(int.Parse(ddlPageContentType.SelectedValue));
                }
                CategoryService.Update(category);
                Response.Redirect("~/Administrator/SubCategoryAdd");
            }
        }

        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/SubCategoryAdd?categoryId=" + ddlMainCategory.SelectedValue);
            //clearForm();
            //rpSubCatItems.DataSource = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "Ar").SubCategories;//SubCategoryService.GetAll("ar");
            //rpSubCatItems.DataBind();
        }

        private void clearForm()
        {
            txtArDes.Text = txtArName.Text = txtEnDes.Text = txtEnName.Text = txtURL.Text = string.Empty;
        }

        protected void rpSubCatItems_ItemCreated(object sender, RepeaterItemEventArgs e)
        {


        }

        protected void rpSubCatItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var subCategories = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "Ar").SubCategories.ToList();
            if (e.CommandName == "moveup")
            {
                List<SubCategory> categories = subCategories;
                var category = categories.Where(x => x.SortId == int.Parse(e.CommandArgument.ToString())).First();
                var nextCategory = categories.Where(x => x.SortId + 1 == int.Parse(e.CommandArgument.ToString())).First();

                category.SortId -= 1;
                nextCategory.SortId += 1;
                SubCategoryService.Update(category);
                SubCategoryService.Update(nextCategory);
                rpSubCatItems.DataSource = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "Ar").SubCategories.OrderBy(x=>x.SortId).ThenBy(x=>x.Id).ToList();
                rpSubCatItems.DataBind();
            }
            else if (e.CommandName == "movedown")
            {
                List<SubCategory> categories = subCategories;
                var category = categories.Where(x => x.SortId == int.Parse(e.CommandArgument.ToString())).First();
                var nextCategory = categories.Where(x => x.SortId - 1 == int.Parse(e.CommandArgument.ToString())).First();

                category.SortId += 1;
                nextCategory.SortId -= 1;
                SubCategoryService.Update(category);
                SubCategoryService.Update(nextCategory);
                rpSubCatItems.DataSource = CategoryService.GetById(int.Parse(ddlMainCategory.SelectedValue), "Ar").SubCategories.OrderBy(x => x.SortId).ThenBy(x => x.Id).ToList();
                rpSubCatItems.DataBind();
            }
        }
    }
}