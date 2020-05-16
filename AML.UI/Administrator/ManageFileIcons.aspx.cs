using AML.Domain.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class ManageFileIcons : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpIcons.DataSource = FileIconService.GetAll();
                rpIcons.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                FileIconService.CreateFileIcon(new FileIcon()
                {
                    FileExtension = txtArName.Text.ToUpper().Trim(),
                    IconPath = uploadSelectedFile(fuDocument)
                });

                rpIcons.DataSource = FileIconService.GetAll();
                rpIcons.DataBind();
            }
        }

        private string uploadSelectedFile(FileUpload fuDocument)
        {
            try
            {
                if (fuDocument.HasFile)
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(fuDocument.FileName);
                    fuDocument.SaveAs(Server.MapPath("~/filesicons/") + fileName);
                    return "filesicons/" + fileName;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return "";
        }
    }
}