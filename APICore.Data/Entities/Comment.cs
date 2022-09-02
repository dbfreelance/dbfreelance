using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APICore.Data.Entities
{
    public class Comment
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string UserFirstName { get; set; }
        public DateTime DateTimeSubmit { get; set; }
        public string Content { get; set; }
        
    }
}
