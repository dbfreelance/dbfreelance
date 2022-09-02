using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Common.DTO.Request
{
    public class EditCommentRequest
    {
        public int UserId { get; set; }
        [Required]
        public int CommentId { get; set; }
        public string UserFirstName { get; set; }
        [Required]
        public DateTime DateTimeEdited { get; set; }
        public string Content { get; set; }
    }
}
