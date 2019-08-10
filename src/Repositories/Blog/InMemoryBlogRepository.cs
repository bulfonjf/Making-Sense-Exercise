using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Create(Blog blog)
        {
            await Task.Run(() => {
                BlogEntity newBlog = new BlogEntity()
                {
                    Id = Guid.NewGuid(),
                    Blog = blog,
                };
                BlogRepository.Add(newBlog);
            });
        }

        public async Task Delete(BlogEntity blog)
        {
            await Task.Run(() => {
                var blogToRemove = BlogRepository.FirstOrDefault(b => b.Id == blog.Id);
                if(blogToRemove != null) 
                    BlogRepository.Remove(blogToRemove);
            });
        }

        public async Task<IEnumerable<BlogEntity>> GetAll()
        {
            var result = await Task.Run(() => {
                return BlogRepository;
            }); 
            return result;
        }
    }
}
