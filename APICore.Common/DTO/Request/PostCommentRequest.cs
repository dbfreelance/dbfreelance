using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Common.DTO.Request
{
    public class PostCommentRequest
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string UserFirstName { get; set; }
        [Required]
        public DateTime DateTimeSubmit { get; set; }
        public string Content { get; set; }
    }
}
