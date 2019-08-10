using System;
using BlogRepository.Entities;
using BlogDomain;
using Microsoft.EntityFrameworkCore;

namespace BlogRepository.Contexts
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogEntity> Blogs {get; set;}

        public BlogContext(DbContextOptions<BlogContext> options)
               : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
