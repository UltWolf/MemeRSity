using System;
using System.Threading.Tasks;

namespace MemeRSity.Services.Abstracts
{
    public interface ISeedAsync
    {
        Task Seed(IServiceProvider provider);
    }
}