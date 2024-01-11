using System;
using IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Entity_Framework;
using Entities;

namespace Repositories.Repository
{
    public class CommentRepository : ICommentRepository
    {
        Context context;
        public CommentRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            comment.DateCreate = DateTime.Now;
            comment.DateModified = DateTime.Now;

            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment;     
        }

        public async Task DeleteComment(int id)
        {
            var commentToDelete = context.Comments.FirstOrDefault(c => c.Id == id);
            if (commentToDelete != null) 
            {
                context.Comments.Remove(commentToDelete);
                await context.SaveChangesAsync();
            }
        }

    }
}
