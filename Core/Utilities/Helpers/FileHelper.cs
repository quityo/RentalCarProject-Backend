﻿using Core.Utilities.Results;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string ImagePath { get; set; }
        public static string SaveImageFile(IFormFile imageFile)
        {
            var sourcepath = Path.GetTempFileName();
            if (imageFile.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            var result = newPath(imageFile);
            File.Move(sourcepath, result.newPath);
            return result.Path2.Replace("\\", "/");
        }
        public static IResult Delete(string path)
        {
            path = path.Replace("/", "\\");
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result.Path2.Replace("\\", "/");
        }
        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            //string webPath = string.Format("/Images/{0}",newPath);

            string result = $@"{path}\{newPath}";
            return (result, $"{newPath}");
        }

    }
}


