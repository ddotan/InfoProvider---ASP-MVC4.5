using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoProvider.Center.BussinessLogic
{
    public class CertificateRepository
    {
        public readonly string r_CertificatePath = ConfigurationManager.AppSettings["CertificateManager.Location"];
        private readonly string r_CertificateFilePrefix = @"Install--";
        private string[] certFolderPaths = ConfigurationManager.AppSettings["CertificateManager.SearchDirectoryNames"].Split(',');

        private static Dictionary<string, string> m_CeritificateDictionary = new Dictionary<string, string>();
        public string GetCertificatePath(string i_CertificateName)
        {

            return m_CeritificateDictionary[i_CertificateName];
        }
        public void UpdateRepository()
        {

            List<List<string>> listOfCertificatePaths = new List<List<string>>();
            var allCertificatePaths = Directory.GetFiles(r_CertificatePath, "*.exe", SearchOption.AllDirectories).ToList().FindAll(x => isValidCertificatePath(x));
            string[] parts;
            string filename = string.Empty;
            Dictionary<string, string> tempCertificate = new Dictionary<string, string>(); 
            foreach (string file in allCertificatePaths)
            {
                try
                {
                    parts = file.Split('\\');
                    filename = parts[parts.Length - 1];
                    tempCertificate.Add(Path.GetFileNameWithoutExtension(filename).Replace(r_CertificateFilePrefix, ""), file);
                }
                catch (Exception ex)
                {
                }
            }
            m_CeritificateDictionary = tempCertificate;
        }
        private bool isValidCertificatePath(string i_FilePath)
        {
            bool valid = false;
            foreach (string path in certFolderPaths)
            {
                if (i_FilePath.Contains(path) && i_FilePath.Contains("Trusted"))
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}
