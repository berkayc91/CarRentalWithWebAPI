using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static readonly string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static readonly string _folderName = "\\images\\";

        public static IResult Upload(IFormFile file)
        {
            var fileExist = CheckFileExist(file);
            if (!fileExist.Success)
            {
                return new ErrorResult(fileExist.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValidation(type);
            var randomFileName = Guid.NewGuid().ToString();

            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDirectory+_folderName);
            CreateImageFile(_currentDirectory+_folderName+randomFileName+type,file);
            return new SuccessResult((_folderName + randomFileName + type).Replace(oldValue: "\\", newValue: "/"));
        }

        public static  IResult Update(IFormFile file, string path)
        {
            var fileExist = CheckFileExist(file);
            if (!fileExist.Success)
            {
                return new ErrorResult(fileExist.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValidation(type);
            var randomFileName = Guid.NewGuid().ToString();


            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile(_currentDirectory+path);
            CheckDirectoryExists(_currentDirectory+_folderName);
            CreateImageFile(_currentDirectory+_folderName+randomFileName+type,file);
            return new SuccessResult((_folderName + randomFileName + type).Replace(oldValue: "\\", newValue: "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory+ path).Replace(oldValue: "/",newValue: "\\"));
            return new SuccessResult();
        }

        private static IResult CheckFileExist(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult("File doesn't exist.");
        }

        private static IResult CheckFileTypeValidation(string type)
        {
            if (type != ".jpeg" && type != ".jpg" && type != ".jpeg")
            {
                return new ErrorResult("Wrong file type");
            }

            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fileStream=File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace(oldValue: "/",newValue: "\\")))
            {
                File.Delete(directory.Replace(oldValue: "/",newValue: "\\"));
            }
        }
    }
}
