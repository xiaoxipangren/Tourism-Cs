using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Spider
{
    public class Spider
    {
        public Downloador Downloador { get; set; }

        public string RootUrl { get; set; }

        public Spider()
        {
            Downloador = new Downloador();
        }

        public void Crawl(string url)
        {
            //Downloador.DownloadAsync(
            //    url,
            //    str =>
            //    {
            //        using (StreamWriter writer = new StreamWriter("data.txt"))
            //        {
            //            writer.Write(str);

            //        }

            //    });
            string str = Downloador.Download(url);
            Console.WriteLine(str);
            Console.ReadKey();
        }


        public void CrawlScenics()
        {
            HtmlDocument doc = LoadHtmlFromUrl("http://www.mafengwo.cn/ajax/router.php");

            

        }

        private HtmlDocument LoadHtmlFromUrl(string url)
        {
            return LoadHtmlFromUrl(url, Encoding.UTF8);
        }
        private HtmlDocument LoadHtmlFromUrl(string url, Encoding encoding)
        {
            string htmlStr = Downloador.Post(url);
            if (string.IsNullOrEmpty(htmlStr))
            {
                return null;
            }
            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(htmlStr);
            return htmlDoc;
        }





    }
}
