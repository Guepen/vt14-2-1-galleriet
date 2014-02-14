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
        private static string PhysicalUploadedThubnailImagesPath;
        private static readonly Regex SantizePath;

        static Gallery()
        {
            ApprovedExtensions = new Regex("^.*.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content/Images");
            PhysicalUploadedThubnailImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content/Images/Thumbnails");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }
        

        public IEnumerable<string> GetImageNames()
        {
            var files = new DirectoryInfo(PhysicalUploadedThubnailImagesPath).GetFiles();
            List<string> imagesList = new List<string>(files.Length);

            foreach (var file in files)
            {
                if (ApprovedExtensions.IsMatch(file.Extension))
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
            var image = System.Drawing.Image.FromStream(stream);
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);

            if (!ApprovedExtensions.IsMatch(fileName))
            {
                throw new ArgumentException();
            }


            if (ImageExists(fileName))
            {
                var fileNameNoExtension = Path.GetFileNameWithoutExtension(fileName);
                var fileNameExtension = Path.GetExtension(fileName);
                int count = 1;

                while (ImageExists(fileName))
                {
                    fileName = String.Format("{0}{1}{2}", fileNameNoExtension, count, fileNameExtension );
                    count++;
                }
                
            }

            if (IsValidImage(image))
            {
                image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));
            }

            thumbnail.Save(Path.Combine(PhysicalUploadedThubnailImagesPath, fileName));

            return fileName;
        }
    }
}