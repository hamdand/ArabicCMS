using AML.Domain.Application;
using FluentNHibernate.Mapping;

namespace AML.Services.Maps
{
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Id(x => x.Id);
            Map(x => x.NameEnglish);
            Map(x => x.NameArabic);
            Map(x => x.LogoURL);
            Map(x => x.UserId);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
        }
    }
}
