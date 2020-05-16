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
    public partial class AddNews : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                rpSubCatItems.DataSource = NewsService.GetAll("ar");
                rpSubCatItems.DataBind();
                if (selectedId > 0)
                {
                    var news = NewsService.GetById(selectedId, "ar");
                    txtArDes.Text = news.DescriptionArabic;
                    txtArName.Text = news.NameArabic;
                    txtEnDes.Text = news.DescriptionEnglish;
                    txtEnName.Text = news.NameEnglish;

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
                        NewsService.CreateNews(new News()
                        {
                            Modified = DateTime.Now,
                            NameArabic = txtArName.Text,
                            NameEnglish = txtEnName.Text,
                            ImageUrl = uploadSelectedFile(fuDocument),
                            SortId = 0,
                            DescriptionArabic = txtArDes.Text,
                            DescriptionEnglish = txtEnDes.Text,
                            UserId = currentUserId
                        });
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        clearForm();
                        rpSubCatItems.DataSource = NewsService.GetAll("ar");
                        rpSubCatItems.DataBind();
                        //Response.Redirect(Request.RawUrl.Split('?')[0] + "?myParam=0", false);

                    }
                    else
                    {
                        var news = NewsService.GetById(selectedId, "ar");
                        news.Modified = DateTime.Now;
                        news.NameArabic = txtArName.Text;
                        news.NameEnglish = txtEnName.Text;
                        if (fuDocument.HasFile)
                            news.ImageUrl = uploadSelectedFile(fuDocument);
                        news.UserId = currentUserId;
                        news.DescriptionArabic = txtArDes.Text;
                        news.DescriptionEnglish = txtEnDes.Text;

                        NewsService.UpdateNews(news);
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
        private string uploadSelectedFile(FileUpload fuDocument)
        {
            try
            {
                if (fuDocument.HasFile)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(fuDocument.FileName);
                    fuDocument.SaveAs(Server.MapPath("~/NewsImages/") + fileName);
                    return "NewsImages/" + fileName;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "";
        }
        private void clearForm()
        {
            txtArDes.Text = txtArName.Text = txtEnDes.Text = txtEnName.Text = string.Empty;
        }
    }
}