using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.Utilities

{
    public static class ArrayHelper
    {
        public static string ArrayToString(string[] i_StrList)
        {
            string output = string.Empty;
            foreach (string str in i_StrList)
            {
                output += str;
                output += " ";
            }
            return output;
        }
    }
}
