using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dotnet_05
{
    public class Documents
    {
        /// <summary>
        /// 获取网页的uri
        /// </summary>
        public Uri uri { get; }

        /// <summary>
        /// 网页文档
        /// </summary>
        private HtmlAgilityPack.HtmlDocument Doc { get; }

        /// <summary>
        /// 创建对象并下载uri对应的网页
        /// </summary>
        /// <param name="uri"></param>
        public Documents(Uri uri)
        {
            this.uri = uri;
            Doc = new HtmlAgilityPack.HtmlDocument();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            Stream strean = request.GetResponse().GetResponseStream();
            Doc = new HtmlAgilityPack.HtmlDocument();
            Doc.Load(strean);
        }

        public Documents(Uri uri, string ua)
        {
            this.uri = uri;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Get";
            request.UserAgent = ua;
            request.Timeout = 5000;
            request.Accept = "Accept:text/html, application/xhtml+xml, */*";
            Stream strean = request.GetResponse().GetResponseStream();
            Doc = new HtmlAgilityPack.HtmlDocument();
            Doc.Load(strean);
            strean.Dispose();
        }
        /// <summary>
        /// 获取网页文件的,以字符串的形式存放网页的HTML和JavaScript等代码
        /// </summary>
        /// <returns></returns>
        public string GetHtmlDoc()
        {
            return Doc.Text;
        }
        /// <summary>
        /// 根据xpath匹配网页中的标签
        /// </summary>
        /// <param name="xpath">请输入一个有效的xpath值</param>
        /// <returns>可以像字典一样使用HtmlNodeCollection</returns>
        public HtmlNodeCollection GetXPath(string xpath)
        {
            return Doc.DocumentNode.SelectNodes(xpath);
        }
        /// <summary>
        /// 获取网页中所有的超链接地址,返回超链接的字符串
        /// </summary>
        /// <returns>可以像字典一样使用HtmlNodeCollection</returns>
        public string[] GetUrls()
        {
            HtmlNodeCollection res = Doc.DocumentNode.SelectNodes("//a");
            List<string> results;
            if (res != null)
            {
                results = new List<string>();
                foreach (HtmlNode n in res)
                {
                    string result = n.GetAttributeValue("href", null);
                    
                    if (result != null)
                        results.Add(result);
                }
                return results.ToArray();
            }
            return null;
        }

        /// <summary>
        /// 获取网页中所有的元素,返回符合key:value的内容。
        /// </summary>
        public string[] GetElementWithKeyValue(string element, string attr, string key, string value, string baseAddr)
        {
            HtmlNodeCollection res = Doc.DocumentNode.SelectNodes("//" + element);
            List<string> results;
            if (res != null)
            {
                results = new List<string>();
                foreach (HtmlNode n in res)
                {
                    string result = "";
                    if (n.GetAttributeValue(key, "").Contains(value))
                        result = n.GetAttributeValue(attr, null);
                    if (result != "")
                    {
                        results.Add(baseAddr != null ? UrlFormat(baseAddr, result) : result);
                    }
                }
                results.Add("");
                return results.ToArray();
            }
            return new string[] { "" };
        }


        public string[] GetTextWithKeyValue(string element, string key, string value)
        {
            HtmlNodeCollection res = Doc.DocumentNode.SelectNodes("//" + element);
            List<string> results;
            if (res != null)
            {
                results = new List<string>();
                foreach (HtmlNode n in res)
                {
                    string result = "";
                    if (n.GetAttributeValue(key, "").Contains(value))
                        result = n.InnerText;
                    if (result != "")
                    {
                        results.Add(result);
                    }
                }
                results.Add("");
                return results.ToArray();
            }
            return new string[] { "" };
        }

        /// <summary>
        /// 将图片保存到磁盘
        /// </summary>
        /// <param name="filename">图片的文件名称</param>
        /// <param name="img">Image对象</param>
        public static void SaveImage(string filename, Image img)
        {
            FileStream sw = new FileStream(filename, FileMode.OpenOrCreate);
            byte[] dat = (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
            sw.Write(dat, 0, dat.Length);
            sw.Close();
        }

        /// <summary>
        /// 从指定url下载图片,循环下载，直到成功为止，每次重试前都会暂停0.1秒
        /// </summary>
        /// <param name="url"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Image GetImage(Uri uri, out int num)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            byte[] pageData = null;
            num = 0;
            while (pageData == null)
            {
                try
                {
                    pageData = wc.DownloadData(uri);
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    num++;
                }
            }
            return Image.FromStream(new MemoryStream(pageData));
        }
        /// <summary>
        /// 从指定url下载图片,返回图片的Image对象,下载失败返回null
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Image GetImage(Uri uri)
        {
            HttpWebRequest hwq = (HttpWebRequest)WebRequest.Create(uri);
            hwq.Method = "Get";
            hwq.UserAgent = CrawlerCore.WindowsUA;
            hwq.Accept = "Accept:text/html, application/xhtml+xml, */*";
            return Image.FromStream(hwq.GetResponse().GetResponseStream());
        }
        /// <summary>
        /// 获取uri对应的的主机名称
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHost(Uri uri)
        {
            if (uri != null)
                return uri.Host;
            else return null;
        }
        /// <summary>
        /// 将流格式转化为字符串
        /// </summary>
        /// <param name="s">输入一个流对象</param>
        /// <returns>返回的字符串</returns>
        public static string StreamToString(Stream s)
        {
            char[] datc = new char[s.Length];
            byte[] datb = new byte[s.Length];
            s.Read(datb, 0, Convert.ToInt32(s.Length));
            for (int i = 0; i < s.Length; i++)
                datc[i] = (char)datb[i];
            return new string(datc);
        }
        /// <summary>
        /// Web页面是否已经记录在字典中
        /// </summary>
        /// <param name="url">指定的页面</param>
        /// <param name="src">字典</param>
        /// <returns></returns>
        public static bool IsExist(string url, Dictionary<string, Documents> src)
        {
            bool result = false;
            foreach (KeyValuePair<string, Documents> pair in src)
            {
                if (pair.Key == url)
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// 将地址进行格式化
        /// </summary>
        /// <param name="baseAddr">基地址</param>
        /// <param name="href">相对地址</param>
        /// <returns></returns>
        public static string UrlFormat(string baseAddr, string href)
        {
            return baseAddr + href;
        }

        /// <summary>
        /// 将地址进行格式化,即将href的内容补全
        /// </summary>
        /// <param name="baseAddr">基地址</param>
        /// <param name="href">相对地址</param>
        /// <returns></returns>
        public static Uri UrlFormat(Uri baseAddr, string href)
        {
            return new Uri(baseAddr, href);
        }
    }
}
