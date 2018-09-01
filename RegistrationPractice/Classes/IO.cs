using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using RegistrationPractice.Classes.Globals;


namespace RegistrationPractice.Classes
{
    public class IO_Operations
    {
        private constants constants;
        string servername;
        public IO_Operations()
        {
            constants = new constants();
            string servername = constants.servername;
        }




        public bool SaveFile()
        {
            return false;
        }

        public string SaveImage(HttpPostedFileBase files, out string imageUrl)
        {
            string result = String.Empty;

            string time = DateTime.UtcNow.ToString();
            time = time.Replace(" ", "-");
            time = time.Replace(":", "-");
            time = time.Replace("/", "-");
            try
            {
                string[] extensions = new string[] { ".jpg", ".png" };
                var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                var checkextension = Path.GetExtension(files.FileName).ToLower();
                var filesize = (files.ContentLength / 1048576);
                if (filesize > 5)
                {
                    throw new Exception("File cannot be saved. Max file extension is 5MB");
                }
                if (!extensions.Contains(checkextension))
                {
                    throw new Exception("File cannot be saved. Invalid extension.");
                }
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/photos"), filename);
                Loggers.Logger.Write("path");
                imageUrl = servername + "/photos/" + filename;
                files.SaveAs(path);

                return result;

            }
            catch (Exception e)
            {
                imageUrl = null;
                return e.Message;
            }

        }

        public bool DeleteImage(string imageurl)
        {
            try
            {
                string imagename = imageurl.Substring(imageurl.IndexOf("photos/") + 7);
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/photos"), imagename);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                Loggers.Logger.Write(e.ToString());
                return false;
            }
        }
    }
}