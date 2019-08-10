using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDomain;
using BlogRepository.Entities;
using BlogRepository.Interfaces;
using BlogRepository.Contexts;
using AutoMapper;

namespace BlogRepository
{
    public class MySQLBlogRepository : IBlogRepository
    {
        private readonly IMapper mapper;
        private readonly BlogContext context;

        public MySQLBlogRepository(IMapper mapper, BlogContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        public async Task Create(Blog blog)
        {
            var blogEntity = mapper.Map<Blog, BlogEntity>(blog);
            await Task.Run(() => {
                using(context)
                {
                    context.Blogs.Add(blogEntity);
                    context.SaveChanges();
                }
            });
        }

        public async Task Delete(BlogEntity blog)
        {
            await Task.Run(() => {
                using(context)
                {
                    context.Blogs.Remove(blog);
                    context.SaveChanges();
                }
            });
        }

        public async Task<IEnumerable<BlogEntity>> GetAll()
        {
            var result = await Task.Run(() => {
                using(context)
                {
                    return context.Blogs.ToList();
                }
            }); 
            return result;
        }
    }
}
