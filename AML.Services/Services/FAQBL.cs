using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class FAQBL
    {
        public List<FAQ> GetAll(string lang)
        {
            var faqs = new List<FAQ>();
            using (var session = NHibernateHelper.OpenSession())
            {
                faqs = session.Query<FAQ>().Where(x => x.IsDeleted == false).ToList();
            }
            if (faqs != null && faqs.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in faqs)
                    {
                        item.Name = item.NameArabic;
                        item.Description = item.DescriptionArabic;
                    }
                else
                    foreach (var item in faqs)
                    {
                        item.Name = item.NameEnglish;
                        item.Description = item.DescriptionEnglish;
                    }


            return faqs;
        }
        public void Create(FAQ faq)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(faq);
                    transaction.Commit();
                }
            }
        }
        public void UpdateFAQ(FAQ faq)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(faq);
                    transaction.Commit();
                }
            }
        }
        public FAQ GetById(int selectedId, string lang)
        {
            var faq = new FAQ();
            using (var session = NHibernateHelper.OpenSession())
            {
                faq = session.Get<FAQ>(selectedId);
            }
            if (faq != null)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                {
                    faq.Name = faq.NameArabic;
                    faq.Description = faq.DescriptionArabic;
                }
                else
                {
                    faq.Name = faq.NameEnglish;
                    faq.Description = faq.DescriptionEnglish;
                }
            return faq;
        }

    }
}
