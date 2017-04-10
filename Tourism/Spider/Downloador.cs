using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tourism.Spider
{
    public class Downloador
    {
        public string Download(string url)
        {
            return Download(url, Encoding.UTF8);
        }

        public string Download(string url, Encoding encoding)
        {
            try
            {
                byte[] byteArray = DownloadData(url);
                return encoding.GetString(byteArray);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string Post(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            request.KeepAlive = true;

            WebHeaderCollection headers = new WebHeaderCollection();
            Dictionary<string,string> dic = new Dictionary<string, string>() {
                {"Cache-Control","no-cache"},
                {"Accept-Lanaguage","zh-CN,zh;q=0.8,en;q=0.6,en-US;q=0.4" },
                {"Pragma","no-cache" }
    };
            dic.ToList().ForEach(pair => headers.Add(pair.Key, pair.Value));
            request.Headers = headers;
            


            

            dic = new Dictionary<string, string> {
                {"sAct","KMdd_StructWebAjax|GetPoisByTag"},
                {"iMddid","10133"},
                {"iTagId","0" },
                {"iPage","1" }
            };
            StringBuilder sb = new StringBuilder();
            dic.ToList().ForEach(pair => sb.Append($"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}&"));
            sb.Remove(sb.Length - 1, 1);

            StreamWriter writer =new StreamWriter(request.GetRequestStream(),Encoding.ASCII);
            writer.Write(sb.ToString());


            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.UTF8);
            string result = reader.ReadToEnd();
            byte[] byteArray = Encoding.UTF8.GetBytes(result);

            return result;
        }

        public string Download(string url, Encoding srcEncoding,Encoding destEncoding)
        {
            try
            {
                byte[] byteArray = DownloadData(url);
                byteArray = Encoding.Convert(srcEncoding, destEncoding, byteArray);
                return destEncoding.GetString(byteArray);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] DownloadData(string url)
        {
            return new WebClient().DownloadData(url);
        }


        public void DownloadAsync(string url,Action<string>callback, string srcEncoding=null, string destEncoding="utf8")
        {

            WebClient client = new WebClient();
            client.DownloadDataCompleted += (o, e) =>
            {
                Console.WriteLine("test");
                byte[] byteArray = e.Result;
                string str="";
                Encoding src = srcEncoding == null ? null : Encoding.GetEncoding(srcEncoding);
                Encoding dest = destEncoding == null ? null : Encoding.GetEncoding(destEncoding);
                if (src != null && dest != null)
                {
                    byteArray = Encoding.Convert(Encoding.GetEncoding(srcEncoding), Encoding.GetEncoding(destEncoding), byteArray);
                    str = dest.GetString(byteArray);
                }
                else if(src==null)
                {
                    str = dest.GetString(byteArray);
                }
                else
                {
                    str = Encoding.UTF8.GetString(byteArray);
                }
                callback(str);
            };

            client.DownloadDataAsync(new Uri(url));


        }




        public void DownloadFile(string url, string file)
        {
            WebClient wc = new WebClient();
            WebRequest request = WebRequest.Create(url);


            string path = Path.GetDirectoryName(file);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            wc.DownloadFile(url, file);
        }
    }
}
