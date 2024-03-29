﻿using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        Context context;
        public ArticleRepository(Context context)
        {
            this.context = context;
        }
        public async Task<Article> CreateArticle(Article article)
        {
            article.DateCreate = DateTime.Now;
            article.DateModified = DateTime.Now;

            context.Articles.Add(article);
            await context.SaveChangesAsync();
            return article;
        }

        public async Task DeleteArticle(int id)
        {
            var articleToDelete = context.Articles.FirstOrDefault(a => a.Id == id);
            if (articleToDelete != null)
            {
                context.Articles.Remove(articleToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await context.Articles.Include(a => a.Comments).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Article> GetArticleByDateDesc()
        {
            return await context.Articles.OrderByDescending(a => a.DateCreate).ThenByDescending(a => a.DateModified).FirstAsync();
        }

        public async Task<Article> SearchByTheme(string theme)
        {
            return await context.Articles.FirstOrDefaultAsync(a => a.Theme.Contains(theme));
        }
        public async Task<bool> IsUnique(string theme)
        {
            return await context.Articles.AnyAsync(a => a.Theme == theme);
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            var articleUpdate = context.Articles.FirstOrDefault(a => a.Id == article.Id);

            articleUpdate.Theme = article.Theme;
            articleUpdate.Auteur = article.Auteur;
            articleUpdate.Contenu = article.Contenu;
            articleUpdate.DateModified = DateTime.Now;
            await context.SaveChangesAsync();

            return article;
        }
    }
}
