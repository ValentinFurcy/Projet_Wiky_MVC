using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entity_Framework
{
    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=Projet_Wiky_MVC;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var a1 = new Article() { Id = 1, Theme = "Animaux", Auteur = "Valentin", DateCreate = DateTime.Now,  Contenu = "Je préfére les animaux aux humains car ils sont fidéles"};
            var a2 = new Article() { Id = 1, Theme = "Code", Auteur = "Valentin", DateCreate = DateTime.Now,  Contenu = "En développement tester s'est douter !!!"};
            
            modelBuilder.Entity<Article>().HasData(a1);
            modelBuilder.Entity<Article>().HasData(a2);
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
