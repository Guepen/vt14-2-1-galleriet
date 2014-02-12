using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galleriet.Model
{
    public class Gallery
    {
        private static readonly Regex ApprovedExtensions;
        private static string PhysicalUploadedImagesPath;
        private static readonly Regex SantizePath;

        static Gallery()
        {
            ApprovedExtensions = new Regex("^.*.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "~/Content/Images");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }
        

        public IEnumerable<string> GetImageNames()
        {
            var files = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();
            List<string> imagesList = new List<string>(files.Length);

            foreach (var file in files)
            {
                if (file.Extension.Contains(ApprovedExtensions.ToString()))
                {
                    imagesList.Add(file.ToString());
                }
            }

            imagesList.Sort();

            return imagesList.AsEnumerable();
        
        }

        public bool ImageExists(string name)
        {
            if (GetImageNames().Contains(name))
            {
                return true;
            }

            else
            {
                return false;
            }
		
        }

        private bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid
                || image.RawFormat.Guid == ImageFormat.Jpeg.Guid 
                || image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }

            else
            {
                return false; 
            }
        }

        public string SaveImage(Stream stream, string fileName)
        {
            /*if (!IsValidImage(fileName))
            {
                throw new ArgumentException();
            }*/

            if (ImageExists(fileName))
            {
                
            }

            return fileName;
        }
    }
}