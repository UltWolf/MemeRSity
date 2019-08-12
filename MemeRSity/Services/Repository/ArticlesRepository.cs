using MemeRSity.Data;
using MemeRSity.Models;
using MemeRSity.Services.Abstracts;
using MemeRSity.ViewModel;
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
    }
}
