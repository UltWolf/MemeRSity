using System;
using System.Threading.Tasks;
using MemeRSity.Models;
using MemeRSity.Services.Abstracts;
using MemeRSity.Services.Scopes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MemeRSity.Services.Seeds
{
    public class UserSeed:ISeedAsync
    {
        public async Task Seed(IServiceProvider provider)
        {
            using (var scope = new ScopeBuilder(provider).ServiceScopeFactory().Build())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();

                await userManager.CreateAsync(new UserApp() {Email = "ultwolf@gmail.com", UserName = "Ultwolf"},
                    "111111FD");
            }
        }

    }
}