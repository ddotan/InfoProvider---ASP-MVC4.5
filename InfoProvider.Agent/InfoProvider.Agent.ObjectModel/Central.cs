using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Agent.ObjectModel
{
    public static class Central
    {
        //public static eCentral GetCentralByPath(string i_Path)
        //{
        //    //fix bridge
        //    string[] paths = i_Path.Split('\\');
        //    eCentral central=eCentral.ES;

        //    if(paths.Length >0)
        //    {

        //        string end = paths[paths.Length - 2].ToLower();
        //        if (end.Contains("lfs"))
        //        {
        //            central = eCentral.LFS;

        //        }
        //        else if (end.Contains("saxo"))
        //        {
        //            central = eCentral.SAXO;

        //        }
        //        else
        //        {
        //            central = eCentral.ES;
        //        }


        //    }
        //    return central;

        //}
        public static eCentral Parse(string i_Port)
        {
            int port = int.Parse(i_Port);
            eCentral central = eCentral.ES1;
            if (port == 55609)
            {
                central = eCentral.ES1;
            }
            else if (port == 55605)
            {
                central = eCentral.ES2;
            }
            else
            {
                central = eCentral.ES3;
            }
            return central;
        }

    }
}
