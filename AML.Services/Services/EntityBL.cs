using AML.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class EntityBL
    {
        public List<Entity> GetAll(string lang)
        {
            var entities = new List<Entity>();
            using (var session = NHibernateHelper.OpenSession())
            {
                entities = session.Query<Entity>().Where(x => x.IsDeleted == false).ToList();
            }
            if (entities != null && entities.Count > 0)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                    foreach (var item in entities)
                        item.Name = item.NameArabic;
            else
                    foreach (var item in entities)
                        item.Name = item.NameEnglish;

            return entities;
        }

        public void Create(Entity entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }

        }

        public Entity GetById(int selectedId, string lang)
        {
            var entity = new Entity();
            using (var session = NHibernateHelper.OpenSession())
            {
                entity = session.Get<Entity>(selectedId);
            }
            if (entity != null)
                if (lang == AML.Domain.Helper.Lang.Arabic.ToString())
                {
                    entity.Name = entity.NameArabic;
                }
                else
                {
                    entity.Name = entity.NameEnglish;
                }
            return entity;
        }

        public void UpdateEntity(Entity entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
