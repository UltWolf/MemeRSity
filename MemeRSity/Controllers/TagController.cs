using System.Linq;
using MemeRSity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemeRSity.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public TagController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        
        [HttpGet("Tag/{name}")]
        public IActionResult GetArticles(string name)
        {
            var tag = this._applicationContext.Tags.FirstOrDefaultAsync(m => m.Name == name);
            var articles = this._applicationContext.ArticleTags.Where(at => at.TagId == tag.Id)
                .Include(at => at.Article);
            return new JsonResult(articles);
        }
    }
}