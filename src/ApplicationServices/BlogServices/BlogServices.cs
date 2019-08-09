using System;
using System.Collections.Generic;
using ApplicationServices.Interfaces;
using BlogDomain;
using BlogRepository.Entities;
using BlogRepository.Interfaces;
using ApplicationServices.Exceptions;

namespace ApplicationServices.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly IBlogRepository blogRepository;

        public BlogServices(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public void Create(Blog blog)
        {
            ValidateBlog(blog);
            blogRepository.Create(blog);
        }

        private void ValidateBlog(Blog blog)
        {
            if(blog == null)
                throw new BusinessException("You must provide a blog to create it.");
            else if(!blog.Title.IsValid() 
            || !blog.Body.IsValid())
                throw new BusinessException("Mandatory fields are missing.");
        }

        public void Delete(BlogEntity blog)
        {
            blogRepository.Delete(blog);
        }

        public IEnumerable<BlogEntity> GetAll()
        {
            return blogRepository.GetAll();
        }
    }
}
