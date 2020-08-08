using Microsoft.EntityFrameworkCore;
using RestApi.NetCore.Data;
using RestApi.NetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.NetCore.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _db;

        public PostService(DataContext db)
        {
            this._db = db;
        }


        public async Task<List<Post>> GetPostsAsync()
        {
            return await _db.Posts.ToListAsync();
        }


        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _db.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }


        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _db.Posts.Update(postToUpdate);
            var updated = await _db.SaveChangesAsync();
            return updated > 0;
        }


        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post == null)
            {
                return false;
            }
            _db.Posts.Remove(post);
            var deleted = await _db.SaveChangesAsync(); 
            return deleted > 0;
        }


        public async Task<bool> CreatePostAsync(Post post)
        {
            await _db.Posts.AddAsync(post);
            var created = await _db.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UserOwnsPost(Guid postId, string getUserId)
        {
            var post = await _db.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postId);

            if (post == null)
            {
                return false;
            }

            if (post.UserId != getUserId)
            {
                return false;
            }

            return true;
        }
    }
}
