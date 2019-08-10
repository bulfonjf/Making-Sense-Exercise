using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationServices.Interfaces;
using BlogDomain;
using BlogRepository.Entities;
using AutoMapper;

namespace WebAPI.Blogs
{
    [Route("api/[controller]")]
    [ApiController]
     public class BlogController : ControllerBase
    {
        private readonly IBlogServices blogservices;
        private readonly IMapper automapper;

        public BlogController(IBlogServices blogservices, IMapper automapper)
        {
            this.blogservices = blogservices;
            this.automapper = automapper;
        }

        // GET api/blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogEntity>>> GetAll()
        {
            var blogs = await blogservices.GetAll();
            return blogs.ToList();
        }

        // POST api/blog
        [HttpPost]
        public async Task Post([FromBody] BlogDTO blogDTO)
        {
            var blog = automapper.Map<BlogDTO, Blog>(blogDTO);
            await blogservices.Create(blog);
        }

        [HttpDelete]
        public async Task Delete([FromBody] BlogDTO blogDTO)
        {
            var blog = automapper.Map<BlogDTO, BlogEntity>(blogDTO);
            await blogservices.Delete(blog);
        }
    }
}