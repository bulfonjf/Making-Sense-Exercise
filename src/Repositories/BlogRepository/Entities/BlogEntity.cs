using System;

namespace BlogRepository.Entities
{
    public class BlogEntity
    {
        public Guid Id {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public string Author {get; set;}
        public string Type {get; set;}
    }
}
