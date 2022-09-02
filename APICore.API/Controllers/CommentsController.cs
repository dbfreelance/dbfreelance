using APICore.API.BasicResponses;
using APICore.Common.DTO.Request;
using APICore.Common.DTO.Response;
using APICore.Data.Entities;
using APICore.Services;
using APICore.Services.Impls;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APICore.API.Controllers
{
    [Route("api/log")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
        }

        [HttpPost]
        [Route("post")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostComment([FromBody] PostCommentRequest post)
        {
            await _commentService.PostComment(post);
            return Created("", true);
        }


        /// <summary>
        /// List all comments. Requires authentication.
        /// </summary>       
        [HttpGet()]
        [Route("comments")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{commentId}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var comment = await _commentService.GetCommentById(commentId);
            return Ok(comment);
        }

        [HttpPut("{commentId}")]
        [Route("edit")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Update(int commentId, [FromBody] EditCommentRequest comment)
        {
            _commentService.EditComment(commentId, comment);
            return Ok(new { message = "Comment updated" });
        }

        [HttpDelete("{commentId}")]
        [Route("delete")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Delete(int commentId)
        {
            _commentService.Delete(commentId);
            return Ok(new { message = "User deleted" });
        }




    }
}
