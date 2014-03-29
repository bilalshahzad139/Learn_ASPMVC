using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace HttpModuleHandlerPrac
{

    /*------------For more detail, check this link
     * http://msdn.microsoft.com/en-us/library/ms972953.aspx
     * 
     */

    //To create an handler, your class should implement 'IHttpHandler' interface
    public class CurrentUserImageHandler : IHttpHandler
    {
        
        public CurrentUserImageHandler() : base()
        {
        }
        
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
            context.Response.ContentType = "Image/jpeg";

            //Read image from physical path
            Image image = Image.FromFile(context.Server.MapPath("~/content/images/user.jpg"));
            byte[] imageBytes = null;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Jpeg);
                imageBytes = memoryStream.ToArray();
            }

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


    }
}
