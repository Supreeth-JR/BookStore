using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    public class InsertBookDetailsInput
    {
        public BookHeader JsonHeader { get; set; }
        public List<BookDetails> JsonDetail { get; set; }

    }
    public class BookHeader
    {
        public string StrAuthorID { get; set; }
        public string StrBookName { get; set; }
        public string StrBookCatagory { get; set; }
        public string Strlanuage { get; set; }
    }
    public class BookDetails
    {
        public int IntBookEdition { get; set; }
        public DateTime DtPublishedDate { get; set; }
        public decimal DecPrice { get; set; }
        public string StrIsNew { get; set; }
        public int IntStock { get; set; }
    }
    public class InsertBookDetailsInputDB
    {
        public string JsonHeader { get; set; }
        public string JsonDetail { get; set; }
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
    public class InsertBookDetailsOutput
    {
        [SQLOutputParam("IntResult")]
        public int IntResult { get; set; }
    }
}
