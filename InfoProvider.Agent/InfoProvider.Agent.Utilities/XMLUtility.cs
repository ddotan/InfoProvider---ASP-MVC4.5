using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InfoProvider.Agent.Utilities

{
    public static class XmlUtility
    {
        public static T Serilize<T>(string i_XmlPath)
        {
            T loadedThis = default(T);
            try
            {
                using (FileStream stream = new FileStream(i_XmlPath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    loadedThis = (T)serializer.Deserialize(stream);
                }
                return loadedThis;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return loadedThis;
        }
    }
}
