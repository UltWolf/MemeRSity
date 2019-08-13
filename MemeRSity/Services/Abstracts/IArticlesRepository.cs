using MemeRSity.Models;
using MemeRSity.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemeRSity.Services.Abstracts
{
    interface IArticlesRepository
    {
           Task AddAsync(ArticlesCreate Article);
           List<Article> GetArticles(int page);
           Article GetArticle(int id);
           void DeleteArticle(Article article);
           void UpdateArticle(Article article);

    }
}
