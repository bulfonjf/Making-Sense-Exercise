using System;

namespace BlogDomain
{
    public class Body
    {
        public string Content {get; set;}

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Content);
        }
    }
}
