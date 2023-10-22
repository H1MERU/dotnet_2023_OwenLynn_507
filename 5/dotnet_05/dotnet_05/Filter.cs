using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_05
{
    public class Filter
    {
        public List<string> types;

        private static Filter instance;

        private Filter()
        {
            types = new List<string>();
        }

        public static Filter Instance()
        {
            if (instance == null)
            {
                instance = new Filter();
            }

            return instance;
        }

        public void Refresh(CheckedListBox cb)
        {
            types.Clear();
            foreach (object item in cb.CheckedItems)
            {
                types.Add(item.ToString());
            }
        }
    }
}
