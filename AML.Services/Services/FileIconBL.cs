using AML.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.Services.Services
{
    public class FileIconBL
    {
        public List<FileIcon> GetAll()
        {
            var categories = new List<FileIcon>();
            using (var session = NHibernateHelper.OpenSession())
            {
                categories = session.Query<FileIcon>().ToList();
            }
            return categories;
        }
        public FileIcon GetByExntesion(string fileExtension)
        {
            var icon = new List<FileIcon>();
            using (var session = NHibernateHelper.OpenSession())
            {
                icon = session.Query<FileIcon>().Where(x => x.FileExtension == fileExtension).ToList();
            }
            if (icon == null || icon.Count < 1)
                return null;

            return icon.First();
        }

        public void CreateFileIcon(FileIcon fileIcon)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(fileIcon);
                    transaction.Commit();
                }
            }
        }
    }
}
