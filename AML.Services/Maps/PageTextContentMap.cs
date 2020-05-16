using AML.Domain.Application;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Maps
{
    class PageTextContentMap : ClassMap<PageTextContent>
    {
        public PageTextContentMap()
        {
            Id(x => x.Id);
            Map(x => x.TextArabic).Length(4001);
            Map(x => x.TextEnglish).Length(4001);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            Map(x => x.UserId);
        }
    }
}
