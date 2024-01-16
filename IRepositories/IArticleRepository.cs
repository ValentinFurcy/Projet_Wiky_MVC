using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IArticleRepository
    {
        //Task<Article> CreateArticle(string theme, string auteur, DateTime dateCreate, string contenu);
        Task<Article> CreateArticle(Article article);
        Task<List<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> UpdateArticle(Article article);
        Task DeleteArticle(int id);
        Task<Article> SearchByTheme(string theme);
        Task<Article> GetArticleByDateDesc();
        Task<bool> IsUnique(string theme);
    }
}
