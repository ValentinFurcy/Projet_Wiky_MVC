using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface ICommentRepository
    {
        Task<Comment> CreateComment(Comment comment);
        Task DeleteComment(int id);
    }
}
