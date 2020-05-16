using AML.Domain.Application;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Maps
{
    public class InquiryMap : ClassMap<Inquiry>
    {
        public InquiryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description).Length(4001);
            Map(x => x.SortId);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            Map(x => x.UserId);
            Map(x => x.IsPublic);
            Map(x => x.IsClosed);
            Map(x => x.IsArabic);
            HasMany(x => x.Answers).Not.LazyLoad().Cascade.All().NotFound.Ignore();
        }
    }
}
