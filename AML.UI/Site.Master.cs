using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AML.Services.Services;
using AML.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace AML.UI
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        public CategoryBL CategoryService = new CategoryBL();
        public string selectedLanguage
        {
            get
            {
                if (Session["lang"] == null) Session["lang"] = "ar-JO";
                if (Session["lang"] != null && Session["lang"].ToString().ToLower().Contains("ar"))
                    return AML.Domain.Helper.Lang.Arabic.ToString();

                return AML.Domain.Helper.Lang.English.ToString();
            }
        }
        public string Stylesheet { get { if (selectedLanguage.ToLower().Contains("ar")) return "content/Site.css"; else return "content/Site-ltr.css"; } }
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["lang"] == null) Session["lang"] = "ar-JO";
                topMenu.DataSource = CategoryService.GetAll(selectedLanguage);
                topMenu.DataBind();

                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                    litLastName.Text = litLastName2.Text = user.LastName;
                    if (HttpContext.Current.User.IsInRole("administrator"))
                        liAdminSite.Visible = true;
                }
                else
                {
                    litLastName.Visible = litLastName2.Visible = topMenu.Visible =
                        liLogout.Visible = li1.Visible = liManage.Visible = liFAQs.Visible = litInquiries.Visible = divInquiry.Visible = false;

                }

            }
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["lang"] != null && Session["lang"].ToString().ToLower().Contains("ar"))
            {
                Session["lang"] = "en-US";
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            }
            else
            {
                Session["lang"] = "ar-JO";
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-JO");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-JO");
            }
            Response.Redirect("~/Default");
        }
        protected string SomeExtractingMethodLikeEval(int id)
        {
            var subCategories = CategoryService.GetById(id, selectedLanguage).SubCategories.Where(x => x.IsDeleted == false).OrderBy(x => x.SortId).ThenBy(x => x.Id);
            string outcome = string.Empty;
            foreach (var item in subCategories)
                outcome += " <li><a href=\"" + (item.ContentType.Id == 1 ? Page.ResolveUrl("~/SubCategoryPageContent/Index?Id=" + item.Id) : Page.ResolveUrl("~/SubCategoryPageContent/Media?Id=" + item.Id)) + "\">" + item.GetType().GetProperty(selectedLanguage == AML.Domain.Helper.Lang.Arabic.ToString() ? "NameArabic" : "NameEnglish").GetValue(item, null) + "</a></li>";
            return outcome;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Response.Redirect("~/Account/Login");
        }
    }

}