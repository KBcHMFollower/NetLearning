using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public List<BlogPost> BlogPosts { get; set; }
    }
}
