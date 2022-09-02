using APICore.Common.DTO.Request;
using APICore.Data.Entities;
using System.Threading.Tasks;

namespace APICore.Services
{
    public interface ICommentService
    {
        Task<Comment> GetAllComments();
        Task<Comment> GetCommentById(int commentId);
        Task PostComment(PostCommentRequest request);
        Task EditComment(int commentId, EditCommentRequest request);
        Task Delete(int commentId);
    }

}