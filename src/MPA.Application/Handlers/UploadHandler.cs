using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MPA.Handlers
{
    public class UploadHandler
    {
        public static async Task<string> UploadAsync(IFormFile file)
        {

            string extension = Path.GetExtension(file.FileName);
            if (extension != ".jpg")
            {
                return "Extension is not Valid (jpg)";
            }

            var newImage = ImageDimensionAdjust.ResizeImage(file, 140, 100);

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(folderPath, fileName);

            await System.IO.File.WriteAllBytesAsync(fullPath, newImage);

            return $"/Images/{fileName}";
        }
    }
}
