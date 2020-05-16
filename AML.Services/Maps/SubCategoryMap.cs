using AML.Domain.Application;
using FluentNHibernate.Mapping;


namespace AML.Services.Maps
{
    public class SubCategoryMap : ClassMap<SubCategory>
    {
        public SubCategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.NameEnglish);
            Map(x => x.NameArabic);
            Map(x => x.DescriptionEnglish).Length(4001);
            Map(x => x.DescriptionArabic).Length(4001);
            Map(x => x.URL);
            Map(x => x.SortId);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            References(x => x.ContentType);
            References(x => x.PageText).Not.LazyLoad().Cascade.All().NotFound.Ignore();
            HasMany(x => x.PageMedia).Not.LazyLoad().Cascade.All().NotFound.Ignore();
            Map(x => x.UserId);
        }
    }
}
