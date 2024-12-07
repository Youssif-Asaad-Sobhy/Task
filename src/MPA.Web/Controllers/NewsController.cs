using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPA.DTOs;
using MPA.Services;

namespace MPA.Web.Controllers
{
    public class NewsController : MPAControllerBase
    {
        private readonly NewsService _newsService;
        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }
         [HttpGet]
        public async Task<IActionResult> Index(int? year, int? month)
        {
            var archiveData = await _newsService.GetArchiveDataAsync();
            var newsItems = year.HasValue && month.HasValue
                ? await _newsService.GetNewsByMonthAsync(year.Value, month.Value)
                : await _newsService.GetAllNewsAsync();

            var model = new NewsListDTO
            {
                ArchiveData = archiveData,
                NewsItems = newsItems
            };

            return View(model);
        }
    }
}
