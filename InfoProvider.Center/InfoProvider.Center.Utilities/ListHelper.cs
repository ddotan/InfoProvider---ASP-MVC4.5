using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Center.Utilites
{
    public static class ListHelper<T>
    {
        public static List<T> CombineTwoLists(List<List<T>> i_Lists)
        {
            List<T> outputList = new List<T>();
           foreach (List<T> list in i_Lists)
           {
               for (int i = 0; i < list.Count; i++)
               {
                   outputList.Add(list[i]);
               }
           }
           return outputList;
        }
    }
}
