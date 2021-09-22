using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infrastructrues
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =false,Inherited =true)]
    public class UploadFileAttribute:ValidationAttribute
    {
        public int FileSize { get; set; } = 1 * 1024 * 1024 * 1024;
        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;
            int allowedFileSize = this.FileSize;
            if (file != null)
            {
                var fileSize = file.ContentLength;
                isValid = fileSize <= allowedFileSize;
            }
                return isValid;

            
        }
    }
}