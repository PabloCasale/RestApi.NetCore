using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.NetCore.Contracts;
using RestApi.NetCore.Domain;

namespace RestApi.NetCore.Controllers
{
    public class PostsController : Controller
    {
        private List<Post> _posts;
        

        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });

            }
        }


        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] Post post)
        {
            if (string.IsNullOrEmpty(post.Id) )
            {
                post.Id = Guid.NewGuid().ToString();
            }

            _posts.Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id);
            return Created(locationUri, post);
        }

    }
}