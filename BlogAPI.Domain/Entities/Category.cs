using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        //Category Post 1-n
        public List<Post> Posts { get; set; }=new List<Post>(); 
    }
}
