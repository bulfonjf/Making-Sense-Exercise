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
                    Title = "My first Blog!",
                    Body = "I hope you like it.",
                    Author = "Juan Bulfon",
                    Type = BlogType.Draft.ToString(),
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
                    Title = blog.Title.Content,
                    Body = blog.Body.Content,
                    Author = blog.Author.Name,
                    Type = blog.Type.ToString(),
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
