using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static IDataResult<List<string>> Upload(List<IFormFile> files, string path)
        {
            List<string> result = new();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var file in files)
            {
                string imageName = path+Guid.NewGuid() + Path.GetExtension(file.FileName); 
                using var stream = new FileStream(imageName, FileMode.Create);
                file.CopyToAsync(stream);
                result.Add(imageName);
            }
            return new SuccessDataResult<List<string>>(result, "File Uploaded");
        }


        public static IResult Delete(string path) 
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return new SuccessResult("File Deleted");
            }

            return new ErrorResult("File not deleted");
           
        }
    }
}
