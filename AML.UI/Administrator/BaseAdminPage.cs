using AML.Services.Services;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using AML.UI.Models;

namespace AML.UI.Administrator
{
    public class BaseAdminPage : System.Web.UI.Page
    {
        public SubCategoryBL SubCategoryService = new SubCategoryBL();
        public CategoryBL CategoryService = new CategoryBL();
        public PageContentTypeBL PageContentService = new PageContentTypeBL();
        public FileIconBL FileIconService = new FileIconBL();
        public EntityBL EntityService = new EntityBL();
        public FAQBL FAQService = new FAQBL();
        public NewsBL NewsService = new NewsBL();
        public InquiryBL InquiryService = new InquiryBL();

        public int selectedId { get { return Request["Id"] == null ? -1 : int.Parse(Request["Id"]); } }
        public bool isArabic { get { return Request["lang"] == null ? true : Request["lang"].Contains("ar") ? true : false; } }
        public string currentUserId { get { return System.Web.HttpContext.Current.User.Identity.GetUserId(); } }
        public ApplicationUser GetUserInformation(string userId)
        {
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            return user;
        }
    }
}