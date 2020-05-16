
using AML.Domain.Application;
using FluentNHibernate.Mapping;

namespace AML.Services.Maps
{
    public class PageMediaContentMap : ClassMap<PageMediaContent>
    {
        public PageMediaContentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Desecription).Length(4001);
            Map(x => x.FilePath);
            Map(x => x.FileIcon);
            Map(x => x.IsEnglishFile);
            Map(x => x.FileDate);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.UserId);
        }
    }
}
