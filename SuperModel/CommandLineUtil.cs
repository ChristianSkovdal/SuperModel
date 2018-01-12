using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperModel
{
    public class CommandLineUtil
    {
        public static bool HasFlag(string[] args, string id)
        {
            var parms = args.Where(a => (a.StartsWith("-") || a.StartsWith("/")));
            foreach (var p in parms)
            {
                var flag = p.ToUpper();
                if (flag.Length == 2 && flag[1].ToString() == id.ToUpper())
                    return true;
            }

            return false;
        }
        public static bool ParseArg(string[] args, string id, out string res)
        {
            res = string.Empty;

            var parms = args.Where(a => (a.StartsWith("-") || a.StartsWith("/")) && a.Contains(":"));
            foreach (var p in parms)
            {
                int colon = p.IndexOf(":");
                string argName = p.Substring(1, colon - 1).ToLower();
                if (id.ToLower() == argName.ToLower())
                {
                    colon++;
                    res = p.Substring(colon, p.Length - colon);
                    return true;
                }
            }

            return false;
        }

        public static bool ParseArg(string[] args, string id, out string[] res)
        {
            res = null;
            string list;
            if (!ParseArg(args, id, out list))
                return false;
            res = list.Split(',', ';');
            return true;
        }
    }
}
