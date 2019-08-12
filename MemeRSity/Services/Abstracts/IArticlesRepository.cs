using MemeRSity.Models;
using MemeRSity.ViewModel;
using System.Threading.Tasks;

namespace MemeRSity.Services.Abstracts
{
    interface IArticlesRepository
    {
           Task AddAsync(ArticlesCreate Article);

    }
}
