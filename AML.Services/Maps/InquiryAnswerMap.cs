using AML.Domain.Application;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Maps
{
    public class InquiryAnswerMap : ClassMap<InquiryAnswer>
    {
        public InquiryAnswerMap()
        {
            Id(x => x.Id);
            Map(x => x.Answer).Length(4001);
            Map(x => x.SortId);
            Map(x => x.IsDeleted);
            Map(x => x.Created);
            Map(x => x.Modified);
            Map(x => x.UserId);
            Map(x => x.IsPublic);
            Map(x=>x.IsArabic);
        }
    }
}
