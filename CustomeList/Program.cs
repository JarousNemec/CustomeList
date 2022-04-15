using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomeList<string> list = new CustomeList<string>();
            int cap = list.Capacity;
            int count = list.Count;
            list.Add("a");
            list.Insert(0,"b");
            int indexOfA = list.IndexOf("a");
            string s = list.ToString();
            list.Clear();
        }
    }
}