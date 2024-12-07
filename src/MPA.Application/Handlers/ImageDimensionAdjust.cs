using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MPA.Handlers
{
    public class ImageDimensionAdjust
    {
        public static byte[] ResizeImage(IFormFile file, int maxWidth, int maxHeight)
        {
            using (var stream = file.OpenReadStream())
            using (var originalImage = Image.FromStream(stream))
            {
                // Calculate new dimensions
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;

                if (originalImage.Width > maxWidth || originalImage.Height > maxHeight)
                {
                    double ratioX = (double)maxWidth / originalImage.Width;
                    double ratioY = (double)maxHeight / originalImage.Height;
                    double ratio = Math.Min(ratioX, ratioY);

                    newWidth = (int)(originalImage.Width * ratio);
                    newHeight = (int)(originalImage.Height * ratio);
                }

                // Resize the image
                var resizedImage = new Bitmap(newWidth, newHeight);
                using (var graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                }

                // Save to memory stream and return as byte array
                using (var memoryStream = new MemoryStream())
                {
                    resizedImage.Save(memoryStream, ImageFormat.Jpeg); // Save as JPEG
                    return memoryStream.ToArray();
                }
            }
        }
    }
}