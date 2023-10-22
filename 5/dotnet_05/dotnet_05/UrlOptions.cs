using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_05
{
    public abstract class UrlOptions
    {
        /// <summary>
        /// 返回对象所属类的名称
        /// </summary>
        public string ObjName { get; protected set; }
        
        /// <summary>
        /// 网页链接的列表
        /// </summary>
        public List<Uri> Uris { get; private set; }
        
        /// <summary>
        /// 存储所有找到的网页链接
        /// </summary>
        public List<Uri> Saves { get; private set; }
        
        /// <summary>
        /// 存储本次深度优先搜索查找到的超链接
        /// </summary>
        public List<Uri> Tmp { get; private set; }
        
        /// <summary>
        /// uris的指针,最初为-1表示没有任何元素
        /// </summary>
        protected int Cursor { get; set; }

        public UrlOptions(Uri uri) 
        {
            Uris = new List<Uri>();
            Saves = new List<Uri>();
            Tmp = new List<Uri>();
            Cursor = -1;
            Uris.Add(uri);
        }

        public UrlOptions(Uri[] uriArr)
        {
            Uris = new List<Uri>(uriArr);
            Cursor = -1;
        }

        /// <summary>
        /// 获取当前的uri
        /// </summary>
        /// <returns></returns>
        public Uri ThisUri()
        {
            return Uris[Cursor];
        }

        /// <summary>
        /// 移动指针并获取下一个uri
        /// </summary>
        /// <returns></returns>
        public Uri NextUri()
        {
            if (Cursor + 1 < Uris.Count)
                return Uris[++Cursor];
            else
                return null;
        }

        /// <summary>
        /// 保存uri
        /// </summary>
        public void Save()
        {
            Saves.AddRange(Uris);
            Uris = Tmp;
            Tmp = new List<Uri>();
        }

        /// <summary>
        /// 判断某一层是否结束
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            if (Cursor >= Uris.Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取当前uri对应的主机名称
        /// </summary>
        /// <returns></returns>
        public string GetHost()
        {
            return Uris[Cursor].Host;
        }

        public int GetUrisLength()
        {
            return Uris.Count;
        }

        /// <summary>
        /// 添加一些链接,由子类实现
        /// </summary>
        public abstract void AddUrls(Uri uri);
    }
}
