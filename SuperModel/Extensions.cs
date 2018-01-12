using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperModel
{

    public static class Extensions
    {
        public static string[] ToLower(this string[] str)
        {
            var str2 = new List<string>();
            foreach (var s in str)
            {
                str2.Add(s.ToLower());
            }
            return str2.ToArray();
        }


    }
}
