using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace HttpModuleHandlerPrac
{
    /*Code for watermark is taken from following link
     * http://www.donnfelker.com/watermarking-images-in-asp-net-with-an-httphandler/
    */ 


    public class ImageHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //Clear current response
            context.Response.Clear();
            //Decide content type based on extension
            context.Response.ContentType = GetContentType(context.Request.PhysicalPath);

            //Load Image, write watermark on it and return bytes
            byte[] imageBytes = WatermarkImage(context);

            //if everything is fine and bytes are returned
            if (imageBytes != null)
            {
                //write bytes to response stream
                context.Response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
            }
            else
            {
                // No bytes = no image which equals NO FILE.
                // Therefore send a 404 - not found response. 
                context.Response.StatusCode = 404;
            }
            context.Response.End();
        }

        #endregion

        public string GetContentType(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp":
                    return "Image/bmp";
                case ".gif":
                    return "Image/gif";
                case ".jpg":
                    return "Image/jpeg";
                case ".png":
                    return "Image/png";
                default:
                    break;
            }
            return String.Empty;
        }

        public ImageFormat GetImageFormat(String path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                default:
                    return null;
            }
        }

        protected byte[] WatermarkImage(HttpContext context)
        {

            byte[] imageBytes = null;
            if (File.Exists(context.Request.PhysicalPath))
            {
                
                string watermark = "Bilal Shahzad GIThub Watermark";

                //Read image from physical path
                Image image = Image.FromFile(context.Request.PhysicalPath);

                Graphics graphic;
                if (image.PixelFormat != PixelFormat.Indexed &&
                            image.PixelFormat != PixelFormat.Format8bppIndexed &&
                            image.PixelFormat != PixelFormat.Format4bppIndexed &&
                            image.PixelFormat != PixelFormat.Format1bppIndexed)
                {
                    // Graphic is not a Indexed (GIF) image
                    graphic = Graphics.FromImage(image);
                }
                else
                {
                    /* Cannot create a graphics object from an indexed (GIF) image. 
                     * So we're going to copy the image into a new bitmap so 
                     * we can work with it. */
                    Bitmap indexedImage = new Bitmap(image);
                    graphic = Graphics.FromImage(indexedImage);

                    // Draw the contents of the original bitmap onto the new bitmap. 
                    graphic.DrawImage(image, 0, 0, image.Width, image.Height);
                    image = indexedImage;
                }
                graphic.SmoothingMode = SmoothingMode.AntiAlias & SmoothingMode.HighQuality;

                Font myFont = new Font("Arial", 20);
                SolidBrush brush = new SolidBrush(Color.FromArgb(80, Color.Red));

                /* This gets the size of the graphic so we can determine 
                 * the loop counts and placement of the watermarked text. */
                SizeF textSize = graphic.MeasureString(watermark, myFont);

                // Write the text across the image. 
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        PointF pointF = new PointF(x, y);
                        graphic.DrawString(watermark, myFont, brush, pointF);
                        x += Convert.ToInt32(textSize.Width);
                    }
                    y += Convert.ToInt32(textSize.Height);
                }


                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, GetImageFormat(context.Request.PhysicalPath));
                    imageBytes = memoryStream.ToArray();
                }

            }
            return imageBytes;
        }
    }
}
