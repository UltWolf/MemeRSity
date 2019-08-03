using System.Collections.Generic;
using System.Linq;
using MemeRSity.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MemeRSity.Services.Extensions
{
    public  static class DbSetExtensions
    {
        public static void AddOrUpdate (this DbSet<Tag> set, params Tag[] type)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var t in type)
            {
                tags.Add(set.FirstOrDefault(m => m.Name == t.Name));
            }

            foreach (var typ in type )
            {
                
                 type.ToList().RemoveMatches(tags, (tag, tag1) => tag==tag1 );
            }
            

        }
    }
}