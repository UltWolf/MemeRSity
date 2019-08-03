using System;
using System.Threading.Tasks;
using MemeRSity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MemeRSity.Services.Seeds
{
    public class DbCreating
    {
        public static  async Task Create(IServiceProvider provider)
        {
            using (var serviceScope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                await dbContext.Database.EnsureCreatedAsync(); 
            }
        }
    }
}