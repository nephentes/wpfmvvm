using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTabExample.ViewModel
{

    public class TabViewModel
    {
        static Random rnd = new Random();

        public string Name { get; set; }

        public List<string> Values { get; set; }

        public TabViewModel()
        {
            Values = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Values.Add(string.Format("Item {0}", rnd.Next()));
            }
        }

        public TabViewModel(string name) : this()
        {
            Name = name;
        }

    }



}
