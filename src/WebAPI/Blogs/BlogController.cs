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
        public ActionResult<IEnumerable<BlogEntity>> GetAll()
        {
            return blogservices.GetAll().ToList();
        }

        // POST api/blog
        [HttpPost]
        public void Post([FromBody] BlogDTO blogDTO)
        {
            var blog = automapper.Map<BlogDTO, Blog>(blogDTO);
            blogservices.Create(blog);
        }

        [HttpDelete]
        public void Delete([FromBody] BlogDTO blogDTO)
        {
            var blog = automapper.Map<BlogDTO, BlogEntity>(blogDTO);
            blogservices.Delete(blog);
        }
    }
}