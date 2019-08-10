using System;
using System.Collections.Generic;
using ApplicationServices.Interfaces;
using BlogDomain;
using BlogRepository.Entities;
using BlogRepository.Interfaces;
using ApplicationServices.Exceptions;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly IBlogRepository blogRepository;

        public BlogServices(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task Create(Blog blog)
        {
            ValidateBlog(blog);
            await blogRepository.Create(blog);
        }

        private void ValidateBlog(Blog blog)
        {
            if(blog == null)
                throw new BusinessException("You must provide a blog to create it.");
            else if(!blog.Title.IsValid() 
            || !blog.Body.IsValid())
                throw new BusinessException("Mandatory fields are missing.");
        }

        public async Task Delete(BlogEntity blog)
        {
            await blogRepository.Delete(blog);
        }

        public async Task<IEnumerable<BlogEntity>> GetAll()
        {
            var result = await blogRepository.GetAll();
            return result;
        }
    }
}
