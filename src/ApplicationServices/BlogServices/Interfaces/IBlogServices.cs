using System.Collections.Generic;
using System.Threading.Tasks;
using BlogDomain;
using BlogRepository.Entities;

namespace ApplicationServices.Interfaces
{
    public interface IBlogServices
    {
        Task<IEnumerable<BlogEntity>> GetAll();
        Task Create(Blog blog);
        Task Delete(BlogEntity blog);
    }
}