using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPA.DTOs;
using MPA.Services;

namespace MPA.Web.Controllers
{
    public class AdminController : MPAControllerBase
    {
        private readonly NewsService _newsService;
        public AdminController(NewsService newsService) {
            _newsService = newsService;
        }
        
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNews(CreateNewsDTO dto)
        {
            if (!ModelState.IsValid) { 
                return View(dto);
            }
            try
            {
                _newsService.CreateNewsAsync(dto).Wait();
                return RedirectToAction(nameof(CreateNews));
            }
            catch
            {
                return View();
            }
        }
    }
}
