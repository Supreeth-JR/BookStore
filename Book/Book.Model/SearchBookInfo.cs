using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Model
{
    public class SearchBookInput
    {
        public string StrType { get; set; }
        public string StrName { get; set; }
    }
    public class BooksSearchOutput
    {
        public string StrBookID { get; set; }
        public string StrBookName { get; set; }
    }
    public class AuthorSearchOutput
    {
        public string StrAuthorID { get; set; }
        public string StrAuthorName { get; set; }
    }
    public class CatagorySearchOutput
    {
        public string StrCatagoryID { get; set; }
        public string StrCatagoryName { get; set; }
    }
}
