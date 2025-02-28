using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreadetAt { get; set; } = DateTime.UtcNow;

        //Foreign Key   
        public int PostId { get; set; }
        public Post? Post { get; set; }


    }
}
