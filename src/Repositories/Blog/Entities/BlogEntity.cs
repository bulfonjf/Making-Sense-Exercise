using System;
using BlogDomain;

namespace BlogRepository.Entities
{
    public class BlogEntity
    {
        public Guid Id {get; set;}
        public Blog Blog {get; set;}
    }
}
