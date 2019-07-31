using System.Threading.Tasks;
using MemeRSity.Data;
using MemeRSity.Models;
using MemeRSity.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MemeRSity.Controllers
{
    public class AuthController : Controller
    {
        // GET
       private readonly  UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly ApplicationContext _applicationContext;
        private IConfiguration _config;
        public AuthController( ApplicationContext applicationContext,UserManager<UserApp> userManager, SignInManager<UserApp> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            _applicationContext = applicationContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserApp user = new UserApp() {  Email = model.Email, UserName = model.Username, Country = model.Country};
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                { 

                    await _signInManager.SignInAsync(user, false); 
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}/";
                   
                    return Redirect(baseUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { });
        }

        [HttpPost] 
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}/";
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
                if (result.Succeeded)
                { 
                     
                        return Redirect(baseUrl);
                  
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
        
      
        

        [HttpGet("LogOff")] 
        public async Task<IActionResult> LogOff()
        { 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
}
    } 