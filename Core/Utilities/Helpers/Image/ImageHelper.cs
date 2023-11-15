using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Image
{
    public static class ImageHelper
    {

        public static string Upload(IFormFile file)
        {

            string extension = Path.GetExtension(file.FileName);
            var guid = Guid.NewGuid();   
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"../WebAPI/wwwroot/{guid}"+extension);
            using (Stream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
                return path;
            }

        }

        public static string Update(IFormFile file,string filePath)
        {
            Delete(filePath);
            return Upload(file);
        }

        public static void Delete(string filePath)
        {
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
