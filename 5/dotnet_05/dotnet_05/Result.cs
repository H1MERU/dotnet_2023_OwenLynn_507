using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotnet_05
{
    public class Result
    {
       /* public List<string> names;
        public List<string> authors;
        public List<string> html;
        public List<string> eupb;
        public List<string> pdf;
        public List<string> txt;*/

        public Dictionary<string, List<string>> DataArrays;

        private static Result instance;

        private Result()
        {
            DataArrays = new Dictionary<string, List<string>>();
            DataArrays["names"] = new List<string>();
            DataArrays["authors"] = new List<string>();
            DataArrays["html"] = new List<string>();
            DataArrays["eupb"] = new List<string>();
            DataArrays["pdf"] = new List<string>();
            DataArrays["txt"] = new List<string>();
        }

        public  void Reset()
        {
            DataArrays = new Dictionary<string, List<string>>();
            DataArrays["names"] = new List<string>();
            DataArrays["authors"] = new List<string>();
            DataArrays["html"] = new List<string>();
            DataArrays["eupb"] = new List<string>();
            DataArrays["pdf"] = new List<string>();
            DataArrays["txt"] = new List<string>();
        }

        public static Result Instance()
        {
            if (instance == null)
            {
                instance = new Result();
            }

            return instance;
        }

        public void AddListEle(string lName, string value)
        {
            DataArrays[lName].Add(value);
        }

        public List<string> GetListByName(string lName)
        {
            return DataArrays[lName];
        }

        public string GetEleByNameIndex(string name, int index)
        {
            return DataArrays[name][index];
        }


    }
}
