using System.Collections.Generic;
using BlogDomain;
using BlogRepository.Entities;

namespace ApplicationServices.Interfaces
{
    public interface IBlogServices
    {
        IEnumerable<BlogEntity> GetAll();
        void Create(Blog blog);
        void Delete(BlogEntity blog);
    }
}