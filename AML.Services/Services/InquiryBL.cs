using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class InquiryBL
    {
        public void Delete(int selectedId)
        {
            var inquiry = new Inquiry();
            using (var session = NHibernateHelper.OpenSession())
            {
                inquiry = session.Query<Inquiry>().Where(x => x.Id == selectedId).First();
            }
            inquiry.IsDeleted = true;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(inquiry);
                    transaction.Commit();
                }
            }
        }

        public void Update(Inquiry item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(item);
                    transaction.Commit();
                }
            }

        }

        public void Create(Inquiry inquiry)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(inquiry);
                    transaction.Commit();
                }
            }
        }

        public object GetAllPublic(bool isArabic)
        {
            var inquiries = new List<Inquiry>();
            using (var session = NHibernateHelper.OpenSession())
            {
                inquiries = session.Query<Inquiry>().Where(x => x.IsDeleted == false && x.IsPublic == true && x.IsClosed == true && x.IsArabic == isArabic).OrderByDescending(x => x.Id).ToList();
            }
            return inquiries;
        }

        public List<Inquiry> GetPending()
        {
            var inquiries = new List<Inquiry>();
            using (var session = NHibernateHelper.OpenSession())
            {
                inquiries = session.Query<Inquiry>().Where(x => x.IsDeleted == false && x.IsClosed == false).OrderByDescending(x => x.Id).ToList();
            }
            return inquiries;
        }

        public Inquiry GetById(int selectedId)
        {
            var inquiries = new List<Inquiry>();
            using (var session = NHibernateHelper.OpenSession())
            {
                inquiries = session.Query<Inquiry>().Where(x => x.IsDeleted == false && x.Id == selectedId).ToList();
            }
            if (inquiries == null || inquiries.Count == 0 || inquiries.Count > 1)
                return null;
            return inquiries.First();
        }

        public List<Inquiry> GetAll(bool isArabic)
        {
            var inquiries = new List<Inquiry>();
            using (var session = NHibernateHelper.OpenSession())
            {
                inquiries = session.Query<Inquiry>().Where(x => x.IsDeleted == false && x.IsArabic == isArabic).OrderByDescending(x => x.Id).ToList();
            }
            return inquiries;
        }
    }
}
