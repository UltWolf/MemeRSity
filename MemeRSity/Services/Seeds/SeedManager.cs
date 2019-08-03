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
                tasksCreating.Add(new Task(()=>DbCreating.Create(host.Services).Start()));
                Task.WaitAll(tasksCreating.ToArray());
                
                return host;
        }
    }
}