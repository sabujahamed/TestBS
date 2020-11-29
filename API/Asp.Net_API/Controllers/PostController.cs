using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNET.BLL;
using ASPNET.DTO;
using ASPNET.DTO.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_API.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost post;
        public PostController(IPost post)
        {
            this.post = post;
        }
        [HttpPost("AddPost")]
        public ActionResult AddUser(Post post)
        {
            return new JsonResult(this.post.AddPost(post));
        }

        [HttpGet("GetPostDetails")]
        public async Task<ActionResult> GetPostDetails(PostFilterPagination postFilter)
        {

            try
            {
                var res = await this.post.GetUserPostDetails(postFilter);
                return  Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}