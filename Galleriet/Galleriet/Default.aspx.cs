using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Galleriet.Model;

namespace Galleriet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            var queryString = Request.QueryString;

            if (queryString != null)
            {
                ImageHolder.Visible = true;   
            }
            ImageHolder.ImageUrl = "Content/Images/" + queryString;
             
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (FileUpload.HasFile)
                {
                    Gallery gallery = new Gallery();
                    gallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);

                    ImageHolder.ImageUrl = "Content/Images/" + FileUpload.FileName;
                    UploadSuccess.Visible = true;
                }
            }

        }

        public IEnumerable<System.String> Repeater1_GetData()
        {
            Gallery gallery = new Gallery();
            return gallery.GetImageNames();
        }
    }
}