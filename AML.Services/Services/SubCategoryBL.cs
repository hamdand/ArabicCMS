using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class SubCategoryBL
    {

        public List<SubCategory> GetAll(string lang)
        {
            var categories = new List<SubCategory>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<SubCategory>().Where(x => x.IsDeleted == false).ToList();
            }
            if (categories != null && categories.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in categories)
                        item.Name = item.NameArabic;
                else
                    foreach (var item in categories)
                        item.Name = item.NameEnglish;


            return categories;
        }

        public void CreateSubCategory(SubCategory category)
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

        public List<SubCategory> GetAllNotLazy(string lang)
        {
            //var categories = new List<SubCategory>();
            //using (var session = NHibernateHelper.OpenSession())
            //{
            //    categories = session.Query<SubCategory>().Where(x => x.IsDeleted == false).ToList();
            //}
            //if (categories != null && categories.Count > 0)
            //    if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
            //        foreach (var item in categories)
            //        {
            //            item.Name = item.NameArabic;
            //            var tmp = item.SubCategories;
            //        }
            //    else
            //        foreach (var item in categories)
            //        {
            //            item.Name = item.NameEnglish;
            //            var tmp = item.SubCategories;
            //        }


            return null;
        }

        public void Update(SubCategory subCategory)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(subCategory);
                    transaction.Commit();
                }
            }
        }
        public void UpdateBulk(List<SubCategory> subCategories)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var item in subCategories)
                        session.Update(item);
                    transaction.Commit();
                }
            }
        }

        public SubCategory GetById(int selectedId, string lang)
        {
            var category = new SubCategory();
            using (var session = NHibernateHelper.OpenSession())
            {
                category = session.Get<SubCategory>(selectedId);
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
