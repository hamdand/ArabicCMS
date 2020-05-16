using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AML.Services.Services
{
    public class CategoryBL
    {
        public List<Category> GetAll(string lang)
        {
            var categories = new List<Category>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<Category>().Where(x => x.IsDeleted == false).ToList();
            }
            if (categories != null && categories.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in categories)
                        item.Name = item.NameArabic;
                else
                    foreach (var item in categories)
                        item.Name = item.NameEnglish;


            return categories.OrderBy(x => x.SortId).ThenBy(x => x.Id).ToList();
        }

        public List<Category> GetCategoryByUrl(string url)
        {
            var categories = new List<Category>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<Category>().Where(x => x.IsDeleted == false && x.URL == url).ToList();
            }
            return categories;
        }

        public void Create(Category category)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(category);
                    transaction.Commit();
                }
            }
        }
        public void Update(Category category)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(category);
                    transaction.Commit();
                }
            }
        }

        public void UpdateBulk(List<Category> categories)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var item in categories)
                        session.Update(item);
                    transaction.Commit();
                }
            }
        }

        public List<Category> GetAllNotLazy(string lang)
        {
            var categories = new List<Category>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<Category>().Where(x => x.IsDeleted == false).ToList();
            }
            if (categories != null && categories.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in categories)
                    {
                        item.Name = item.NameArabic;
                        var tmp = item.SubCategories;
                    }
                else
                    foreach (var item in categories)
                    {
                        item.Name = item.NameEnglish;
                        var tmp = item.SubCategories;
                    }


            return categories;
        }
        public Category GetById(int selectedId, string lang)
        {
            var category = new Category();
            using (var session = NHibernateHelper.OpenSession())
            {
                category = session.Get<Category>(selectedId);
            }
            if (category != null)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                {
                    category.Name = category.NameArabic;
                    category.Description = category.DescriptionArabic;
                }
                else
                {
                    category.Name = category.NameEnglish;
                    category.Description = category.DescriptionEnglish;
                }
            return category;
        }

    }
}
