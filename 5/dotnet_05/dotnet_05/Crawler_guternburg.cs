using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace dotnet_05
{
    internal class Crawler_guternburg : CrawlerCore
    {
        public Crawler_guternburg(string keyword)
        {
            Link = "https://www.gutenberg.org";
            SearchLink = Link + "/ebooks/search/?query=" + keyword;
            init();
        }

        public override void PageProcesser(Documents doc)
        {
            try
            {
                string[] hrefs = doc.GetUrls();
                string pattern = @"ebooks/\d+";

                // 使用 Parallel.ForEach 并行处理每本书搜索结果
                Parallel.ForEach(hrefs, item =>
                {
                    if (Regex.IsMatch(item, pattern))
                    {
                        string link = "https://www.gutenberg.org" + item;
                        Documents d;
                        Uri u = new Uri(link);
                        if (u == null)
                            return;
                        d = new Documents(u);

                        string title = GetTitle(d);
                        string author = GetAuthor(d);

                        lock (Result.Instance())
                        {
                            Result.Instance().AddListEle("names", title);
                            Result.Instance().AddListEle("authors", author);
                            Parallel.ForEach(Filter.Instance().types, type =>
                            {
                                Result.Instance().AddListEle(type, GetFileLink(type, d));
                            });
                        }
                    }
                });
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
        }

        public string GetTitle(Documents doc)
        {
            return doc.GetTextWithKeyValue("td", "itemprop", "headline")[0];
        }

        public string GetAuthor(Documents doc)
        {
            return doc.GetTextWithKeyValue("a", "itemprop", "creator")[0];
        }



        public string GetFileLink(string type, Documents doc)
        {
           
            string res = "";
            if(type == "html")
            {
                res = doc.GetElementWithKeyValue("a", "href", "type", "text/html", Link)[0];
            }
            if(type == "eupb")
            {
                res = doc.GetElementWithKeyValue("a", "href", "type", "application/epub+zip", Link)[0];
            }
            if(type == "pdf")
            {
                res = doc.GetElementWithKeyValue("a", "href", "type", "application/pdf", Link)[0];
            }
            if(type == "txt")
            {
                res = doc.GetElementWithKeyValue("a", "href", "type", "text/plain", Link)[0];
            }
            return res;
        }
        
    }
}
