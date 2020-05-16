using AML.Domain.Helper;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Maps
{
    public class FileIconMap : ClassMap<FileIcon>
    {
        public FileIconMap()
        {
            Id(x => x.Id);
            Map(x => x.FileExtension);
            Map(x => x.IconPath);
            Map(x => x.UserId);
        }
    }
}
