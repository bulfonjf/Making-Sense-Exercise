using System;
using AuthorDomain;

namespace BlogDomain
{
    public class Blog
    {
        public Title Title {get; set;}
        public Body Body {get; set;}
        public Author Author {get; set;}
        public BlogType Type {get; set;}
    }
}
