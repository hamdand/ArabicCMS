using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class CategoryAdd : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPageContentType.DataSource = PageContentService.GetAll("ar");
                ddlPageContentType.DataBind();

                List<Category> categories = CategoryService.GetAll("ar").OrderBy(x => x.SortId).ThenBy(x => x.Id).ToList();

                if (!isSorder(categories))
                {
                    int i = 1;
                    foreach (var item in categories)
                    {
                        item.SortId = i;
                        i++;
                    }
                    CategoryService.UpdateBulk(categories);
                }

                rpSubCatItems.DataSource = categories.OrderBy(x => x.SortId).ToList();
                rpSubCatItems.DataBind();

                if (selectedId > 0)
                {
                    var category = CategoryService.GetById(selectedId, "ar");
                    txtArDes.Text = category.DescriptionArabic;
                    txtArName.Text = category.NameArabic;
                    txtEnDes.Text = category.DescriptionEnglish;
                    txtEnName.Text = category.NameEnglish;
                    txtURL.Text = category.URL;
                    ddlPageContentType.SelectedValue = category.ContentType.Id.ToString();
                    ddlPageContentType.Enabled = false;
                }
            }
        }

        private bool isSorder(List<Category> categories)
        {
            var category = categories.Where(x => x.IsDeleted == false && x.SortId == 0);
            if (categories == null || categories.Count == 0)
                return true;

            return false;
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
                        var category = CategoryService.GetCategoryByUrl(txtURL.Text.Trim().ToUpper());

                        if (category == null || category.Count == 0)
                        {
                            CategoryService.Create(new Category()
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
                            litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                            litSendMsg.Visible = true;
                            clearForm();
                            rpSubCatItems.DataSource = CategoryService.GetAll("ar");
                            rpSubCatItems.DataBind();
                            //Response.Redirect(Request.RawUrl.Split('?')[0] + "?myParam=0", false);
                        }
                        else
                        {
                            litErrorMsg.Text = "<div id=\"errormessage\" style=\"display:block\"> URL Already Exist</div>";
                            litErrorMsg.Visible = true;
                        }
                    }
                    else
                    {
                        var category = CategoryService.GetById(selectedId, "ar");
                        category.Modified = DateTime.Now;
                        category.NameArabic = txtArName.Text;
                        category.NameEnglish = txtEnName.Text;
                        //category.ContentType = PageContentService.GetById(int.Parse(ddlPageContentType.SelectedValue));
                        category.UserId = currentUserId;
                        category.URL = txtURL.Text.Trim().ToUpper();
                        category.DescriptionArabic = txtArDes.Text;
                        category.DescriptionEnglish = txtEnDes.Text;

                        CategoryService.Update(category);
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        rpSubCatItems.DataSource = CategoryService.GetAll("ar");
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
            txtArDes.Text = txtArName.Text = txtEnDes.Text = txtEnName.Text = txtURL.Text = string.Empty;
        }

        protected void rpSubCatItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "moveup")
            {
                List<Category> categories = CategoryService.GetAll("ar");
                var category = categories.Where(x => x.SortId == int.Parse(e.CommandArgument.ToString())).First();
                var nextCategory = categories.Where(x => x.SortId + 1 == int.Parse(e.CommandArgument.ToString())).First();

                category.SortId -= 1;
                nextCategory.SortId += 1;
                CategoryService.Update(category);
                CategoryService.Update(nextCategory);
                rpSubCatItems.DataSource = CategoryService.GetAll("Ar");
                rpSubCatItems.DataBind();
            }
            else if (e.CommandName == "movedown")
            {
                List<Category> categories = CategoryService.GetAll("ar");
                var category = categories.Where(x => x.SortId == int.Parse(e.CommandArgument.ToString())).First();
                var nextCategory = categories.Where(x => x.SortId - 1 == int.Parse(e.CommandArgument.ToString())).First();

                category.SortId += 1;
                nextCategory.SortId -= 1;
                CategoryService.Update(category);
                CategoryService.Update(nextCategory);
                rpSubCatItems.DataSource = CategoryService.GetAll("Ar");
                rpSubCatItems.DataBind();
            }
        }
    }
}