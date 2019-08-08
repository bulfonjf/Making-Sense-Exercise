using System;
using System.Collections.Generic;
using AuthorDomain;
using BlogDomain;
using BlogRepository.Entities;

namespace BlogRepository.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<BlogEntity> GetAll();
        void Create(Blog blog);

        void Delete(BlogEntity blog);
    }
}
