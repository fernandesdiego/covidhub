using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HNEWS.Models;
using HNEWS.Data;
using Microsoft.Extensions.Configuration;

namespace HNEWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleRepository _articleRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _articleRepository = new ArticleRepository();
        }
        // q=covid&lang=pt&media=True
        public async Task<IActionResult> Index()
        {            
            var article = await _articleRepository.GetArticleAsync();
            return View(article);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
}
}        
 