using System;
using System.Collections.Generic;
using ApplicationServices.Interfaces;
using BlogDomain;
using BlogRepository.Entities;
using BlogRepository.Interfaces;

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
            blogRepository.Create(blog);
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
