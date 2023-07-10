using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrapingPractice.Data;

namespace ScrapingPractice.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<NewsItem> Scrape(string searchTerm)
        {
            return Scraper.Scrape();
        }
    }
}
