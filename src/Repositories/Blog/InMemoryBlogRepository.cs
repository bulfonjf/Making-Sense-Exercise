using System;
using System.Collections.Generic;
using System.Linq;
using AuthorDomain;
using BlogDomain;
using BlogRepository.Entities;
using BlogRepository.Interfaces;

namespace BlogRepository
{
    public class InMemoryBlogRepository : IBlogRepository
    {
        public InMemoryBlogRepository()
        {
            this.BlogRepository = new List<BlogEntity>()
            {
                new BlogEntity()
                {
                    Id = Guid.NewGuid(),
                    Blog = new Blog()
                    {
                        Title = new Title(){ Content = "My first Blog!"},
                        Body = new Body(){ Content = "I hope you like it."},
                        Author = new Author(){ Name = "Juan Bulfon"},
                        Type = BlogType.Draft,
                    }
                }
            };
        }
        public List<BlogEntity> BlogRepository { get; private set; }

        public void Create(Blog blog)
        {
            BlogEntity newBlog = new BlogEntity()
            {
                Id = Guid.NewGuid(),
                Blog = blog,
            };
            BlogRepository.Add(newBlog);
        }

        public void Delete(BlogEntity blog)
        {
            var blogToRemove = BlogRepository.FirstOrDefault(b => b.Id == blog.Id);
            if(blogToRemove != null) 
                BlogRepository.Remove(blogToRemove);
        }

        public IEnumerable<BlogEntity> GetAll()
        {
            return BlogRepository;
        }
    }
}
