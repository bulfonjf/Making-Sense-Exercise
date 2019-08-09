using System;

namespace BlogDomain
{
    public class Title
    {
        public string Content {get; set;}

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Content);
        }
    }
}
