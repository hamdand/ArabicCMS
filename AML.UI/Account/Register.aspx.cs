using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using AML.UI.Models;
using System.Web.UI.WebControls;
using AML.Domain.Application;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AML.UI.Account
{
    public partial class Register : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEntityName.DataSource = EntityService.GetAll(selectedLanguage);
                ddlEntityName.DataBind();
                if (ddlEntityName.Items.Count > 0)
                    ddlEntityName.Items.Insert(0, new ListItem() { Text = "الرجاء الإختيار", Value = "-1" });
                else
                {
                    var entity = new Entity()
                    {
                        Created = DateTime.Now,
                        IsDeleted = false,
                        Modified = DateTime.Now,
                        NameArabic = "تقنية المعلومات",
                        NameEnglish = "IT Department",
                        SortId = 1
                    };
                    EntityService.Create(entity);
                    ddlEntityName.Items.Insert(0, new ListItem() { Text = IsArabic ? entity.NameArabic  : entity.NameEnglish, Value = entity.Id.ToString() });
                }
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser()
                {
                    UserName = Email.Text.Trim(),
                    Email = Email.Text.Trim(),
                    FirstName = txtFName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    EntityName = ddlEntityName.SelectedValue,
                    PhoneNumber = txtMobile.Text.Trim(),
                    JobTitle = txtJobTitle.Text.Trim(),
                };
                user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole() { UserId = user.Id, RoleId = "1000" });
                IdentityResult result = manager.Create(user, Password.Text);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");


                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}