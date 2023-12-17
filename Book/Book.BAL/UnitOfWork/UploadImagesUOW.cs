using Book.DAL;
using Book.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Book.BAL.UnitOfWork
{
    public class UploadImagesUOW
    {
        private readonly IBookDAL ObjDAL;
        public UploadImagesUOW(IBookDAL ObjDAL)
        {
            this.ObjDAL = ObjDAL;
        }
        public BookImageUploadOutput UploadImage([FromForm] BookImageUploadInput ObjInput)
        {
            if (ObjInput?.TileImage.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ObjInput.TileImage.CopyToAsync(ms);
                    BookImageUploadInputDB ObjInputDB = new BookImageUploadInputDB()
                    {
                        StrBookEdition = ObjInput.StrBookEdition,
                        StrBookId = ObjInput.StrBookId,
                        Name = ObjInput.Name,
                        ImageType = ObjInput.ImageType,
                        TileImage = ms.ToArray()
                    };
                    return ObjDAL.UploadImage(ObjInputDB);
                }
            }
            return null;
        }
        public List<GetBookImageOutput> GetBookImage(GetBookImageInput ObjInput) => ObjDAL.GetBookImage(ObjInput);

    }
}