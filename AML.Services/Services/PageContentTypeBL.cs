using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class PageContentTypeBL
    {
        public List<PageContentType> GetAll(string lang)
        {
            var types = new List<PageContentType>();
            using (var session = NHibernateHelper.OpenSession())
            {
                types = session.Query<PageContentType>().Where(x => x.IsDeleted == false).ToList();
            }

            return types;
        }

        public PageContentType GetById(int selectedId)
        {
            var category = new PageContentType();
            using (var session = NHibernateHelper.OpenSession())
            {
                category = session.Get<PageContentType>(selectedId);
            }

            return category;
        }
    }
}
