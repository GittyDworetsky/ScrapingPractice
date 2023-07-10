using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingPractice.Data
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Comments { get; set; }
    }
}
