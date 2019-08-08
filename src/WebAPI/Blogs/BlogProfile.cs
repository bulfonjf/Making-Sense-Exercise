using System;
using AuthorDomain;
using AutoMapper;
using BlogDomain;
using BlogRepository.Entities;

namespace WebAPI.Blogs
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogDTO>()
            .ForMember(blogDTO => blogDTO.Title, opts => opts.MapFrom(blog => blog.Title.Content))
            .ForMember(blogDTO => blogDTO.Body, opts => opts.MapFrom(blog => blog.Body.Content))
            .ForMember(blogDTO => blogDTO.Author, opts => opts.MapFrom(blog => blog.Author.Name))
            .ForMember(blogDTO => blogDTO.Type, opts => opts.MapFrom(blog => Enum.GetName(typeof(BlogType), blog.Type)));

            CreateMap<BlogDTO, Title>()
            .ForMember(title => title.Content, opts => opts.MapFrom(blogDTO => blogDTO.Title));

            CreateMap<BlogDTO, Body>()
            .ForMember(body => body.Content, opts => opts.MapFrom(blogDTO => blogDTO.Body));

            CreateMap<BlogDTO, Author>()
            .ForMember(author => author.Name, opts => opts.MapFrom(blogDTO => blogDTO.Author));

            CreateMap<BlogDTO, Blog>()
            .ForMember(blog => blog.Author, opts => opts.MapFrom(blogDTO => blogDTO))
            .ForMember(blog => blog.Title, opts => opts.MapFrom(blogDTO => blogDTO))
            .ForMember(blog => blog.Body, opts => opts.MapFrom(blogDTO => blogDTO))
            .ForMember(blog => blog.Type, opts => opts.MapFrom(blogDTO => (BlogType)Enum.Parse(typeof(BlogType), blogDTO.Type)));

            CreateMap<BlogDTO, BlogEntity>()
            .ForMember(blog => blog.Id, opts => opts.MapFrom(blogDTO => blogDTO.Id))
            .ForMember(blog => blog.Blog, opts => opts.MapFrom(blogDTO => blogDTO));

            CreateMap<BlogEntity, BlogDTO>()
            .ForMember(blogDTO => blogDTO.Id, opts => opts.MapFrom(blog => blog.Id.ToString("D")));
            
        }
    }
}