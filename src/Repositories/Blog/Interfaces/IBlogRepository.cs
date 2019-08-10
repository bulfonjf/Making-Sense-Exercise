using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorDomain;
using BlogDomain;
using BlogRepository.Entities;

namespace BlogRepository.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetAll();
        Task Create(Blog blog);

        Task Delete(BlogEntity blog);
    }
}
