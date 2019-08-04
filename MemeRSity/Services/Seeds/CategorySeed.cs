using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemeRSity.Data;
using MemeRSity.Data.Enums;
using MemeRSity.Models;
using MemeRSity.Services.Abstracts;
using MemeRSity.Services.Scopes;
using Microsoft.Extensions.DependencyInjection;

namespace MemeRSity.Services.Seeds
{
    public class CategorySeed:ISeedAsync
    {
        public async Task Seed(IServiceProvider provider)
        {
            using (var serviceScope = new ScopeBuilder(provider).ServiceScopeFactory().Build())
            {
                ApplicationContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                
                foreach (var name in Enum.GetNames(typeof(CategoryEnum)))
                {
                    await dbContext.Categories.AddAsync(new Category() {Name = name});
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}