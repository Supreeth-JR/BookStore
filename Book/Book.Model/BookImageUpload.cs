using Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    public class BookImageUploadInput
    {
        public int StrBookEdition { get; set; }
        public string StrBookId { get; set; }
        public string Name { get; set; }
        public IFormFile TileImage { get; set; }
        public string ImageType { get; set; }
    }
    public class BookImageUploadInputDB
    {
        public int StrBookEdition { get; set; }
        public string StrBookId { get; set; }
        public string Name { get; set; }
        public byte[] TileImage { get; set; }
        public string ImageType { get; set; }
        [SQLOutputParam("intResult")]
        public int intResult { get; set; }
    }
    public class BookImageUploadOutput
    {
        [SQLOutputParam("intResult")]
        public int intResult { get; set; }
    }
    public class GetBookImageInput
    {
        public string StrBookID { get; set; }
        public int IntEdition { get; set; }
    }
    public class GetBookImageOutput
    {
        public string StrBookName { get; set; }
        public string StrBookId { get; set; }
        public int IntEdition { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
    }
}
