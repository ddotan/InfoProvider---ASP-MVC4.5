using System;
using System.Collections.Generic;
using InfoProvider.Webs.Models;
using InfoProvider.Webs.ServiceReference1;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace InfoProvider.Webs.Controllers
{
    public class CertificatesController : Controller
    {
        //
        // GET: /Certificates/
        private static IInfoProviderCenter center = new InfoProviderCenterClient();

        public ActionResult Download(string Name)
        {
            byte[] filedata = { };
            string contentType = string.Empty;
            try
            {
                string fullFilePath = center.GetCertificatePath(Name);
                string filename = Path.GetFileName(fullFilePath);
                string filepath = fullFilePath;
                filedata = System.IO.File.ReadAllBytes(filepath);
                contentType = MimeMapping.GetMimeMapping(filepath);

                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
            }
            catch (Exception ex)
            {
                Logger.LogManager.Instance.WriteError("Error while trying to download certificate: " + ex.Message);
            }
            return File(filedata, contentType);
        }

    }
}
