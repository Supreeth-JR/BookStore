using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    public class BookInfoInput
    {
        public string StrBookID { get; set; }
        public string StrBookName { get; set; }
        public string StrIsNew { get; set; }
        public string StrCatagory { get; set; }
        public string StrAuthorName { get; set; }

    }
    public class BookInfoOutput
    {
        public string StrBookId { get; set; }
        public string StrAuthorId { get; set; }
        public string StrAuthorName { get; set; }
        public string StrAuthorLastName { get; set; }
        public string StrBookName { get; set; }
        public string StrCatagoryId { get; set; }
        public string StrCatagoryName { get; set; }
        public string StrLanguage { get; set; }
        public int IntEdition { get; set; }
        public DateTime DtPublishDate { get; set; }
        public decimal DecMoney { get; set; }
        public int IntReview { get; set; }
        public string StrBookIsNew { get; set; }
        public int IntStock { get; set; }
        public string StrImageName { get; set; }
        public byte[] Image { get; set; }
        public string StrImageType { get; set; }
    }
    public class BookInfoHeader
    {
        public string StrBookId { get; set; }
        public string StrAuthorId { get; set; }
        public string StrAuthorName { get; set; }
        public string StrAuthorLastName { get; set; }
        public string StrBookName { get; set; }
        public string StrCatagoryId { get; set; }
        public string StrCatagoryName { get; set; }
        public string StrLanguage { get; set; }
        public List<BookInfoDetail> BookInfoDetails { get; set; }
    }
    public class BookInfoDetail
    {
        public string StrBookId { get; set; }
        public int IntEdition { get; set; }
        public DateTime? DtPublishDate { get; set; }
        public decimal DecMoney { get; set; }
        public int IntReview { get; set; }
        public string StrBookIsNew { get; set; }
        public int IntStock { get; set; }
        public string strTag { get; set; }
        public string StrImageURL { get; set; }
        public string StrImageName { get; set; }
    }
}
