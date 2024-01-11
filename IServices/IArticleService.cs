using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IArticleService
    {
        Task <Article> CreateArticle(string theme, string auteur, DateTime dateCreate, string contenu);
        Task <List<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task <Article> UpdateArticle(int id);
        Task <Article> DeleteArticle(int id);
    }
}
