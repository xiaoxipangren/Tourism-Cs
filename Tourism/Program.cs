using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Spider;


namespace Tourism
{
    class Program
    {
        static void Main(string[] args)
        {
            Tourism.Spider.Spider spider = new Tourism.Spider.Spider();
            spider.CrawlScenics();
        }
    }
}
