using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class NewsBL
    {
        public List<News> GetAll(string lang)
        {
            var news = new List<News>();
            using (var session = NHibernateHelper.OpenSession())
            {
                news = session.Query<News>().Where(x => x.IsDeleted == false).ToList();
            }
            if (news != null && news.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in news)
                    {
                        item.Name = item.NameArabic;
                        item.Description = item.DescriptionArabic;
                    }
                else
                    foreach (var item in news)
                    {
                        item.Name = item.NameEnglish;
                        item.Description = item.DescriptionEnglish;
                    }


            return news;
        }
        public void CreateNews(News news)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(news);
                    transaction.Commit();
                }
            }
        }
        public void UpdateNews(News news)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(news);
                    transaction.Commit();
                }
            }
        }
        public News GetById(int selectedId, string lang)
        {
            var news = new News();
            using (var session = NHibernateHelper.OpenSession())
            {
                news = session.Get<News>(selectedId);
            }
            if (news != null)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                {
                    news.Name = news.NameArabic;
                    news.Description = news.DescriptionArabic;
                }
                else
                {
                    news.Name = news.NameEnglish;
                    news.Description = news.DescriptionEnglish;
                }
            return news;
        }
    }
}
