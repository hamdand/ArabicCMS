using AML.Domain.Application;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Maps
{
    public class NewsMap : ClassMap<News>
    {
        public NewsMap()
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
            Map(x=>x.ImageUrl);
        }
    }
}
