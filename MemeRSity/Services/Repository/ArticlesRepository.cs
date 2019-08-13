using MemeRSity.Data;
using MemeRSity.Models;
using MemeRSity.Services.Abstracts;
using MemeRSity.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemeRSity.Services
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ApplicationContext _context;
        private const int count = 20;
        public ArticlesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async  Task AddAsync(ArticlesCreate Article)
        {
            Article dbArticle = Article;
           
            List<Tag> tags = new List<Tag>(Article.Tags);
            _context.Articles.Add(dbArticle);
            _context.Tags.AddRange(tags);
            
            await _context.SaveChangesAsync();

            dbArticle.ImgPath = await WriteFile(Article, dbArticle);
            _context.Update(dbArticle);

            await _context.SaveChangesAsync();

            foreach (var tag in tags)
            {
                dbArticle.Tags.Add(new ArticleTag() { TagId = tag.Id, ArticleId = dbArticle.Id });
            }

            await _context.SaveChangesAsync();
        }

        public void DeleteArticle(Article article)
        { 
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public List<Article> GetArticles(int page)
        {
            return _context.Articles.Skip(page * count).Take(count).ToList();
        }

        public void UpdateArticle(Article article)
        {
            try
            {
                _context.Update(article);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.Id))
                {
                    return ;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        private async Task<string> WriteFile(ArticlesCreate articleCreate, Article article)
        {
            FileInfo fi = new FileInfo(articleCreate.Image.FileName);
            var newFilename = article.Id + "_" + String.Format("{0:d}",
                                  (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
            var webPath =   @"\wwwroot\";
            var path = Path.Combine("", webPath + @"\ImageFiles\" + newFilename);
            var pathToSave = @"/ImageFiles/" + newFilename;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await articleCreate.Image.CopyToAsync(stream);
            }

            return  pathToSave;
        }

        public Article GetArticle(int id)
        {
            return this._context.Articles.Find(id);
        }
    }
}
