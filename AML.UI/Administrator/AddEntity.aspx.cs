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
    public partial class AddEntity : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddlPageContentType.DataSource = PageContentService.GetAll("ar");
                //ddlPageContentType.DataBind();

                rpSubCatItems.DataSource = EntityService.GetAll("ar");
                rpSubCatItems.DataBind();
                if (selectedId > 0)
                {
                    var category = EntityService.GetById(selectedId, "ar");
                    txtArName.Text = category.NameArabic;

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
                        EntityService.Create(new Entity()
                        {
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            NameArabic = txtArName.Text,
                            NameEnglish = txtEnName.Text,
                            LogoURL = uploadSelectedFile(fuDocument),
                            SortId = 0,
                            UserId = currentUserId
                        });
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        clearForm();
                        rpSubCatItems.DataSource = EntityService.GetAll("ar");
                        rpSubCatItems.DataBind();
                        //Response.Redirect(Request.RawUrl.Split('?')[0] + "?myParam=0", false);

                    }
                    else
                    {

                        Entity entity = EntityService.GetById(selectedId, "ar");
                        entity.Modified = DateTime.Now;
                        entity.NameArabic = txtArName.Text;
                        entity.NameEnglish = txtEnName.Text;
                        entity.LogoURL = uploadSelectedFile(fuDocument);
                        
                        entity.UserId = currentUserId;


                        EntityService.UpdateEntity(entity);
                        litSendMsg.Text = "<div id=\"sendmessage\" style=\"display:block\">تم الحفظ بنجاح</div>";
                        litSendMsg.Visible = true;
                        rpSubCatItems.DataSource = EntityService.GetAll("ar");
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
                    fuDocument.SaveAs(Server.MapPath("~/EnitiesLogos/") + fileName);
                    return "EnitiesLogos/" + fileName;
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
            txtArName.Text = txtEnName.Text = string.Empty;
        }

    }
}