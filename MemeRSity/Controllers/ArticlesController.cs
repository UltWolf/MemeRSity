using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemeRSity.Data;
using MemeRSity.Models;
using MemeRSity.ViewModel;
using System.IO;
using Microsoft.Extensions.Hosting;
using MemeRSity.Services;

namespace MemeRSity.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ArticlesRepository _repository;

        public ArticlesController(ArticlesRepository repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        // GET: Articles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _repository.GetArticle((int)id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ArticlesCreate article)
        {
            if (ModelState.IsValid)
            {

                await CreateAtDb(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        private async Task CreateAtDb(ArticlesCreate article)
        {
            if (HttpContext.User.IsInRole("Admin"))
            {
                article.isPublish = true;
            }
            await _repository.AddAsync(article);
            
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _repository.GetArticle((int)id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Title,Img")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateArticle(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _repository.GetArticle((int)id);
            if (article == null)
            {
                return NotFound();
            }
            

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _repository.GetArticle((int)id);
            _repository.DeleteArticle(article);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
