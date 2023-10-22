using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_05
{
    class UrlOptionImpl : UrlOptions
    {
        public UrlOptionImpl(Uri uri) : base(uri)
        {
            ObjName = "uri";
        }


        public override void AddUrls(Uri uri)
        {
            if (uri.Host != Uris[0].Host)
                return;
            if (Uris.IndexOf(uri) == -1 && Saves.IndexOf(uri) == -1 && Tmp.IndexOf(uri) == -1)
                Tmp.Add(uri);
        }
    }
}
