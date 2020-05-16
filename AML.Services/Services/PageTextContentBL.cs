using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class PageTextContentBL
    {
        public List<PageTextContent> GetAll(string lang)
        {
            var categories = new List<PageTextContent>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<PageTextContent>().Where(x => x.IsDeleted == false).ToList();
            }
            return categories;
        }
    }
}
