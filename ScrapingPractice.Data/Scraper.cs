using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingPractice.Data
{
    public static class Scraper
    {
        public static List<NewsItem> Scrape()
        {
            var html = GetNewsItemHtml();
            return ParseHtml(html);
        }

        private static string GetNewsItemHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "foobar");

            var url = "https://thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }

        private static List<NewsItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var divs = document.QuerySelectorAll(".td-module-container.td-category-pos-image");
            var items = new List<NewsItem>();

            foreach (var div in divs)
            {
                NewsItem item = new();
                items.Add(item);

                var titleElement = div.QuerySelector(".entry-title.td-module-title");
                if (titleElement != null)
                {
                    item.Title = titleElement.TextContent;
                }

                var image = div.QuerySelector(".entry-thumb.td-thumb-css.td-animation-stack-type0-2");
                if (image != null)
                {
                    item.Image = image.Attributes["data-img-url"].Value;
                }
     
                var aTag = div.QuerySelector("a.td-image-wrap");
                if (aTag != null)
                {
                    item.Url = aTag.Attributes["href"].Value;
                }

                var content = div.QuerySelector(".td-excerpt");
                if (content != null)
                {
                    item.Content = content.TextContent;
                }

                var comments = div.QuerySelector(".td-module-comments");
                if (comments != null)
                {
                    var commentLink = comments.QuerySelector("a");
                    if (commentLink != null)
                    {
                        item.Comments = commentLink.TextContent;
                    }
                }
            }

            return items;
        }
    }
}


