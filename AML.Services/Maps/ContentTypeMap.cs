using FluentNHibernate.Mapping;
using AML.Domain.Application;

namespace AML.Services.Maps
{
    public class ContentTypeMap : ClassMap<PageContentType>
    {
        public ContentTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            Map(x => x.UserId);
        }
    }
}
