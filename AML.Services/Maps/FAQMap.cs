using AML.Domain.Application;
using FluentNHibernate.Mapping;


namespace AML.Services.Maps
{
    public class FAQMap : ClassMap<FAQ>
    {
        public FAQMap()
        {
            Id(x => x.Id);
            Map(x => x.NameEnglish);
            Map(x => x.NameArabic);
            Map(x => x.DescriptionEnglish).Length(4001);
            Map(x => x.DescriptionArabic).Length(4001);
            Map(x => x.SortId);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            Map(x => x.UserId);
        }
    }
}
