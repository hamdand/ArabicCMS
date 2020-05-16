
using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class MainCategoryEditContentMedia : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var category = CategoryService.GetById(selectedId, isArabic ? AML.Domain.Helper.Lang.Arabic.ToString() : AML.Domain.Helper.Lang.English.ToString());

                litTitle.Text = category.Name;
                litDes.Text = category.Description;
                txtDocDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                rpFiles.DataSource = category.PageMedia.Where(x => x.IsDeleted == false);
                rpFiles.DataBind();
                if (category.PageText != null)
                {
                    //                    FreeTextBox1.Text = isArabic ? category.PageText.TextArabic : category.PageText.TextEnglish;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && fuDocument.HasFile)
            {
                var fileMedia = new PageMediaContent();
                fileMedia.Name = txtFileName.Text;
                fileMedia.IsEnglishFile = rbLang.SelectedValue == "0" ? false : true;
                fileMedia.Created = DateTime.Now;
                fileMedia.Desecription = txtDescription.Text;
                fileMedia.FileDate = DateTime.Parse(txtDocDate.Text);
                fileMedia.FilePath = uploadSelectedFile(fuDocument);
                var fileIcon = FileIconService.GetByExntesion(Path.GetExtension(fuDocument.FileName).ToUpper().Trim());
                fileMedia.UserId = currentUserId;
                if (fileIcon != null && fileIcon.Id > 0)
                    fileMedia.FileIcon = fileIcon.IconPath;
                else
                    fileMedia.FileIcon = "filesicons/unknown.jpeg";

                var category = CategoryService.GetById(selectedId, "Ar");
                if (category.PageMedia == null)
                    category.PageMedia = new List<PageMediaContent>();

                category.PageMedia.Add(fileMedia);

                CategoryService.Update(category);

                litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                litSendMsg.Visible = true;
                clearForm();

                txtDocDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        private void clearForm()
        {
            txtDescription.Text = txtDocDate.Text = txtFileName.Text = string.Empty;
        }

        private string uploadSelectedFile(FileUpload fuDocument)
        {
            try
            {
                if (fuDocument.HasFile)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(fuDocument.FileName);
                    fuDocument.SaveAs(Server.MapPath("~/MainCategoryFiles/") + fileName);
                    return "MainCategoryFiles/" + fileName;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "";
        }

        protected void rpFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var category = CategoryService.GetById(selectedId, "Ar");
                category.PageMedia.Where(x => x.Id == int.Parse(e.CommandArgument.ToString())).First().IsDeleted = true;
                CategoryService.Update(category);

                rpFiles.DataSource = category.PageMedia.Where(x => x.IsDeleted == false);
                rpFiles.DataBind();
            }
        }
    }
}