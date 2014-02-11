using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content/Images");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }
        

        public IEnumerable<string> GetImageNames()
        {
            var sortedFiles = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles().OrderBy(f => f.Name).ToList();

            return sortedFiles;
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
            if (image.RawFormat.Guid == System.Drawing.Imaging.Gif.Guid
                || image.RawFormat.Guid == System.Drawing.Imaging.Jpeg.Guid 
                || image.RawFormat.Guid == System.Drawing.Imaging.Png.Guid)
            {
                return true;
            }

            else
            {
                return false; 
            }
        }

        public string SaveImage(Stream stream, string fileName)
        { }
    }
}