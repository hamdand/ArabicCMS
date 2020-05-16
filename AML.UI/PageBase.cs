using AML.Services.Services;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using AML.UI.Models;

namespace AML.UI
{
    public class PageBase : Page
    {
        public SubCategoryBL SubCategoryService = new SubCategoryBL();
        public CategoryBL CategoryService = new CategoryBL();
        public PageContentTypeBL PageContentService = new PageContentTypeBL();
        public EntityBL EntityService = new EntityBL();
        public FAQBL FAQService = new FAQBL();
        public NewsBL NewsService = new NewsBL();
        public InquiryBL InquireyService = new InquiryBL();
        public int selectedId { get { return int.Parse(Request["Id"]); } }
        public string currentUserId { get { return HttpContext.Current.User.Identity.GetUserId(); } }
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
        public bool IsArabic
        {
            get
            {
                if (Session["lang"] == null) Session["lang"] = "ar-JO";
                if (Session["lang"] != null && Session["lang"].ToString().ToLower().Contains("ar"))
                    return true;

                return false;
            }
        }
        protected override void InitializeCulture()
        {
            if (Session["lang"] == null) Session["lang"] = "ar-JO";
            if (Session["lang"].ToString().ToLower().Contains("ar"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-JO");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-JO");
            }
            base.InitializeCulture();
        }
        public ApplicationUser GetUserInformation(string userId)
        {
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            return user;
        }
    }
}