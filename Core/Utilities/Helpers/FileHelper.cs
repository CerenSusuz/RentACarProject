using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                { 
                    file.CopyTo(stream); 
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newPath = Guid.NewGuid().ToString()
               + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + fileExtension;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"Content\img");
            string result = $@"{path}\{newPath}";
            return result;
        }

    }
}
