using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MemeRSity.Services.Seeds
{
    public static class SeedManager
    {
        public   static  IWebHost Seed(this IWebHost host)
        {       List<Task> tasksCreating = new List<Task>();
                var services = host.Services;
                tasksCreating.Add(DbCreating.Create(services));
                tasksCreating.Add(new CategorySeed().Seed(services));
                tasksCreating.Add(new UserSeed().Seed(services));
                Task.WaitAll(tasksCreating.ToArray());
                
                return host;
        }
    }
}