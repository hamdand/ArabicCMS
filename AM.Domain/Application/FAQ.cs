﻿using System;

namespace AML.Domain.Application
{
    public class FAQ
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string NameEnglish { get; set; }
        public virtual string NameArabic { get; set; }
        public virtual string DescriptionArabic { get; set; }
        public virtual string DescriptionEnglish { get; set; }
        public virtual int SortId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual string UserId { get; set; }

    }
}
