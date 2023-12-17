using System;

namespace Book.Model
{
    public class GetBooksInput
    {
        public string JsonCatagory { get; set; }
    }
    public class GetBooksOutput
    {
        public string StrBookId { get; set; }
        public string StrAuthorId { get; set; }
        public string StrBookName { get; set; }
        public string StrCatagoryID { get; set; }
        public string StrLanguage { get; set; }
        public int IntBookEdition { get; set; }
        public DateTime DtPublishedDate { get; set; }
        public decimal DecPrice { get; set; }
        public int IntReview { get; set; }
        public string StrCatagoryName { get; set; }
        public string StrAuthorName { get; set; }
        public string StrAuthorlastName { get; set; }
        public string StrImageName { get; set; }
        public byte[] Image { get; set; }
        public string StrImageType { get; set; }
    }
}
